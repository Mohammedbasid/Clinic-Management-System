using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;

namespace clinlib
{
    public class SchedAppt:Ischedappt
    {
        static SqlConnection cnn;
        static SqlCommand cmd;
        private static SqlConnection getConnection()
        {
            cnn = new SqlConnection("Data Source =.; Initial Catalog" +
                " = Clinicmanagement; Integrated Security = True");
            cnn.Open();
            return cnn;
        }

        public bool valschedappt(int patient_id,string docspec)
        {
            cnn = getConnection();
            cmd = new SqlCommand("select * from patients where patient_id = @patient_id", cnn);
            cmd.Parameters.AddWithValue("@patient_id",patient_id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if(!sdr.HasRows)
            {
                throw new patientidexception("Patient ID does not exist.");
            }
            List<string> specialization = new List<string>();
            specialization.Add("General");
            specialization.Add("Internal Medicine");
            specialization.Add("Pediatrics");
            specialization.Add("Orthopedics");
            specialization.Add("Ophthalmology");

            if(!specialization.Contains(docspec))
            {
                throw new specializationexception("Specialization does not exist.");
            }
            return true;
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

        public List<Doctor> dispdocspec(string docspec)
        {
            List<Doctor> Doct = new List<Doctor>();

            cnn = getConnection();
            cmd = new SqlCommand("select * from doctors where specialization = @specialization", cnn);
            cmd.Parameters.AddWithValue("@specialization", docspec);
            SqlDataReader sdr = cmd.ExecuteReader();
            int doctor_id;
            string firstName;
            string lastName;
            string sex;
            string specialization;
            TimeSpan visiting_from;
            TimeSpan visiting_to;
            while (sdr.Read())
            {
                doctor_id = sdr.GetInt32(0);
                firstName = sdr.GetString(1);
                lastName = sdr.GetString(2);
                sex = sdr.GetString(3);
                specialization = sdr.GetString(4);
                visiting_from = sdr.GetTimeSpan(5);
                visiting_to = sdr.GetTimeSpan(6);
                Doctor doc = new Doctor(doctor_id, firstName, lastName,
                    sex, specialization, visiting_from, visiting_to);
                Doct.Add(doc);


            }
            return Doct;
        }

        public List<Appointment> dispallslotsfordoc(int doctor_id,DateTime date)
        {
            List<Appointment> appt = new List<Appointment>();
            cnn = getConnection();
            cmd = new SqlCommand("select * from appointments where doctor_id=@doctor_id and apptstatus='Available' and visitdate=@date");
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@doctor_id", doctor_id);
            cmd.Parameters.AddWithValue("@date", date);
            SqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                appt.Add(new Appointment(sdr.GetInt32(0), sdr.GetInt32(1), sdr.GetDateTime(2), sdr.GetString(3), sdr.GetString(4)));
            }
            return appt;
        }

        public int apptbooking (int apptid,int patient_id)
        {
            cnn = getConnection();
            cmd = new SqlCommand("update appointments set apptstatus='Booked',patient_id =@patient_id where apptid=@apptid",cnn);
            cmd.Parameters.AddWithValue("@apptid", apptid);
            cmd.Parameters.AddWithValue("@patient_id", patient_id);
            int apptbooked = cmd.ExecuteNonQuery();
            if(apptbooked == 1)
            {
                return apptbooked;
            }
            throw new appointmentidexception("Appointment ID is not valid! Please enter a valid Appointment ID"); 
        }
    }
}
