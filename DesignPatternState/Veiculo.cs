using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternState
{
    public class Veiculo
    {
        private string nome;
        private string modelo;
        private string ano;
        private Fabricante fabricante;
        private IEstadoVeiculo estado;

        public Veiculo(string nome, string modelo, string ano, Fabricante fabricante)
        {
            this.nome = nome;
            this.modelo = modelo;
            this.ano = ano;
            this.fabricante = fabricante;
        }

        public string GetNome()
        {
            return this.nome;
        }

        public string GetModelo()
        {
            return this.modelo;
        }

        public string GetAno()
        {
            return this.ano;
        }

        public Fabricante GetFabricante()
        {
            return this.fabricante;
        }

        public void AlterarEstado(IEstadoVeiculo estado)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("## Alterando Estado ##"));
            sb.AppendLine(string.Format("{0} para o estado {1}", this.estado, estado));
            this.estado = estado;
        }

        public void Devolver()
        {
            this.estado.DevolverVeiculo(this);
        }

        public bool Alugar()
        {
            return this.estado.AlugarVeiculo(this);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Nome: {0}", this.nome));
            sb.AppendLine(string.Format("Modelo: {0}", this.modelo));
            sb.AppendLine(string.Format("Ano: {0}", this.ano));
            sb.AppendLine(string.Format("Fabricante: {0}", this.fabricante));

            return sb.ToString();
        }
    }
}
