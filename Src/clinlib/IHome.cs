using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinlib
{
    public interface iHome
    {
        public List<Doctor> viewDoctors();

        public int addPatient(Patient p,out int patient_id);

        public bool validatePatient(string firstname, string lastname, string sex, int age, string dob);
    }
}
