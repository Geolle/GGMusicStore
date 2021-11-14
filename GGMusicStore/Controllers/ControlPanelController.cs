using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.MusicInfo;
using AutoMapper;
using System.IO;
using Core.Shopping;

namespace GGMusicStore
{
    [Authorize(Roles = "Admin")]
    public class ControlPanelController : Controller
    {
        private AlbumService albumService;
        private GenreService genreService;
        private ArtistService artistService;
        private OrderService orderService;
        public ControlPanelController(AlbumService albumService, GenreService genreService, ArtistService artistService, OrderService orderService)
        {
            this.albumService = albumService;
            this.genreService = genreService;
            this.artistService = artistService;
            this.orderService = orderService;
        }

        /// <summary>
        /// 后台主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Home()
        {
            return View();
        }

        #region 音乐流派管理

        /// <summary>
        /// 音乐流派管理
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageGenres()
        {

            return View();
        }
        /// <summary>
        /// 音乐流派列表
        /// </summary>
        /// <returns></returns>
        public PartialViewResult _ListGenres()
        {
            var genres = genreService.GetAll();
            return PartialView(genres);
        }

        /// <summary>
        /// 编辑/添加音乐流派 GET
        /// </summary>
        /// <param name="genreId">音乐流派</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult _EditGenre(int genreId = 0)
        {
            Genre genre = new Genre();
            if (genreId > 0)
            {
                //编辑
                var genreCanBeNull = genreService.Get(genreId);
                if (genreCanBeNull != null)
                {
                    genre = genreCanBeNull;
                }
            }
            else
            {
                //添加
                genre = new Genre();
            }
            return View(genre);
        }

        /// <summary>
        /// 编辑/添加音乐流派 POST
        /// </summary>
        /// <param name="genreEditModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult _EditGenre(Genre genreEditModel)
        {
            if (ModelState.IsValid)
            {
                var genre = genreService.Get(genreEditModel.GenreId) ?? new Genre();
                genre.GenreName = genreEditModel.GenreName;
                genre.Description = genreEditModel.Description;
                if (genreEditModel.GenreId > 0)
                {
                    //编辑
                    genreService.Update(genre);
                    return Json(new { MessageType = 1, MessageContent = "成功编辑音乐流派" });
                }
                else
                {
                    //添加
                    genreService.Create(genre);
                    return Json(new { MessageType = 1, MessageContent = "成功添加音乐流派" });
                }
            }
            return Json(new { MessageType = 0, MessageContent = "添加音乐流派失败" });
        }

        /// <summary>
        /// 删除音乐流派
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteGenre(int genreId)
        {
            if (genreId > 0)
            {
                genreService.Delete(genreId);
                return Json(new { MessageType = 1, MessageContent = "成功删除音乐流派" });
            }
            else
            {
                return Json(new { MessageType = 0, MessageContent = "删除音乐流派失败" });
            }

        }
        #endregion


        #region 音乐人管理
        /// <summary>
        /// 音乐人管理
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageArtists()
        {

            return View();
        }
        /// <summary>
        /// 音乐人列表
        /// </summary>
        /// <returns></returns>
        public PartialViewResult _ListArtists()
        {
            var artists = artistService.GetAll();

            return PartialView(artists);
        }

        /// <summary>
        /// 编辑/添加音乐人 GET
        /// </summary>
        /// <param name="artistId">音乐人</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult _EditArtist(int artistId = 0)
        {
            ArtistEditModel artistEditModel = new ArtistEditModel();
            if (artistId > 0)
            {
                //编辑
                var artist = artistService.Get(artistId);
                if (artist != null)
                {
                    artistEditModel.ArtistId = artist.ArtistId;
                    artistEditModel.ArtistName = artist.ArtistName;
                    artistEditModel.Description = artist.Description;
                    if (!string.IsNullOrEmpty(artist.ArtistGenreIds))
                    {
                        artistEditModel.ArtistGenres = artist.ArtistGenreIds.Split(';');
                    }
                }
            }
            else
            {
                //添加
                //artistEditModel = new Artist();
            }
            var genresMultiSelect = new MultiSelectList(genreService.GetAll(), "GenreId", "GenreName", artistEditModel.ArtistGenres);
            ViewData["genresMultiSelect"] = genresMultiSelect;
            return View(artistEditModel);
        }

        /// <summary>
        /// 编辑/添加音乐人 POST
        /// </summary>
        /// <param name="artistEditModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult _EditArtist(ArtistEditModel artistEditModel)
        {
            if (ModelState.IsValid)
            {
                var artist = artistService.Get(artistEditModel.ArtistId) ?? new Artist();
                artist.ArtistName = artistEditModel.ArtistName;
                artist.Description = artistEditModel.Description;
                var artistGenresString = string.Join(";", artistEditModel.ArtistGenres ?? new List<string>());

                artist.ArtistGenreIds = artistGenresString;
                if (artistEditModel.ArtistId > 0)
                {
                    //编辑
                    artistService.Update(artist);
                    return Json(new { MessageType = 1, MessageContent = "成功编辑音乐人信息" });
                }
                else
                {
                    //添加
                    artistService.Create(artist);
                    return Json(new { MessageType = 1, MessageContent = "成功添加音乐人" });
                }
            }
            return Json(new { MessageType = 0, MessageContent = "添加音乐人失败" });
        }

        /// <summary>
        /// 删除音乐人
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteArtist(int artistId)
        {
            if (artistId > 0)
            {
                artistService.Delete(artistId);
                return Json(new { MessageType = 1, MessageContent = "成功删除音乐人" });
            }
            else
            {
                return Json(new { MessageType = 0, MessageContent = "删除音乐人失败" });
            }

        }

        #endregion

        #region 音乐专辑管理
        /// <summary>
        /// 音乐专辑管理
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageAlbums()
        {
            return View();
        }
        /// <summary>
        /// 音乐专辑列表
        /// </summary>
        /// <returns></returns>
        public PartialViewResult _ListAlbums(int pageSize = 20, int pageIndex = 1)
        {
            var albums = albumService.GetPagingData(pageSize, pageIndex);

            return PartialView(albums);
        }

        /// <summary>
        /// 编辑/添加音乐专辑 GET
        /// </summary>
        /// <param name="albumId">音乐专辑</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult _EditAlbum(int albumId = 0)
        {
            Album albumEditModel = new Album();
            if (albumId > 0)
            {
                //编辑
                albumEditModel = albumService.Get(albumId);
            }
            else
            {
                //添加
                //albumEditModel = new Album();
                albumEditModel.AlbumStatus = true;
            }

            ViewData["genresSelectList"] = new SelectList(genreService.GetAll(), "GenreId", "GenreName", albumEditModel.GenreId);
            ViewData["artistsSelectList"] = new SelectList(artistService.GetAll(), "ArtistId", "ArtistName", albumEditModel.ArtistId);

            return View(albumEditModel);
        }

        /// <summary>
        /// 编辑/添加音乐专辑 POST
        /// </summary>
        /// <param name="albumEditModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult _EditAlbum(Album albumEditModel)
        {
            if (ModelState.IsValid)
            {

                if (albumEditModel.AlbumId > 0)
                {
                    //编辑
                    var album = albumService.Get(albumEditModel.AlbumId);
                    album.GenreId = albumEditModel.GenreId;
                    album.ArtistId = albumEditModel.ArtistId;
                    album.AlbumName = albumEditModel.AlbumName;
                    album.Description = albumEditModel.Description;
                    album.AlbumNum = albumEditModel.AlbumNum;
                    album.Price = albumEditModel.Price;
                    album.Discount = albumEditModel.Discount;
                    //if (album.DiscountPrice > 0)
                    //{
                    //    album.DiscountPrice = albumEditModel.DiscountPrice;
                    //}
                    //else
                    //{
                    //    album.DiscountPrice = albumEditModel.Price * albumEditModel.Discount * new Decimal(0.1);
                    //}
                    album.DiscountPrice = albumEditModel.Price * albumEditModel.Discount * new Decimal(0.1);
                    if (album.AlbumStatus == false && albumEditModel.AlbumStatus == true)
                    {
                        album.GroundingTime = DateTime.Now;
                    }
                    album.AlbumStatus = albumEditModel.AlbumStatus;
                    if (string.IsNullOrEmpty(albumEditModel.AlbumArtUrl))
                    {
                        album.AlbumArtUrl = "/images/placeholder.jpg";
                    }
                    else
                    {
                        album.AlbumArtUrl = albumEditModel.AlbumArtUrl;
                    }

                    albumService.Update(album);
                    return Json(new { MessageType = 1, MessageContent = "成功编辑音乐专辑" });
                }
                else
                {
                    //添加
                    albumEditModel.GroundingTime = DateTime.Now;
                    albumEditModel.DiscountPrice = albumEditModel.Price * albumEditModel.Discount * new Decimal(0.1);
                    albumService.Create(albumEditModel);
                    return Json(new { MessageType = 1, MessageContent = "成功添加音乐专辑" });
                }
            }
            return Json(new { MessageType = 0, MessageContent = "操作失败" });
        }

        [HttpGet]
        public PartialViewResult _SaveAlbumArt()
        {
            return PartialView();
        }


        /// <summary>
        /// 保存专辑标题图
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult _SaveAlbumArt(HttpPostedFileBase files)
        {
            string pathForSaving = Server.MapPath("/images/albumArt");
            //HttpPostedFileBase file = Request.Files["files"];
            if (Request.Files.Count == 1)
            {
                string fileName = null;
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase uploadedFile = Request.Files[file] as HttpPostedFileBase;
                    if (uploadedFile != null && uploadedFile.ContentLength > 0)
                    {
                        var path = Path.Combine(pathForSaving, uploadedFile.FileName);
                        fileName = uploadedFile.FileName;
                        uploadedFile.SaveAs(path);
                    }
                }
                var url = "/images/albumArt/" + fileName;
                return Json(new { MessageType = 1, MessageContent = url });
            }
            return Json(new { MessageType = 0, MessageContent = "专辑封面上传失败" });
        }

        ///// <summary>
        ///// 音乐专辑详情
        ///// </summary>
        ///// <param name="albumId">音乐专辑</param>
        ///// <returns></returns>
        //[HttpGet]
        //public ActionResult _DetailAlbum(int albumId = 0)
        //{
        //    Album album = new Album();
        //    if (albumId > 0)
        //    {
        //        album = albumService.Get(albumId);
        //    }

        //    return View(album);
        //}

        /// <summary>
        /// 删除音乐专辑
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteAlbum(int albumId)
        {
            if (albumId > 0)
            {
                albumService.Delete(albumId);
                return Json(new { MessageType = 1, MessageContent = "成功删除音乐专辑" });
            }
            else
            {
                return Json(new { MessageType = 0, MessageContent = "删除音乐专辑失败" });
            }
        }

        #endregion


        #region 订单管理
        public ActionResult ManageOrders()
        {
            return View();
        }

        public PartialViewResult _ListOrders(int pageSize = 20, int pageIndex = 1)
        {
            var orderPagingDate = orderService.GetAll(pageSize, pageIndex);

            return PartialView(orderPagingDate);
        }

        [HttpPost]
        public JsonResult ChangeOrderState(int orderId)
        {
            if (orderId > 0)
            {
                var order = orderService.Get(orderId);
                order.IsDeal = !order.IsDeal;
                orderService.Update(order);
                return Json(new { MessageType = 1, MessageContent = "成功改变订单状态!" });
            }
            return Json(new { MessageType = 0, MessageContent = "改变订单状态失败!" });
        }


        #endregion

    }
}