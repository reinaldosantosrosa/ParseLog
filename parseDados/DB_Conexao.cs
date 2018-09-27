using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace parseDados

{
  


    public class DB_Conexao
    {

        private SqlConnection cn = new SqlConnection(@"Data Source=NOTEBOOK\SQLEXPRESS;Initial Catalog=Log;Integrated Security=True");

        public SqlConnection AbrirConexao()
        {
            if ( cn.State == ConnectionState.Closed)
            cn.Open();
           

            return cn;
        }



        public SqlConnection FecharConexao()
        {
            if (cn.State == ConnectionState.Open)
               cn.Close();
            
            return cn;
        }
        
    }




}
