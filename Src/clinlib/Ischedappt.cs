using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinlib
{
    public interface Ischedappt
    {
        public List<Doctor> dispdocspec(string docspec);
        public List<Appointment> dispallslotsfordoc(int doctor_id,DateTime day);
        public int apptbooking(int apptid, int patient_id);
        public bool valschedappt(int patient_id, string docspec);
        public bool valdateformat(string inddate);
        public bool valapid(List<int> aid, int apptid);
        public bool valdatelimit(string datelimit);
    }
}
