using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_for_Felopater1
{
    public class Functions
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string Constr;
        public Functions()
        {
            Constr = @"Data Source=.;Initial Catalog=Emp1;Integrated Security=True;Pooling=False";
            con = new SqlConnection(Constr);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, con);
            sda.Fill(dt);
            return dt;
        }

    }
}
