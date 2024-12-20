using System;
using System.Linq;

namespace TesteCandidatoTriangulo
{
    public class Triangulo
    {
        /// <summary>
        ///    6
        ///   3 5
        ///  9 7 1
        /// 4 6 8 4
        /// Um elemento somente pode ser somado com um dos dois elementos da próxima linha. Como o elemento 5 na Linha 2 pode ser somado com 7 e 1, mas não com o 9.
        /// Neste triangulo o total máximo é 6 + 5 + 7 + 8 = 26
        /// 
        /// Seu código deverá receber uma matriz (multidimensional) como entrada. O triângulo acima seria: [[6],[3,5],[9,7,1],[4,6,8,4]]
        /// </summary>
        /// <param name="dadosTriangulo"></param>
        /// <returns>Retorna o resultado do calculo conforme regra acima</returns>
        public int SomaMaximaTriangulo(string dadosTriangulo)
        {
            int[][] triangulo = ConverterStringParaMatriz(dadosTriangulo);
            int somaMaxima = CalcularSomaMaxima(triangulo);

            return somaMaxima;
        }

        private static int[][] ConverterStringParaMatriz(string dadosTriangulo)
        {
            if (string.IsNullOrWhiteSpace(dadosTriangulo))
                throw new ArgumentException("Entrada inválida.");

            try
            {
                return dadosTriangulo
                    .Trim('[', ']')
                    .Split(new[] { "],[" }, StringSplitOptions.None)
                    .Select(linha => linha
                        .Trim('[', ']')
                        .Split(',')
                        .Select(int.Parse)
                        .ToArray()
                    )
                    .ToArray();
            }
            catch
            {
                throw new FormatException("Entrada inválida.");
            }
        }

        private static int CalcularSomaMaxima(int[][] triangulo)
        {
            if (triangulo == null || triangulo.Length == 0)
                throw new ArgumentException("Matriz fora do padrão suportado.");

            int soma = triangulo[0][0];
            int indice = 0;

            for (int linha = 1; linha < triangulo.Length; linha++)
            {
                if (triangulo[linha][indice] > triangulo[linha][indice + 1])
                {
                    soma += triangulo[linha][indice];
                }
                else
                {
                    soma += triangulo[linha][indice + 1];
                    indice++;
                }
            }

            return soma;
        }
    }
}
