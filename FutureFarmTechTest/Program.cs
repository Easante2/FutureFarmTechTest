using System;

namespace FutureFarmTechTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create new instance of the farm and define each farm field
            AppleTreeFarm newFarmField1 = new AppleTreeFarm("Cowfield", 300, 400, "Barley", Convert.ToDateTime("18 / 02 / 2020"), 4);
            AppleTreeFarm newFarmField2 = new AppleTreeFarm("Hillside", 600, 400, "Winter Wheat", Convert.ToDateTime("05 / 02 / 2020"), 6);
            AppleTreeFarm newFarmField3 = new AppleTreeFarm("Top", 200, 600, "Barley", Convert.ToDateTime("22 / 12 / 2020"), 4);
            AppleTreeFarm newFarmField4 = new AppleTreeFarm("Big Field", 800, 500, "Sugar Beet", Convert.ToDateTime("09 / 01 / 2020"), 9);
            AppleTreeFarm newFarmField5 = new AppleTreeFarm("Upper River", 200, 200, "Barley", Convert.ToDateTime("18 / 01 / 2020"), 4);
            AppleTreeFarm newFarmField6 = new AppleTreeFarm("Lower River", 500, 100, "Sugar Beet", Convert.ToDateTime("08 / 02 / 2020"), 9);
            AppleTreeFarm newFarmField7 = new AppleTreeFarm("Southside", 400, 400, "Winter Wheat", Convert.ToDateTime("12 / 01 / 2020"), 6);
            AppleTreeFarm farm = new AppleTreeFarm();
            farm.AddFarmFieldToArrayList(newFarmField1, newFarmField2, newFarmField3, newFarmField4, newFarmField5, newFarmField6, newFarmField7);
            farm.DisplayOrderCatalogue();
          
        }
    }
}
