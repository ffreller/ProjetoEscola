using System;
using ProjetoEscola.Essencial;

namespace Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Endereco end = new Endereco();
            Aluno aln = new Aluno();
            Professor prf = new Professor();
            Materia mat = new Materia();
            Turma tur = new Turma();
            Sala sal = new Sala();

            int opcao = 0;
            while(opcao!=9)
            {
                Console.Clear();
                Console.WriteLine("Programa de Cadastro de Escolar");
                Console.WriteLine("");
                Console.WriteLine("Digite um das opções abaixo para seguir: ");
                Console.WriteLine("1-Cadastro de Alunos\n2-Cadastro de Professores\n3-Cadastro de Materias\n4-Cadastro de Turmas\n9-Sair");
                opcao = int.Parse(Console.ReadLine());
                switch(opcao)
                {
                    case 1:
                    Console.WriteLine("Digite um codigo para o aluno");
                    aln.id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o nome do aluno: ");
                    aln.nome = Console.ReadLine();
                    Console.WriteLine("Digite o email do aluno");
                    aln.email = Console.ReadLine();
                    Console.WriteLine("Digite a idade do aluno");
                    aln.idade = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite a rua onde o aluno mora");
                    end.logradouro = Console.ReadLine();
                    Console.WriteLine("Digite o numero da residencia");
                    end.numero = Console.ReadLine();
                    Console.WriteLine("Digite o complemeto");
                    end.complemento = Console.ReadLine();
                    Console.WriteLine("Digite o bairro");
                    end.bairro = Console.ReadLine();
                    Console.WriteLine("Digite a cidade");
                    end.cidade = Console.ReadLine();
                    aln.end = end;

                    Console.WriteLine(aln.Salvar());
                    break;

                    case 2:
                    Console.WriteLine("Digite um codigo para o professor");
                    prf.id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o nome do professor");
                    prf.nome = Console.ReadLine();
                    Console.WriteLine("Digite a formação do professor");
                    prf.formacao = Console.ReadLine();
                    Console.WriteLine("Digite o telefone");
                    prf.telefone = Console.ReadLine();
                    Console.WriteLine("Digite a rua da residencia");
                    end.logradouro = Console.ReadLine();
                    Console.WriteLine("Digite o numero da residencia");
                    end.numero = Console.ReadLine();
                    Console.WriteLine("Digite o complemeto");
                    end.complemento = Console.ReadLine();
                    Console.WriteLine("Digite o bairro");
                    end.bairro = Console.ReadLine();
                    Console.WriteLine("Digite a cidade");
                    end.cidade = Console.ReadLine();
                    prf.end = end;

                    Console.WriteLine(prf.Salvar());
                    break;


                    case 3:
                    Console.WriteLine("Digite um codigo para a materia");
                    mat.id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o titulo da materia");
                    mat.titulo = Console.ReadLine();
                    Console.WriteLine("Digite a carga horária da materia");
                    mat.cargahoraria = Console.ReadLine();

                    Console.WriteLine(mat.Salvar());
                    break;

                    case 4:
                    Console.WriteLine("Digite um codigo para a turma");
                    tur.id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o titulo da turma");
                    tur.tituloturma = Console.ReadLine();
                    int adicionar = -1;
                    int qtd = 0;
                    Aluno[] novosalunos = new Aluno[20];
                    while(adicionar!=0)
                    {
                        Console.WriteLine("Essa turma comporta 20 alunos. Digite os ids dos alunos que farão parte desta turma. Para sair digite 0(zero)\nFaltão:"+(20-qtd));
                        adicionar = int.Parse(Console.ReadLine());
                        if(aln.Pesquisar(adicionar)==null)
                        {
                            Console.WriteLine("Este aluno não existe");
                            Console.WriteLine("Pressione qualquer tecla para continuar");
                        }
                        else
                        {
                            novosalunos[qtd] = aln.Pesquisar(adicionar);
                            qtd++;
                        }
                    }
                    tur.aln = novosalunos;

                    Console.WriteLine("Digite o id do professor");
                    prf.id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Nome do Professor");
                    prf.nome = Console.ReadLine();

                    tur.prf = prf;

                    qtd = 0;
                    adicionar = -1;
                    Materia[] novamateria = new Materia[5];
                    while(adicionar!=0){
                        Console.WriteLine("Digite no maximo 5 Materias. Digite o ids das materias para adicioná-las. Para sair digite SAIR\nFaltam "+(5-qtd));
                        adicionar = int.Parse(Console.ReadLine());
                        if(mat.Pesquisar(adicionar)==null){
                            Console.WriteLine("Materia não encontrada");
                            Console.WriteLine("Pressione uma tecla para continuar");
                        }
                        else{
                            novamateria[qtd] = mat.Pesquisar(adicionar);
                            qtd++;
                        }
                    }
                
                    tur.mat = novamateria;

                    Console.WriteLine("Digite os dados da sala SEPARADOS POR (;) como segue: Id;Numero da sala; Tipo de sala; Capacidade e tecle ENTER");
                    string[] dadossala = Console.ReadLine().Split(';');
                    sal.id = int.Parse(dadossala[0]);
                    sal.numero = int.Parse(dadossala[1]);
                    sal.tiposala = dadossala[2];
                    sal.capacidade = int.Parse(dadossala[3]);

                    tur.sal = sal;

                    Console.WriteLine(tur.Salvar());
                    break;
                }
            }
        }
    }
}

