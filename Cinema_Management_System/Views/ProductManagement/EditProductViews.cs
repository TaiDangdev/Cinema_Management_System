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

namespace Cinema_Management_System.Views.ProductManagement
{
    public partial class EditProductViews : Form
    {
        private Guna2ShadowForm shadowForm;
        public EditProductViews()
        {
            InitializeComponent();
            SetupUI();
        }
        private void SetupUI()
        {
            this.Text = "Sửa sản phẩm";
            DragHelper.EnableDrag(this, control_Panel);
            shadowForm = new Guna2ShadowForm
            {
                ShadowColor = Color.Black,
                BorderRadius = 20
            };
            shadowForm.SetShadowForm(this);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void acceptProduct_Btn_Click(object sender, EventArgs e)
        {

        }
    }
}
