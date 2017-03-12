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
using ProjectxCam2.DAO;
using ProjectxCam2.Model;

namespace ProjectxCam2.UserColtrol
{
    public partial class ucAddCam : DevExpress.XtraEditors.XtraUserControl
    {
        List<Camera> listCam = new List<Camera>();
        CameraDAO dao = new CameraDAO();
        public ucAddCam()
        {
            InitializeComponent();
            loadGrid();
        }

        private void ucAddCam_Load(object sender, EventArgs e)
        {
            List<string> protocol = new List<string>();
            protocol.Add("rstp");
            protocol.Add("htpp");
            protocol.Add("https");
            comboboxProtocol.DataSource = protocol;     
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string address = comboboxProtocol.Text.Trim() + "://" + txtName.Text.Trim()+":" + txtPass.Text.Trim() + "@" + txtIP.Text.Trim() +":"+txtPort.Text.Trim()+ "/" + txtExtention.Text.Trim();

            Camera cam = new Camera();
            cam.CamName = txtCamName.Text.Trim();
            cam.DateAdded = DateTime.Now;
            cam.Comment = txtComment.Text.Trim();
            cam.isDeleted = false;
            
            cam.CamAddress = address;
            int result = dao.addCamera(cam);
            txtFullAdress.Text = address;
            if (result > -1)
            {
                MessageBox.Show("Thêm thành công!");
                loadGrid();
            }
            else
                MessageBox.Show("Lỗi rồi");

        }
        private void loadGrid()
        {                       
            gridControl1.DataSource = dao.getAllCamera();
           // if(dao.getAllCamera())      
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Camera cam = (Camera)gridView1.GetRow(e.RowHandle);
            txtCamName.Text = cam.CamName;
            txtComment.Text = cam.Comment;
            //txtName.Text = cam.
            //txtIP.Text = cam.
        }
    }
}
