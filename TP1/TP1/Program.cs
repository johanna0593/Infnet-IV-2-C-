namespace TP1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool executar = true;

            while (executar)
            {
                Console.Clear(); // Limpa a tela a cada ciclo para ficar mais limpo
                Console.WriteLine("Escolha o exercício para executar:");
                Console.WriteLine("1 - Exercício 01 (Desconto)");
                Console.WriteLine("2 - Exercício 02 (Mensagem Multilíngue)");
                Console.WriteLine("3 - Exercício 03 (Cálculo de Área)");
                Console.WriteLine("4 - Exercício 04 (Sensor de Temperatura)");
                Console.WriteLine("5 - Exercício 05 (Notificação de Download)");
                Console.WriteLine("6 - Exercício 06 (Multicast Delegate Logger)");
                Console.WriteLine("7 - Exercício 07 (Robustez de Delegates)");


                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");

                string opcao = Console.ReadLine() ?? "";

                switch (opcao)
                {
                    case "1":
                        var exercicio_01 = new Exercicio_01();
                        exercicio_01.Start();
                        break;

                    case "2":
                        var exercicio_02 = new Exercicio_02();
                        exercicio_02.Start();
                        break;

                    case "3":
                        var exercicio_03 = new Exercicio_03();
                        exercicio_03.Start();
                        break;

                    case "4":
                        var exercicio_04 = new Exercicio_04();
                        exercicio_04.Start();
                        break;

                    case "5":
                        var exercicio_05 = new Exercicio_05();
                        exercicio_05.Start();
                        break;

                    case "6":
                        var exercicio_06 = new Exercicio_06();
                        exercicio_06.Start();
                        break;

                    case "7":
                        var exercicio_07 = new Exercicio_07();
                        exercicio_07.Start();
                        break;

                    case "0":
                        executar = false; // Sai do loop e termina o programa
                        Console.WriteLine("Saindo... Obrigado!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (executar)
                {
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}
