using System;
using System.IO;
using System.Text;

namespace ProjetoEscola.Essencial
{
    public class Professor
    {
        public int id { get; set; } 
        public string nome { get; set; }    
        public string formacao { get; set; }   
        public string telefone { get; set; }
        public Endereco end { get; set; }


        public Professor()
        {
            
        }
        public Professor(int id,string nome, string formacao, string telefone, Endereco end)
        {
            this.id = id;
            this.nome = nome;
            this.formacao = formacao;
            this.telefone = telefone;
            this.end = end;

        }

         public string Salvar()
         {
            string msg = "";
            StreamWriter arquivo = null;
            try
            {
                arquivo = new StreamWriter("Professor.csv",true);
                arquivo.WriteLine(id+";"+nome+";"+formacao+";"+telefone+";"+end.logradouro+";"+end.numero+";"+end.complemento+";"+end.bairro+";"+end.cidade);
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

        public Professor Pesquisar(int id){
            Professor prf = null;
            Endereco end = null;
            StreamReader arquivo = null;
            try
            {
                end = new Endereco();
                prf = new Professor();
                arquivo = new StreamReader("Professor.csv",Encoding.Default);
                string linha = "";
                while((linha=arquivo.ReadLine())!=null)
                {
                    string[] dados=linha.Split(';');
                    if(dados[0]==id.ToString())
                    {
                        prf.id = int.Parse(dados[0]);
                        prf.nome = dados[1];
                        prf.formacao = dados[2];
                        prf.telefone = dados[3];
                        end.logradouro = dados[4];
                        end.numero = dados[5];
                        end.complemento = dados[6];
                        end.bairro = dados[7];
                        end.cidade = dados[8];
                        prf.end = end;
                        break;
                    }
                }

            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao tentar ler o arquivo "+ ex.Message);
            }
            finally
            {
                arquivo.Close();
            }
            return prf;
        }

    }
}
