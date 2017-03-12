using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectxCam2.Model
{
    class Camera
    {              
        public int ID { set; get; }        
        public string CamName { set; get; }
        public string CamAddress { set; get; }
        public string Comment { set; get; }
        public DateTime DateAdded { set; get; }
        public DateTime DateModded { set; get; }
        public int UserAdded { set; get; }
        public int UserModded { set; get; }
        public bool isDeleted { set; get; }
    }
}
