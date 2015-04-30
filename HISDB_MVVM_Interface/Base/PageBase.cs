using System;

namespace HISDB_MVVM_Interface.Base
{
    public class PageBase : System.Windows.Controls.UserControl
    {
        private String _pageName;
        public String PageName
        {
            get
            {
                return _pageName;
            }
            set
            {
                _pageName = value;
            }
        }

    }
}
