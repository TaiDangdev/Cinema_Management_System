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
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Models;
using Cinema_Management_System.Views.MessageBox;

namespace Cinema_Management_System.Views.ProductManagement
{
    public partial class EditProductView : Form
    {
        private ProductDTO productToEdit;
        private Bitmap productImage;
        private bool isImageSelected = false;
        private Dictionary<Control, Label> errorMap;
        private Guna2ShadowForm shadowForm;

        public EditProductView(ProductDTO product)
        {
            InitializeComponent();
            productToEdit = product;
            SetupUI();
            InitValidation();
            LoadProductToForm();
        }

        private void SetupUI()
        {
            this.Text = "Chỉnh sửa sản phẩm";
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

        private void LoadProductToForm()
        {
            if (productToEdit == null) return;

            nameProduct_Txt.Text = productToEdit.Name;
            quantity_Txt.Text = productToEdit.Quantity.ToString();
            purchasePrice_Txt.Text = productToEdit.PurchasePrice.ToString("N0");
            poster_Pic.Image = productToEdit.ImageSource;
            isImageSelected = productToEdit.ImageSource != null;

            if (productToEdit.Type == 1)
                typeProduct_cbb.SelectedIndex = 0;
            else if (productToEdit.Type == 2)
                typeProduct_cbb.SelectedIndex = 1;

            CheckAllFieldsValid();
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

                if (string.IsNullOrWhiteSpace(text))
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
                    if (!decimal.TryParse(text.Replace(",", ""), out decimal price) || price <= 0)
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


        private void CheckAllFieldsValid()
        {
            bool allValid = errorMap.All(entry => string.IsNullOrEmpty(GetErrorMessage(entry.Key))) && isImageSelected;
            acceptProduct_Btn.Enabled = allValid;
            acceptProduct_Btn.FillColor = allValid ? Color.FromArgb(0, 122, 204) : Color.FromArgb(150, 0, 122, 204);
        }


        private void EditProductView_Load(object sender, EventArgs e)
        {

        }

        private void acceptProduct_Btn_Click(object sender, EventArgs e)
        {
            if (!ValidateProductInput()) return;

            ProductDTO updatedProduct = GetProductDTOFromForm();

            ProductDA productDA = new ProductDA();
            try
            {
                productDA.EditProduct(updatedProduct);
                MessageBoxHelper.ShowSuccess("Thành công", "Cập nhật sản phẩm thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Lỗi", $"Không thể cập nhật sản phẩm: {ex.Message}");
            }
        }
        private bool ValidateProductInput()
        {
            return true; // Đã xử lý kiểm tra ở TextChanged và Leave
        }
        private ProductDTO GetProductDTOFromForm()
        {
            int productType = 1;
            if (typeProduct_cbb.SelectedItem != null)
            {
                //Đồ ăn 
                //Nước uống
                string selectedType = typeProduct_cbb.SelectedItem.ToString().Trim();
                if (selectedType.Contains("Đồ ăn"))
                    productType = 1;
                else if (selectedType.Contains("Nước uống"))
                    productType = 2;
            }

            return new ProductDTO(
                productToEdit.Id,
                nameProduct_Txt.Text.Trim(),
                productImage ?? (Bitmap)poster_Pic.Image,
                int.Parse(quantity_Txt.Text.Trim()),
                (int)decimal.Parse(purchasePrice_Txt.Text.Replace(",", "").Trim()),  // Loại bỏ dấu phẩy trước khi chuyển thành decimal
                productToEdit.Price,
                productType
            );

        }
        private void choseImage_btn_Click(object sender, EventArgs e)
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

        private void reset_btn_Click(object sender, EventArgs e)
        {
            LoadProductToForm();
            HideAllErrorLabels();
        }
    }
}
