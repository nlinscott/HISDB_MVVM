
namespace HISDB_Model.People
{
    //honestly, what do you think this does
    public class Doctor : PersonBase
    {
        //display basic data
        public Doctor(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public Doctor(int empId, string expertise, string firstName, string lastName) 
            : base(firstName, lastName)
        {
            _employeeID = empId;
            _area = expertise;
        }

        private int _employeeID;
        private string _area;

        public int EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }


        public string ExpertiseArea
        {
            get { return _area; }
            set { _area = value; }
        }

    }
}
