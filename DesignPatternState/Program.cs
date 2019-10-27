using System;
using System.Collections.Generic;

namespace DesignPatternState
{
    class Program
    {
        static void Main(string[] args)
        {
            

            
        }

        static List<Veiculo> GetVeiculos()
        {
            Fabricante bmw = new Fabricante("BMW", "Alemanha");
            Fabricante mercedes = new Fabricante("Mercedes-Benz", "Alemanha");
            Fabricante porche = new Fabricante("Porsche", "Alemanha");

            List<Veiculo> veiculos = new List<Veiculo>();

            Veiculo bmw_series1 = new Veiculo
            (
                "BMW Série 1",
                "BMW 120i Sport",
                "2019",
                bmw
            );

            Veiculo bmw_x1 = new Veiculo
            (
                "BMW X5",
                "3.0 xDrive30d Auto",
                "2019",
                bmw
            );

            return veiculos;
        }
        
    }
}
