namespace CalculadoraEmEquipe.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            string resultadoString = "";

            List<String> historico = new();

            while (continuar)
            {
                string opcao = MostrarMenuPrincipal();

                decimal resultado = 0, primeiroNumero, segundoNumero;

                switch (opcao)
                {
                    case "S":
                        continuar = false;
                        break;

                    case "H":
                        Console.Clear();

                        foreach (string print in historico)
                        {
                            Console.WriteLine($"   {print}");
                        }
                        Console.ReadKey();

                        break;

                    case "4":
                        Console.Clear();

                        RealizarOperacaoDeDivisão(out resultadoString, historico,
                            out resultado, out primeiroNumero, out segundoNumero);

                        ExibirResultadoDaOperacao(resultado);

                        break;

                    default:
                        break;
                }
            }
        }

        private static void ExibirResultadoDaOperacao(decimal resultado)
        {
            decimal resultadoFormatado = Math.Round(resultado, 2);

            Console.WriteLine();
            Console.Write("   O resultado da operação é: " + resultadoFormatado);

            Console.ReadLine();
        }

        private static void RealizarOperacaoDeDivisão(out string resultadoString, List<string> historico, out decimal resultado, out decimal primeiroNumero, out decimal segundoNumero)
        {
            ObterPrimeiroESegundoNumero(out primeiroNumero, out segundoNumero);

            while (segundoNumero == 0)
            {
                Console.WriteLine("   O segundo número não pode ser zero, digite outro valor...");

                Console.WriteLine("   Digite o segundo número: ");

                segundoNumero = Convert.ToDecimal(Console.ReadLine());
            }

            resultado = primeiroNumero / segundoNumero;

            decimal resultadoFormatado = Math.Round(resultado, 2);

            resultadoString = primeiroNumero.ToString() + " / " + segundoNumero.ToString() + " = " + resultadoFormatado.ToString();

            historico.Add(resultadoString);
        }

        private static void ObterPrimeiroESegundoNumero(out decimal primeiroNumero, out decimal segundoNumero)
        {
            Console.WriteLine();
            Console.Write("   Digite o primeiro número: ");
            primeiroNumero = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine();
            Console.Write("   Digite o segundo número: ");
            segundoNumero = Convert.ToDecimal(Console.ReadLine());
        }

        public static string MostrarMenuPrincipal()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine("__________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("                           Calculadora Em Equipe!                                 ");
            Console.WriteLine("__________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("   Digite:                                                                        ");
            Console.WriteLine();
            Console.WriteLine("   4  - Para realizar uma operação de divisão.                                    ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("   S  - Para sair.                                                                ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("   H  - Para visualizar o histórico de operações.                                 ");
            Console.WriteLine();
            Console.WriteLine("__________________________________________________________________________________");
            Console.WriteLine();
            Console.Write("   Opção escolhida: ");

            string opcao = Console.ReadLine().ToUpper();

            bool opcaoValida = opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "S" && opcao != "H";

            while (opcaoValida)
            {
                if (opcaoValida)
                {
                    Console.WriteLine("\n   Opção inválida, tente novamente. ");
                    Console.ReadKey();
                    break;
                }
            }
            return opcao;
        }
    }
}