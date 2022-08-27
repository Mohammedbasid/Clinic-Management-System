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
        static SqlConnection cnn;
        static SqlCommand cmd;
        private static SqlConnection GetConnection()
        {
            cnn = new SqlConnection("Data Source =.; Initial Catalog" +
                " = Clinicmanagement; Integrated Security = True");
            cnn.Open();
            return cnn;
        }

        public List<Appointment> showapptsofpatient(int patient_id, DateTime canceldate)
        {
            List<Appointment> appts = new List<Appointment>();
            cnn = GetConnection();
            cmd = new SqlCommand("select * from appointments where patient_id=@patient_id and visitdate=@canceldate", cnn);
            cmd.Parameters.AddWithValue("@patient_id",patient_id);
            cmd.Parameters.AddWithValue("@canceldate", canceldate);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                appts.Add(new Appointment(sdr.GetInt32(0),sdr.GetInt32(1),sdr.GetDateTime(2),sdr.GetString(3), sdr.GetString(4), sdr.GetInt32(5)));
            }
            return appts;
        }

        public int cancelAppt(int apptid,int patient_id)
        {
            cnn = GetConnection();
            cmd = new SqlCommand("update appointments set apptstatus='Available',patient_id=null where apptid=@apptid and patient_id=@patient_id",cnn);
            cmd.Parameters.AddWithValue("@apptid",apptid);
            cmd.Parameters.AddWithValue("@patient_id", patient_id);
            int apptcancelled = cmd.ExecuteNonQuery();
            if (apptcancelled == 1)
            {
                return apptcancelled;
            }
            throw new appointmentidexception("Appointment ID not Valid");
        }

        public bool patientidvalidation(int patient_id)
        {
            cnn = GetConnection();
            cmd = new SqlCommand("select * from patients where patient_id=@patient_id", cnn);
            cmd.Parameters.AddWithValue("@patient_id", patient_id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if(sdr.HasRows)
            {
                return true;
            }
            throw new patientidexception("Enter a valid Patient ID.");

        }

        public bool valdateformat(string inddate)
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
