using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.MessageBox;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
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

namespace Cinema_Management_System.Views.MovieManagement
{
    public partial class ExtendMovieView : Form
    {
        private Guna2ShadowForm shadowForm;
        private MovieDTO _movie;
        private Dictionary<Control, Label> errorMap;
        public ExtendMovieView(MovieDTO movie)
        {
            InitializeComponent();
            _movie = movie;
            SetupUI();
            InitValidation();
        }

        private void SetupUI()
        { 
            showTime_Txt.Text = "0";
            DragHelper.EnableDrag(this, control_Panel);
            shadowForm = new Guna2ShadowForm
            {
                ShadowColor = Color.Black,
                BorderRadius = 20
            };
            shadowForm.SetShadowForm(this);

            DateTime endDate;
            if (DateTime.TryParse(_movie.EndDate, out endDate))
            {
                endMovie_Txt.MinDate = endDate;
                endMovie_Txt.Value = endDate;   
            }
            else
            {
                endMovie_Txt.MinDate = DateTime.Today;
                endMovie_Txt.Value = DateTime.Today;
            }
        }

        private void acceptMovie_Btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBoxHelper.ShowQuestion("Thông báo", "Bạn có chắc chắn muốn gia hạn phim này không?");
            if (result == DialogResult.No)
            {
                return;
            }
            _movie.EndDate = endMovie_Txt.Value.ToString("yyyy-MM-dd");
            _movie.TotalShowtimes += int.Parse(showTime_Txt.Text);
            _movie.ImportPrice += int.TryParse(priceMovie_Txt.Text.Replace(",", ""), out int price) ? price : 0;
            bool success = MovieDA.Instance.UpdateMovie(_movie);
            if (success)
            {
                MessageBoxHelper.ShowSuccess("Thành công", "Gia hạn phim thành công!");
                this.Close();
            }
            else
            {
                MessageBoxHelper.ShowError("Lỗi", "Không thể gia hạn phim. Vui lòng thử lại!");
            }
        }

        private void InitValidation()
        {
            errorMap = new Dictionary<Control, Label>
            {
                { priceMovie_Txt, priceError_Txt },
                { showTime_Txt, showTimeError_Txt },
            };

            foreach (var entry in errorMap)
            {
                var textBox = entry.Key;
                textBox.TextChanged += (s, e) =>
                {
                    ValidateSingleField(textBox);
                    CheckAllFieldsValid();
                };

                textBox.Leave += (s, e) =>
                {
                    ValidateSingleField(textBox);
                    if (decimal.TryParse(priceMovie_Txt.Text, out var price) && price > 0)
                    {
                        priceMovie_Txt.Text = price.ToString("N0");
                    }
                    if (decimal.TryParse(showTime_Txt.Text, out var soluong) && soluong > 0)
                    {
                        showTime_Txt.Text = soluong.ToString("N0");
                    }
                };
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
                if (string.IsNullOrWhiteSpace(control.Text))
                {
                    error = "*Không được để trống!";
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
            string text = control.Text.Trim();

            if (string.IsNullOrWhiteSpace(text))
            {
                return "*Không được để trống!";
            }

            if (control == priceMovie_Txt)
            {
                if(!decimal.TryParse(text, out decimal price) || price < 0)
                    return "*Giá trị không hợp lệ!";
                int showtimes = int.TryParse(showTime_Txt.Text, out int st) ? st : 0;
                if (showtimes == 0 && price != 0)
                {
                    return "*Chỉ chỉnh thời gian thì giá nhập phải bằng 0!";
                }
                if (showtimes > 0 && price == 0)
                {
                    return "*Thêm suất chiếu thì giá nhập phải lớn hơn 0!";
                }

            }

            if (control == showTime_Txt && (!decimal.TryParse(text, out decimal total) || total <= 0))
            {
                return "*Giá trị không hợp lệ!";
            }

            return string.Empty;
        }

        private void CheckAllFieldsValid()
        {
            bool allValid = errorMap.All(entry => string.IsNullOrEmpty(GetErrorMessage(entry.Key)));
            acceptMovie_Btn.Enabled = allValid;
        }

        private void huy_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
