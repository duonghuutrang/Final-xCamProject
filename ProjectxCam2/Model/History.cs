using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectxCam2.Model
{
    class History
    {
        public int ID { set; get; }
        public int CameraID { set; get; }
        public int PeopleID { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public DateTime DateCaptured { set; get; }
        public DateTime TimeIn { set; get; }
        public DateTime TimeOut { set; get; }
        public string FaceCaptured { set; get; }
        public string FrameCaptured { set; get; }
        public bool isDeleted { set; get; }
    }
}
