using Core.MusicInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GGMusicStore
{
    public class StoreController : Controller
    {
        private AlbumService albumService;
        private GenreService genreService;
        private ArtistService artistService;

        public StoreController(AlbumService albumService, GenreService genreService, ArtistService artistService)
        {
            this.albumService = albumService;
            this.genreService = genreService;
            this.artistService = artistService;
        }


        /// <summary>
        /// 音乐商店首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Store(string keyword="")
        {
            ViewData["allGenre"] = genreService.GetAll();
            ViewData["keyword"] = keyword;
            return View();
        }

        /// <summary>
        /// 音乐专辑列表
        /// </summary>
        /// <returns></returns>
        public PartialViewResult _ListAlbums(string keyword = "")
        {
            var albums = albumService.GetAll().Where(n => n.AlbumStatus == true);
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                albums = albums.Where(n => (n.Artist.ArtistName.ToLower().Contains(keyword) || n.Genre.GenreName.ToLower().Contains(keyword) || n.AlbumName.ToLower().Contains(keyword)));
            }
            return PartialView(albums);
        }






    }
}