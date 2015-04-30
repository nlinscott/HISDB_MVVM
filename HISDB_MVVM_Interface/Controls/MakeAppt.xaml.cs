
using HISDB_MVVM_Interface.Base;
using HISDB_MVVM_Interface.VM;

namespace HISDB_MVVM_Interface.Controls
{
    public partial class MakeAppt : PageBase
    {
        public MakeAppt()
        {
            InitializeComponent();

            PageName = "Make Appointment";

            DataContext = new NewAppointmentVM();
        }
    }
}
