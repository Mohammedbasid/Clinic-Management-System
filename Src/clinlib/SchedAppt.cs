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
        static SqlConnection connection;
        static SqlCommand command;
        private static SqlConnection getConnection()
        {
            connection = new SqlConnection("Data Source =.; Initial Catalog" +
                " = Clinicmanagement; Integrated Security = True");
            connection.Open();
            return connection;
        }

        /* This Method is used to Validate the Appointment Schedule With Correct Specialization */
        public bool ValidateSchedAppointment(int patient_id,string docspec)
        {
            connection = getConnection();
            command = new SqlCommand("select * from patients where patient_id = @patient_id", connection);
            command.Parameters.AddWithValue("@patient_id",patient_id);
            SqlDataReader sdr = command.ExecuteReader();
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
        /* This Method Checks Whether the Entered Date is between the given Dates */
        public bool ValDateLimit(string datelimit)
        {
            List<string> dl = new List<string>();
            dl.Add("26/08/2022");
            dl.Add("27/08/2022");
            dl.Add("28/08/2022");
            dl.Add("29/08/2022");
            dl.Add("30/08/2022");
            dl.Add("31/08/2022");
            dl.Add("01/09/2022");
            dl.Add("02/09/2022");
            dl.Add("03/09/2022");
            dl.Add("04/09/2022");
            dl.Add("05/09/2022");
            dl.Add("06/09/2022");
            dl.Add("07/09/2022");
            dl.Add("08/09/2022");
            dl.Add("09/09/2022");
            dl.Add("10/09/2022");
            foreach (string s in dl)
            {
                if (datelimit.Equals(s))
                {
                    return true;
                }
            }
            throw new DateLimitExceededException("Please Enter the date Between 26/08/2022 to 10/09/2022.");
        }

        /* This Method Displays the Doctor Based on Specialization */
        public List<Doctor> DisplayDoctorSpecialization(string docspec)
        {
            List<Doctor> Doct = new List<Doctor>();

            connection = getConnection();
            command = new SqlCommand("select * from doctors where specialization = @specialization", connection);
            command.Parameters.AddWithValue("@specialization", docspec);
            SqlDataReader sdr = command.ExecuteReader();
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

        /* This Method Checks Whether the given Doctor ID is Correct or Not  */
        public bool ValidateDoctorId(int docter_id, List<int> docid)
        {
            if (docid.Contains(docter_id))
            {
                return true;
            }
            throw new DocIdException("The Given Doctor ID is not Under the Required Specialization or ID does not Exist.");
        }

        /* This Method Shows the Slots Available for the Doctor */
        public List<Appointment> DispAllSlotsforDoctor(int doctor_id,DateTime date)
        {
            List<Appointment> appt = new List<Appointment>();
            connection = getConnection();
            command = new SqlCommand("select * from appointments where doctor_id=@doctor_id and apptstatus='Available' and visitdate=@date");
            command.Connection = connection;
            command.Parameters.AddWithValue("@doctor_id", doctor_id);
            command.Parameters.AddWithValue("@date", date);
            SqlDataReader sdr = command.ExecuteReader();
            if(!sdr.HasRows)
            {
                throw new NoAppointmentAvailableException("No Appointment is Available on this Date for Required Specialization!");
            }
            while(sdr.Read())
            {
                appt.Add(new Appointment(sdr.GetInt32(0), sdr.GetInt32(1), sdr.GetDateTime(2), sdr.GetString(3), sdr.GetString(4)));
            }
            return appt;
        }

        /* This Method is to Book a slot for the Patient */
        public int AppointmentBooking(int apptid,int patient_id)
        {
            connection = getConnection();
            command = new SqlCommand("update appointments set apptstatus='Booked',patient_id =@patient_id where apptid=@apptid", connection);
            command.Parameters.AddWithValue("@apptid", apptid);
            command.Parameters.AddWithValue("@patient_id", patient_id);
            int apptbooked = command.ExecuteNonQuery();
            if(apptbooked == 1)
            {
                return apptbooked;
            }
            throw new appointmentidexception("Appointment ID is not valid! Please enter a valid Appointment ID"); 
        }

        /* This Method Checks Whether the given Appointment ID is Correct or not */
        public bool ValidateAppointmentId(List<int> aid, int apptid)
        {
            bool flag = false;
            foreach (int id in aid)
            {
                if (apptid == id)
                {
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                throw new appointmentidexception("Appointment ID Does not Exist.");
            }
            return true;
        }
    }
}
