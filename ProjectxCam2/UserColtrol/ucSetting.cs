using System;
using System.IO;
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
    public partial class ucSetting : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSetting()
        {
            InitializeComponent();
        }

        private void btnBrowseTrainDBFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtTrainDBFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnBrowseImageFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtImageFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnBrowseFaceFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFaceFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.maxMinuteToRecord = trackBarControlHistoryTime.Value;
            Properties.Settings.Default.maxSaveDay = trackBarControlmaxSaveDay.Value;
            if (txtTrainDBFolder.Text.Trim() != "" || txtFaceFolder.Text.Trim() != "" || txtFaceFolder.Text.Trim() != "")
            {
                Properties.Settings.Default.trainerDataPath = txtTrainDBFolder.Text.Trim();
                Properties.Settings.Default.faceImagePath = txtImageFolder.Text.Trim();
                Properties.Settings.Default.frameImagePath = txtFaceFolder.Text.Trim();
               
                if (toggleSwitch1.IsOn)
                    Properties.Settings.Default.saveFrame = true;
                if (toggleSwitch2.IsOn)
                    Properties.Settings.Default.saveUnknownPeople = true;
                if (toggleSwitch3.IsOn)
                    Properties.Settings.Default.autoAlertUnknownPeople = true;
                Properties.Settings.Default.Save();
                MessageBox.Show("Đã lưu lại cấu hình");
            }
            else
                MessageBox.Show("Cần chọn đường dẫn trước.");
        }

        private void ucSetting_Load(object sender, EventArgs e)
        {
            txtTrainDBFolder.Text = Properties.Settings.Default.trainerDataPath;
            txtFaceFolder.Text = Properties.Settings.Default.faceImagePath;
            txtImageFolder.Text = Properties.Settings.Default.frameImagePath;
            trackBarControlHistoryTime.Value = Properties.Settings.Default.maxMinuteToRecord;
            trackBarControlmaxSaveDay.Value = Properties.Settings.Default.maxSaveDay;
            lblMinuteToSave.Text = Properties.Settings.Default.maxMinuteToRecord + " phút";
            if (Properties.Settings.Default.saveFrame)
                toggleSwitch1.IsOn = true;
            if (Properties.Settings.Default.saveUnknownPeople)
                toggleSwitch2.IsOn = true;
            if (Properties.Settings.Default.autoAlertUnknownPeople)
                toggleSwitch3.IsOn = true;

        }

        private void trackBarControlHistoryTime_ValueChanged(object sender, EventArgs e)
        {
            lblMinuteToSave.Text = trackBarControlHistoryTime.Value + " phút";
        }

        private void trackBarControlmaxSaveDay_ValueChanged(object sender, EventArgs e)
        {
            lblMaxSaveDay.Text = trackBarControlmaxSaveDay.Value + " ngày";
        }
    }
}
