using System;
using System.IO;
using System.Text;

namespace ProjetoEscola.Essencial
{
    public class Materia
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string cargahoraria { get; set; }

          public string Salvar(){
            string msg = "";
            StreamWriter arquivo = null;
            try
            {
                arquivo = new StreamWriter("Materias.csv",true);
                arquivo.WriteLine(id+";"+titulo+";"+cargahoraria);
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
            return msg;
        }

        public Materia Pesquisar(int id)
        {
            Materia mat = null;
            StreamReader arquivo = null;
            try
            {
                mat = new Materia();
                arquivo = new StreamReader("Materias.csv",Encoding.Default);
                string linha = "";
                while((linha=arquivo.ReadLine())!=null)
                {
                    string[] dados=linha.Split(';');
                    if(dados[0]==id.ToString())
                    {
                        mat.id = int.Parse(dados[0]);
                        mat.titulo = dados[1];
                        mat.cargahoraria = dados[2];
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
            return mat;
        }



    }
}
