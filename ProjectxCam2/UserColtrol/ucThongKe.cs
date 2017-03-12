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
using ProjectxCam2.Model;
using ProjectxCam2.DAO;

namespace ProjectxCam2.UserColtrol
{
    public partial class ucThongKe : DevExpress.XtraEditors.XtraUserControl
    {
        HistoryDAO hDAO;
        public ucThongKe()
        {
            InitializeComponent();
            hDAO = new HistoryDAO();
        }
        private void loadGrid(int i)
        {            
            gridControl1.DataSource = hDAO.getTopHistorys();            
        }

        private void ucThongKe_Load(object sender, EventArgs e)
        {
            //backgroundWorkerHistory.RunWorkerAsync();
            loadGrid(1);
        }

        private void loadAllCombobox()
        {

        }

        private void loadComboboxMonth()
        {

        }
        private void loadComboboxYear()
        {

        }

        private void backgroundWorkerHistory_DoWork(object sender, DoWorkEventArgs e)
        {
            
          
        }
    }
}
