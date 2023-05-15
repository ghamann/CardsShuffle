using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBaralhoCartas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<String[]> baralho = new List<String[]>();
            for (int i = 0; i < 53; i++)
            {
                switch (i)
                {
                    //Copas
                    case 0:
                        baralho.Add(new String[2] { i.ToString(), "Ás de copas" });
                        break;
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        baralho.Add(new String[2] { (i).ToString(), (i + 1).ToString() + " de copas" });
                        break;
                    case 10:
                        baralho.Add(new String[2] { (i).ToString(), "Valete  de copas" });
                        break;
                    case 11:
                        baralho.Add(new String[2] { (i).ToString(), "Dama  de copas" });
                        break;
                    case 12:
                        baralho.Add(new String[2] { (i).ToString(), "Rei  de copas" });
                        break;
                    //Espadas
                    case 13:
                        baralho.Add(new String[2] { i.ToString(), "Ás de espadas" });
                        break;
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                    case 21:
                    case 22:
                        baralho.Add(new String[2] { (i).ToString(), (i - 12).ToString() + " de espadas" });
                        break;
                    case 23:
                        baralho.Add(new String[2] { (i).ToString(), "Valete  de espadas" });
                        break;
                    case 24:
                        baralho.Add(new String[2] { (i).ToString(), "Dama  de espadas" });
                        break;
                    case 25:
                        baralho.Add(new String[2] { (i).ToString(), "Rei  de espadas" });
                        break;
                    //Ouros
                    case 26:
                        baralho.Add(new String[2] { i.ToString(), "Ás de ouros" });
                        break;
                    case 27:
                    case 28:
                    case 29:
                    case 30:
                    case 31:
                    case 32:
                    case 33:
                    case 34:
                    case 35:
                        baralho.Add(new String[2] { (i).ToString(), (i - 25).ToString() + " de ouros" });
                        break;
                    case 36:
                        baralho.Add(new String[2] { (i).ToString(), "Valete  de ouros" });
                        break;
                    case 37:
                        baralho.Add(new String[2] { (i).ToString(), "Dama  de ouros" });
                        break;
                    case 38:
                        baralho.Add(new String[2] { (i).ToString(), "Rei  de ouros" });
                        break;
                    //Paus
                    case 39:
                        baralho.Add(new String[2] { i.ToString(), "Ás de paus" });
                        break;
                    case 40:
                    case 41:
                    case 42:
                    case 43:
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                        baralho.Add(new String[2] { (i).ToString(), (i - 38).ToString() + " de paus" });
                        break;
                    case 49:
                        baralho.Add(new String[2] { (i).ToString(), "Valete  de paus" });
                        break;
                    case 50:
                        baralho.Add(new String[2] { (i).ToString(), "Dama  de paus" });
                        break;
                    case 51:
                        baralho.Add(new String[2] { (i).ToString(), "Rei  de paus" });
                        break;
                    default:
                        break;
                }
            }
            // Console.WriteLine("Cartas do Baralho: ");
            // foreach (String[] carta in baralho)
            // { Console.WriteLine(carta[0] + " " + carta[1]); }

            ////Embaralhar ///////////////////////
            Random random = new Random();
            int numeroAleatorio = 0;
            List<String[]> embaralhado = new List<String[]>();
            String[] aux = new string[2];

            for (int j = baralho.Count; j > 0; j--)
            {
                numeroAleatorio = random.Next(baralho.Count);
                aux = baralho[numeroAleatorio];
                embaralhado.Add(aux);
                baralho.RemoveAt(numeroAleatorio);
            }
            //Console.WriteLine("Cartas embaralhadas: ");
            //foreach (String[] carta in embaralhado)
            //{ Console.WriteLine(carta[0] + " " + carta[1]); }

            ////Distribuir /////////////////////// //////////////////////////Adicionar escolha de jogadores
            int numJogadores;
            int numCartas;
            int cond;
            do
            {
                Console.WriteLine("Digite quantos jogadores: ");
                numJogadores = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite quantas cartas: ");
                numCartas = int.Parse(Console.ReadLine());
                cond = numJogadores * numCartas;
                if (cond >= 52)
                {
                    Console.WriteLine("Digite um número de cartas/jogadores existente!");
                }
            }
            while (cond >= 52);


            List<List<string[]>> maosJogadores = new List<List<string[]>>();


            for (int nj = 0; nj < numJogadores; nj++)
            {
                List<string[]> maoJogador = new List<string[]>();
                for (int n = 0; n < numCartas; n++)
                {
                    string[] bar = new string[2];
                    bar[0] = (embaralhado[nj * numCartas + n][0]);
                    bar[1] = (embaralhado[nj * numCartas + n][1]);
                    maoJogador.Add(bar);
                    //Console.WriteLine("Mão jogador " + nj + " é " + maoJogador[n][0]);
                }

                // Ordenar a mão do jogador

                maoJogador.Sort((x, y) => int.Parse(x[0]).CompareTo(int.Parse(y[0]))); //Sort complicado... teve ajuda do ChaGPT... Estava trocando string/int e indices   
                maosJogadores.Add(maoJogador);
            }

            //imprimir mão ORGANIZADA decodificada

            for (int i = 0; i < numJogadores; i++)
            {
                Console.WriteLine("\n");
                Console.WriteLine($"Cartas do Jogador {i + 1}:");
                List<string[]> listaSecundaria = maosJogadores[i];

                for (int j = 0; j < numCartas; j++)
                {
                    string[] carta = listaSecundaria[j];
                    Console.WriteLine(carta[1]);
                }
            }
            Console.ReadKey();
        }
    }
}
