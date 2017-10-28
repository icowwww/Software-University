using System;
using System.Collections.Generic;

namespace Sales_Report
{
    public class Sales_Report
    {
        public static void Main()
        {
            SortedDictionary<string, decimal> sales = GetSales();
            foreach (var sale in sales)
                Console.WriteLine("{0} -> {1:f2}", sale.Key, sale.Value);            
        }

        private static SortedDictionary<string, decimal> GetSales()
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, decimal> sales = new SortedDictionary<string, decimal>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string town = data[0];
                decimal price = decimal.Parse(data[2]);
                decimal quantity = decimal.Parse(data[3]);
                if (!sales.ContainsKey(town))
                    sales[town] = 0;
                sales[town] += price * quantity;
            }
            return sales;
        }
    }
}
