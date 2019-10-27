namespace DesignPatternState
{
    public interface IEstadoVeiculo
    {
        void DevolverVeiculo(Veiculo veiculo);
        bool AlugarVeiculo(Veiculo veiculo);
    }
}