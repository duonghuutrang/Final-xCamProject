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
using Emgu.CV.Structure;
using Emgu.Util;
using ProjectxCam2.DAO;
using ProjectxCam2.Model;


namespace ProjectxCam2.UserColtrol
{
    public partial class ucXCam : XtraUserControl
    {
        string _trainerDataPath = Properties.Settings.Default.trainerDataPath;
        string _capturedDataPath = @"D:\Camera\Final xCamProject\ProjectxCam2\bin\Debug\TrainedFace";
        int cameraID = Properties.Settings.Default.cameraID;
        int peopleID = Properties.Settings.Default.peopleID;
        int saveSequent = Properties.Settings.Default.maxMinuteToRecord;
        bool autoAlert = Properties.Settings.Default.autoAlertUnknownPeople;
        bool alertNow;
        private VideoCapture _capture;
        HistoryDAO hDAO;
        PeopleDAO pDAO;
        CameraDAO camDAO;
        FaceDAO fDAO;
        private CascadeClassifier _cascadeClassifier;
        private bool _hasRecognizedFace = false;
        private bool _captureInProgress;
        private RecognizerEngine _recognizerEngine, _recognizerEngineunKnow;
        private bool _clicked = false;
        private int _dectionID = -1;
        private List<Camera> listCameras = new List<Camera>();
        #region [Contructor ]
        public ucXCam()
        {
            InitializeComponent();       
            hDAO = new HistoryDAO();
            camDAO = new CameraDAO();
            fDAO = new FaceDAO();
            pDAO = new PeopleDAO();
            #region [Khởi tạo camera]
            _recognizerEngine = new RecognizerEngine(_trainerDataPath,1);
            _recognizerEngineunKnow = new RecognizerEngine(_trainerDataPath, 2);
            _cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_default.xml");
            #endregion

        }
        #endregion

        #region [ProcessFrame]
        private void ProcessFrame(Object sender, EventArgs args)
        {
            if (_clicked == false)
                cleartextBox();
            try
            {
                imageBox1.Image = _capture.QueryFrame();
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
                                var f = imageFrame.Copy(face).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                                var predictedUserId = _recognizerEngine.RecognizeUser(new Image<Gray, byte>(imageBox2.Image.Bitmap));                                
                                imageBox2.Image = f;                                
                                var p = getPeoplebyID(predictedUserId);
                                if (p != null)
                                {
                                    ShowPeopleInfo(p);
                                    saveKnownImage(imageFrame, p);
                                    loadGridViewHistorys();
                                }
                                if (p == null && autoAlert)
                                    MessageBox.Show("Có người lạ xâm nhập vào vùng cấm");
                                if (p == null)
                                {
                                    //var unknowuser = _recognizerEngineunKnow.RecognizeUser(new Image<Gray, byte>(f.ToBitmap()));
                                    //if(unknowuser==-1)
                                    SaveUnknownImage(f, imageFrame,1);
                                }
                            }
                        }
                        imageBox1.Image = imageFrame;
                        //  if (imageBox2.Image != null) _hasRecognizedFace = true;
                    }
                }
            }
            catch { }
        }
        #endregion

        #region [Clear textbox]
        private void cleartextBox()
        {
            txtPeopleID.Text = "Đang nhận dạng";
            txtAddress.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtPosition.Text = "";
            imageBox2.Image = new Image<Bgr, byte>("image2.png");

        }
        #endregion
        
        #region [Show people Info]
        private void ShowPeopleInfo(People p)
        {
            txtName.Text = p.FirstName + " " + p.LastName;
            txtPeopleID.Text = p.PeopleID;
            txtPosition.Text = p.Position;
            txtAddress.Text = p.Address;
            txtPhone.Text = p.Phone;
            lblResult.Text = "Đã nhận diện vào lúc: " + DateTime.Now.ToString();
        }
        #endregion

        #region[Get People by ID]
        private People getPeoplebyID(int predictedUserId)
        {           
            return pDAO.getPeopleByID(predictedUserId);
        }
        #endregion

        private int saveKnownImage(Image<Bgr, byte> frame, People p)
        {           
            var filename = "";
            History h = new History();
            h.CameraID = cameraID;
            h.PeopleID = p.ID;
            h.isDeleted = false;
            h.FaceCaptured = null;

            if (toggleSwitchSaveFream.IsOn)
            {
                int num = hDAO.getMaxID();
                filename = _capturedDataPath + "frame_" + num + "_" + p.ID + ".bmp";
                frame.Save(filename);
            }

            h.FrameCaptured = filename;
            if (checkSaveCondition(p.ID))
            {
                int result = hDAO.addHistory(h);
                if (result > -1)
                {
                    lblDateStatus.Text = "Đã ghi nhận vào lúc: " + DateTime.Now.ToString();
                    lblResult.Text = "Đã lưu lại ảnh chụp";
                    backgroundWorkerHistory.RunWorkerAsync();
                }
            }
            return 0;
        }
        private int SaveUnknownImage(Image<Gray, byte> face, Image<Bgr, byte> frame, int _method)
        {
            History h = new History();
            int num = hDAO.getMaxID();
            var filename = "face_" + num + ".bmp";
            var framename = "frame_" + num + ".bmp";
            face.Save(_capturedDataPath + filename);
            frame.Save(_capturedDataPath + framename);
            /* if (_method == 1)
             {               

                 face.Save(_capturedDataPath + filename);
                 frame.Save(_capturedDataPath + framename);
                 Face f = new Face();
                 f.FaceTrainedPath = filename;
                 f.DateCaptured = DateTime.Now;
                 f.PeopleID = "000000000";
                 f.CameraID = 0;
                 if (fDAO.addTrainFace(f) > -1)
                     lblResult.Text = "Phát hiện một khuôn mặt mới";
                 h.FaceCaptured = filename;
            }  

             h.CameraID = cameraID;
             h.FrameCaptured = framename;
             int result = hDAO.addHistory(h);
             if (result > -1)
             {
                 lblDateStatus.Text = "Đã ghi nhận người lạ vào lúc: " + DateTime.Now.ToString();

                 backgroundWorkerHistory.RunWorkerAsync();
             }*/
             
            return 0;
        }
   
        private void loadGirdviewCamera()
        {
            listCameras = camDAO.getAllCamera();
            gridControl1.DataSource = listCameras;
        }

        private void loadGridViewUnKnownHistory()
        {
            gridControl3.DataSource = hDAO.getTopHistorys(0);
        }

        private void ucXCam_Load(object sender, EventArgs e)
        {
            //backgroundWorkerHistory.RunWorkerAsync();
            loadGridViewHistorys();
            loadGirdviewCamera();
            LoadComboxCamera();
            loadGridViewUnKnownHistory();
        }

        #region [đánh số TT]
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

        private void loadGridViewHistorys()
        {
            gridControl2.DataSource = hDAO.getTopHistorys();
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            History his = (History)gridView2.GetRow(e.RowHandle);
            try
            {
                txtName.Text = his.FirstName + " " + his.LastName;
                txtPeopleID.Text = his.PeopleID.ToString();
                _clicked = !_clicked;
                try
                {
                    imageBox2.Image = new Image<Bgr, byte>(his.FrameCaptured);
                }
                catch { }
            }
            catch { }
        }

        private bool checkSaveCondition(int _id)
        {
            bool result = false;
            History his = new History();

            his = hDAO.getLatestHistorybyPeopleID(_id);

            var savedtime = Convert.ToDateTime(his.DateCaptured.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            var datetimenow = Convert.ToDateTime(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            //var datetimenow = DateTime.Now.ToString();
            var minute = hDAO.getMinuteDiff(savedtime, datetimenow);          
            if (minute > saveSequent)
                result = true;
            return result;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                Camera cam = (Camera)gridView2.GetRow(e.RowHandle);              
            }
            catch { }
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column.Name == "colLSSTT")
                    e.DisplayText = (e.RowHandle + 1).ToString();
            }
            catch { }
        }

        private void LoadComboxCamera()
        {            
            List<string> lst = new List<string>();
            foreach (Camera c in listCameras)
            {
                lst.Add(c.CamName);
            }
            comboboxCameras.DataSource = lst;
        }
        #region [start camera ]
        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            if (toggleSwitchAlertNow.IsOn)
                alertNow = true;
            var cameracaption = "";
            try
            {
                //var url = @"rtsp://admin:admin@192.168.1.110:554/12/";
                // _capture = new VideoCapture(@"E:\YouTube.mp4");
                var url = "";
                if (txtCameraURL.Text.Trim() != "")
                {
                    url = txtCameraURL.Text.Trim();
                }
                else
                {
                    foreach (Camera c in listCameras)
                    {
                        if (c.CamName == comboboxCameras.SelectedText)
                        {
                            url = c.CamAddress;
                            cameracaption = c.CamName;
                        }
                    }
                }
                try
                {

                    if (url == "" || url == "*")
                        _capture = new VideoCapture();
                    else
                        _capture = new VideoCapture(url);
                }
                catch { }
                if (_capture != null)
                {
                    if (_captureInProgress)
                    { Application.Idle -= ProcessFrame; }
                    else
                    { Application.Idle += ProcessFrame; }
                }
                _captureInProgress = !_captureInProgress;
            }
            catch { }
            xtraTabControl2.SelectedTabPageIndex = 0;
            xtraTabControl1.SelectedTabPageIndex = 1;
            comboboxCameras.Enabled = false;
            txtCameraURL.Enabled = false;
            btnStartCamera.Enabled = false;
            btnPauseCamera.Enabled = true;
            groupControl2.Text = cameracaption;
        }
        #endregion

        private void btnPauseCamera_Click(object sender, EventArgs e)
        {
            comboboxCameras.Enabled = true;
            txtCameraURL.Enabled = true;
            btnStartCamera.Enabled = true;
            btnPauseCamera.Enabled = false;
            Release();
        }
        private void Release()
        {
            try
            {
                _capture.Stop();
                _capture.Dispose();
                Application.Idle -= ProcessFrame;
                _captureInProgress = !_captureInProgress;
            }
            catch { }
        }

        private void backgroundWorkerHistory_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            // e.Result = TrainRecognizer(worker, e);
            //loadGridViewHistorys();
        }

        private void toggleSwitchAlertNow_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitchAlertNow.IsOn)
                alertNow = true;
            else
                alertNow = false;
        }

        private void backgroundWorkerHistory_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

    }

}


