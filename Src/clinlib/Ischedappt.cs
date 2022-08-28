using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinlib
{
    public interface Ischedappt
    {
        public bool ValidateSchedAppointment(int patient_id, string docspec);
        public bool ValDateFormat(string inddate);
        public bool ValDateLimit(string datelimit);
        public List<Doctor> DisplayDoctorSpecialization(string docspec);
        public bool ValidateDoctorId(int docter_id, List<int> docid);
        public List<Appointment> DispAllSlotsforDoctor(int doctor_id,DateTime day);
        public int AppointmentBooking(int apptid, int patient_id);
        public bool ValidateAppointmentId(List<int> aid, int apptid);
    }
}
