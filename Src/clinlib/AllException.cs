using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinlib
{
    public class AllException:ApplicationException
    {
        public AllException(string message) : base(message)
        {

        }
    }

    public class LoginException: ApplicationException
    {
        public LoginException(string message) : base(message)
        {

        }
    }
    public class NameException : ApplicationException
    {
        public NameException(string message) : base(message)
        {

        }
    }

    public class AgeLimitException : ApplicationException
    {
        public AgeLimitException(string message) : base(message)
        {

        }
    }

    public class patientidexception : ApplicationException
    {
        public patientidexception(string message) : base(message)
        {

        }
    }

    public class DocIdException : ApplicationException
    {
        public DocIdException(string message) : base(message)
        {

        }
    }

    public class specializationexception : ApplicationException
    {
        public specializationexception(string message) : base(message)
        {

        }
    }

    public class indiandateformatexception : ApplicationException
    {
        public indiandateformatexception(string message) : base(message)
        {

        }
    }

    public class appointmentidexception : ApplicationException
    {
        public appointmentidexception(string message) : base(message)
        {

        }
    }

    public class NoAppointmentAvailableException : ApplicationException
    {
        public NoAppointmentAvailableException(string message) : base(message)
        {

        }
    }

    public class DateLimitExceededException : ApplicationException
    {
        public DateLimitExceededException(string message) : base(message)
        {

        }
    }
}
