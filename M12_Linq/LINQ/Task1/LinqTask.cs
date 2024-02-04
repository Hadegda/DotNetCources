using System;
using System.Collections.Generic;
using System.Linq;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
			return customers.Where(customer => customer.Orders.Sum(order => order.Total) > limit);
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
			return customers.Select(customer => (customer, suppliers.Where(supplier => supplier.Country == customer.Country && supplier.City == customer.City)));
		}

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
			throw new NotImplementedException();
		}

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
			return customers.Where(customer => customer.Orders.Where(order => order.Total > limit).Any());
		}

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
			return customers.Where(customer => customer.Orders.Any()).Select(customer => ( customer, customer.Orders.First().OrderDate ));
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
			return customers.Where(customer => customer.Orders.Any()).Select(customer => (customer, customer.Orders.First().OrderDate))
				.OrderBy(pair => pair.customer.CustomerID)
				.OrderByDescending(pair => pair.customer.Orders.Sum(order => order.Total))
				.OrderBy(pair => pair.OrderDate.Month)
				.OrderBy(pair => pair.OrderDate.Year);
		}

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
			return customers.Where(customer => 
                !customer.PostalCode.All(s => char.IsDigit(s)) || 
                customer.Region == null || 
                !customer.Phone.Any(s => s == '('));
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
			/* example of Linq7result

             category - Beverages
	            UnitsInStock - 39
		            price - 18.0000
		            price - 19.0000
	            UnitsInStock - 17
		            price - 18.0000
		            price - 19.0000
             */

			return products.GroupBy(product => product.Category)
                .Select(res => new Linq7CategoryGroup() { Category = res.Key, UnitsInStockGroup = res.GroupBy(product => product.UnitsInStock)
                .Select(res => new Linq7UnitsInStockGroup() { UnitsInStock = res.Key, Prices = res.OrderBy(p => p.UnitPrice).Select(p => p.UnitPrice)}) });
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            return products.GroupBy(product => 
            {
                if (product.UnitPrice <= cheap)
                {
					return cheap;
				}
				if (product.UnitPrice <= middle)
				{
					return middle;
				}
				return expensive; 
            }).Select(group => (group.Key, group.Select(items => items)));
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            throw new NotImplementedException();
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
			return String.Join("", suppliers.Select(supplier => supplier.Country).Distinct()
                .OrderBy(country => country)
                .OrderBy(country => country.Length));
        }
    }
}