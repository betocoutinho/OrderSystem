using System;
using System.Collections.Generic;
using System.Text;
using OrderSystem.Entities.Enum;
using System.Globalization;

namespace OrderSystem.Entities
{
    class Order
    {
        public DateTime Moment { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(OrderStatus status, Client client)
        {
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            OrderItems.Remove(orderItem);
        }

        public double total()
        {
            double sum = 0;

            foreach (var item in OrderItems)
            {
                sum = sum + item.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ORDER SUMMARY: ");
            sb.Append("Order Moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order Status: " + Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name.ToString() + " ");
            sb.Append($"({Client.BirthDate:dd/MM/yyyy})");
            sb.AppendLine(" - " + Client.Email.ToString());
            sb.AppendLine("Order items: ");

            foreach (var item in OrderItems)
            {
                sb.AppendLine(item.ToString());
            }
            sb.Append("Total Price: $");

            sb.AppendLine(this.total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();



        }
    }
}
