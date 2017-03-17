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
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using ProjectxCam2.Model;
using ProjectxCam2.DAO;

namespace ProjectxCam2.UserColtrol
{
    public partial class ucAddTrainedImage : XtraUserControl
    {
        #region [Khởi tạo biến toàn cục]
        string storeImagePath = Properties.Settings.Default.faceImagePath;

        private VideoCapture _capture;
        private CascadeClassifier _cascadeClassifier;
       private bool _hasRecognizedFace;
        private bool _captureInProgress;
        private RecognizerEngine _recognizerEngine;

        #region [Hình ảnh]
        List<Face> faces = new List<Face>();

        List<Face> facetoShow = new List<Face>();

        Image<Gray, byte> trainingImage;

        #endregion

        People p = new People();
        PeopleDAO pDAO = new PeopleDAO();
        #endregion

        public ucAddTrainedImage()
        {
            InitializeComponent();
            #region [khởi tạo camera]
            try
            {
                _capture = new VideoCapture();
                _cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_default.xml");

                if (_capture != null)
                {
                    if (_captureInProgress)
                    { Application.Idle -= ProcessFrame; }
                    else
                    { Application.Idle += ProcessFrame; }
                }
                _captureInProgress = !_captureInProgress;
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            #endregion
        }

        #region [Xử lý hình ảnh]
        private void ProcessFrame(Object sender, EventArgs args)
        {
            try
            {
                imageBoxMain.Image = _capture.QueryFrame();
                if (!_hasRecognizedFace)
                {
                    using (var imageFrame = _capture.QueryFrame().ToImage<Bgr, Byte>())
                    {
                        if (imageFrame != null)
                        {
                            var grayframe = imageFrame.Convert<Gray, byte>();
                            var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty);
                            foreach (var face in faces)
                            {
                                imageFrame.Draw(face, new Bgr(Color.Red), 3);
                                trainingImage = imageFrame.Copy(face).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                            }
                        }
                        imageBoxMain.Image = imageFrame;                  
                        
                    }
                }
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
        }
        #endregion

        #region [Capture Click]
        private void btnCapture_Click(object sender, EventArgs e)
        {
            txtPeopleID.Enabled = false;
            if (txtPeopleID.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập một mã nhân viên hoặc chọn bên dưới");
                return;
            }
            for (int i = 0; i < 6; i++)
            {
                if (facetoShow[i].status == false)
                {
                    try
                    {
                        facetoShow[i].status = true;
                        var path = captureAFace(i);
                        if (path != "")                        
                            facetoShow[i].FaceTrainedPath = path;                        
                        else
                            return;
                        facetoShow[i].PeopleID = int.Parse(txtPeopleID.Text.Trim());
                       // facetoShow[i].DateCaptured = DateTime.Now; 
                    }
                    catch { }
                    return;
                }
            }
            if (facetoShow.Count >= 6)
            {
                MessageBox.Show("Đã chụp đủ 6 ảnh bạn có muốn lưu không");
                return;
            }
        }
        #endregion

        #region [user coltrol load]
        private void ucAddTrainedImage_Load(object sender, EventArgs e)
        {
            loadGridView();
            loadListImage();
            _recognizerEngine = new RecognizerEngine(storeImagePath,1);
            bckGroundTrainer.RunWorkerAsync();
        }
        #endregion

        #region [load data lên gridview]
        private void loadGridView()
        {
            gridControl1.DataSource = pDAO.getAllPeoples();
        }
        #endregion

        #region [Load số thứ tự]
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column.Name == "colSTT")
                    e.DisplayText = (e.RowHandle + 1).ToString();
            }
            catch { }
        }
        #endregion

        #region [show lấy id từ grid view]
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            People emp = (People)gridView1.GetRow(e.RowHandle);
            txtPeopleID.Text = emp.ID.ToString();
        }
        #endregion

        #region [try save]
        private void trySave(string filename)
        {            
            trainingImage.Save(filename);
        }
        #endregion

        #region [Capture a face and save]
        private string captureAFace(int i)
        {
            var fullname = "";
            var filename = "";
            try
            {
                fullname = storeImagePath + txtPeopleID.Text.Trim() + "_" + i + ".bmp";
                if (trainingImage != null)
                {
                    switch (i)
                    {
                        case 0:
                            imageBox1.Image = trainingImage;
                            break;
                        case 1:
                            imageBox2.Image = trainingImage;
                            break;
                        case 2:
                            imageBox3.Image = trainingImage;
                            break;
                        case 3:
                            imageBox4.Image = trainingImage;
                            break;
                        case 4:
                            imageBox5.Image = trainingImage;
                            break;
                        case 5:
                            imageBox6.Image = trainingImage;
                            break;
                    }
                }
                trySave(fullname);
            }
            catch { }
            return filename;
        }
        #endregion

        #region [Khởi tạo list image]
        private void loadListImage()
        {
            for (int i = 0; i < 6; i++)
            {
                Face f = new Face();
                f.status = false;
                facetoShow.Add(f);
            }
        }
        #endregion

        #region [Save Data to DB]
        private void bntSaveData_Click(object sender, EventArgs e)
        {
            bool isSucess = true;
            foreach (Face f in facetoShow)
            {
                FaceDAO fDAO = new FaceDAO();
                if (fDAO.addTrainFace(f) == -1)
                    isSucess = false;
            }
            if (isSucess)
                lblTrainInfo.Text = "Đã tạo dữ liệu nhận dạng";
            else
                lblTrainInfo.Text = "Lỗi rồi!";           
        }
        #endregion
        #region [Train face]
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

        private void bckGroundTrainer_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            e.Result = TrainRecognizer(worker, e);
        }

        private void bckGroundTrainer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                
                lblTrainInfo.Text = "Hủy khởi tạo dữ liệu";
            }
            else
            {
                var result = (bool)e.Result;
                if (result)
                    lblTrainInfo.Text = "Đã tạo dữ liệu nhận dạng";
               // lblTrainingStatus.Text = result ? "Training has been completed successfully!" : "Training could not be completed, An Error Occurred";
            }
            btnTrain.Enabled = true;
        }
        #endregion

        private void btnTrainNow_Click(object sender, EventArgs e)
        {
            btnTrain.Enabled = false;
            lblTrainInfo.Text = "Đang xử lý";
            bckGroundTrainer.RunWorkerAsync();
        }
        private void Release()
        {
            try
            {
                _capture.Stop();
                _capture.Dispose();
                Application.Idle -= ProcessFrame;
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Release();
        }
    }
}



