using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace parseDados
{
    public class DB_Log
    {

        DB_Conexao cn = new DB_Conexao();

        SqlDataReader leer;
        DataTable tabela = new DataTable();
        DataTable tbResumo = new DataTable();

        SqlCommand comand = new SqlCommand();


        public DataTable MostrarLog()
        {
            comand.Connection = cn.AbrirConexao();
            comand.CommandText = "MostrarLog";
            comand.CommandType = CommandType.StoredProcedure;


            leer = comand.ExecuteReader();

            
            tabela.Reset();

            tabela.Load(leer);
           
            cn.FecharConexao();

            return tabela;
        }

        public DataTable GetResumo()
        {


            
          
            comand.Connection = cn.AbrirConexao();
            comand.CommandText = "ResumoGame";
            comand.CommandType = CommandType.StoredProcedure;

            
            leer = comand.ExecuteReader();

            tbResumo.Reset();

            tbResumo.Load(leer);
            cn.FecharConexao();

            return tbResumo;
        }


        public void InsereDados(string Jogo, string JogadorKill, string JogadorKilled, string MortePor)
        {
            comand.Connection = cn.AbrirConexao();
            comand.CommandType = CommandType.Text;
            comand.CommandText = "INSERT INTO game (game, PlayerKill, PlayerKilled, MortePor) values ('" + Jogo + "','" + JogadorKill + "','" + JogadorKilled + "','" + MortePor + "')";
            comand.ExecuteNonQuery();
            cn.FecharConexao();
            
        }

        public void ExcluiLog()
        {
            comand.Connection = cn.AbrirConexao();
            comand.CommandText = "ExcluiDadosLog";
            comand.CommandType = CommandType.StoredProcedure;
     

            comand.ExecuteNonQuery();
            cn.FecharConexao();

        }






    }

}
