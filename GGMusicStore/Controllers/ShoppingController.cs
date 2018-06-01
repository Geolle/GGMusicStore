using Core.MusicInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Shopping;

namespace GGMusicStore
{
    public class ShoppingController : Controller
    {
        private AlbumService albumService;
        private GenreService genreService;
        private ArtistService artistService;
        private CartService cartService;
        private OrderService orderService;

        public ShoppingController(AlbumService albumService, GenreService genreService, ArtistService artistService, CartService cartService, OrderService orderService)
        {
            this.albumService = albumService;
            this.genreService = genreService;
            this.artistService = artistService;
            this.cartService = cartService;
            this.orderService = orderService;

        }

        /// <summary>
        /// 导航栏购物车状态
        /// </summary>
        /// <returns></returns>
        public PartialViewResult _CartLayout()
        {
            ViewData["CartCount"] = cartService.CountCartItems(cartService.GetCartId(this.HttpContext));
            return PartialView();
        }

        /// <summary>
        /// 购物车管理
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageCart()
        {
            return View();
        }

        /// <summary>
        /// 购物车列表
        /// </summary>
        /// <returns></returns>
        public PartialViewResult _ListCartItems()
        {
            var cartId = cartService.GetCartId(this.HttpContext);
            var myCart = cartService.GetAllItemsInCart(cartId).ToList();
            ViewData["TotalMoney"] = cartService.GetTotalMoney(cartId);
            return PartialView(myCart);
        }

        /// <summary>
        /// 添加到购物车
        /// </summary>
        /// <param name="toCartNum"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddToCart(int albumId, int toCartNum)
        {

            if (albumId > 0 && toCartNum > 0)
            {
                var cartId = cartService.GetCartId(this.HttpContext);
                cartService.AddToCart(cartId, albumId, toCartNum);
                return Json(new { MessageType = 1, MessageContent = "添加成功" });

            }

            return Json(new { MessageType = 0, MessageContent = "添加失败" });
        }

        /// <summary>
        /// 从购物车中移除
        /// </summary>
        /// <param name="toCartNum"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteCartItem(int albumId, int deleteNum)
        {

            if (albumId > 0 && deleteNum > 0)
            {
                var cartId = cartService.GetCartId(this.HttpContext);
                cartService.DeleteCartItem(cartId, albumId, deleteNum);
                return Json(new { MessageType = 1, MessageContent = "删除成功" });

            }
            return Json(new { MessageType = 0, MessageContent = "添加失败" });
        }

        /// <summary>
        /// 清空购物车
        /// </summary>
        /// <param name="toCartNum"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EmptyCart()
        {
            var cartId = cartService.GetCartId(this.HttpContext);
            cartService.EmptyCart(cartId);
            return Json(new { MessageType = 1, MessageContent = "成功清空购物车" });
        }

        /// <summary>
        /// 将购物车转移到某个用户下
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult MigrateCart()
        {
            if (!string.IsNullOrEmpty(this.HttpContext.Session["CartId"].ToString()))
            {
                cartService.MigrateCart(this.HttpContext.User.Identity.Name, cartService.GetCartId(this.HttpContext));
                HttpContext.Session["CartId"] = this.HttpContext.User.Identity.Name;
                return Json(new { MessageType = 1, MessageContent = "成功载入购物车" });
            }
            else
            {
                return Json(new { MessageType = 2, MessageContent = "赶快去挑选喜爱的专辑吧" });
            }
        }

        /// <summary>
        /// 判断专辑是否售罄
        /// </summary>
        /// <returns></returns>
        public JsonResult IsAllAlbumAvailable()
        {
            var IsAllAlbumAvailable = cartService.IsAllAlbumAvailable(cartService.GetCartId(this.HttpContext));
            if (IsAllAlbumAvailable)
            {
                return Json(new { MessageType = 1, MessageContent = "所有的专辑均在售卖中" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { MessageType = 0, MessageContent = "某些专辑已售罄" }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 编辑订单 GET
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult _EditOrder()
        {
            var order = new Order();
            order.UserName = this.HttpContext.User.Identity.Name;
            order.Total = cartService.GetTotalMoney(cartService.GetCartId(this.HttpContext));
            return View(order);
        }

        /// <summary>
        /// 编辑订单 POST
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public JsonResult _EditOrder(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                Order order = new Order();
                TryUpdateModel<Order>(order, formCollection);
                var ispayed = formCollection.Get("isPayed");
                if (ispayed == "IsPayed")
                {
                    order.OrderDate = DateTime.Now;
                    //order.Total=
                    orderService.Create(order);
                    orderService.CreateOrder(order.OrderId, cartService.GetCartId(this.HttpContext));
                    return Json(new { MessageType = 1, MessageContent = "成功生成订单!" });
                }
                return Json(new { MessageType = 0, MessageContent = "请首先支付订单!" });
            }

            return Json(new { MessageType = 0, MessageContent = "订单创建失败" });
        }

    }
}