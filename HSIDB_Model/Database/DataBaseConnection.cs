using System.Data.SqlClient;

namespace HISDB_Model.Database
{

    public abstract class DataBaseConnection
    {
        protected void initialize()
        {
            if(_connection == null){
                _connection = new SqlConnection(Connection.ConectionStrings.DriverString);
            }

            if (!_isOpen)
            {
                _connection.Open();
                _isOpen = true;
            }
         
        }

        protected void close()
        {
            _connection.Close();
            _isOpen = false;
        }

        private bool _isOpen = false;
        protected static SqlConnection _connection = null;

        public bool IsOpen
        {
            get { return _isOpen; } 
        }

    }
}
