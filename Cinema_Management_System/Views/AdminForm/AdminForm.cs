using Cinema_Management_System.Views.ShowTimeManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Cinema_Management_System.AboutAccount_Form;

namespace Cinema_Management_System
{
    public partial class AdminForm : Form
    {
        private Guna.UI2.WinForms.Guna2Button currentSelectedButton = null;

        public AdminForm()
        {
            InitializeComponent();
            InitializeSubForms();
        }

        private List<UserControl> subControls;

        private void SelectSidebarButton(Guna.UI2.WinForms.Guna2Button selectedButton)
        {
            if (currentSelectedButton != null)
            {
                currentSelectedButton.FillColor = Color.White;
                currentSelectedButton.ForeColor = Color.Black; 
            }

            selectedButton.FillColor = Color.FromArgb(203, 45, 62); 
            selectedButton.ForeColor = Color.White; 

            currentSelectedButton = selectedButton;
        }


        private void InitializeSubForms()
        {
            subControls = new List<UserControl>
            {
                aboutAccount_Form1,
                movieManagementView1,
                customerManagementView1,
                //movieManageForm1,
                //showtimeManageForm1,
                //staffManageForm1,
                //customerManageForm1,
                //statisticalForm1,
                //voucherForm1,
                //productManageForm1
                showTimeManagementyForm1
            };
        }

        private void HideAllsubControls()
        {
            foreach (var control in subControls)
            {
                control.Hide();
            }
        }

        private void ShowSubForm(UserControl controlToShow)
        {
            HideAllsubControls();
            controlToShow.Show();

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logout_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void profile_Btn_Click(object sender, EventArgs e)
        {
            SelectSidebarButton(profile_Btn);
            ShowSubForm(aboutAccount_Form1);
        }

        private void filmManage_Btn_Click(object sender, EventArgs e)
        {
            SelectSidebarButton(filmManage_Btn);
            ShowSubForm(movieManagementView1);
        }

        private void showtimeManage_Btn_Click(object sender, EventArgs e)
        {
            SelectSidebarButton(showtimeManage_Btn);
            ShowSubForm(showTimeManagementyForm1);
        }

        private void staffManage_Btn_Click(object sender, EventArgs e)
        {
            //ShowSubForm(staffManageForm1);
        }

        private void customerManage_Btn_Click(object sender, EventArgs e)
        {
            SelectSidebarButton(customerManage_Btn);
            ShowSubForm(customerManagementView1);
        }

        private void productManage_Btn_Click(object sender, EventArgs e)
        {
            //ShowSubForm(productManageForm1);
        }

        private void voucher_Btn_Click(object sender, EventArgs e)
        {
            //ShowSubForm(voucherForm1);
        }

        private void thongKe_Btn_Click(object sender, EventArgs e)
        {
            //ShowSubForm(statisticalForm1);
        }

        private void customerManagementView1_Load(object sender, EventArgs e)
        {

        }

        private void customerManagementView1_Load_1(object sender, EventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var db = new ConnectDataContext())
                {
                    var staff = db.STAFFs.FirstOrDefault(s => s.Id == CurrentUser.StaffId);
                    if (staff != null)
                    {
                        name_Txt.Text = staff.FullName;
                        name_Txt.AutoSize = false;
                        name_Txt.MaximumSize = new Size(slidebar_Panel.Width - 20, 0); // chừa margin 10px mỗi bên
                        name_Txt.TextAlign = ContentAlignment.MiddleCenter;

                        // Cập nhật kích thước label cho vừa nội dung (chiều cao)
                        Size preferredSize = TextRenderer.MeasureText(name_Txt.Text, name_Txt.Font, name_Txt.MaximumSize, TextFormatFlags.WordBreak);
                        name_Txt.Size = new Size(name_Txt.MaximumSize.Width, preferredSize.Height);

                        // Căn giữa theo chiều ngang
                        name_Txt.Location = new Point(
                            (slidebar_Panel.Width - name_Txt.Width) / 2,
                            name_Txt.Location.Y // Giữ nguyên vị trí Y hiện tại
                        );

                        avatar_pic.Location = new Point(
                        (slidebar_Panel.Width - avatar_pic.Width) / 2,
                            avatar_pic.Location.Y // giữ nguyên vị trí Y
                        );

                        if (staff.ImageSource != null)
                        {
                            using (MemoryStream ms = new MemoryStream(staff.ImageSource.ToArray()))
                            {
                                avatar_pic.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            avatar_pic.Image = Properties.Resources.icons8_person_32;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
