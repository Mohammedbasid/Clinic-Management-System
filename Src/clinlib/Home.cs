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
        static SqlConnection cnn;
        static SqlCommand cmd;
        static SqlCommand cmd1;
        public static SqlConnection getConnection()
        {
            cnn = new SqlConnection("Data Source =.; Initial Catalog" + " = Clinicmanagement; Integrated Security = True");
            cnn.Open();
            return cnn;
        }

        public List<Doctor> viewDoctors()
        {
            cnn = getConnection();
            cmd = new SqlCommand("select * from doctors",cnn);
            SqlDataReader sdr = cmd.ExecuteReader();
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

        public List<Patient> viewPatients()
        {
            cnn = getConnection();
            cmd = new SqlCommand("select * from patients", cnn);
            SqlDataReader sdr = cmd.ExecuteReader();
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


        public int addPatient(Patient p,out int patient_id)
        {
            cnn = getConnection();
            cmd = new SqlCommand("insert into patients(firstname,lastname,sex,age,dob) values(@firstname,@lastname,@sex,@age,@dob)");
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@firstname", p.firstname);
            cmd.Parameters.AddWithValue("@lastname", p.lastname);
            cmd.Parameters.AddWithValue("@sex", p.sex);
            cmd.Parameters.AddWithValue("@age", p.age);
            cmd.Parameters.AddWithValue("@dob", p.dob);
            int ListPatient = cmd.ExecuteNonQuery();
            cmd1 = new SqlCommand("select patient_id from patients where firstname=@firstname and lastname=@lastname and sex=@sex and age=@age and dob=@dob",cnn);
            cmd1.Parameters.AddWithValue("@firstname", p.firstname);
            cmd1.Parameters.AddWithValue("@lastname", p.lastname);
            cmd1.Parameters.AddWithValue("@sex", p.sex);
            cmd1.Parameters.AddWithValue("@age", p.age);
            cmd1.Parameters.AddWithValue("@dob", p.dob);
            SqlDataReader sdr =cmd1.ExecuteReader();
            sdr.Read();
            patient_id = sdr.GetInt32(0);
            return ListPatient;
        }
    }
}
