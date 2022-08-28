using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using clinlib;
namespace ClinicManagementClient
{
    class Client
    {
        public static void Main()
        {
            Console.WriteLine("****WELCOME TO CLINIC MANAGEMENT SYSTEM****");
            while (true)
            {
                try
                {
                    Console.WriteLine("Login Here");
                    Console.WriteLine();
                    Console.WriteLine("Enter the Username: ");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter the Password: ");
                    string password = Console.ReadLine();
                    Login log = new Login();
                    iHome home = new Home();
                    log.loginUser(username, password);
                    Console.WriteLine("----  Login Successful!!!!!  ----");
                    Console.WriteLine();
                    Console.WriteLine("----Home Page----");
                    Ischedappt isa = new SchedAppt();
                    Icancsched ics = new CancSched();

                    while (true)
                    {
                        Console.WriteLine("Press 1 to List All Doctors");
                        Console.WriteLine("Press 2 to Add a new  Patient");
                        Console.WriteLine("Press 3 to List All Patients");
                        Console.WriteLine("Press 4 to Schedule a Appointment");
                        Console.WriteLine("Press 5 to Cancel a Appointment");
                        Console.WriteLine("Press 6 to Logout");
                        Console.WriteLine("Enter your Choice");
                        int ch = Convert.ToInt32(Console.ReadLine());
                        if (ch == 6)
                        {
                            break;
                        }
                        switch (ch)
                        {
                            case 1:
                                {
                                    List<Doctor> doc = home.viewDoctors();
                                    Console.WriteLine("\t\t\t---Doctor Details---");
                                    foreach (Doctor dr in doc)
                                    {
                                        Console.WriteLine($"Doctor ID : {dr.doctor_id} \nFirstName : {dr.firstname}\n" +
                                            $"LastName : {dr.lastname} \nSex : {dr.sex} \nSpecialization : {dr.specialization}" +
                                            $"\nVisiting from : {dr.visiting_from} \nVisiting to : {dr.visiting_to} \n -------------------------------");
                                    }
                                    break;
                                }   
                            case 2:
                                {
                                    try
                                    {
                                        Console.WriteLine("---Adding Patient Details---");
                                        Console.WriteLine("Enter the Patient First Name: ");
                                        string firstname = Console.ReadLine();
                                        Console.WriteLine("Enter the Patient Last Name: ");
                                        string lastname = Console.ReadLine();
                                        Console.WriteLine("Enter the Patient Sex: ");
                                        string sex = Console.ReadLine();
                                        Console.WriteLine("Enter the age: ");
                                        int age = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter the Date Of Birth: ");
                                        string dob = Console.ReadLine();

                                        home.validatePatient(firstname, lastname, sex, age, dob);
                                        DateTime dateofbirth = Convert.ToDateTime(dob);
                                        Patient pt = new Patient(firstname, lastname, sex, age, dateofbirth);
                                        int id;
                                        int suc = home.addPatient(pt, out id);
                                        if (suc == 1)
                                        {
                                            Console.WriteLine("----- Patient " + firstname + "" + lastname + " was inserted successfully!!!! -----");
                                            Console.WriteLine("The Patient ID is :" + id);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Patient is not Inserted!!");
                                        }
                                    }
                                    catch(Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    List<Patient> pat = home.viewPatients();
                                    Console.WriteLine("\t\t\t---Patient Details---");
                                    foreach (Patient ps in pat)
                                    {
                                        Console.WriteLine($"Patient ID : {ps.patient_id} \nFirstName : {ps.firstname}\n" +
                                            $"LastName : {ps.lastname} \nSex : {ps.sex} \nAge : {ps.age}" +
                                            $"\nDate Of Birth : {ps.dob}\n -------------------------------");
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    try
                                    {
                                        Console.WriteLine("Enter the Patient ID: ");
                                        int patient_id = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Enter the Available Specializations from the following: ");
                                        Console.WriteLine("General \nInternal Medicine \nPediatrics \nOrthopedics \nOphthalmology");
                                        string docspec = Console.ReadLine();
                                        isa.valschedappt(patient_id,docspec);
                                        List<Doctor> doc = isa.dispdocspec(docspec);
                                        Console.WriteLine("---Doctor Specialization Details---");
                                        foreach (Doctor d in doc)
                                        {
                                            Console.WriteLine($"Doctor ID : {d.doctor_id} \nFirstName : {d.firstname}\n" +
                                                $"LastName : {d.lastname} \nSex : {d.sex} \nSpecialization : {d.specialization} " +
                                                $"\nVisiting from : {d.visiting_from} \nVisiting to : {d.visiting_to}");
                                        }
                                        Console.WriteLine("Enter the Date that you want to book the Appointment.");
                                        Console.WriteLine("Book any Date from 26/08/2022 to 10/09/2022 : ");
                                        string ApptDate = Console.ReadLine();
                                        isa.valdatelimit(ApptDate);
                                        isa.valdateformat(ApptDate);
                                        Console.WriteLine("Enter the Doctor ID: ");
                                        int docid = Convert.ToInt32(Console.ReadLine());
                                        DateTime dateofappointment = DateTime.Parse(ApptDate);
                                        List<Appointment> appt = isa.dispallslotsfordoc(docid, dateofappointment);
                                        List<int> apid = new List<int>();
                                        Console.WriteLine("The Available Slots are: ");
                                        foreach (Appointment a in appt)
                                        { 
                                            apid.Add(a.apptid);
                                            Console.WriteLine($"Appointment id : {a.apptid} \nDoctor id : {a.doctor_id}\n" +
                                                $"Date : {a.visitdate} \nAppointment Time : {a.appttime} \nStatus : {a.apptstatus} " +
                                                $"\nPatient id : {a.patient_id} ");
                                        }
                                        Console.WriteLine("Enter the Appointment ID");
                                        int appointmentId = Convert.ToInt32(Console.ReadLine());
                                        isa.valapid(apid, appointmentId);
                                        isa.apptbooking(appointmentId,patient_id);
                                        Console.WriteLine("Appointment successfully booked for Patient ID " + patient_id);
                                        Console.WriteLine("Your Appointment ID is " + appointmentId);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    try
                                    {
                                        Console.WriteLine("----Cancellation----");
                                        Console.WriteLine("Enter the Patient ID");
                                        int patient_id = Convert.ToInt32(Console.ReadLine());
                                        ics.patientidvalidation(patient_id);
                                        Console.WriteLine("The Available Dates for Cancellation are: ");
                                        Console.WriteLine("26/08/2022 to 10/09/2022");
                                        Console.WriteLine("Enter the Date You Want to Cancel Appointment: ");
                                        string visitdate = Console.ReadLine();
                                        isa.valdatelimit(visitdate);
                                        ics.valdateformat(visitdate);
                                        DateTime dt = Convert.ToDateTime(visitdate);
                                        List<Appointment> appt = ics.showapptsofpatient(patient_id, dt);
                                        if (appt.Count == 0)
                                        {
                                            Console.WriteLine("Patient has no Appointments.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("---The Booked Appointments are---");
                                            foreach (Appointment a in appt)
                                            {
                                                Console.WriteLine($"Appointment ID : {a.apptid} \nDoctor ID : {a.doctor_id}\n" +
                                                    $"Date : {a.visitdate} \nAppointment Time : {a.appttime} \nStatus : {a.apptstatus} " +
                                                    $"\nPatient ID : {a.patient_id} ");
                                            }
                                            Console.WriteLine("Enter the Appointment ID Which has to be Cancelled: ");
                                            int apptid = Convert.ToInt32(Console.ReadLine());
                                            ics.cancelAppt(apptid, patient_id);
                                            Console.WriteLine("Appointment of ID " + apptid + " is Cancelled Successfully.");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    break;
                                }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}