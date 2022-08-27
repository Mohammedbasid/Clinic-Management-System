using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinlib
{
    public class Patient
    {
        public int patient_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string sex { get; set; }
        public int age { get; set; }
        public DateTime dob { get; set; }
        public Patient()
        {

        }
        public Patient(int patient_id, string firstname, string lastname, string sex, int age, DateTime dob)
        {
            this.patient_id = patient_id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.sex = sex;
            this.age = age;
            this.dob = dob;
        }
        public Patient(string firstname, string lastname, string sex, int age, DateTime dob)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.sex = sex;
            this.age = age;
            this.dob = dob;
        }
    }
    
}
