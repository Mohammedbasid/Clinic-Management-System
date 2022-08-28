using clinlib;
namespace TestProject1
{
    public class Tests
    {
        ILogin ilogin;
        iHome ihome;
        Ischedappt ischedappt;
        Icancsched icancsched;
        [SetUp]
        public void Setup()
        {
            ilogin = new Login();
            ihome = new Home();
            ischedappt = new SchedAppt();
            icancsched = new CancSched();
        }

        [Test]
        public void TestLogin()
        {
            bool actualValue = ilogin.loginUser("Basid007", "basid@123");
            bool expectedVal = true;
            Assert.AreEqual(expectedVal,actualValue);
        }

        [Test]
        public void viewAllDoctors()
        {
            int actualValue = ihome.viewDoctors().Count;
            int expectedVal = 5;
            Assert.AreEqual(expectedVal,actualValue);
        }

        [Test]
        public void viewAllPatients()
        {
            int actualValue = ihome.viewPatients().Count;
            int expectedVal = 18;
            Assert.AreEqual(expectedVal, actualValue);
        }

        [Test]
        public void AddPatient()
        {
            int p;
            int actualValue = ihome.addPatient(new Patient(564,"Kailash","sridhar","M",21,Convert.ToDateTime("15/07/2001")),out p);
            int expectedValue = 1;
            Assert.AreEqual(expectedValue,actualValue);

        }

        [Test]
        public void ValidatePatient()
        {
            bool actualValue = ihome.validatePatient("Kailash", "sridhar", "M", 21, "15/08/2001");
            bool expectedValue = false;
            Assert.AreEqual(expectedValue, actualValue);

        }

        [Test]
        public void alldocspec()
        {
            int actualValue = ischedappt.dispdocspec("Pediatrics").Count;
            int expectedValue = 1;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void getallslots()
        {
            int actualValue = ischedappt.dispallslotsfordoc(901,DateTime.Parse("30/08/2022")).Count();
            int expectedValue = 1;
            Assert.AreEqual(expectedValue, actualValue);
        }


        [Test]
        public void apptbooking()
        {
            int actualValue = ischedappt.apptbooking(101,564);
            int expectedValue = 1;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void valschedappt()
        {
            bool actualValue = ischedappt.valschedappt(564, "Internal Medicine");
            bool expectedValue = true;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void valformatinddate()
        {
            bool actualValue = ischedappt.valdateformat("29/11/2000");
            bool expectedValue = true;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void showapptofpatient()
        {
            int actualValue = icancsched.showapptsofpatient(564,DateTime.Parse("26/08/2022")).Count();
            int expectedValue = 1;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void cancappt()
        {
            int actualValue = icancsched.cancelAppt(101,564);
            int expectedValue = 1;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void valapid()
        {
            List<int> list = new List<int>() { 101};
            bool actualValue = ischedappt.valapid(list,101);
            bool expectedValue = true;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void valdatelt()
        {
            bool actualValue = ischedappt.valdatelimit("10/09/2022");
            bool expectedValue = true;
            Assert.AreEqual(expectedValue, actualValue);
        }





    }
}