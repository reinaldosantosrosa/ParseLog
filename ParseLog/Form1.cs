using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using parseDados;
using Newtonsoft.Json;
using System.Data;
using System.Collections.Generic;

namespace ParseLog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        DB_Log dbLog = new DB_Log();


        private void MostrarDados()
        {
            
          dataGridView1.DataSource = dbLog.MostrarLog();

            dataGridView1.Refresh();

        }




        public static string DataTable_JSON_JsonNet( DataTable tab)
        {
            try
            { 
                string jsonString = string.Empty;
                jsonString = JsonConvert.SerializeObject(tab, Formatting.Indented);



                return jsonString;


            }
            catch
            {
                throw;
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {

            dbLog.ExcluiLog();
            
            string pattern = @"(InitGame)|(Kill:\s)(\d*\s\d\s\d*:)(\s\w.+|\s\W.+)(killed)(\s\w.+)(by)(\s\w.+|\s\W.+)\n";

          
            Match match;
          

            StreamReader inFile = new StreamReader(@".\Game.log");
            string input = inFile.ReadToEnd();
            inFile.Close();


            Regex reg = new Regex(pattern, RegexOptions.Multiline);
            match = reg.Match(input);

            match = match.NextMatch();
            string game="";
            int i = 0;

            if (match.Success)
            {
                do
                {
                                                   

                    if (match.Groups[1].Value == "Game"  || match.Groups[4].Value == "")
                    {  i++;
                        game = "Game" + "_" + i.ToString();
                     
                    }
                    
                    if (match.Groups[4].Value != "")
                    dbLog.InsereDados(game, match.Groups[4].Value, match.Groups[6].Value, match.Groups[8].Value);

                    match = match.NextMatch();
                    
                }
                while (match.Success);

                MessageBox.Show("fim do processamento");

                MostrarDados();

                button2.Enabled = true;
              
            }
            else
            {
                MessageBox.Show("Erro ao ler arquivo de log");

             
            }


            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                try
                {
                   DataTable dt = dbLog.GetResumo();

                                

                    textBox1.Text = "";
                    

         
                    string resultado = DataTable_JSON_JsonNet(dt);
                    
                    textBox1.Text = resultado;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                }
            }



        }
    }
}
