using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternState
{
    public class Disponivel : IEstadoVeiculo
    {
        private Disponivel instancia;

        public Disponivel()
        {
            this.instancia = new Disponivel();
        }

        public Disponivel GetInstancia()
        {
            return this.instancia;
        }
        public bool AlugarVeiculo(Veiculo veiculo)
        {
            Console.WriteLine($"Alugando o veículo: {veiculo}");
            veiculo.AlterarEstado(new Alugar());
            return true;
        }

        public void DevolverVeiculo(Veiculo veiculo)
        {
            Console.WriteLine("O veículo não está alugado");
        }

        public override string ToString()
        {
            return "Disponível";
        }
    }
}
