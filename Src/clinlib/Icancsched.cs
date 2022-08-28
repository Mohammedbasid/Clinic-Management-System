using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinlib
{
    public interface Icancsched
    {
        public List<Appointment> ShowAppointmentsofPatients(int patient_id, DateTime canceldate);
        public int cancelAppt(int apptid, int patient_id);
        public bool PatientIdValidation(int patient_id);
        public bool ValDateFormat(string inddate);
    }
}
