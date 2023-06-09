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
                    case "3": 
                        RealizarOperacaoMultiplicacao(historico, out resultado);
                        break;

                    case "S":
                        continuar = false;
                        break; 
                    default:
                        break;
                }

                decimal resultadoFormatado = Math.Round(resultado, 2);

                Console.WriteLine();
                Console.Write("   O resultado da operação é:" + resultadoFormatado);

                Console.ReadLine();
            }
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

            Console.WriteLine("   3  - Para multiplicação.                                                       ");
            Console.WriteLine();
            Console.WriteLine("   S  - Para sair.                                                                ");
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
                    break;
                }
            }
            return opcao;
        }

        public static void RealizarOperacaoMultiplicacao(List<string> historico, out decimal resultadoFormatado)
        {
            decimal primeiroNumero, segundoNumero;

            ObterPrimeiroESegundoNumero(out primeiroNumero, out segundoNumero);

            decimal resultado = primeiroNumero * segundoNumero;
            resultadoFormatado = Math.Round(resultado, 2);
            string resultadoString = primeiroNumero.ToString() + " * " + segundoNumero.ToString() + " = " + resultado;

            historico.Add(resultadoString);
        }
    }
}

