using System;
using System.Collections.Generic;

namespace PivotGrid_GettingStarted
{
    public class ProductSales
    {
        public string Product { get; set; }

        public string Date { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public int Quantity { get; set; }

        public double Amount { get; set; }

        public double UnitPrice { get; set; }

        public double TotalPrice { get; set; }

        public static ProductSalesCollection GetSalesData()
        {
            // Geography
            string[] countries = new string[] { "Australia", "Canada", "France", "Germany", "United Kingdom", "United States" };

            string[] states1 = new string[] { "New South Wales", "Queensland", "South Australia", "Tasmania", "Victoria" };

            string[] states2 = new string[] { "Alberta", "British Columbia", "Brunswick", "Manitoba", "Ontario", "Quebec" };

            string[] states3 = new string[] { "Charente Maritime", "Essonne", "Garonne (Haute)", "Gers", };

            string[] states4 = new string[] { "Munich", "Brandenburg", "Hamburg", "Hessen", "Nordrhein Westfalen", "Saarland" };

            string[] states5 = new string[] { "England" };

            string[] states6 = new string[] { "New York", "North Carolina", "Alabama", "California", "Colorado", "New Mexico", "South Carolina" };

            // Time
            string[] dates = new string[] { "FY 2005", "FY 2006", "FY 2007", "FY 2008", "FY 2009" };

            // Products
            string[] products = new string[] { "Bike", "Car" };

            Random r = new Random(123345345);
            int numberOfRecords = 2000;
            ProductSalesCollection listOfProductSales = new ProductSalesCollection();
            for (int i = 0; i < numberOfRecords; i++)
            {
                ProductSales sales = new ProductSales();
                sales.Country = countries[r.Next(1, countries.GetLength(0))];
                sales.Quantity = r.Next(1, 12);

                /// 1 percent discount for 1 quantity
                double discount = (30000 * sales.Quantity) * (double.Parse(sales.Quantity.ToString()) / 100);
                sales.Amount = (30000 * sales.Quantity) - discount;
                sales.TotalPrice = sales.Amount * sales.Quantity;
                sales.UnitPrice = sales.Amount / sales.Quantity;
                sales.Date = dates[r.Next(r.Next(dates.GetLength(0) + 1))];
                sales.Product = products[r.Next(r.Next(products.GetLength(0) + 1))];
                switch (sales.Country)
                {
                    case "Australia":
                        {
                            sales.State = states1[r.Next(states1.GetLength(0))];
                            break;
                        }
                    case "Canada":
                        {
                            sales.State = states2[r.Next(states2.GetLength(0))];
                            break;
                        }
                    case "France":
                        {
                            sales.State = states3[r.Next(states3.GetLength(0))];
                            break;
                        }
                    case "Germany":
                        {
                            sales.State = states4[r.Next(states4.GetLength(0))];
                            break;
                        }
                    case "United Kingdom":
                        {
                            sales.State = states5[r.Next(states5.GetLength(0))];
                            break;
                        }
                    case "United States":
                        {
                            sales.State = states6[r.Next(states6.GetLength(0))];
                            break;
                        }
                }
                listOfProductSales.Add(sales);
            }
            return listOfProductSales;
        }

        //Retrieve the item source from the ProductSalesCollection
        public class ProductSalesCollection : List<ProductSales>
        {
        }
    }
    
}
