using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank
{
    public class Donation
    {
        public int ID { get; set; }
        public int DonorID { get; set; }
        public DateTime DateTime { get; set; }
        public int NurseID { get; set; }
        public int FacilityID { get; set; }
        public int BloodBagID { get; set; }
    }
}
