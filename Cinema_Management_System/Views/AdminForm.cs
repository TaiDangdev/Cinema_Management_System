using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Management_System
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            InitializeSubForms();
        }

        private List<UserControl> subControls;

        private void InitializeSubForms()
        {
            subControls = new List<UserControl>
            {
                aboutAccount_Form1,
                movieManagementView1,
                //movieManageForm1,
                //showtimeManageForm1,
                //staffManageForm1,
                //customerManageForm1,
                //statisticalForm1,
                //voucherForm1,
                //productManageForm1
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
            ShowSubForm(aboutAccount_Form1);
        }

        private void filmManage_Btn_Click(object sender, EventArgs e)
        {
            ShowSubForm(movieManagementView1);
        }

        private void showtimeManage_Btn_Click(object sender, EventArgs e)
        {
            //ShowSubForm(showtimeManageForm1);
        }

        private void staffManage_Btn_Click(object sender, EventArgs e)
        {
            //ShowSubForm(staffManageForm1);
        }

        private void customerManage_Btn_Click(object sender, EventArgs e)
        {
            //ShowSubForm(customerManageForm1);
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

    }
}
