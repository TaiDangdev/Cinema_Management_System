using Cinema_Management_System.Models;
using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.MovieManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static Cinema_Management_System.Views.MovieManagement.MovieManagementView;
using Cinema_Management_System.ViewModels.MovieManagementVM;
using Cinema_Management_System.Views.MessageBox;
using Cinema_Management_System.ViewModels.MovieManagementVM.Feature;
using Cinema_Management_System.ViewModels;
using Cursors = System.Windows.Forms.Cursors;
using Guna.UI2.WinForms;
using System.Drawing.Drawing2D;
using static Cinema_Management_System.AboutAccount_Form;



namespace Cinema_Management_System.Views.ProductManagement
{
    public partial class ProductManagementView : UserControl
    {
        private ProductDA _product;
        private decimal totalAmount = 0;  // Biến lưu tổng tiền
        public ProductManagementView()
        {
            InitializeComponent();
            InitializeDataGridView();
            _product = new ProductDA();
            LoadProducts();
            if (AboutAccount_Form.currentRole == "Nhân viên")
            {
                this.addProduct_btn.Hide();
            }
        }

        private void LoadProducts()
        {
            productPanel.Controls.Clear();

            string searchText = searchProduct_Txt.Text.Trim().ToLower(); // Từ khóa tìm kiếm
            string selectedFilter = filterProduct_Cbx.SelectedItem?.ToString(); // Lọc theo loại sản phẩm

            List<ProductDTO> products = _product.GetAllProducts(); // Lấy tất cả sản phẩm

            // Lọc theo loại sản phẩm nếu có chọn
            if (!string.IsNullOrEmpty(selectedFilter))
            {
                if (selectedFilter == "Đồ ăn")
                {
                    products = _product.FilterProductsByType(1); // Type 1: Đồ ăn
                }
                else if (selectedFilter == "Nước uống")
                {
                    products = _product.FilterProductsByType(2); // Type 2: Nước uống
                }
            }

            // Lọc theo tên sản phẩm nếu có từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchText))
            {
                products = products.Where(p => p.Name.ToLower().Contains(searchText)).ToList(); // Lọc theo tên
            }

            // Hiển thị các sản phẩm đã lọc
            foreach (var product in products)
            {
                Panel productItem = CreateProductPanel(product);
                Label title = CreateProductTitleLabel(product.Name);
                Button productButton = CreateProductButton(product);
                if (AboutAccount_Form.currentRole != "Nhân viên")
                {
                    Button btnMoreOptions = CreateMoreOptionsButton(product, productItem);
                    btnMoreOptions.Top = 0;
                    btnMoreOptions.Left = productButton.Width - btnMoreOptions.Width - 10;
                    productButton.Top = btnMoreOptions.Bottom + 10;
                    btnMoreOptions.Visible = false;
                    productItem.Controls.Add(btnMoreOptions);
                    // Thiết lập hiệu ứng hover
                    SetupHoverEffect(productButton, title, btnMoreOptions, product);
                }    
                
                Label priceLabel = CreateProductPriceLabel((int)product.Price);
                Label quantityLabel = CreateProductQuantityLabel(product.Quantity);

                // Sắp xếp vị trí các control trong Panel
                
                title.Top = productButton.Bottom + 5;
                priceLabel.Top = title.Bottom + 2;
                quantityLabel.Top = priceLabel.Bottom + 2;
                

                // Thêm các control vào Panel
                productItem.Controls.Add(title);
                productItem.Controls.Add(priceLabel);
                productItem.Controls.Add(quantityLabel);
                productItem.Controls.Add(productButton);
                
                // Thêm Panel vào FlowLayoutPanel
                productPanel.Controls.Add(productItem);
            }
        }

        private Label CreateProductPriceLabel(decimal price)
        {
            return new Label
            {
                Text = $"Giá: {price:N0} VNĐ",
                AutoSize = false,
                Width = 220,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DarkGreen,
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };
        }

        private Label CreateProductQuantityLabel(int quantity)
        {
            return new Label
            {
                Text = $"Số lượng: {quantity}",
                AutoSize = false,
                Width = 220,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DarkSlateGray,
                Font = new Font("Segoe UI", 9, FontStyle.Italic)
            };
        }


        /// <summary>
        /// Tạo Panel chứa phim
        /// </summary>
        private Panel CreateProductPanel(ProductDTO product)
        {
            return new Panel
            {
                Width = 220,
                Height = 410,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.None
            };
        }

        /// <summary>
        /// Tạo Label tiêu đề sản phẩm
        /// </summary>
        private Label CreateProductTitleLabel(string titleText)
        {
            return new Label
            {
                Text = titleText,
                AutoSize = false,
                Width = 220,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Padding = new Padding(5),
                AutoEllipsis = true // Tự động thu gọn khi quá dài
            };
        }

        /// <summary>
        /// Tạo Button chứa ảnh poster
        /// </summary>
        private Button CreateProductButton(ProductDTO product)
        {
            Button productButton = new Button
            {
                Width = 220,
                Height = 260,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                BackgroundImage = product.ImageSource,
                BackgroundImageLayout = ImageLayout.Zoom,
                Cursor = Cursors.Hand
            };
            productButton.FlatAppearance.BorderSize = 0;
            productButton.Click += (sender, e) =>
            {
                AddProductToBill(product);  // Adds product to DataGridView when clicked
            };
            return productButton;
        }
        private void AddProductToBill(ProductDTO product)
        {
            bool productExists = false;
            int availableQuantity = product.Quantity;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                // Check if the product name matches
                if (row.Cells["Column1"].Value.ToString() == product.Name)
                {
                    // If found, update the quantity
                    int currentQuantity = Convert.ToInt32(row.Cells["Column2"].Value);

                    // Kiểm tra nếu số lượng muốn thêm vượt quá số lượng có sẵn
                    if (currentQuantity + 1 > availableQuantity)
                    {
                        MessageBoxHelper.ShowInfo("Cảnh báo", $"Không thể thêm. Số lượng sản phẩm '{product.Name}' trong kho chỉ còn {availableQuantity}!");
                        return;
                    }

                    row.Cells["Column2"].Value = currentQuantity + 1;
                    totalAmount += (int)product.Price;
                    productExists = true;
                    break;
                }
            }

            // If the product doesn't exist in the grid, add it as a new row
            if (!productExists)
            {
                if (availableQuantity > 0)
                {
                    int rowIndex = dgv.Rows.Add();
                    dgv.Rows[rowIndex].Cells["Column1"].Value = product.Name;  // Product name column
                    dgv.Rows[rowIndex].Cells["Column2"].Value = 1;  // Default quantity
                    dgv.Rows[rowIndex].Cells["Column3"].Value = product.Price;  // Product price column

                    totalAmount += (int)product.Price;  // Cập nhật tổng tiền khi thêm sản phẩm mới vào hóa đơn
                }
                else
                {
                    MessageBoxHelper.ShowInfo("Thông báo", $"Sản phẩm '{product.Name}' hiện đã hết hàng!");
                }
            }

            // Cập nhật tổng tiền lên label
            guna2HtmlLabel1.Text = $"Tổng tiền: {totalAmount:N0} VNĐ";
        }


        private void InitializeDataGridView()
        {
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            // Add new columns for increase/decrease buttons
            DataGridViewButtonColumn increaseButtonColumn = new DataGridViewButtonColumn
            {
                Name = "THÊM",
                Text = "+",
                UseColumnTextForButtonValue = true,
                Width = 47
            };

            DataGridViewButtonColumn decreaseButtonColumn = new DataGridViewButtonColumn
            {
                Name = "GIẢM",
                Text = "-",
                UseColumnTextForButtonValue = true,
                Width = 47
            };

            // Add the columns to DataGridView
            dgv.Columns.Add(increaseButtonColumn);
            dgv.Columns.Add(decreaseButtonColumn);

            // Handle the click events for the buttons
            dgv.CellContentClick += DataGridView1_CellContentClick;
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that the click is on one of the button columns (Increase or Decrease)
            if (e.ColumnIndex == dgv.Columns["THÊM"].Index)
            {
                // Increase the quantity by 1
                IncreaseQuantity(e.RowIndex);
            }
            else if (e.ColumnIndex == dgv.Columns["GIẢM"].Index)
            {
                // Decrease the quantity by 1, but not below 1
                DecreaseQuantity(e.RowIndex);
            }
        }
        private void IncreaseQuantity(int rowIndex)
        {
            try
            {
                // Get the current quantity and the available stock quantity for the product
                int currentQuantity = Convert.ToInt32(dgv.Rows[rowIndex].Cells["Column2"].Value);
                string productName = dgv.Rows[rowIndex].Cells["Column1"].Value.ToString();

                // Lấy sản phẩm từ cơ sở dữ liệu hoặc danh sách sản phẩm của bạn
                var product = _product.GetAllProducts().FirstOrDefault(p => p.Name == productName);

                if (product != null)
                {
                    int availableQuantity = product.Quantity;  // Số lượng sản phẩm trong kho

                    if (currentQuantity < availableQuantity)
                    {
                        // Nếu số lượng hiện tại nhỏ hơn số lượng có sẵn trong kho, tăng số lượng
                        dgv.Rows[rowIndex].Cells["Column2"].Value = currentQuantity + 1;
                        UpdateTotalAmount();
                    }
                    else
                    {   
                        MessageBoxHelper.ShowInfo("Cảnh báo", $"Không thể tăng số lượng sản phẩm '{product.Name}' vượt quá số lượng có sẵn trong kho ({availableQuantity})!");
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Sản phẩm không tìm thấy trong cơ sở dữ liệu!");
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        private void DecreaseQuantity(int rowIndex)
        {
            // Get the current quantity and decrement it by 1, but make sure it doesn't go below 1
            try
            {
                int currentQuantity = Convert.ToInt32(dgv.Rows[rowIndex].Cells["Column2"].Value);

                if (currentQuantity > 1)
                {
                    // Giảm số lượng trong DataGridView
                    dgv.Rows[rowIndex].Cells["Column2"].Value = currentQuantity - 1;

                    // Tính lại tổng tiền sau khi giảm số lượng
                    UpdateTotalAmount();
                }
                else if (currentQuantity == 1)
                {
                    // Nếu số lượng = 1 thì xóa dòng
                    dgv.Rows.RemoveAt(rowIndex);

                    // Tính lại tổng tiền sau khi xóa dòng
                    UpdateTotalAmount();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Số lượng không thể giảm dưới 1!");
                }
            }
            catch
            {

            }
        }
        private void UpdateTotalAmount()
        {
            totalAmount = 0; // Reset lại tổng tiền

            // Duyệt qua tất cả các dòng trong DataGridView để tính tổng tiền
            foreach (DataGridViewRow row in dgv.Rows)
            {
                int quantity = Convert.ToInt32(row.Cells["Column2"].Value);
                decimal price = Convert.ToDecimal(row.Cells["Column3"].Value);

                // Cập nhật tổng tiền
                totalAmount += quantity * price;
            }

            // Cập nhật label tổng tiền
            guna2HtmlLabel1.Text = $"Tổng tiền: {totalAmount:N0} VNĐ";
        }

        /// <summary>
        /// Tạo nút tùy chọn (Chỉnh sửa, Xóa)
        /// </summary>
        private Button CreateMoreOptionsButton(ProductDTO product, Panel parentPanel)
        {
            Button btnMoreOptions = new Button
            {
                Width = 20,
                Height = 20,
                BackgroundImage = Properties.Resources.icons8_more_24, // Icon dấu ba chấm
                BackgroundImageLayout = ImageLayout.Zoom,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnMoreOptions.FlatAppearance.BorderSize = 0;
            
            ContextMenuStrip menu = new ContextMenuStrip
            {
                Renderer = new CustomMenuRenderer(), // Áp dụng Renderer để thay đổi UI
                ShowImageMargin = false, // Ẩn lề hình ảnh mặc định
                BackColor = Color.White, // Màu nền
            };

            menu.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            menu.Items.Add("✏ Chỉnh sửa", null, (s, e) => EditProduct(product));
            menu.Items.Add("🗑 Xóa", null, (s, e) => DeleteProduct(product));
            menu.Items.Add("➕ Thêm số lượng", null, (s, e) => AddQuantity(product));
            btnMoreOptions.Click += (s, e) => menu.Show(System.Windows.Forms.Cursor.Position);

            return btnMoreOptions;
        }
        /// <summary>
        /// Thêm số lượng cho sản phẩm
        /// </summary>
        private void AddQuantity(ProductDTO product)
        {
            using (var form = new Form())
            {
                form.Text = $"Thêm số lượng cho '{product.Name}'";
                form.Width = 350;
                form.Height = 200;
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedSingle;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.BackColor = Color.FromArgb(240, 240, 240);

                var shadowForm = new Guna2ShadowForm
                {
                    ShadowColor = Color.Black,
                    BorderRadius = 15
                };
                shadowForm.SetShadowForm(form);

                var label = new Guna2HtmlLabel
                {
                    Text = "Nhập số lượng cần thêm:",
                    Location = new Point(20, 30),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.FromArgb(64, 64, 64)
                };

                var textBox = new Guna2TextBox
                {
                    Location = new Point(20, 60),
                    Width = 300,
                    Height = 35,
                    BorderRadius = 10,
                    BorderColor = Color.FromArgb(200, 200, 200),
                    PlaceholderText = "Nhập số lượng (số nguyên dương)",
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.Black,
                    PlaceholderForeColor = Color.Gray
                };

                var okButton = new Guna2Button
                {
                    Text = "Xác nhận",
                    Location = new Point(20, 110),
                    Width = 140,
                    Height = 40,
                    BorderRadius = 10,
                    FillColor = Color.FromArgb(0, 122, 204),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };

                var cancelButton = new Guna2Button
                {
                    Text = "Hủy",
                    Location = new Point(180, 110),
                    Width = 140,
                    Height = 40,
                    BorderRadius = 10,
                    FillColor = Color.FromArgb(255, 77, 77),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };

                okButton.Click += (sender, e) =>
                {
                    if (int.TryParse(textBox.Text, out int additionalQuantity) && additionalQuantity > 0)
                    {
                        try
                        {
                            var dbProduct = _product.GetAllProducts().FirstOrDefault(p => p.Id == product.Id);
                            if (dbProduct != null)
                            {
                                dbProduct.Quantity += additionalQuantity;
                                _product.EditProduct(dbProduct);

                                MessageBoxHelper.ShowSuccess("Thành công", $"Đã thêm {additionalQuantity} sản phẩm.\nTổng số lượng hiện tại: {dbProduct.Quantity}");
                                form.Close();
                                LoadProducts();
                            }
                            else
                            {
                                MessageBoxHelper.ShowError("Lỗi", "Không tìm thấy sản phẩm để cập nhật.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBoxHelper.ShowError("Lỗi", $"Lỗi khi cập nhật sản phẩm: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBoxHelper.ShowError("Lỗi", "Vui lòng nhập một số nguyên dương hợp lệ!");
                    }
                };

                cancelButton.Click += (sender, e) => form.Close();

                form.Controls.Add(label);
                form.Controls.Add(textBox);
                form.Controls.Add(okButton);
                form.Controls.Add(cancelButton);

                form.ShowDialog();
            }
        }

        /// <summary>
        /// Mở giao diện chỉnh sửa phim
        /// </summary>
        private void EditProduct(ProductDTO product)
        {
            EditProductView editProductView = new EditProductView(product);
            editProductView.ShowDialog();
            LoadProducts();
        }

        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        private void DeleteProduct(ProductDTO product)
        {
            //DialogResult result = System.Windows.Forms.MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{product.Name}' không?",
            //    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //result = MessageBoxHelper.ShowQuestion("Xác nhận xóa", $"Bạn có chắc chắn muốn xóa sản phẩm '{product.Name}' không?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (MessageBoxHelper.ShowQuestion("Xác nhận xóa", $"Bạn có chắc chắn muốn xóa sản phẩm '{product.Name}' không?") == DialogResult.Yes)
            {
                try
                {
                    _product.DeleteProduct(product);
                    LoadProducts(); // Làm mới danh sách sau khi xóa
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show($"Lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // <summary>
        /// Phương thức xóa sản phẩm theo ID (được gọi từ DeleteProduct)
        /// </summary>
        public void DeleteProduct(int id)
        {
            try
            {
                var product = _product.GetAllProducts().FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    throw new Exception("Không tìm thấy sản phẩm để xóa.");
                }
                _product.DeleteProduct(product);
                LoadProducts();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa sản phẩm: " + ex.Message);
            }
        }

        /// <summary>
        /// Thêm hiệu ứng phóng to ảnh khi hover
        /// </summary>
        private void SetupHoverEffect(Button productButton, Label titleLabel, Button btnMoreOptions, ProductDTO product)
        {
            Timer zoomTimer = new Timer { Interval = 10 };
            Timer hideButtonTimer = new Timer { Interval = 2000 };
            int targetSize = 240;
            int originalSize = 220;
            bool zoomingIn = false;

            productButton.MouseEnter += (s, e) =>
            {
                zoomingIn = true;
                zoomTimer.Start();
                titleLabel.ForeColor = Color.Red;
                btnMoreOptions.Visible = true;
                hideButtonTimer.Stop();
            };

            productButton.MouseLeave += (s, e) =>
            {
                zoomingIn = false;
                zoomTimer.Start();
                titleLabel.ForeColor = Color.Black;
                hideButtonTimer.Start();
            };

            hideButtonTimer.Tick += (s, e) =>
            {
                btnMoreOptions.Visible = false;
                hideButtonTimer.Stop();
            };

            zoomTimer.Tick += (s, e) =>
            {
                if (zoomingIn)
                {
                    if (productButton.Width < targetSize)
                    {
                        productButton.Width += 2;
                        productButton.Height += 2;
                        productButton.Left -= 1;
                        productButton.Top -= 1;
                    }
                    else zoomTimer.Stop();
                }
                else
                {
                    if (productButton.Width > originalSize)
                    {
                        productButton.Width -= 2;
                        productButton.Height -= 2;
                        productButton.Left += 1;
                        productButton.Top += 1;
                    }
                    else zoomTimer.Stop();
                }
            };

        }
        
        private void filterMovie_Cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {
            int radius = 20; // bo góc 20px
            Rectangle rect = guna2Panel6.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //using (Pen pen = new Pen(Color.OrangeRed, 1)) // viền đen, dày 2px
                //{
                //    e.Graphics.DrawPath(pen, path);
                //}
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            int radius = 20; // bo góc 20px
            Rectangle rect = guna2Panel1.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //using (Pen pen = new Pen(Color.OrangeRed, 1)) // viền đen, dày 2px
                //{
                //    e.Graphics.DrawPath(pen, path);
                //}
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {
            int radius = 20; // bo góc 20px
            Rectangle rect = guna2Panel4.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //using (Pen pen = new Pen(Color.OrangeRed, 1)) // viền đen, dày 2px
                //{
                //    e.Graphics.DrawPath(pen, path);
                //}
            }
        }

        private void addProduct_Btn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AddProductView"] == null)
            {
                AddProductView AddProductView = new AddProductView();

                AddProductView.Opacity = 0; // Bắt đầu từ mờ
                AddProductView.Show();

                Timer fadeTimer = new Timer { Interval = 10 };
                fadeTimer.Tick += (s, args) =>
                {
                    if (AddProductView.Opacity < 1)
                    {
                        AddProductView.Opacity += 0.05;
                    }
                    else
                    {
                        fadeTimer.Stop();
                    }
                };
                fadeTimer.Start();

                // Nếu bạn vẫn muốn load lại danh sách sau khi form đóng:
                AddProductView.FormClosed += (s, args) => LoadProducts();
            }
            else
            {
                // Nếu form đã mở, chỉ cần kích hoạt lại form
                Application.OpenForms["AddProductView"].Activate();
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0 || dgv.Rows.Cast<DataGridViewRow>().All(row => row.IsNewRow))
            {
                MessageBoxHelper.ShowInfo("Thông báo", "Giỏ hàng trống, không thể thanh toán!");
                return;
            }

            // Lấy thông tin nhân viên hiện tại từ CurrentUser
            int staffId = CurrentUser.StaffId;
            string staffName = string.Empty;

            // Lấy thông tin nhân viên từ cơ sở dữ liệu bằng staffId
            using (var db = new ConnectDataContext())
            {
                var staff = db.STAFFs.FirstOrDefault(s => s.Id == staffId);
                if (staff != null)
                {
                    staffName = staff.FullName;
                }
            }

            if (string.IsNullOrEmpty(staffName))
            {
                System.Windows.Forms.MessageBox.Show("Không tìm thấy thông tin nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy ngày giờ hiện tại
            DateTime billDate = DateTime.Now;

            // Tạo một bản ghi hóa đơn mới
            Bill_SellProduct newBill = new Bill_SellProduct
            {
                Staff_Id = staffId,
                StaffName = staffName,
                TotalAmount = (int)totalAmount, // Giả sử totalAmount là decimal, ép kiểu về int để lưu vào cơ sở dữ liệu
                BillDate = billDate // Gán ngày hiện tại vào BillDate
            };

            // Chèn vào bảng Bill_SellProduct và lấy ID của hóa đơn mới
            using (var db = new ConnectDataContext())
            {
                db.Bill_SellProducts.InsertOnSubmit(newBill);
                db.SubmitChanges();
                int billId = newBill.Id; // Lấy ID của hóa đơn sau khi chèn vào cơ sở dữ liệu

                if (billId > 0)
                {
                    // Lặp qua các sản phẩm trong DataGridView và thêm vào bảng BillDetailProduct
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        string productName = row.Cells["Column1"].Value.ToString(); // Lấy tên sản phẩm từ DataGridView
                        int quantity = Convert.ToInt32(row.Cells["Column2"].Value); // Lấy số lượng từ DataGridView
                        decimal unitPrice = Convert.ToDecimal(row.Cells["Column3"].Value); // Lấy đơn giá từ DataGridView

                        // Tính tổng tiền cho sản phẩm này
                        int totalPrice = (int)(quantity * unitPrice);

                        // Chèn vào bảng BillDetailProduct
                        BillDetailProduct billDetail = new BillDetailProduct
                        {
                            Bill_Id = billId,
                            Product_Id = GetProductIdByName(productName), // Lấy ID sản phẩm từ tên sản phẩm
                            Quantity = quantity,
                            UnitPrice = (int)unitPrice,  // Ép kiểu sang int để lưu vào cơ sở dữ liệu
                            TotalPrice = totalPrice
                        };

                        db.BillDetailProducts.InsertOnSubmit(billDetail);  // Chèn chi tiết hóa đơn vào cơ sở dữ liệu

                        // Cập nhật số lượng sản phẩm trong kho
                        UpdateProductQuantityInStock(productName, quantity); // Cập nhật số lượng sản phẩm trong kho
                    }

                    // Lưu tất cả thay đổi vào cơ sở dữ liệu
                    db.SubmitChanges();

                    // Hiển thị thông báo thanh toán thành công
                    MessageBoxHelper.ShowSuccess("Thông báo", "Thanh toán thành công!");

                    // Mở form PrintBillSale để in hóa đơn
                    PrintBillSale printForm = new PrintBillSale(billId);
                    printForm.Show(); // Mở form in hóa đơn

                    // Làm mới DataGridView và tổng tiền
                    dgv.Rows.Clear();  // Xóa các sản phẩm trong DataGridView
                    totalAmount = 0;   // Đặt lại tổng tiền
                    guna2HtmlLabel1.Text = $"Tổng tiền: {totalAmount:N0} VNĐ"; // Cập nhật lại label với tổng tiền mới
                    LoadProducts();    // Tải lại danh sách sản phẩm
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Lỗi khi tạo hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Phương thức để lấy Product ID từ tên sản phẩm (dùng trong cơ sở dữ liệu hoặc danh sách sản phẩm)
        private int GetProductIdByName(string productName)
        {
            using (var db = new ConnectDataContext())
            {
                var product = db.Products.FirstOrDefault(p => p.Name == productName);
                return product != null ? product.ID : 0;  // Trả về ID của sản phẩm, nếu không tìm thấy thì trả về 0
            }
        }

        // Phương thức để cập nhật số lượng sản phẩm trong kho
        private void UpdateProductQuantityInStock(string productName, int quantitySold)
        {
            using (var db = new ConnectDataContext())
            {
                var product = db.Products.FirstOrDefault(p => p.Name == productName);
                if (product != null)
                {
                    product.Quantity -= quantitySold;  // Giảm số lượng sản phẩm theo số lượng bán ra
                    db.SubmitChanges();  // Lưu thay đổi vào cơ sở dữ liệu
                }
            }
        }
        private void searcProduct_Txt_TextChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void guna2Panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
