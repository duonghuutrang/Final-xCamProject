using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectxCam2.Model
{
    class People
    {
        public int ID { set; get; }
        public string PeopleID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Position { set; get; }
        public bool Sex { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public string Comment { set; get; }
        public DateTime BirthDay { set; get; }
        public DateTime DateAdded { set; get; }
        public bool isDeleted { set; get; }
    }
}
