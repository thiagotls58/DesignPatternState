using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternState
{
    public class Alugar : IEstadoVeiculo
    {
        private Alugar instancia;
        public Alugar()
        {
            this.instancia = new Alugar();
        }
        public void DevolverVeiculo(Veiculo veiculo)
        {
            veiculo.AlterarEstado(new Disponivel());
            Console.WriteLine($"O seguinte veículo foi devolvido com sucesso: \n{veiculo}");
        }

        public bool AlugarVeiculo(Veiculo veiculo)
        {
            Console.WriteLine($"Este veículo {veiculo.GetNome()} não está disponível");
            return false;
        }

        public override string ToString()
        {
            return "Alugado";
        }
    }
}
