using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
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

namespace Cinema_Management_System.Views.StaffManagement
{
    public partial class StaffDetailView : Form
    {
        private Guna2ShadowForm shadowForm;
        public StaffDetailView(StaffDTO staff)
        {
            InitializeComponent();
            SetupUI();
            LoadStaffDetails(staff);
        }

        private void SetupUI()
        {
            DragHelper.EnableDrag(this, control_Panel);
            shadowForm = new Guna2ShadowForm
            {
                ShadowColor = Color.Black,
                BorderRadius = 20
            };
            shadowForm.SetShadowForm(this);
        }

        private void LoadStaffDetails(StaffDTO staff)
        {
            if (staff == null) return;
            name_Txt.Text = staff.FullName;
            name_Txt.TextAlign = ContentAlignment.MiddleCenter;
            name_Txt.MaximumSize = new Size(avatar_Pic.Width, 0);
            name_Txt.AutoSize = true;

            staffId_Txt.Text = StaffDA.formatID(staff.Id, "NV");
            role_Txt.Text = staff.Role;
            sex_Txt.Text = staff.Gender;
            birth_Txt.Text = staff.Birth;
            email_Txt.Text = staff.Email;
            phone_Txt.Text = staff.PhoneNumber;
            startDate_Txt.Text = staff.NgayVaoLam;
            salary_Txt.Text = staff.Salary.ToString("N0");

            if (staff.ImageSource != null)
            {
                avatar_Pic.Image = staff.ImageSource;
            }
            else
            {
                avatar_Pic.Image = Properties.Resources.icons8_person_32;
            }

            name_Txt.Location = new Point(
                avatar_Pic.Location.X + (avatar_Pic.Width / 2) - (name_Txt.Width / 2),
                name_Txt.Location.Y
            );
        }
    }
}
