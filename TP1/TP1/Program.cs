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
