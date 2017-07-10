using System;
using System.Collections.Generic;

namespace dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("TSLA", "Tesla");
            stocks.Add("AAPL", "Apple");
            stocks.Add("NKE", "Nike");

            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();

            purchases.Add((ticker: "GM", shares: 150, price: 23.21));
            purchases.Add((ticker: "GM", shares: 32, price: 17.87));
            purchases.Add((ticker: "GM", shares: 80, price: 19.02));

            purchases.Add((ticker: "CAT", shares: 27, price: 42.42));
            purchases.Add((ticker: "CAT", shares: 112, price: 37.94));

            purchases.Add((ticker: "TSLA", shares: 93, price: 307.97));
            purchases.Add((ticker: "TSLA", shares: 49, price: 313.39));
            purchases.Add((ticker: "TSLA", shares: 130, price: 301.93));

            purchases.Add((ticker: "AAPL", shares: 24, price: 145.45));
            purchases.Add((ticker: "AAPL", shares: 30, price: 144.23));
            purchases.Add((ticker: "AAPL", shares: 49, price: 143.21));

            purchases.Add((ticker: "NKE", shares: 392, price: 54.04));
            purchases.Add((ticker: "NKE", shares: 12, price: 56.72));
            purchases.Add((ticker: "NKE", shares: 78, price: 55.55));

            /* 
            Define a new Dictionary to hold the aggregated purchase information.
            - The key should be a string that is the full company name.
            - The value will be the valuation of each stock (price*amount)

            {
                "General Electric": 35900,
                "AAPL": 8445,
                ...
            }
            */

            Dictionary<string, double> aggregates = new Dictionary<string, double>();

            // Iterate over the purchases and 
            foreach ((string ticker, int shares, double price) purchase in purchases)
            {
                // Does the company name key already exist in the report dictionary?
                if(aggregates.ContainsKey(stocks[purchase.ticker])){
                // If it does, update the total valuation
                    aggregates[stocks[purchase.ticker]] += purchase.shares*purchase.price;
                }
                // If not, add the new key and set its value
                else {
                    aggregates.Add(stocks[purchase.ticker], purchase.shares*purchase.price);
                }
            }
            foreach(KeyValuePair<string, double> valuation in aggregates){
                Console.WriteLine($"{valuation.Key}:  ${valuation.Value}");
            }
        }
    }
}
