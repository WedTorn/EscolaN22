using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Escola_POO_BASE.Classes
{
    public class Aluno : Usuario
    {
        #region Propriedades
        public DateTime DtMatricula { get; set; }
        #endregion

        #region Construtores
        public Aluno()
        {
        }

        public Aluno(int id, string nome, DateTime dtNascimento, DateTime dtMatricula, string email, string senha, bool ativo) : base(id, nome, dtNascimento, email, senha, ativo)
        {
            DtMatricula = dtMatricula;
        }
        #endregion

        #region Métodos
        public void Cadastrar(List<Aluno> alunos)
        {
            string query = string.Format($"insert into Aluno values ('{Nome}','{DtNascimento}', '{DtMatricula}', '{Email}','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3' , 1 )");
            query += "; Select scope_identity()";
            Conexao cn = new Conexao(query);

            try
            {
                cn.AbrirCoxexao();
                Id = Convert.ToInt32(cn.comando.ExecuteScalar());
                alunos.Add(this);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.FechaConexao();
            }

        }
        public void Alterar()
        {
            string query = string.Format($"UPDATE Aluno set Nome = '{Nome}', Dtnascimento = '{DtNascimento}', DtMatricula = '{DtMatricula}', email = '{Email}' where =  {Id} ");
            Conexao cn = new Conexao(query);
            

            try 
            {
                cn.AbrirCoxexao();
                cn.comando.ExecuteNonQuery();
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.FechaConexao();
            }
        }
        public void Excluir()
        {
            string query = string.Format($"UPDATE Aluno SET Ativo  = 0 where id = {Id}");
            Conexao cn = new Conexao(query);

            try
            {
                cn.AbrirCoxexao();
                cn.comando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.FechaConexao();
            }

        }

        public static List<Aluno> Buscar(List<Aluno>alunos ,int indexCbbBuscar,string texto)
        {
            switch (indexCbbBuscar)
            {
                case 0:
                    // busca por nome

                    return alunos.Where(a => a.Nome.ToUpper().Normalize(NormalizationForm.FormD).Contains(texto.ToUpper().Normalize(NormalizationForm.FormD))).ToList();

                    //break;quando nao for return , e obrigatorio o uso do break
                case 1:
                    //busca por email

                    return alunos.Where(a => a.Email.Contains(texto)).ToList();
                       
                        //quando nao for return , e obrigatorio o uso do break
                case 2:
                    return alunos.Where(a => a.Id == Convert.ToInt32(texto)).ToList();
                        // buscar por matricula (id)
                       //break;quando nao for return , e obrigatorio o uso do break

                default:
                      // retornar a lista sem filtro
                    return alunos;
                      //break;quando nao for return , e obrigatorio o uso do break
            }


        }

        #endregion
    }
}
