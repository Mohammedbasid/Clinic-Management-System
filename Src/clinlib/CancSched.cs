using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;

namespace clinlib
{
    public  class CancSched : Icancsched
    {
        static SqlConnection Connection;
        static SqlCommand Command;
        private static SqlConnection GetConnection()
        {
            Connection = new SqlConnection("Data Source =.; Initial Catalog" +
                " = Clinicmanagement; Integrated Security = True");
            Connection.Open();
            return Connection;
        }

        /* This Method Shows Appointments of Patients Based on PatientID and Date */
        public List<Appointment> ShowAppointmentsofPatients(int patient_id, DateTime canceldate)
        {
            List<Appointment> appts = new List<Appointment>();
            Connection = GetConnection();
            Command = new SqlCommand("select * from appointments where patient_id=@patient_id and visitdate=@canceldate", Connection);
            Command.Parameters.AddWithValue("@patient_id",patient_id);
            Command.Parameters.AddWithValue("@canceldate", canceldate);
            SqlDataReader sdr = Command.ExecuteReader();
            while (sdr.Read())
            {
                appts.Add(new Appointment(sdr.GetInt32(0),sdr.GetInt32(1),sdr.GetDateTime(2),sdr.GetString(3), sdr.GetString(4), sdr.GetInt32(5)));
            }
            return appts;
        }
         /* This Method Cancels the Appointment */
        public int cancelAppt(int apptid,int patient_id)
        {
            Connection = GetConnection();
            Command = new SqlCommand("update appointments set apptstatus='Available',patient_id=null where apptid=@apptid and patient_id=@patient_id",Connection);
            Command.Parameters.AddWithValue("@apptid",apptid);
            Command.Parameters.AddWithValue("@patient_id", patient_id);
            int apptcancelled = Command.ExecuteNonQuery();
            if (apptcancelled == 1)
            {
                return apptcancelled;
            }
            throw new appointmentidexception("Appointment ID not Valid");
        }
        /*This Method Validates the Patient ID*/
        public bool PatientIdValidation(int patient_id)
        {
            Connection = GetConnection();
            Command = new SqlCommand("select * from patients where patient_id=@patient_id", Connection);
            Command.Parameters.AddWithValue("@patient_id", patient_id);
            SqlDataReader sdr = Command.ExecuteReader();
            if(sdr.HasRows)
            {
                return true;
            }
            throw new patientidexception("Enter a valid Patient ID.");

        }
        /* This Method Checks Whether the date is in Indian Format or not */
        public bool ValDateFormat(string inddate)
        {
            DateTime date;
            if (!DateTime.TryParseExact(inddate, "dd'/'MM'/'yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                throw new indiandateformatexception("Please enter the date in Indian Format (dd/mm/yyyy)");
            }
            return true;
        }
    }
}
