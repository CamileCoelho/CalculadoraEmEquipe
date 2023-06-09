﻿namespace CalculadoraEmEquipe.ConsoleApp
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
                        ExibirHistoricoDeOperecoes(historico);
                        break;
                    case "1":
                        RealizarOperacaoSoma(historico, out resultado);
                        ExibirResultadoDaOperacao(resultado);
                        break;
                    case "2":
                        RealizarOperacaoSubtracao(historico, out resultado);
                        ExibirResultadoDaOperacao(resultado);
                        break;
                    case "3":
                        RealizarOperacaoMultiplicacao(historico, out resultado);
                        ExibirResultadoDaOperacao(resultado);
                        break;
                    case "4":
                        RealizarOperacaoDeDivisão(historico, out resultado);
                        ExibirResultadoDaOperacao(resultado);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ExibirHistoricoDeOperecoes(List<string> historico)
        {
            Console.Clear();

            foreach (string print in historico)
            {
                Console.WriteLine($"   {print}");
            }
            Console.ReadKey();
        }

        private static void RealizarOperacaoDeDivisão(List<string> historico, out decimal resultadoFormatado)
        {
            decimal primeiroNumero, segundoNumero;

            ObterPrimeiroESegundoNumero(out primeiroNumero, out segundoNumero);

            while (segundoNumero == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n   O segundo número não pode ser zero, digite outro valor...");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("   Digite o segundo número: ");

                segundoNumero = Convert.ToDecimal(Console.ReadLine());
            }

            decimal resultado = primeiroNumero / segundoNumero;

            resultadoFormatado = Math.Round(resultado, 2);

            string resultadoString = primeiroNumero.ToString() + " / " + segundoNumero.ToString() + " = " + resultadoFormatado.ToString();

            historico.Add(resultadoString);
        }

        private static void ObterPrimeiroESegundoNumero(out decimal primeiroNumero, out decimal segundoNumero)
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("   Digite o primeiro número: ");
            primeiroNumero = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine();
            Console.Write("   Digite o segundo número: ");
            segundoNumero = Convert.ToDecimal(Console.ReadLine());
        }

        public static void RealizarOperacaoSoma(List<string> historico, out decimal resultadoFormatado)
        {
            decimal primeiroNumero, segundoNumero;

            ObterPrimeiroESegundoNumero(out primeiroNumero, out segundoNumero);

            decimal resultado = primeiroNumero + segundoNumero;

            resultadoFormatado = Math.Round(resultado, 2);
            string resultadoString = primeiroNumero.ToString() + " + " + segundoNumero.ToString() + " = " + resultadoFormatado;

            historico.Add(resultadoString);
        }

        public static void RealizarOperacaoSubtracao(List<string> historico, out decimal resultadoFormatado)
        {
            decimal primeiroNumero, segundoNumero;

            ObterPrimeiroESegundoNumero(out primeiroNumero, out segundoNumero);

            decimal resultado = primeiroNumero - segundoNumero;

            resultadoFormatado = Math.Round(resultado, 2);
            string resultadoString = primeiroNumero.ToString() + " + " + segundoNumero.ToString() + " = " + resultadoFormatado;

            historico.Add(resultadoString);
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

        private static void ExibirResultadoDaOperacao(decimal resultado)
        {
            decimal resultadoFormatado = Math.Round(resultado, 2);

            Console.WriteLine();
            Console.Write("   O resultado da operação é: " + resultadoFormatado);

            Console.ReadLine();
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
            Console.WriteLine("   1  - Para soma.                                                                ");
            Console.WriteLine();
            Console.WriteLine("   2  - Para subtração                                                            ");
            Console.WriteLine();
            Console.WriteLine("   3  - Para multiplicação.                                                       ");
            Console.WriteLine();
            Console.WriteLine("   4  - Para para divisão.                                                        ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("   H  - Para visualizar o histórico de operações.                                 ");
            Console.WriteLine();
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
                    Console.ReadKey();
                    break;
                }
            }
            return opcao;
        }
    }
}

