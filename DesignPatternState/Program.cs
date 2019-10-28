using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DesignPatternState
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fabricante> fabricantes = new List<Fabricante>();
            fabricantes.Add(new Fabricante(100, "BMW", "Alemanha"));
            fabricantes.Add(new Fabricante(101, "Mercedes-Benz", "Alemanha"));
            fabricantes.Add(new Fabricante(102, "Porsche", "Alemanha"));

            List<Veiculo> veiculos = new List<Veiculo>();
            veiculos.Add(new Veiculo
            (
                200,
                "BMW Série 1",
                "BMW 120i Sport",
                "2019",
                fabricantes[0]
            ));

            veiculos.Add(new Veiculo
            (
                201,
                "BMW X5",
                "3.0 xDrive30d Auto",
                "2019",
                fabricantes[0]
            ));

            veiculos.Add(new Veiculo
            (
                202,
                "GLA",
                "1.6 Flex Fuel 200 Style DCT",
                "2019",
                fabricantes[1]
            ));

            veiculos.Add(new Veiculo
            (
                203,
                "Classe A",
                "1.3 Turbo 200 Sedan Style DCT",
                "2019",
                fabricantes[1]
            ));

            veiculos.Add(new Veiculo
            (
                204,
                "911 Conversível",
                "3.0 Carrera Cabriolet 18/19",
                "2019",
                fabricantes[2]
            ));

            veiculos.Add(new Veiculo
            (
                205,
                "Cayenne",
                "3.0 E-Hybrid Auto 4WD 19/20",
                "2019",
                fabricantes[2]
            ));

            bool quit = false;
            do
            {
                Console.Clear();
                TelaPrincipal();
                string op = Console.ReadLine();

                switch (op.ToUpper())
                {
                    case "1":
                        TelaAlugarVeiculo(veiculos);
                        try
                        {
                            int cod = Int32.Parse(Console.ReadLine());
                            Veiculo veiculo = veiculos.Where(v =>
                                v.GetCodigo() == cod).FirstOrDefault();

                            if (veiculo == null)
                                throw new Exception();

                            TelaConfirmarAluguel(veiculo);
                            string resp = Console.ReadLine().ToUpper();
                            if (resp == "S")
                            {
                                veiculo.AlterarStatus(new Alugar());
                                Console.WriteLine("ALUGADO COM SUCESSO!!!");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("CÓDIGO INVÁLIDO");
                        }
                        break;

                    case "2":
                        TelaDevolverVeiculo(veiculos);
                        try
                        {
                            int cod = Int32.Parse(Console.ReadLine());
                            Veiculo veiculo = veiculos.Where(v =>
                                v.GetCodigo() == cod).FirstOrDefault();

                            if (veiculo == null)
                                throw new Exception();

                            TelaConfirmarDevolucao(veiculo);
                            string resp = Console.ReadLine().ToUpper();
                            if (resp == "S")
                            {
                                veiculo.AlterarStatus(new Disponivel());
                                Console.WriteLine("DEVOLVIDO COM SUCESSO!!!");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("CÓDIGO INVÁLIDO");
                        }
                        break;

                    case "3":
                        TelaRevisarVeiculo(veiculos);
                        try
                        {
                            int cod = Int32.Parse(Console.ReadLine());
                            Veiculo veiculo = veiculos.Where(v =>
                                v.GetCodigo() == cod).FirstOrDefault();

                            if (veiculo == null)
                                throw new Exception();

                            TelaConfirmarRevisao(veiculo);
                            string resp = Console.ReadLine().ToUpper();
                            if (resp == "S")
                            {
                                veiculo.AlterarStatus(new Revisar());
                                Console.WriteLine("ENVIADO PARA REVISÃO COM SUCESSO!!!");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("CÓDIGO INVÁLIDO");
                        }
                        break;

                    case "4":
                        TelaTodosVeiculos(veiculos);
                        break;

                    case "Q":
                        quit = true;
                        break;

                    default:
                        Console.WriteLine("OPÇÃO INVÁLIDA!");
                        break;
                }

                Console.WriteLine();
                if (!quit)
                    Console.WriteLine("PRECIONE QUALQUER TECLA PARA CONTINUAR...");
                else
                {
                    Console.WriteLine("Bye...");
                    Thread.Sleep(1500);
                }


            } while (!quit);
        }

        static void TelaPrincipal()
        {
            Console.WriteLine("\t\tSISTEMA HMT LOCADORA - MENU PRINCIPAL");
            Console.WriteLine();
            Console.WriteLine("SERVIÇOS");
            Console.WriteLine("[1] - ALUGAR VEÍCULO");
            Console.WriteLine("[2] - DEVOLVER VEÍCULO");
            Console.WriteLine("[3] - REVISAR VEÍCULO");
            Console.WriteLine("[4] - TODOS VEÍCULOS");
            Console.WriteLine("[Q] - SAIR");

            Console.WriteLine();
            Console.Write("ESCOLHA UMA OPÇÃO: ");
        }

        static void TelaAlugarVeiculo(List<Veiculo> veiculos)
        {
            List<Veiculo> veiculos_disponiveis = veiculos.Where(v => 
                v.GetStatus().ToString() == "Disponível")
                .ToList();
            Console.Clear();
            Console.WriteLine("\t\tSISTEMA HMT LOCADORA - ALUGAR VEÍCULO");
            Console.WriteLine("VEÍCULOS DISPONÍVEIS");
            Console.WriteLine();
            foreach (var v in veiculos_disponiveis)
            {
                Console.WriteLine("Código: {0}\nNome: {1}\nFabricante: {2}",
                    v.GetCodigo(), v.GetNome(), v.GetFabricante().GetNome());
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("DIGITE O CÓDIGO DO VEÍCULO");
        }

        static void TelaConfirmarAluguel(Veiculo veiculo)
        {
            Console.Clear();
            Console.WriteLine("\t\tSISTEMA HMT LOCADORA - ALUGAR VEÍCULO");
            Console.WriteLine("DADOS DO VEÍCULO:");
            Console.WriteLine(veiculo);
            Console.WriteLine();

            Console.WriteLine("CONFIRMA ALUGUEL? S/n:");

        }

        static void TelaDevolverVeiculo(List<Veiculo> veiculos)
        {
            List<Veiculo> veiculos_indisponiveis = veiculos.Where(v =>
                v.GetStatus().ToString() == "Alugado" || v.GetStatus().ToString() == "Revisão")
                .ToList();
            Console.Clear();
            Console.WriteLine("\t\tSISTEMA HMT LOCADORA - DEVOLVER VEÍCULO");
            Console.WriteLine("VEÍCULOS INDISPONÍVEIS");
            Console.WriteLine();
            foreach (var v in veiculos_indisponiveis)
            {
                Console.WriteLine("Código: {0}\nNome: {1}\nFabricante: {2}\nStatus: {3}",
                    v.GetCodigo(), v.GetNome(), v.GetFabricante().GetNome(), v.GetStatus());
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("DIGITE O CÓDIGO DO VEÍCULO");
        }

        static void TelaConfirmarDevolucao(Veiculo veiculo)
        {
            Console.Clear();
            Console.WriteLine("\t\tSISTEMA HMT LOCADORA - DEVOLVER VEÍCULO");
            Console.WriteLine("DADOS DO VEÍCULO:");
            Console.WriteLine(veiculo);
            Console.WriteLine();

            Console.WriteLine("CONFIRMA DEVOLUÇÃO? S/n:");

        }

        static void TelaRevisarVeiculo(List<Veiculo> veiculos)
        {
            List<Veiculo> veiculos_disponiveis = veiculos.Where(v =>
                v.GetStatus().ToString() == "Disponível")
                .ToList();
            Console.Clear();
            Console.WriteLine("\t\tSISTEMA HMT LOCADORA - REVISAR VEÍCULO");
            Console.WriteLine("VEÍCULOS DISPONÍVEIS");
            Console.WriteLine();
            foreach (var v in veiculos_disponiveis)
            {
                Console.WriteLine("Código: {0}\nNome: {1}\nFabricante: {2}",
                    v.GetCodigo(), v.GetNome(), v.GetFabricante().GetNome());
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("DIGITE O CÓDIGO DO VEÍCULO");
        }

        static void TelaConfirmarRevisao(Veiculo veiculo)
        {
            Console.Clear();
            Console.WriteLine("\t\tSISTEMA HMT LOCADORA - REVISAR VEÍCULO");
            Console.WriteLine("DADOS DO VEÍCULO:");
            Console.WriteLine(veiculo);
            Console.WriteLine();

            Console.WriteLine("CONFIRMA REVISÃO? S/n:");

        }

        static void TelaTodosVeiculos(List<Veiculo> veiculos)
        {
            Console.Clear();
            Console.WriteLine("\t\tSISTEMA HMT LOCADORA - TODOS VEÍCULOS");
            foreach (var v in veiculos)
            {
                Console.WriteLine(v);
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine();
            }
        }
    }
}
