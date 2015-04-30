using System;
using System.ComponentModel;

namespace HISDB_MVVM_Interface.VM
{
    //must be inherited
   public class Notifiable : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

       /// <summary>
        /// update the interface to which the property is bound
       /// </summary>
       /// <param name="propertyName">Pass the string of the property name</param>
        protected void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
