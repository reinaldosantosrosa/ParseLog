using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using parseDados;


namespace parseNegocio
{
   


    class CN_Log
    {
        DB_Log dbLog = new DB_Log();


        DataTable MostrarLog()
        {
            DataTable tabela = new DataTable();

            tabela = dbLog.MostrarLog();


            return tabela;
       }

    }
    
}
