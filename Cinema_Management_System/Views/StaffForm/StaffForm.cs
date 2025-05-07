using Cinema_Management_System.Views.CustomerManagement;
using Cinema_Management_System.Views.MovieManagement;
using Cinema_Management_System.Views.StaffManagement;
using Cinema_Management_System.Views.Statistics;
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

namespace Cinema_Management_System.Views.StaffForm
{
    public partial class StaffForm : Form
    {
        private Guna.UI2.WinForms.Guna2Button currentSelectedButton = null;
        private List<UserControl> subControls;
        public StaffForm()
        {
            InitializeComponent();
            InitializeSubForms();
        }

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
                productManagementView1,
                showTimeManagementyForm1,
                aboutAccount_Form1,
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

        private void showtimeManage_Btn_Click(object sender, EventArgs e)
        {
            SelectSidebarButton(showtimeManage_Btn);
            ShowSubForm(showTimeManagementyForm1);
        }

        private void productManage_Btn_Click(object sender, EventArgs e)
        {
            SelectSidebarButton(productManage_Btn);
            ShowSubForm(productManagementView1);
        }

        private void profile_Btn_Click(object sender, EventArgs e)
        {
            SelectSidebarButton(profile_Btn);
            ShowSubForm(aboutAccount_Form1);
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

        private void StaffForm_Load(object sender, EventArgs e)
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
                        name_Txt.MaximumSize = new Size(slidebar_Panel.Width - 20, 0); 
                        name_Txt.TextAlign = ContentAlignment.MiddleCenter;

                        Size preferredSize = TextRenderer.MeasureText(name_Txt.Text, name_Txt.Font, name_Txt.MaximumSize, TextFormatFlags.WordBreak);
                        name_Txt.Size = new Size(name_Txt.MaximumSize.Width, preferredSize.Height);

                        name_Txt.Location = new Point(
                            (slidebar_Panel.Width - name_Txt.Width) / 2,
                            name_Txt.Location.Y
                        );

                        avatar_pic.Location = new Point(
                        (slidebar_Panel.Width - avatar_pic.Width) / 2,
                            avatar_pic.Location.Y
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
                System.Windows.Forms.MessageBox.Show("Lỗi:" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SelectSidebarButton(showtimeManage_Btn);
            ShowSubForm(showTimeManagementyForm1);
        }
    }
}
