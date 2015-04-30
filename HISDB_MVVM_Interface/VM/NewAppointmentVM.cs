using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using HISDB_Model.Database;
using HISDB_Model.People;
using HISDB_Model.Schedule;
using HISDB_MVVM_Interface.Commands;

namespace HISDB_MVVM_Interface.VM
{
    class NewAppointmentVM
    {
        private List<string> _sexList;
        public List<string> SexList
        {
            get { return _sexList; }
            set { _sexList = value; }
        }

        private List<string> _bloodTypeList;
        public List<string> BloodTypeList
        {
            get { return _bloodTypeList; }
            set { _bloodTypeList = value; }
        }

        public NewAppointmentVM()
        {
            initializeLists();
            _doctorList = new DoctorList();
            _newAppointment = new Appointment();
            
        }

        private ICommand _submit;
        public ICommand Submit
        {
            get
            {
                if (_submit == null)
                {
                    _submit = new Command(SumbitData);
                }
                return _submit;
            }
        }

        private DoctorList _doctorList;
        public DoctorList DocList
        {
            get { return _doctorList; }
            set { _doctorList = value; }

        }



        private Appointment _newAppointment;
        public Appointment NewAppointment
        {
            get { return _newAppointment; }
            set { _newAppointment = value; }
        }

        public void SumbitData(object obj)
        {

            DatabaseOperations dbo = DatabaseOperations.getInstance();
            
            if (dbo.InsertNewAppointment(NewAppointment))
            {
                MessageBox.Show("Appointment created successfully.");
            }
            else
            {
                MessageBox.Show("Error in creating appointment");
            }


           // MessageBox.Show(NewAppointment.PatientInNeed.FirstName);

        }

        private void initializeLists()
        {
            _sexList = new List<string>();
            _sexList.Add("F");
            _sexList.Add("M");

            _bloodTypeList = new List<string>();
            _bloodTypeList.Add("O+");
            _bloodTypeList.Add("O-");
            _bloodTypeList.Add("A+");
            _bloodTypeList.Add("A-");
            _bloodTypeList.Add("B+");
            _bloodTypeList.Add("B-");
            _bloodTypeList.Add("AB+");
            _bloodTypeList.Add("AB-");
        }

        /*
         * 
         * 
         * 
         * Create/insert new Patient with all info needed
         * 
         * assign a Doctor from populated list of all doctors
         * 
         * 
         * 
         * Validate Input?
         * 
         * 
         * 
         * 
         * 
         * 
         */

    }
}
