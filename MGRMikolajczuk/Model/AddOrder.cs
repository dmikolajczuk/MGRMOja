using System;
using System.Linq;

namespace MGRMikolajczuk.Model
{
    public class AddOrder

    {
        private CaffeDataContext db;

        public AddOrder()
        {
            db = new CaffeDataContext();
        }
        public void Add(OrderClass orderClass, int userId, string paySysName)
        {
            var paySys = db.PaymentSystems.FirstOrDefault(s => s.Payment.Equals(paySysName));
            int maxOrderId = (int)db.Orders.Max(s => s.Id_Order);

            var dateTime = DateTime.Now;
            var date = dateTime.Date;
            Order o = new Order()
            {
                Id_Order = maxOrderId+1,
                Id_User = userId,
                Sum = orderClass._sum,
                Date = date,
                PaymentSystem = paySys.Id_Payment,
                Ended = true,
                Name = orderClass._name
            };

            db.Orders.InsertOnSubmit(o);

            AddOrderItem(orderClass,maxOrderId+1);

            db.SubmitChanges();
        }

        private void AddOrderItem(OrderClass order, int orderId)
        {
            int maxId = (int)db.OrderItems.Max(s => s.Id_OrderItem);
            foreach (var item in order._productList)
            {
                maxId+=1;
                OrderItem orderItem = new OrderItem()
                {
                    Id_Order = orderId,
                    Id_Product = item.product.Id_Product,
                    Id_OrderItem = maxId,
                    Quantity = item.quantity
                };
                db.OrderItems.InsertOnSubmit(orderItem);
            }
        }
    }
}