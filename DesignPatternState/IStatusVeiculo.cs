namespace DesignPatternState
{
    public interface IStatusVeiculo
    {
        void AlugarVeiculo(Veiculo veiculo);
        void DevolverVeiculo(Veiculo veiculo);
        void RevisarVeiculo(Veiculo veiculo);
    }
}