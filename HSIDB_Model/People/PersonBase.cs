
namespace HISDB_Model.People
{
    public abstract class PersonBase
    {
        public PersonBase() { }
        public PersonBase(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        private string _lastName;
        private string _firstName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }

        }

    }
}
