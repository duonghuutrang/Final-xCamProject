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
    public partial class ucAddPeople : DevExpress.XtraEditors.XtraUserControl
    {
        private People p = new People();
        private PeopleDAO pDAO = new PeopleDAO();
        private int selectedID;
        public ucAddPeople()
        {
            InitializeComponent();
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            var p = getPeopleInfo();
            if (pDAO.addPeople(p) > -1)
                MessageBox.Show("Thêm thành công");
            else
                MessageBox.Show("Lỗi rồi");

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            People emp = (People)gridView1.GetRow(e.RowHandle);
            selectedID = emp.ID;
            txtAddress.Text = emp.Address;
            txtFirstName.Text = emp.FirstName;
            txtLastName.Text = emp.LastName;
            txtPhone.Text = emp.Phone;
            txtPosition.Text = emp.Position;
            txtPeopleID.Text = emp.PeopleID;
            if (emp.Sex == true)
                radioMale.Checked = true;
            else
                radioFemale.Checked = true;
            txtComment.Text = emp.Comment;
            btnUpdateInfo.Enabled = true;
        }
        private void loadGridview()
        {
            gridControl1.DataSource = pDAO.getAllPeoples();
        }

        private void ucAddPeople_Load(object sender, EventArgs e)
        {
            loadGridview();
            btnUpdateInfo.Enabled = false;
        }
        private int updatePeople()
        {
            var p = getPeopleInfo();
            if (pDAO.updatePeople(p))
            {
                MessageBox.Show("Cập nhật thành công");
                btnUpdateInfo.Enabled = false;
                loadGridview();
            }
            else
                MessageBox.Show("Lỗi rồi");
         
            return -1;
        }
        private People getPeopleInfo()
        {
            People p = new People();
            p.ID = selectedID;
            p.PeopleID = txtPeopleID.Text.Trim();
            p.FirstName = txtFirstName.Text.Trim();
            p.LastName = txtLastName.Text.Trim();
            p.Position = txtPosition.Text.Trim();
            if (radioMale.Checked)
                p.Sex = true;
            else
                p.Sex = false;
            p.Phone = txtPhone.Text.Trim();
            p.Address = txtAddress.Text.Trim();
            p.Comment = txtComment.Text.Trim();
            p.BirthDay = dateTimePicker1.Value;
            p.DateAdded = DateTime.Now;
            p.isDeleted = false;
            return p;
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            updatePeople();
        }
    }
}
