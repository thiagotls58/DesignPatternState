using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternState
{
    public class Veiculo
    {
        private int codigo;
        private string nome;
        private string modelo;
        private string ano;
        private Fabricante fabricante;
        private IStatusVeiculo status;

        public Veiculo(int codigo, string nome, string modelo, string ano, Fabricante fabricante)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.modelo = modelo;
            this.ano = ano;
            this.fabricante = fabricante;
            this.status = new Disponivel();
        }

        public int GetCodigo()
        {
            return this.codigo;
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

        public IStatusVeiculo GetStatus()
        {
            return this.status;
        }

        public void AlterarStatus(IStatusVeiculo estado)
        {
            this.status = estado;
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine(string.Format("## Alterando Estado ##"));
            //sb.AppendLine(string.Format("{0} para o estado {1}", this.estado, estado));
            //Console.WriteLine(sb.ToString());
        }

        public void Alugar()
        {
            this.status.AlugarVeiculo(this);
        }
        public void Devolver()
        {
            this.status.DevolverVeiculo(this);
        }

        public void Revisar()
        {
            this.status.RevisarVeiculo(this);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Código: {0}", this.codigo));
            sb.AppendLine(string.Format("Nome: {0}", this.nome));
            sb.AppendLine(string.Format("Modelo: {0}", this.modelo));
            sb.AppendLine(string.Format("Ano: {0}", this.ano));
            sb.AppendLine(string.Format("Fabricante: {0}", this.fabricante.GetNome()));
            sb.AppendLine(string.Format("Status: {0}", this.status));
            return sb.ToString();
        }
    }
}
