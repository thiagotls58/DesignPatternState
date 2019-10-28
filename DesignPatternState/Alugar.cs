﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternState
{
    public class Alugar : IStatusVeiculo
    {
        public void AlugarVeiculo(Veiculo veiculo)
        {
            Console.WriteLine($"O seguinte veículo já está alugado: \n{veiculo}");
        }
        public void DevolverVeiculo(Veiculo veiculo)
        {
            veiculo.AlterarStatus(new Disponivel());
            Console.WriteLine($"O seguinte veículo foi devolvido com sucesso: \n{veiculo}");
        }

        public void RevisarVeiculo(Veiculo veiculo)
        {
            Console.WriteLine($"O seguinte veículo não está disponível para revisão: \n{veiculo}");
        }

        public override string ToString()
        {
            return "Alugado";
        }
    }
}
