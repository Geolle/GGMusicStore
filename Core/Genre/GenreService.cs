using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;

namespace Core.MusicInfo
{
    public class GenreService
    {
        private MusicStoreEntities storeDB;

        public GenreService()
        {
            this.storeDB = new MusicStoreEntities();
        }

        /// <summary>
        /// 获取所有的流派
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Genre> GetAll()
        {
            var genres = storeDB.Genres.ToList();
            return genres;
        }

        /// <summary>
        /// 根据音乐流派Id获取相应流派
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        public Genre Get(int genreId)
        {
            var genre = storeDB.Genres.Where(n => n.GenreId == genreId);
            if (genre != null && genre.Any())
            {
                return genre.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 创建音乐流派
        /// </summary>
        /// <param name="genre"></param>
        public void Create(Genre genre)
        {
            storeDB.Genres.Add(genre);
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 更新音乐流派
        /// </summary>
        /// <param name="genre"></param>
        public void Update(Genre genre)
        {
            storeDB.Entry(genre).State = System.Data.Entity.EntityState.Modified;
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 删除音乐流派
        /// </summary>
        /// <param name="genreId"></param>
        public void Delete(int genreId)
        {
            var genre = storeDB.Genres.Find(genreId);
            storeDB.Genres.Remove(genre);
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 根据音乐流派Id获取流派名称
        /// </summary>
        /// <param name="genreIds"></param>
        /// <returns></returns>
        public string GetGenreNames(string[] genreIds)
        {
            var genreNames =new List<string>();
            foreach (var genreId in genreIds)
            {
                var genre = Get(int.Parse(genreId));
                if (genre==null)
                {
                    continue;
                }
                else
                {
                    genreNames.Add(genre.GenreName);
                }
            }
            return string.Join(",", genreNames);
        }
    }
}
