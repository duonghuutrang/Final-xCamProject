using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ProjectxCam2.UserColtrol
{
    public partial class ucLogin : DevExpress.XtraEditors.XtraUserControl
    {
        public ucLogin()
        {
            InitializeComponent();
            
        }

        private void ucLogin_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Show();
        }
    }
}
