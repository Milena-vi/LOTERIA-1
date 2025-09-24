using System;
using System.Linq;

namespace LoteriaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "🎲 Loteria - Mega Sena 🎲";
            var corPadrao = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            try
            {
                Console.WriteLine("====================================");
                Console.WriteLine("        🎰 LOTERIA - MEGA SENA 🎰");
                Console.WriteLine("====================================\n");

                // Gerar números sorteados (6 números únicos de 1 a 60)
                Random rnd = new Random();
                int[] sorteio = new int[6];
                int sorteados = 0;

                while (sorteados < 6)
                {
                    int num = rnd.Next(1, 61);
                    if (!sorteio.Contains(num))
                    {
                        sorteio[sorteados] = num;
                        sorteados++;
                    }
                }

                // Ler aposta do usuário
                int[] aposta = new int[6];
                Console.WriteLine("Digite seus 6 números da sorte (1 a 60):\n");

                for (int j = 0; j < 6; j++)
                {
                    while (true)
                    {
                        Console.Write($"Número {j + 1}: ");
                        string? entrada = Console.ReadLine();
                        if (int.TryParse(entrada, out int valor) && valor >= 1 && valor <= 60 && !aposta.Contains(valor))
                        {
                            aposta[j] = valor;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("❌ Número inválido ou repetido! Tente novamente.");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                    }
                }

                // Exibir resultado do sorteio
                Console.WriteLine("\n💫 Números sorteados:");
                Console.WriteLine(string.Join(" - ", sorteio.OrderBy(n => n)));

                Console.WriteLine("\n📜 Sua aposta:");
                Console.WriteLine(string.Join(" - ", aposta.OrderBy(n => n)));

                // Calcular acertos
                var acertos = aposta.Intersect(sorteio).OrderBy(n => n).ToArray();
                Console.WriteLine($"\n✅ Você acertou {acertos.Length} número(s)!");

                if (acertos.Length > 0)
                {
                    Console.WriteLine("Números acertados: " + string.Join(", ", acertos));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("😢 Nenhum acerto dessa vez... Tente novamente!");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            finally
            {
                Console.ForegroundColor = corPadrao;
                Console.WriteLine("\nPressione qualquer tecla para sair...");
                Console.ReadKey();
            }
        }
    }
}
