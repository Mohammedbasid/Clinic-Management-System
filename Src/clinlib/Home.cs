using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Globalization;
namespace clinlib
{
    public class Home : iHome
    {
        List<Doctor> alldoctors = new List<Doctor>();
        List<Patient> allpatients = new List<Patient>();
        static SqlConnection Connection;
        static SqlCommand Command;
        static SqlCommand Command1;
        public static SqlConnection getConnection()
        {
            Connection = new SqlConnection("Data Source =.; Initial Catalog" + " = Clinicmanagement; Integrated Security = True");
            Connection.Open();
            return Connection;
        }

        /* This Method Lists All Available Doctors */
        public List<Doctor> viewDoctors()
        {
            Connection = getConnection();
            Command = new SqlCommand("select * from doctors", Connection);
            SqlDataReader sdr = Command.ExecuteReader();
            int doctor_id;
            string firstname;
            string lastname;
            string sex;
            string specialization;
            TimeSpan visiting_from;
            TimeSpan visiting_to;
            while (sdr.Read())
            {
                doctor_id = sdr.GetInt32(0);
                firstname = sdr.GetString(1);
                lastname = sdr.GetString(2);
                sex = sdr.GetString(3);
                specialization = sdr.GetString(4);
                visiting_from = sdr.GetTimeSpan(5);
                visiting_to = sdr.GetTimeSpan(6);
                Doctor doc = new Doctor(doctor_id,firstname,lastname,
                    sex,specialization,visiting_from,visiting_to);
                alldoctors.Add(doc);
            }
            return alldoctors;
        }

        /* This Method Lists All Available Patients */
        public List<Patient> viewPatients()
        {
            Connection = getConnection();
            Command = new SqlCommand("select * from patients", Connection);
            SqlDataReader sdr = Command.ExecuteReader();
            int patient_id;
            string firstname;
            string lastname;
            string sex;
            int age;
            DateTime dob;
            while (sdr.Read())
            {
                patient_id = sdr.GetInt32(0);
                firstname = sdr.GetString(1);
                lastname = sdr.GetString(2);
                sex = sdr.GetString(3);
                age = sdr.GetInt32(4);
                dob = sdr.GetDateTime(5);
                Patient pt = new Patient(patient_id, firstname, lastname,
                    sex, age, dob);
                allpatients.Add(pt);
            }
            return allpatients;
        }

        /* This Method is Used to Validate the Patient Details */
        public bool validatePatient(string firstname, string lastname, string sex, int age, string dob)
        {
            string nameregex = "[^A-Za-z0-9]";
            Regex regx = new Regex(nameregex);
            if (regx.IsMatch(firstname) || regx.IsMatch(lastname))
            {
                throw new NameException("Please Enter a valid First Name or Last Name");
            }
            if (age < 0 || age > 120)
            {
                throw new AgeLimitException("Please Enter a valid age between 0-120");
            }

            DateTime date;
            if (!DateTime.TryParseExact(dob, "dd'/'MM'/'yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                throw new indiandateformatexception("Please enter the date in Indian Format (dd/mm/yyyy)");
            }
            return true;
        }

        /* This Method is used to Add New Patients */
        public int addPatient(Patient p,out int patient_id)
        {
            Connection = getConnection();
            Command = new SqlCommand("insert into patients(firstname,lastname,sex,age,dob) values(@firstname,@lastname,@sex,@age,@dob)");
            Command.Connection = Connection;
            Command.Parameters.AddWithValue("@firstname", p.firstname);
            Command.Parameters.AddWithValue("@lastname", p.lastname);
            Command.Parameters.AddWithValue("@sex", p.sex);
            Command.Parameters.AddWithValue("@age", p.age);
            Command.Parameters.AddWithValue("@dob", p.dob);
            int ListPatient = Command.ExecuteNonQuery();
            Command1 = new SqlCommand("select patient_id from patients where firstname=@firstname and lastname=@lastname and sex=@sex and age=@age and dob=@dob", Connection);
            Command1.Parameters.AddWithValue("@firstname", p.firstname);
            Command1.Parameters.AddWithValue("@lastname", p.lastname);
            Command1.Parameters.AddWithValue("@sex", p.sex);
            Command1.Parameters.AddWithValue("@age", p.age);
            Command1.Parameters.AddWithValue("@dob", p.dob);
            SqlDataReader sdr = Command1.ExecuteReader();
            sdr.Read();
            patient_id = sdr.GetInt32(0);
            return ListPatient;
        }
    }
}
