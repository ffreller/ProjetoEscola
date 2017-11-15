using System;
using System.IO;
using System.Text;
namespace ProjetoEscola.Essencial
{
    public class Aluno
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public int idade{get;set;}
        public Endereco end { get; set; }

        public Aluno()
        {
            
        }
        public Aluno(int id, string nome,string email, int idade, Endereco end)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.idade = idade;
            this.end = end;
        }

        public string Salvar()
        {
            string msg = "";
            StreamWriter arquivo = null;
            try
            {
                arquivo = new StreamWriter("Alunos.csv",true);
                arquivo.WriteLine(id+";"+nome+";"+email+";"+idade+";"+end.logradouro+";"+end.numero+";"+end.complemento+";"+end.bairro+";"+end.cidade
                );
                msg = "Dados salvo com sucesso!";
                
            }
            catch(Exception ex)
            {
                msg = "Erro ao tentar salvar o arquivo "+ex.Message;
            }
            finally
            {
                arquivo.Close();
            }
            Console.WriteLine(msg);
            return msg;
            
        }
        
        public Aluno Pesquisar(int id)
        {
            Aluno aln = null;
            Endereco end = null;
            StreamReader arquivo = null;
            try
            {
                aln = new Aluno();
                end = new Endereco();
                arquivo = new StreamReader("Alunos.csv",Encoding.Default);
                string linha = "";
                while((linha=arquivo.ReadLine())!=null)
                {
                    string[] dados=linha.Split(';');
                    if(dados[0]==id.ToString())
                    {
                        aln.id = int.Parse(dados[0]);
                        aln.nome = dados[1];
                        aln.email = dados[2];
                        aln.idade = int.Parse(dados[3]);
                        end.logradouro = dados[4];
                        end.numero = dados[5];
                        end.complemento = dados[6];
                        end.bairro = dados[7];
                        end.cidade = dados[8];
                        aln.end = end;

                        break;
                    }
                }

            }
            catch(Exception ex){
                throw new Exception("Erro ao tentar ler o arquivo "+ ex.Message);
            }
            finally{
                arquivo.Close();
            }
            return aln;
        }

    }
}

