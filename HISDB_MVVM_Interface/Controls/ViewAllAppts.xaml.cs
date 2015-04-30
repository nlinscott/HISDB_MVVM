
using HISDB_MVVM_Interface.Base;
using HISDB_MVVM_Interface.VM;

namespace HISDB_MVVM_Interface.Controls
{
    public partial class ViewAllAppts : PageBase
    {
        public ViewAllAppts()
        {
            InitializeComponent();

            PageName = "View All Appointments";

            DataContext = new ViewAppointmentsVM();
        }
    }
}
