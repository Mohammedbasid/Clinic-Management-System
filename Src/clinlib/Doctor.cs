using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinlib
{
    public class Doctor
    {
       public int doctor_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; } 
        public string sex { get; set; }
        public string specialization { get; set; }
        public TimeSpan visiting_from { get; set; }
        public TimeSpan visiting_to { get; set; }

        public Doctor()
        {

        }
       
        public Doctor(int doctor_id, string firstname, string lastname, string sex, string specialization, TimeSpan visiting_from, TimeSpan visiting_to)
        {
            this.doctor_id = doctor_id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.sex = sex;
            this.specialization = specialization;
            this.visiting_from = visiting_from;
            this.visiting_to = visiting_to;
        }
    }
}
