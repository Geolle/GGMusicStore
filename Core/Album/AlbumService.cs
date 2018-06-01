using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;
using Core.Common;

namespace Core.MusicInfo
{
    public class AlbumService
    {
        private MusicStoreEntities storeDB;

        public AlbumService()
        {

            this.storeDB = new MusicStoreEntities();
        }

        public Album Get(int albumId)
        {
            return storeDB.Albums.Find(albumId);
        }


        /// <summary>
        /// 获取所有的专辑
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Album> GetAll()
        {
            var allAlbums = storeDB.Albums.ToList();
            return allAlbums;
        }

        /// <summary>
        /// 获取分页的音乐专辑
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public PagingDataSet<Album> GetPagingData(int pageSize = 20, int pageIndex = 1)
        {
            var allAlbums = storeDB.Albums.ToList();

            var albums = allAlbums.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            return new PagingDataSet<Album>(albums)
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalRecords = allAlbums.Count
            };
        }


        /// <summary>
        /// 获取某一流派下的专辑数
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        public int GenreAlbumNum(int genreId)
        {
            return storeDB.Albums.Where(n => n.GenreId == genreId).Count();
        }

        /// <summary>
        /// 获取某一音乐人的专辑数
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns></returns>
        public int ArtistAlbumNum(int artistId)
        {
            return storeDB.Albums.Where(n => n.GenreId == artistId).Count();
        }


        /// <summary>
        /// 创建音乐专辑
        /// </summary>
        /// <param name="album"></param>
        public void Create(Album album)
        {
            storeDB.Albums.Add(album);
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 更新音乐专辑
        /// </summary>
        /// <param name="album"></param>
        public void Update(Album album)
        {
            storeDB.Entry(album).State = System.Data.Entity.EntityState.Modified;
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 删除音乐专辑
        /// </summary>
        /// <param name="artistId"></param>
        public void Delete(int albumId)
        {
            var album = storeDB.Albums.Find(albumId);
            storeDB.Albums.Remove(album);
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 获取畅销专辑
        /// </summary>
        /// <param name="num">获取数量</param>
        public IEnumerable<Album> GetHotAlbums(int num)
        {
            return storeDB.Albums.OrderByDescending(n => n.OrderDetails.Count).Take(num).ToList();
        }

        /// <summary>
        /// 获取最新上架的专辑
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public IEnumerable<Album> GetLatestGroundingAlbums(int num)
        {
          return  storeDB.Albums.OrderByDescending(n => n.GroundingTime).Take(num).ToList();
        }

    }
}
