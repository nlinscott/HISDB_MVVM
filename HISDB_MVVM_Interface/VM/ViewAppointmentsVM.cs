using System;
using System.Windows;
using System.Windows.Input;
using HISDB_Model.Schedule;
using HISDB_MVVM_Interface.Commands;

namespace HISDB_MVVM_Interface.VM
{
    class ViewAppointmentsVM : Notifiable
    {

       

        private AppointmentList _apptList;
        public AppointmentList ApptList
        {
            get { return _apptList; }
            set 
            { 
                _apptList = value;
                NotifyPropertyChanged("ApptList");
            }
        }

        #region commands

        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get 
            {
                if (_refreshCommand == null)
                {
                    _refreshCommand = new Command(Refresh);
                }
                return _refreshCommand;
            }
        }

        #endregion

        public ViewAppointmentsVM()
        {

           // try
           // {
                ApptList = new AppointmentList();
          //  }
           // catch (Exception ex)
           // {
           //     MessageBox.Show(ex.Message);
           // }
        }


        public void Refresh(object obj)
        {
            try
            {
                ApptList.Refresh();
                NotifyPropertyChanged("ApptList");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
