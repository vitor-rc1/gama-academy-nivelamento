using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Empresa empresa = new Empresa();

            while(true)
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo ao sistem de genreciamento!!");
                Console.WriteLine("Digite uma opção");
                Console.WriteLine("1 - Cadastrar funcionário");
                Console.WriteLine("2 - Cadastrar o horário de entrada e saída de um funcionário");
                Console.WriteLine("3 - Mostrar relatório de um funcionário");
                Console.WriteLine("0 - Finalizar");
                int opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 0)
                {
                    break;
                } 
                else if (opcao == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Digite o nome do funcionário");
                    string nome = Console.ReadLine();
                    empresa.CadastrarFuncionario(nome);
                    Console.ReadLine();
                }
                else if (opcao == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Digite o ID do funcionário");
                    int id = Convert.ToInt32(Console.ReadLine());
                    
                    Console.WriteLine("Digite a data no formato DD/MM/AAAA");
                    string data = Console.ReadLine();

                    Console.WriteLine("Digite o horario de entrada no formato HH:MM");
                    string entrada = Console.ReadLine();

                    Console.WriteLine("Digite o horario de saída no formato HH:MM");
                    string saida = Console.ReadLine();


                    empresa.RegistrarPonto(id, data, entrada, saida);
                    Console.ReadLine();
                }
                else if (opcao == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Digite o ID do funcionário");
                    int id = Convert.ToInt32(Console.ReadLine());
                    empresa.ImprimirRelatorioFuncionario(id);
                    Console.ReadLine();
                }
            }
        }
    }
}
