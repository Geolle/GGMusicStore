using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.MusicInfo;
using Core.Shopping;
using Core.Data;

namespace GGMusicStore
{
    public class HomeController : Controller
    {
        private AlbumService albumService;
        private CartService cartService;

        public HomeController(AlbumService albumService,CartService cartService)
        {

            this.albumService = albumService;
            this.cartService = cartService;

        }

        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Home()
        {

            ViewData["hotAlbums"] = albumService.GetHotAlbums(3);
            ViewData["newAlbums"] = albumService.GetLatestGroundingAlbums(3);
            System.Data.Entity.Database.SetInitializer(new SampleData());

            return View();
        }


        //public ActionResult HotAlbums()
        //{
            
        //}

    }
}