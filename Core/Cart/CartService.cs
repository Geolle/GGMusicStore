using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Core.Shopping
{
    public class CartService
    {

        private MusicStoreEntities storeDB;

        public CartService()
        {
            this.storeDB = new MusicStoreEntities();
        }
        /// <summary>
        /// 获取或新建一个购物车Id
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session["CartId"] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session["CartId"] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session["CartId"] = tempCartId.ToString();
                }
            }
            return context.Session["CartId"].ToString();
        }

        /// <summary>
        /// 将专辑添加到购物车
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="albumId"></param>
        /// <param name="buyNum"></param>
        public void AddToCart(string cartId, int albumId, int buyNum)
        {
            var cartItem = storeDB.Carts.SingleOrDefault(c => c.CartId == cartId && c.AlbumId == albumId);
            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    AlbumId = albumId,
                    CartId = cartId,
                    Count = buyNum,
                    DateCreated = DateTime.Now
                };
                storeDB.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count = cartItem.Count + buyNum;
            }
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 获取购物车中的所有专辑
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public IEnumerable<Cart> GetAllItemsInCart(string cartId)
        {
            if (!string.IsNullOrEmpty(cartId))
            {
                return storeDB.Carts.Where(n => n.CartId == cartId).ToList();
            }
            return null;
        }

        /// <summary>
        /// 获得购物车中专辑总数
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public int CountCartItems(string cartId)
        {
            var allItemsInCart = GetAllItemsInCart(cartId);
            int totalCount = 0;
            if (allItemsInCart != null && allItemsInCart.Any())
            {
                foreach (var item in allItemsInCart)
                {
                    totalCount += item.Count;
                }
            }
            return totalCount;
        }


        /// <summary>
        /// 从购物车中移除专辑
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="albumId"></param>
        /// <param name="deleteNum"></param>
        public void DeleteCartItem(string cartId, int albumId, int deleteNum)
        {
            var cartItem = storeDB.Carts.SingleOrDefault(c => c.CartId == cartId && c.AlbumId == albumId);
            if (cartItem != null)
            {
                if (cartItem.Count == 1)
                {
                    storeDB.Carts.Remove(cartItem);
                }
                else
                {
                    cartItem.Count -= deleteNum;
                }
                storeDB.SaveChanges();
            }
        }

        /// <summary>
        /// 清空购物车
        /// </summary>
        /// <param name="cartId"></param>
        public void EmptyCart(string cartId)
        {
            var cartItems = storeDB.Carts.Where(cart => cart.CartId == cartId).ToList();
            foreach (var cartItem in cartItems)
            {
                storeDB.Carts.Remove(cartItem);
            }
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 计算购物车中所有物品的总价值
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public decimal GetTotalMoney(string cartId)
        {
            var allItemsInCart = GetAllItemsInCart(cartId);
            decimal totalMoney = 0;
            foreach (var item in allItemsInCart)
            {
                totalMoney = totalMoney + item.Count * item.Album.Price;
            }
            return totalMoney;
        }


        /// <summary>
        /// 将购物车转移到某个用户下
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="cartId"></param>
        public void MigrateCart(string userName, string cartId)
        {
            var allItemsInCart = GetAllItemsInCart(cartId);
            foreach (Cart item in allItemsInCart)
            {
                item.CartId = userName;
            }
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 判断购物车中专辑是否有效
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public bool IsAllAlbumAvailable(string cartId)
        {
            bool isAllAlbumAvailable = true;
            var cartItems = GetAllItemsInCart(cartId);
            if (cartItems != null && cartItems.Any())
            {
                foreach (var item in cartItems)
                {
                    if (item.Album.AlbumNum == 0 || item.Album.AlbumStatus == false)
                    {
                        isAllAlbumAvailable = false;
                        break;
                    }
                }
            }
            return isAllAlbumAvailable;
        }
        
    }
}
