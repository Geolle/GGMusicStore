using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;

namespace Core.MusicInfo
{
    public class ArtistService
    {
        private MusicStoreEntities storeDB;

        public ArtistService()
        {
            this.storeDB = new MusicStoreEntities();
        }

        /// <summary>
        /// 获取所有的流派
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Artist> GetAll()
        {
            var artists = storeDB.Artists.ToList();
            return artists;
        }

        /// <summary>
        /// 根据音乐流派Id获取相应流派
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns></returns>
        public Artist Get(int artistId)
        {
            //var artist = storeDB.Artists.Where(n => n.ArtistId == artistId);
            //if (artist != null && artist.Any())
            //{
            //    return artist.FirstOrDefault();
            //}
            //else
            //{
            //    return null;
            //}
            var artist = storeDB.Artists.Find(artistId);
            return artist;
        }


        /// <summary>
        /// 创建音乐流派
        /// </summary>
        /// <param name="artist"></param>
        public void Create(Artist artist)
        {
            storeDB.Artists.Add(artist);
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 更新音乐流派
        /// </summary>
        /// <param name="artist"></param>
        public void Update(Artist artist)
        {
            storeDB.Entry(artist).State = System.Data.Entity.EntityState.Modified;
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 删除音乐流派
        /// </summary>
        /// <param name="artistId"></param>
        public void Delete(int artistId)
        {
            var artist = storeDB.Artists.Find(artistId);
            storeDB.Artists.Remove(artist);
            storeDB.SaveChanges();
        }
    }
}
