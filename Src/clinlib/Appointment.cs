using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinlib
{
    public class Appointment
    {
        public int apptid { get; set; }
        public int doctor_id { get; set; }
        public DateTime visitdate { get; set; }
        public string appttime { get; set; }
        public string apptstatus { get; set; }
        public int? patient_id { get; set; }

        public Appointment()
        {

        }

        public Appointment(int apptid, int doctor_id, DateTime visitdate, string appttime, string apptstatus)
        {
            this.apptid = apptid;
            this.doctor_id = doctor_id;
            this.visitdate = visitdate;
            this.appttime = appttime;
            this.apptstatus = apptstatus;
            this.patient_id = null;
        }

        public Appointment(int apptid, int doctor_id, DateTime visitdate, string appttime, string apptstatus,int patient_id)
        {
            this.apptid = apptid;
            this.doctor_id = doctor_id;
            this.visitdate = visitdate;
            this.appttime = appttime;
            this.apptstatus = apptstatus;
            this.patient_id = patient_id;
        }
    }
}
