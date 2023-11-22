using System;

namespace Task1
{
    public class Product
	{
		public string Name { get; set; }
		public double Price { get; set; }

		public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }


		public override bool Equals(Object obj)
		{
			if ((obj == null) || !this.GetType().Equals(obj.GetType()))
			{
				return false;
			}
			else
			{
				Product p = (Product)obj;
				return (Name == p.Name) && (Price == p.Price);
			}
		}

		public override int GetHashCode()
		{
			return (Name.GetHashCode() << 2) ^ Price.GetHashCode();
		}
	}
}
