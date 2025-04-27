using Guna.UI2.WinForms.Suite;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinema_Management_System.Models;
using Cinema_Management_System.Views.MessageBox;
using Cinema_Management_System.Models.DTOs;
using System.Windows.Resources;

namespace Cinema_Management_System.Views.ProductManagement
{
    public partial class AddProductView : Form
    {
        private Bitmap productImage;
        private bool isImageSelected = false;
        private Dictionary<Control, Label> errorMap;
        private Guna2ShadowForm shadowForm;
        public AddProductView()
        {
            InitializeComponent();
            SetupUI();
            InitValidation();

        }
        private void SetupUI()
        {
            this.Text = "Thêm sản phẩm";
            DragHelper.EnableDrag(this, control_Panel);
            shadowForm = new Guna2ShadowForm
            {
                ShadowColor = Color.Black,
                BorderRadius = 20
            };
            shadowForm.SetShadowForm(this);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void InitValidation()
        {
            errorMap = new Dictionary<Control, Label>
            {
                { nameProduct_Txt, nameError_Txt },
                { typeProduct_cbb, typeError_Txt },
                { quantity_Txt, quantityError_Txt },
                { purchasePrice_Txt, purchasepriceError_Txt }
            };

            foreach (var x in errorMap)
            {
                var control = x.Key;
                if (control is Guna2TextBox textBox)
                {
                    textBox.TextChanged += (s, e) =>
                    {
                        ValidateSingleField(textBox);
                        CheckAllFieldsValid();
                    };

                    textBox.Leave += (s, e) =>
                    {
                        ValidateSingleField(textBox);
                        if (decimal.TryParse(purchasePrice_Txt.Text, out var price) && price > 0)
                        {
                            purchasePrice_Txt.Text = price.ToString("N0");
                        }
                    };
                }
                else if (control is Guna2ComboBox comboBox)
                {
                    comboBox.SelectedIndexChanged += (s, e) =>
                    {
                        ValidateSingleField(comboBox);
                        CheckAllFieldsValid();
                    };
                }
            }

            HideAllErrorLabels();
        }

        private void HideAllErrorLabels()
        {
            foreach (var entry in errorMap)
            {
                entry.Value.Visible = false;
            }
        }
        private void ClearError(Control control)
        {
            if (errorMap.TryGetValue(control, out Label errorLabel))
            {
                errorLabel.Text = "";
                errorLabel.Visible = false;
            }
        }
        private void ValidateSingleField(Control control)
        {
            string error = GetErrorMessage(control);

            if (errorMap.TryGetValue(control, out Label label))
            {
                if (control is Guna2TextBox && string.IsNullOrWhiteSpace(control.Text))
                {
                    error = "*Không được để trống!";
                }
                else if (control is Guna2ComboBox comboBox && comboBox.SelectedIndex == -1)
                {
                    error = "*Vui lòng chọn loại sản phẩm!";
                }

                if (string.IsNullOrEmpty(error))
                {
                    ClearError(control);
                }
                else
                {
                    label.Text = error;
                    label.Visible = true;
                }
            }
        }

        private string GetErrorMessage(Control control)
        {
            if (control is Guna2TextBox textBox)
            {
                string text = textBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(text) || string.IsNullOrEmpty(text))
                {
                    return "*Không được để trống!";
                }

                if (control == quantity_Txt)
                {
                    if (!int.TryParse(text, out int quantity) || quantity < 0)
                    {
                        return "*Số lượng không hợp lệ!";
                    }
                }

                if (control == purchasePrice_Txt)
                {
                    if (!decimal.TryParse(text, out decimal price) || price <= 0)
                    {
                        return "*Giá nhập không hợp lệ!";
                    }
                }

                if (control == nameProduct_Txt && text.Length > 100)
                {
                    return "*Tên sản phẩm không quá 100 ký tự!";
                }
            }
            else if (control is Guna2ComboBox comboBox)
            {
                if (comboBox.SelectedIndex == -1)
                {
                    return "*Vui lòng chọn loại sản phẩm!";
                }
            }

            return string.Empty;
        }


        private bool ValidateProductInput()
        {
            // Kiểm tra thêm nếu cần (hiện tại các kiểm tra đã có trong GetErrorMessage)
            return true;
        }
        private void CheckAllFieldsValid()
        {
            bool allValid = errorMap.All(entry => string.IsNullOrEmpty(GetErrorMessage(entry.Key))) && isImageSelected;
            acceptProduct_Btn.Enabled = allValid;

            // Tùy chỉnh giao diện khi nút bị vô hiệu hóa (tùy chọn)
            if (!allValid)
            {
                acceptProduct_Btn.FillColor = Color.FromArgb(150, acceptProduct_Btn.FillColor); // Làm mờ bằng cách giảm độ trong suốt của màu
            }
            else
            {
                acceptProduct_Btn.FillColor = Color.FromArgb(0, 122, 204); // Màu xanh dương khi hợp lệ
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddProductView_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                nameProduct_Txt.Focus();
                CheckAllFieldsValid(); // Gọi để cập nhật trạng thái nút ngay khi form load
            }));
        }

        private void chooseImage_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog { Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    productImage = new Bitmap(dialog.FileName);
                    poster_Pic.Image = productImage;
                    isImageSelected = true;
                    CheckAllFieldsValid();
                }
            }
        }

        private void acceptProduct_Btn_Click(object sender, EventArgs e)
        {
            if (!ValidateProductInput()) return;

            // Declare and initialize productDTO before using it  
            var productDTO = GetProductDTOFromForm();

            // Declare and initialize productDA before using it  
            ProductDA productDA = new ProductDA();

            var existingProduct = productDA.GetAllProducts().FirstOrDefault(p => p.Name.Equals(productDTO.Name, StringComparison.OrdinalIgnoreCase));
            if (existingProduct != null)
            {
                MessageBoxHelper.ShowError("Lỗi", "Đây là chức năng thêm sản phẩm mới!");
                return;
            }

            try
            {
                productDA.AddProduct(productDTO);
                MessageBoxHelper.ShowSuccess("Thông báo", "Thêm sản phẩm thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Lỗi", $"Lỗi khi thêm sản phẩm: {ex.Message}");
            }
        }
        private ProductDTO GetProductDTOFromForm()
        {
            // Lấy giá trị Type từ typeProduct_cbb.SelectedItem
            int productType = 1; // Giá trị mặc định nếu không xác định được
            if (typeProduct_cbb.SelectedItem != null)
            {
                string selectedType = typeProduct_cbb.SelectedItem.ToString();
                if (selectedType.Contains("Type 1"))
                    productType = 1; // Đồ ăn
                else if (selectedType.Contains("Type 2"))
                    productType = 2; // Thức uống
            }

            return new ProductDTO(
                0, // ID will be auto-generated
                nameProduct_Txt.Text.Trim(),
                productImage,
                int.Parse(quantity_Txt.Text.Trim()),
                (int)decimal.Parse(purchasePrice_Txt.Text.Replace(",", "").Trim()), // Keep as decimal
                null, // Price will be set by trigger
                productType // Type: 1 (Đồ ăn), 2 (Thức uống), hoặc 3 (Khác)
            );
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            foreach (var control in errorMap.Keys)
            {
                if (control is Guna2TextBox)
                {
                    control.Text = string.Empty;
                }
                else if (control is Guna2ComboBox)
                {
                    ((Guna2ComboBox)control).SelectedIndex = 0;
                }
            }
            poster_Pic.Image = null;
            productImage = null;
            isImageSelected = false;
            HideAllErrorLabels();
            acceptProduct_Btn.Enabled = false; // Vô hiệu hóa nút sau khi reset
            CheckAllFieldsValid(); // Cập nhật giao diện nút
            nameProduct_Txt.Focus();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void typeProduct_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
