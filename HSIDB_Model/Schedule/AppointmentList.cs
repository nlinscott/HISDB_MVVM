using System.Collections.ObjectModel;
using HISDB_Model.Database;

namespace HISDB_Model.Schedule
{
    public class AppointmentList : ObservableCollection<Appointment>
    {

        public AppointmentList()
        {
            /*
            Patient patient = new Patient(1, 1, "6303 Asd Dr.", "Nic", "Linscott");

            Doctor doc = new Doctor(1, "Gynocologist", "Cheri", "Stankycunt");

            Add(new Appointment("Got rekt at his job and needs stitches",doc,patient,DateTime.Now, DateTime.Parse("1/15/2016")));
            */
            DatabaseOperations connection = DatabaseOperations.getInstance();

            foreach( Appointment app in connection.getAllAppointments()){
                Add(app);
            }

            connection.Close();
            
        }

        public void Refresh()
        {

            DatabaseOperations connection = DatabaseOperations.getInstance();

            ObservableCollection<Appointment> temp = connection.getAllAppointments();
            
            if (temp.Count > this.Count)
            {
                Clear();
                foreach(Appointment app in temp)
                {
                    Add(app);
                }
            }

            connection.Close();

        }
    }
}
