using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternState
{
    public class Disponivel : IStatusVeiculo
    {
        public void AlugarVeiculo(Veiculo veiculo)
        {
            veiculo.AlterarStatus(new Alugar());
            Console.WriteLine($"Veículo alugado com sucesso: \n{veiculo}");
        }

        public void DevolverVeiculo(Veiculo veiculo)
        {
            Console.WriteLine($"O seguinte veículo já está disponível:\n{veiculo}");
        }

        public void RevisarVeiculo(Veiculo veiculo)
        {
            veiculo.AlterarStatus(new Revisar());
            Console.WriteLine($"Veículo em revisão: \n{veiculo}");
        }

        public override string ToString()
        {
            return "Disponível";
        }
    }
}
