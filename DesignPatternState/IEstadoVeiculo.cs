namespace DesignPatternState
{
    public interface IEstadoVeiculo
    {
        public void Devolver(Veiculo veiculo);
        public bool Alugar(Veiculo veiculo);
    }
}