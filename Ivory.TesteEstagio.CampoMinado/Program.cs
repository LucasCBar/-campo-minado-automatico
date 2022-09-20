using Ivory.TesteEstagio.CampoMinado;
using System;

namespace Ivory.TesteEstagio.CampoMinado
{
    class Program
    {
        static void Main(string[] args)
        {
            var campoMinado = new CampoMinado();
            Console.WriteLine("Início do jogo\n=========");
            Console.WriteLine(campoMinado.Tabuleiro);

            // Realize sua codificação a partir deste ponto, boa sorte!

            // Variaveis utilizadas
            var r = '\r';
            var n = '\n';
            var linha = 9;
            var coluna = 9;

            // Matriz para guardar posições das bombas
            int[,] casas_bombas = new int[linha, coluna];
            Array.Clear(casas_bombas, 0, casas_bombas.Length);

            while (campoMinado.JogoStatus == 0)
            {
              var Tabuleiro_campo_minado = campoMinado.Tabuleiro;
              var aux = 0;
              char[] aux_tabuleiro = Tabuleiro_campo_minado.ToCharArray();
              char[] tabuleiro = new char[linha * coluna];
              char[,] campo_minado = new char[linha, coluna];

              foreach (var c in aux_tabuleiro) {
                if (c != r && c != n)
                {
                  tabuleiro[aux] = c;
                  aux++;
                }
              }
                aux = 0;

                for (var x = 0; x < linha; x++) {
                  for (var y = 0; y < coluna; y++) {
                    campo_minado[x, y] = tabuleiro[aux];
                    aux++;
                  }
                }

                // logica para localizar as casas com bombas

                for (var x = 0; x < linha; x++) {
                    for (var y = 0; y < coluna; y++) {
                        if (campo_minado[x, y] == '-' | campo_minado[x, y] == '0') {
                          continue;
                        } else {
                            var numCasa = (int)Char.GetNumericValue(campo_minado[x, y]);
                            var casasLivres = 0;

                            // Analiza quantas casas livres existe em volta de um casa atual

                            if (x - 1 >= 0 && y - 1 >= 0) {
                              if (campo_minado[x - 1, y - 1] == '-') {
                                casasLivres++;
                              }
                            }
                            if (x - 1 >= 0) {
                              if (campo_minado[x - 1, y] == '-') {
                                casasLivres++;
                              }
                            }

                            if (x - 1 >= 0 && y + 1 < coluna) {
                              if (campo_minado[x - 1, y + 1] == '-') {
                                casasLivres++;
                              }
                            }

                            if (y - 1 >= 0) {
                              if (campo_minado[x, y - 1] == '-') {
                                casasLivres++;
                              }
                            }

                            if (y + 1 < coluna) {
                              if (campo_minado[x, y + 1] == '-') {
                                casasLivres++;
                              }
                            }

                            if (x + 1 < linha && y - 1 >= 0) {
                              if (campo_minado[x + 1, y - 1] == '-') {
                                casasLivres++;
                              }
                            }

                            if (x + 1 < linha) {
                              if (campo_minado[x + 1, y] == '-') {
                                casasLivres++;
                              }
                            }

                            if (x + 1 < linha && y + 1 < coluna) {
                              if (campo_minado[x + 1, y + 1] == '-') {
                                casasLivres++;
                              }
                            }

                            if (numCasa == casasLivres) {
                                if (x - 1 >= 0 && y - 1 >= 0) {
                                  if (campo_minado[x - 1, y - 1] == '-') {
                                    casas_bombas[x - 1, y - 1] = 1;
                                  }
                                }

                                if (x - 1 >= 0) {
                                  if (campo_minado[x - 1, y] == '-') {
                                    casas_bombas[x - 1, y] = 1;
                                  }
                                }

                                if (x - 1 >= 0 && y + 1 < coluna) {
                                  if (campo_minado[x - 1, y + 1] == '-') {
                                    casas_bombas[x - 1, y + 1] = 1;
                                  }
                                }

                                if (y - 1 >= 0) {
                                  if (campo_minado[x, y - 1] == '-') {
                                    casas_bombas[x, y - 1] = 1;
                                  }
                                }

                                if (y + 1 < coluna) {
                                  if (campo_minado[x, y + 1] == '-') {
                                    casas_bombas[x, y + 1] = 1;
                                  }
                                }

                                if (x + 1 < coluna && y - 1 >= 0) {
                                  if (campo_minado[x + 1, y - 1] == '-') {
                                    casas_bombas[x + 1, y - 1] = 1;
                                  }
                                }

                                if (x + 1 < linha) {
                                  if (campo_minado[x + 1, y] == '-') {
                                    casas_bombas[x + 1, y] = 1;
                                  }
                                }

                                if (x + 1 < linha && y + 1 < coluna) {
                                  if (campo_minado[x + 1, y + 1] == '-') {
                                    casas_bombas[x + 1, y + 1] = 1;
                                  }
                                }
                            }
                        }
                    }
                }

                //Abre as casa sem bombas
                for (var x = 0; x < linha; x++) {
                    for (var y = 0; y < coluna; y++) {
                        if (campo_minado[x, y] == '-' | campo_minado[x, y] == '0') {
                          continue;
                        } else {
                            var numCasa = (int)Char.GetNumericValue(campo_minado[x, y]);
                            var numMinas = 0;

                            if (x - 1 >= 0 && y - 1 >= 0) {
                              if (casas_bombas[x - 1, y - 1] == 1) {
                                numMinas++;
                              }
                            }

                            if (x - 1 >= 0) {
                              if (casas_bombas[x - 1, y] == 1) {
                                numMinas++;
                              }
                            }

                            if (x - 1 >= 0 && y + 1 < coluna) {
                              if (casas_bombas[x - 1, y + 1] == 1) {
                                numMinas++;
                              }
                            }

                            if (y - 1 >= 0) {
                              if (casas_bombas[x, y - 1] == 1) {
                                numMinas++;
                              }
                            }

                            if (y + 1 < coluna) {
                              if (casas_bombas[x, y + 1] == 1) {
                                numMinas++;
                              }
                            }

                            if (x + 1 < linha && y - 1 >= 0) {
                              if (casas_bombas[x + 1, y - 1] == 1) {
                                numMinas++;
                              }
                            }

                            if (x + 1 < linha) {
                              if (casas_bombas[x + 1, y] == 1) {
                                numMinas++;
                              }
                            }

                            if (x + 1 < linha && y + 1 < coluna) {
                              if (casas_bombas[x + 1, y + 1] == 1) {
                                numMinas++;
                              }
                            }

                            if (numMinas == numCasa) {
                              if (x - 1 >= 0 && y - 1 >= 0) {
                                if (campo_minado[x - 1, y - 1] == '-' && casas_bombas[x - 1, y - 1] != 1) {
                                  campoMinado.Abrir(x, y);
                                }
                              }

                              if (x - 1 >= 0) {
                                if (campo_minado[x - 1, y] == '-' && casas_bombas[x - 1, y] != 1) {
                                  campoMinado.Abrir(x, y + 1);
                                }
                              }

                              if (x - 1 >= 0 && y + 1 < coluna) {
                                if (campo_minado[x - 1, y + 1] == '-' && casas_bombas[x - 1, y + 1] != 1) {
                                  campoMinado.Abrir(x, y + 2);
                                }
                              }

                              if (y - 1 >= 0) {
                                if (campo_minado[x, y - 1] == '-' && casas_bombas[x, y - 1] != 1) {
                                  campoMinado.Abrir(x + 1, y);
                                }
                              }

                              if (y + 1 < coluna) {
                                if (campo_minado[x, y + 1] == '-' && casas_bombas[x, y + 1] != 1) {
                                  campoMinado.Abrir(x + 1, y + 2);
                                }
                              }

                              if (x + 1 < linha && y - 1 >= 0) {
                                if (campo_minado[x + 1, y - 1] == '-' && casas_bombas[x + 1, y - 1] != 1) {
                                  campoMinado.Abrir(x + 2, y);
                                }
                              }

                              if (x + 1 < linha) {
                                if (campo_minado[x + 1, y] == '-' && casas_bombas[x + 1, y] != 1) {
                                  campoMinado.Abrir(x + 2, y + 1);
                                }
                              }

                              if (x + 1 < linha && y + 1 < coluna) {
                                if (campo_minado[x + 1, y + 1] == '-' && casas_bombas[x + 1, y + 1] != 1) {
                                  campoMinado.Abrir(x + 2, y + 2);
                                }
                              }
                          }
                        }
                    }
                }

                Console.WriteLine("=========");
                Console.WriteLine(campoMinado.Tabuleiro);

                if (campoMinado.JogoStatus == 1) {
                    Console.WriteLine("=========");
                    Console.WriteLine("Vitória!");
                } else if (campoMinado.JogoStatus == 2) {
                    Console.WriteLine("=========");
                    Console.WriteLine("Game Over, você selecionou uma casa com bomba!");
                }
            }
        }
    }
}