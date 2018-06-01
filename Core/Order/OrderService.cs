using Core.Common;
using Core.Data;
using Core.MusicInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Shopping
{



    public class OrderService
    {
        private MusicStoreEntities storeDB;
        private CartService cartService=new CartService();

        public OrderService()
        {
            this.storeDB = new MusicStoreEntities();
        }


        /// <summary>
        /// 获取所有的订单
        /// </summary>
        /// <returns></returns>
        public PagingDataSet<Order> GetAll(int pageSize,int pageIndex)
        {
            var allOrders = storeDB.Orders.ToList();

            var orders = allOrders.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            return new PagingDataSet<Order>(orders)
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalRecords = allOrders.Count
            };
        }

        /// <summary>
        /// 根据订单Id获取订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Order Get(int orderId)
        {
            var order = storeDB.Orders.Where(n => n.OrderId == orderId);
            if (order != null && order.Any())
            {
                return order.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取某一专辑的所有订单详情
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        public List<OrderDetail> Gets(int albumId)
        {
            return storeDB.OrderDetails.Where(n => n.AlbumId == albumId).ToList();
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="order"></param>
        public void Create(Order order)
        {
            storeDB.Orders.Add(order);
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 更新订单
        /// </summary>
        /// <param name="order"></param>
        public void Update(Order order)
        {
            storeDB.Entry(order).State = System.Data.Entity.EntityState.Modified;
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="orderId"></param>
        public void Delete(int orderId)
        {
            var order = storeDB.Orders.Find(orderId);
            storeDB.Orders.Remove(order);
            storeDB.SaveChanges();
        }




        /// <summary>
        /// 创建订单完整订单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public void CreateOrder(int orderId, string cartId)
        {
            decimal orderTotal = 0;
            var cartItems = cartService.GetAllItemsInCart(cartId);
            foreach (var item in cartItems)
            {
                var unitPrice = item.Album.Price * item.Count;
                var orderDetail = new OrderDetail
                {
                    AlbumId = item.AlbumId,
                    OrderId = orderId,
                    UnitPrice = unitPrice,
                    Quantity = item.Count
                };
                orderTotal += unitPrice;
                storeDB.OrderDetails.Add(orderDetail);
            }
            storeDB.SaveChanges();
            cartService.EmptyCart(cartId);
        }

       
    }
}
