using System.Collections.Generic;
using HISDB_MVVM_Interface.Base;
using HISDB_MVVM_Interface.Controls;

namespace HISDB_MVVM_Interface.VM
{
    class NavigationVM : Notifiable
    {
        public List<PageBase> SideBar
        {
            get
            {
                
                return _sideBar;
            }
            set
            {
                _sideBar = value;
                NotifyPropertyChanged("SideBar");
            }

        }

        private List<PageBase> _sideBar;

        public NavigationVM()
        {
            _sideBar = new List<PageBase>();


            _sideBar.Add(new MakeAppt());
            _sideBar.Add(new ViewAllAppts());

            NotifyPropertyChanged("SideBar");

        
        }

    }
}
