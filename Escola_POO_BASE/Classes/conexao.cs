using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola_POO_BASE.Classes
{
    internal class Conexao
    {

        //conexão remota 

        #region Variaveis

        //String de Conexão                                   informacoes chumbadas = HardCode
        private static string _strConexao = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=EscolaN22;Integrated Security = True";

        //variaveis de uso (podenm ou não serem usadas ao decorrer do projeto)
        public SqlConnection conexao = new SqlConnection(_strConexao);

        public SqlCommand comando; // Armazena a query (select , uptade)

        public SqlDataAdapter da;// Adptador para alguns componentes 

        public SqlDataReader dr; // Recebe os Select's

        public DataSet ds;// trabalha com multiplas tabelas
         





        #endregion

        #region Construtores

        public Conexao(string query)
        {
            comando = new SqlCommand(query, conexao); // comando montado
            da = new SqlDataAdapter(query , conexao); // caso necessario , esta pronto
            ds = new DataSet(); //se necessarop
        }
        #endregion

        #region Métodos
        //Um Método para abrir a conexão com o banco
        public void AbrirCoxexao()
        {
            if  (conexao.State == ConnectionState.Open)
            {
                conexao.Close();

            }
            conexao.Open();
        }
        // e um outro metoda para fechar a conexao com o banco
        public void FechaConexao()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        #endregion
    }
}
