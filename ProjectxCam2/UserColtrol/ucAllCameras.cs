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
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.UI;


namespace ProjectxCam2.UserColtrol
{
    public partial class ucAllCameras : XtraUserControl
    {
        string _trainerDataPath = Properties.Settings.Default.trainerDataPath;
        List<Camera> listCamera;
        CameraDAO camDAO;
        CameraRun cRun1, cRun2, cRun3, cRun4, cRun5, cRun6, cRun7, cRun8;
        public ucAllCameras()
        {
            InitializeComponent();
            listCamera = new List<Camera>();
            camDAO = new CameraDAO();
        }
        private void loadGirdviewCamera()
        {            
            listCamera = camDAO.getAllCamera();
            gridControl1.DataSource = listCamera;
        }

        private void ucAllCameras_Load(object sender, EventArgs e)
        {
            loadGirdviewCamera();
            enableButton();
        }

        private void btnStopCam1_Click(object sender, EventArgs e)
        {
            cRun1.Release();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column.Name == "colSTT")
                    e.DisplayText = (e.RowHandle + 1).ToString();
            }
            catch { }
        }


        #region [Start class camera run]
        private class CameraRun
        {
            bool _captureInProgress;
            VideoCapture _capture;
            string url;
            private RecognizerEngine _recognizerEngine;
            private CascadeClassifier _cascadeClassifier;
            ImageBox picturebox;
            public CameraRun(ImageBox _picturebox, string _url)
            {
                this.picturebox = _picturebox;
                this.url = _url;
                try
                {
                    if (url == "" || url == "*")
                        _capture = new VideoCapture();
                    else
                        _capture = new VideoCapture(url);
                }
                catch { }
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
            private void ProcessFrame(Object sender, EventArgs args)
            {
                var imageFrame = _capture.QueryFrame().ToImage<Bgr, Byte>();

                if (imageFrame != null)
                {
                    var grayframe = imageFrame.Convert<Gray, byte>();
                    var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty);
                    foreach (var face in faces)
                    {
                        imageFrame.Draw(face, new Bgr(Color.Red), 3);
                        var f = imageFrame.Copy(face).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);

                    }
                    picturebox.Image = imageFrame;
                }
            }
            public void Release()
            {
                try
                {
                    this._capture.Stop();
                    this._capture.Dispose();
                    Application.Idle -= ProcessFrame;
                    _captureInProgress = !_captureInProgress;
                }
                catch { }
            }
        }
        #endregion

        #region [Start camera]
        private void btnStartCam1_Click(object sender, EventArgs e)
        {
            cRun1 = new CameraRun(imageBox1,listCamera[0].CamAddress);
        }

        private void btnStartCam2_Click(object sender, EventArgs e)
        {
            cRun2 = new CameraRun(imageBox2,listCamera[1].CamAddress);
        }

        private void btnStartCam3_Click(object sender, EventArgs e)
        {
            cRun3 = new CameraRun(imageBox3,listCamera[2].CamAddress);
        }

        private void btnStartCam4_Click(object sender, EventArgs e)
        {
            cRun4 = new CameraRun(imageBox4,listCamera[3].CamAddress);
        }
        #endregion
        private void enableButton()
        {
            try
            {
                if (listCamera[0].CamAddress != "")
                    btnStartCam1.Enabled = true;
                if (listCamera[1].CamAddress != "")
                    btnStartCam2.Enabled = true;
                if (listCamera[2].CamAddress != "")
                    btnStartCam3.Enabled = true;
                if (listCamera[4].CamAddress != "")
                    btnStartCam4.Enabled = true;
                if (listCamera[5].CamAddress != "")
                    btnStartCam5.Enabled = true;
            }
            catch { }
        }
    }
}


