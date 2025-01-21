using System.Globalization;

namespace EmployeeDirectory.Helpers
{
    public class RepositoryException : Exception
    {
        public RepositoryException(): base() { }

        public RepositoryException(string message): base(message) { }

        public RepositoryException(string message, params object[] args) 
            : base(string.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}
