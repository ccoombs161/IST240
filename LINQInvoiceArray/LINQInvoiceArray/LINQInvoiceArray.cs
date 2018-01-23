using System;
using System.Linq;
using System.Collections.Generic;

namespace LINQInvoiceArray
{
    public class LINQInvoiceArray
    {
        public static void Main(string[] args)
        {
            // Initialize array of invoices
            Invoice[] invoices =
            {
                new Invoice( 83, "Electric sander", 7, 57.98M ),
                new Invoice( 24, "Power saw", 18, 99.99M ),
                new Invoice( 7, "Sledge hammer", 11, 21.5M ),
                new Invoice( 77, "Hammer", 76, 11.99M ),
                new Invoice( 39, "Lawn mower", 3, 79.5M ),
                new Invoice( 68, "Screwdriver", 106, 6.99M ),
                new Invoice( 56, "Jig saw", 21, 11M ),
                new Invoice( 3, "Wrench", 34, 7.5M ) }; // end initialzier list

            // a) use LINQ to sort invoices by description
            var sortedByDescription =
                from item in invoices
                orderby item.PartDescription
                select item;

            // display invoices, sorted by description
            Console.WriteLine("a) Sorted by description:\n");
            foreach (var item in sortedByDescription)
                Console.WriteLine(item);

            // b) use LINQ to sort invoices by price
            var sortedByPrice =
                from item in invoices
                orderby item.Price
                select item;

            // display invoices, sorted by price
            Console.WriteLine("\n\nb) Sorted by price:\n");
            foreach (var item in sortedByPrice)
                Console.WriteLine(item);

            // c) use LINQ to select description and quantity, sort by quantity 
            var descriptionAndQuantity =
                from item in invoices
                orderby item.Quantity
                select new { item.PartDescription, item.Quantity };

            // display description and quantity, sorted by quantity
            Console.WriteLine(
                "\n\nc) Description and quantity, sorted by quantity:\n");
            Console.WriteLine("{0,-25} {1, -5}", "Description", "Quantity");
            foreach (var item in descriptionAndQuantity)
                Console.WriteLine("{0,-25} {1, 5}", item, item.PartDescription,
                    item.Quantity);


            // d) use LINQ to select description and calculated 
            // invoice total; sort by invoice total
            var descriptionAndTotal =
                from item in invoices
                let total = item.Quantity * item.Price
                orderby total
                select new { item.PartDescription, InvoiceTotal = total };

            // display description and calcualted invoice total 
            Console.WriteLine(
                "\n\nd) Description and invoice total, sort by invoice total:\n");
            foreach (var item in descriptionAndTotal)
                Console.WriteLine(item);

            // e) use LINQ to filter previous query results on range of totals
            var totalBetween200And500 =
                from item in descriptionAndTotal
                where item.InvoiceTotal > 200M && item.InvoiceTotal < 500M
                select item;

            // display filtered descriptions and invoice totals 
            Console.WriteLine(string.Format(
                "\n\ne) Invoice totals between {0:C} and {1:C}:\n", 200, 500));
            foreach (var item in totalBetween200And500)
                Console.WriteLine(item);

            Console.ReadLine();
        } // end Main
    } // end class LINQInvoiceArray
}