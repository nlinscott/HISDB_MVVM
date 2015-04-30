using System;

namespace HISDB_Model.People
{
    public class PatientSpecs
    {
        public PatientSpecs() { }

        public PatientSpecs(string address1, string sex, string dob, int height,
            int weight, string bloodType, string ssn) 
            : this(address1,null,sex,dob,height,weight,bloodType,ssn)
        {


        }

        public PatientSpecs(string address1, string address2, string sex, string dob, int height,
            int weight, string bloodType, string ssn)
        {
            _address1 = address1;
            _address2 = address2;
            _sex = sex;
            _dob = DateTime.Parse(dob);
            _height_in = height;
            _weight = weight;
            _bloodType = bloodType;
            _ssn = ssn;

        }


        #region private

        private string _address1;
        private string _address2;
        private string _sex;
        private DateTime _dob;
        private int _height_in;
        private int _weight;
        private string _bloodType;
        private string _ssn;

        #endregion

        #region public properties
        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }

        }

        public DateTime DoB
        {
            get { return _dob; }
            set { _dob = value; }

        }

        public int Height
        {
            get { return _height_in; }
            set { _height_in = value; }

        }

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }

        }

        public string BloodType
        {
            get { return _bloodType; }
            set { _bloodType = value; }
        }

        public string SSN
        {
            get { return _ssn; }
            set { _ssn = value; }
        }

        public string Address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }

        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        #endregion
    }
}
