using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace OrderSystem.Entities
{
    class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }

        public OrderItem()
        {

        }

        public OrderItem(int quantity, Product product)
        {
            Quantity = quantity;
            Price = product.Price;
            Product = product;
        }

        public double SubTotal()
        {
            return Price * Quantity;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Product.Name.ToString() + "," + " quantity: " 
                + Quantity
                + ", "
                + "Subtotal: $"
                + this.SubTotal().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }


    }
}
