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



namespace Cinema_Management_System.Views.ProductManagement
{
    public partial class ProductManagementView : UserControl
    {
        private ProductDA _product;
        public ProductManagementView()
        {
            InitializeComponent();
            _product = new ProductDA();
            LoadProducts();
        }
        private void LoadProducts()
        {
            productPanel.Controls.Clear();

            string searchText = searcProduct_Txt.Text.Trim().ToLower();
            string selectedFilter = filterProduct_Cbx.SelectedItem?.ToString();

            List<ProductDTO> products = _product.GetAllProducts();

            // Lọc theo Type
            if (selectedFilter == "Đồ ăn")
            {
                products = _product.FilterProductsByType(1); // Type 1: Đồ ăn
            }
            else if (selectedFilter == "Nước uống")
            {
                products = _product.FilterProductsByType(2); // Type 2: Thức uống
            }

            // Tìm kiếm theo Name
            if (!string.IsNullOrEmpty(searchText))
            {
                products = _product.FilterProductsByName(searchText);
            }

            foreach (var product in products)
            {
                Panel productItem = CreateProductPanel(product);
                Label title = CreateProductTitleLabel(product.Name);
                Button productButton = CreateProductButton(product);
                Button btnMoreOptions = CreateMoreOptionsButton(product, productItem);
                Label priceLabel = CreateProductPriceLabel((int)product.Price);
                Label quantityLabel = CreateProductQuantityLabel(product.Quantity);

                // Sắp xếp vị trí các control trong Panel
                btnMoreOptions.Top = 0;
                btnMoreOptions.Left = productButton.Width - btnMoreOptions.Width - 10;
                productButton.Top = btnMoreOptions.Bottom + 10;
                title.Top = productButton.Bottom + 5;
                priceLabel.Top = title.Bottom + 2;
                quantityLabel.Top = priceLabel.Bottom + 2;
                btnMoreOptions.Visible = false;

                // Thêm các control vào Panel
                productItem.Controls.Add(title);
                productItem.Controls.Add(priceLabel);
                productItem.Controls.Add(quantityLabel);
                productItem.Controls.Add(productButton);
                productItem.Controls.Add(btnMoreOptions);
                // Thiết lập hiệu ứng hover
                SetupHoverEffect(productButton, title, btnMoreOptions, product);

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
            return productButton;
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
            DialogResult result = System.Windows.Forms.MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{product.Name}' không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
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

        private void ProductManagementView_Load(object sender, EventArgs e)
        {

        }

        private void addMovie_Btn_Click(object sender, EventArgs e)
        {
            //AddProductView addProductView = new AddProductView();
            //addProductView.Show();
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

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void productPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searcProduct_Txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void productPanel_Paint_1(object sender, PaintEventArgs e)
        {

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
                using (Pen pen = new Pen(Color.OrangeRed, 1)) // viền đen, dày 2px
                {
                    e.Graphics.DrawPath(pen, path);
                }
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
                using (Pen pen = new Pen(Color.OrangeRed, 1)) // viền đen, dày 2px
                {
                    e.Graphics.DrawPath(pen, path);
                }
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
                using (Pen pen = new Pen(Color.OrangeRed, 1)) // viền đen, dày 2px
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
