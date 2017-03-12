using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using ProjectxCam2.UserColtrol;

namespace ProjectxCam2
{
    public partial class xCamMainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private RecognizerEngine _recognizerEngine, _recognizerEngineunKnown;
        string storeImagePath = Properties.Settings.Default.faceImagePath;
        public xCamMainForm()
        {
            InitializeComponent();
        }

        private void xCamMainForm_Load(object sender, EventArgs e)
        {
            ribbon.SelectedPage = ribbonPage2;
            _recognizerEngine = new RecognizerEngine(storeImagePath,1);
            _recognizerEngineunKnown = new RecognizerEngine(storeImagePath, 2);
        }

        private void btnCamera_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucXCam uc = new ucXCam();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uc);
        }

        private void btnAddCamera_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucAddCam uc = new ucAddCam();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uc);

        }

        private void btnAddPeople_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucAddPeople uc = new ucAddPeople();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uc);
        }

        private void btnAddTrainImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucAddTrainedImage uc = new ucAddTrainedImage();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uc);
        }

        private void btnThongKe_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucThongKe uc = new ucThongKe();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uc);
        }

        private void btnSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucSetting uc = new ucSetting();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uc);
        }

        private void btnAllCamera_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucAllCameras uc = new ucAllCameras();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uc);
        }

        private void btnCreateReconizerDB_ItemClick(object sender, ItemClickEventArgs e)
        {
            backgroundDBTrainer.RunWorkerAsync();
            barStaticItem1.Caption = "Đang xử lý dữ liệu";
            btnCreateReconizerDB.Enabled = false;
        }

        private void backgroundDBTrainer_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            e.Result = TrainRecognizer(worker, e);
        }

        private void backgroundDBTrainer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {

                barStaticItem1.Caption = "Hủy tạo dữ liệu";
            }
            else
            {
                var result = (bool)e.Result;
                if (result)
                    barStaticItem1.Caption = "Đã tạo dữ liệu nhận dạng";
                // lblTrainingStatus.Text = result ? "Training has been completed successfully!" : "Training could not be completed, An Error Occurred";
            }
            btnCreateReconizerDB.Enabled = true;
        }
        private bool TrainRecognizer(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                var hasTrainedRecognizer = _recognizerEngine.TrainRecognizer(1);
                return hasTrainedRecognizer;
            }
            return false;
        }
        private bool TrainRecognizerunKnown(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                var hasTrainedRecognizer = _recognizerEngineunKnown.TrainRecognizer(2);
                return hasTrainedRecognizer;
            }
            return false;
        }

        private void btnReconizerPeople_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucReconizationbyImage uc = new ucReconizationbyImage();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uc);
        }

        private void btnReport_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnDataFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void btnLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucLogin uc = new ucLogin();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uc);        
           
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucLogin uc = new ucLogin();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uc);
        }

        private void btnTrainUnknownDB_ItemClick(object sender, ItemClickEventArgs e)
        {
            backgroundDBUnknown.RunWorkerAsync();
            barStaticItem1.Caption = "Đang xử lý dữ liệu";
            btnCreateReconizerDB.Enabled = false;
        }

        private void backgroundDBUnknown_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;            
            e.Result = TrainRecognizerunKnown(worker, e);
        }
    }
}