using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Management_System.Views.Statistics
{
    public partial class StatisticsView : UserControl
    {
        public StatisticsView()
        {
            InitializeComponent();
        }

        private void StatisticsView_Load(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            int[] allowedTabs = { 2, 3, 4 };
            if(!allowedTabs.Contains(e.TabPageIndex) )
            {
                e.Cancel= true;
            }    
        }
    }
}
