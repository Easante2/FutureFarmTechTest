using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Collections;
using System.Linq;

namespace FutureFarmTechTest
{
    //Enum of Chemicals and price
    public enum Chemicals{
        Ryezapon = 240,
        Berbelikar = 156,
        Quadranis = 191
    }
    public class AppleTreeFarm
    {

        public AppleTreeFarm() { }

        //second constractor to create new farm field 
        public AppleTreeFarm(string name, int width, int length, string crop, DateTime lastSprayed, int applFrequency)
        {
            Name = name;
            Width = width;
            Length = length;
            Crop = crop;
            LastSprayed = lastSprayed;
            ApplicationFrequency = applFrequency;
            Area = width * length;
        }

        public string Name { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public string Crop { get; set; }
        public DateTime LastSprayed { get; set; }
        public int ApplicationFrequency { get; set; }
        public DateTime NextOrderDate { get; set; }
        public double TotalCost { get; set; }
        //Area of the farm field is width x length. Area unit is squared meters 
        public int Area { get; set; }
        
        public List<AppleTreeFarm> farmField = new List<AppleTreeFarm>();
        
        //Use Date and calendar library to calculate date for next order
        public void CalcWeeksTillNextOrder()
        {
            for (int i =0; i < farmField.Count; i++) { 
                Calendar myCal = CultureInfo.InvariantCulture.Calendar;
                DateTime dt = farmField[i].LastSprayed;
                //Add 6 weeks to last sprayed date
                dt = myCal.AddWeeks(farmField[i].LastSprayed, farmField[i].ApplicationFrequency);
                //minus by one week as order will need to be placed a week before
                dt = myCal.AddWeeks(dt, -1);
                farmField[i].NextOrderDate = dt;
                System.Diagnostics.Debug.WriteLine(dt);
            }
        }

        //Method to calculate the cost per litre for each chemical order
        public void CalcCostPerChemical()
        {
            //Loop through each Enum of chemicals
            //Find price per litre for each chemical for each farm field
            foreach(int pricePerLitre in Enum.GetValues(typeof(Chemicals)))
            {
                for (int i = 0; i < farmField.Count; i++) { 
                    int litre = 0;
                    string chemical = Enum.GetName(typeof(Chemicals), pricePerLitre);
                    System.Diagnostics.Debug.WriteLine(pricePerLitre + " " + chemical);
                
                    //looping through each chemical and calculate cost
                    if(chemical == "Ryezapon" && farmField[i].Crop == "Winter Wheat")
                    {
                        //since 1 litre of a given chemical covers 1 Hectare, litre = hectare
                         litre = ConvertAreaSqMetersToHectare(farmField[i].Area);
                        //find the total cost by multiplying the price of the chemical by the number of litres
                        farmField[i].TotalCost = Math.Round(Convert.ToDouble(pricePerLitre * litre), 2);
                    } 
                    else if(chemical == "Berbelikar" && farmField[i].Crop == "Barley")
                    {
                        litre = ConvertAreaSqMetersToHectare(farmField[i].Area);
                        farmField[i].TotalCost = Math.Round(Convert.ToDouble(pricePerLitre * litre), 2);
                    } 
                    else if(chemical == "Quadranis" && farmField[i].Crop == "Sugar Beet")
                    {
                        litre = ConvertAreaSqMetersToHectare(farmField[i].Area);
                        farmField[i].TotalCost = Math.Round(Convert.ToDouble(pricePerLitre * litre), 2);
                    }
                }
            }
        }

        //1 hectare = 10,000 squared meters
        //the area of the farm field is width x length in squared meters
        //To find the hectare of the farm field = Area / 10000
        public int ConvertAreaSqMetersToHectare(int area)
        {
            int hectareInSqMeters = 10000;
            return area / hectareInSqMeters;
        }

        //Use Params to store multiple objects, from method call, into a temp array and add each object into an arraylist
        //Add each farm field to an arraylist
        public void AddFarmFieldToArrayList(params AppleTreeFarm[] field)
        {
            farmField.Clear();
            foreach(AppleTreeFarm f in field)
            {
                farmField.Add(f);
            }
            
        }

        //Output the order catalogue
        public void DisplayOrderCatalogue()
        {
            //Call the methods to calculate the next order dates and price per chemical 
            CalcWeeksTillNextOrder();
            CalcCostPerChemical();

            Console.WriteLine("Order Catalogue list:");
            for(int i =0; i < farmField.Count; i++) {
                if (farmField[i].Crop == "Winter Wheat") { 
                    Console.WriteLine("Next order date: " + farmField[i].NextOrderDate.ToString("dd/MM/yyyy") +  " , " +
                        "Chemical: " + Enum.GetName(typeof(Chemicals), 240) + " , " + "Price: £" +  farmField[i].TotalCost);
                }
                else if (farmField[i].Crop == "Barley")
                {
                    Console.WriteLine("Next order date: " + farmField[i].NextOrderDate.ToString("dd/MM/yyyy") + " , " +
                        "Chemical: " + Enum.GetName(typeof(Chemicals), 156) + " , " + "Price: £" + farmField[i].TotalCost);
                }  
                else if (farmField[i].Crop == "Sugar Beet")
                {
                    Console.WriteLine("Next order date: " + farmField[i].NextOrderDate.ToString("dd/MM/yyyy") + " , " +
                        "Chemical: " + Enum.GetName(typeof(Chemicals), 191) + " , " + "Price: £" + farmField[i].TotalCost);
                }
            }
        }

    }






}
