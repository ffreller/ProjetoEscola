using System;
using System.IO;

namespace ProjetoEscola.Essencial
{
    public class Turma
    {
        public int id { get; set; }
        public string tituloturma { get; set; } 
        public Aluno[] aln{get;set;}
        public Professor prf{get;set;}
        public Materia[] mat{get;set;}
        public Sala sal{get;set;}


        public string Salvar()
        {
            string msg = "";
            StreamWriter arquivo = null;
            try
            {
                arquivo = new StreamWriter("Turma.csv",true);
                foreach(var ma in mat)
                {
                    foreach(var al in aln)
                    {
                        arquivo.WriteLine(
                            id+";"+
                            tituloturma+";"+
                            "Id do Aluno:"+al.id+";"+
                            "Nome do Aluno:"+al.nome+";"+
                            "Id do Profesor: "+ prf.id+";"+
                            "Nome do Professor:"+prf.nome+";"+
                            "Materia: "+ma.titulo+";"+
                            "Sala:"+sal
                        );
                    }
                }
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
    }
}
