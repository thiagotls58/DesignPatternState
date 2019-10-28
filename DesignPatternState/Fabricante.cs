using System.Text;

namespace DesignPatternState
{
    public class Fabricante
    {
        private int codigo;
        private string nome;
        private string pais;

        public Fabricante(int codigo, string nome, string pais)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.pais = pais;
        }

        public int GetCodigo()
        {
            return this.codigo;
        }

        public string GetNome()
        {
            return this.nome;
        }

        public string GetPais()
        {
            return this.pais;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Código: {0}", this.codigo));
            sb.AppendLine(string.Format("Nome: {0}", this.nome));
            sb.AppendLine(string.Format("País: {0}", this.pais));

            return sb.ToString();
        }
    }
}