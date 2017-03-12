using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using ProjectxCam2.Model;
using ProjectxCam2.DAO;
using System.IO;
using Emgu.CV.CvEnum;

namespace ProjectxCam2
{
    class RecognizerEngine
    {
        private FaceRecognizer _faceRecognizer;
        private String _recognizerFilePath;
        private int method;
        public RecognizerEngine(string path,int _method)
        {
            _recognizerFilePath = path;
            _faceRecognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);
            this.method = _method;
        }

        public bool TrainRecognizer(int _method)
        {
            this.method = _method;
            List<Face> allFaces = new List<Face>();
            FaceDAO fDAO = new FaceDAO();
            if (method == 1)
            {
                allFaces = fDAO.getAllFace();
            }else
            {
                allFaces = fDAO.getAllUnKnowFace();
            }
           
            if (allFaces != null)
            {
                try
                {
                    var faceImages = new Image<Gray, byte>[allFaces.Count];
                    var faceLabels = new int[allFaces.Count];

                    for (int i = 0; i < allFaces.Count; i++)
                    {
                        try
                        {
                            var faceImage = new Image<Gray, byte>(allFaces[i].FaceTrainedPath).Resize(100, 100, Inter.Cubic);
                            faceImages[i] = faceImage;
                        }
                        catch { Console.WriteLine("Không thể đọc file"); }
                        faceLabels[i] = allFaces[i].ID;
                    }                
                    _faceRecognizer.Train(faceImages, faceLabels);
                   _faceRecognizer.Save(_recognizerFilePath+"traineddata"+method+".xcam");
                }
                catch (Exception e){ Console.WriteLine(e.ToString()); }
            }
            return true;

        }

        public void LoadRecognizerData()
        {
            _faceRecognizer.Load(_recognizerFilePath);
        }

        public int RecognizeUser(Image<Gray, byte> userImage)
        {
            /*  Stream stream = new MemoryStream();
              stream.Write(userImage, 0, userImage.Length);
              var faceImage = new Image<Gray, byte>(new Bitmap(stream));*/
            _faceRecognizer.Load(_recognizerFilePath + "traineddata"+method+".xcam");

            var result = _faceRecognizer.Predict(userImage.Resize(100, 100,Inter.Cubic));
            return result.Label;
        }
        
    }
}
