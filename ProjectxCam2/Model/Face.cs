using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectxCam2.Model
{
    class Face
    {
        public int ID { set; get; }
        public int CameraID { set; get; }
        public string PeopleID { set; get; }
        public byte[] FaceCaptured { get; set; }
        public string FaceTrainedPath { set; get; }
        public DateTime DateCaptured { get; set; }
        public string Comment { set; get; }
        public bool status { set; get; }
        public bool isDeleted { set; get; }
    }
}
