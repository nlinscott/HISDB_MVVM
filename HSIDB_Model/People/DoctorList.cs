using System.Collections.Generic;
using HISDB_Model.Database;

namespace HISDB_Model.People
{
    public class DoctorList : List<Doctor>
    {
        //this list will be used in a dropdown to select which doctor the patient will see
        //list is made up of doctor objects

        public DoctorList()
        {

            DatabaseOperations connection = DatabaseOperations.getInstance();

            foreach (Doctor doc in connection.getAllDoctors())
            {
                Add(doc);
            }

            connection.Close();
        }
    }
}
