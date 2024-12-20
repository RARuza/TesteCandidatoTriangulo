using System;

namespace TesteCandidatoTriangulo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o triângulo no formato [[6],[3,5],[9,7,1],[4,6,8,4]]:");
            string entrada = Console.ReadLine();

            try
            {
                int somaMaxima = new Triangulo().SomaMaximaTriangulo(entrada);

                Console.WriteLine($"A soma máxima do triângulo é: {somaMaxima}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
