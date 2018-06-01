using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Autofac;

namespace Core.MusicInfo
{
    /// <summary>
    /// 音乐人
    /// </summary>
    public class Artist
    {
        /// <summary>
        /// 音乐人Id
        /// </summary>
        public int ArtistId { get; set; }

        /// <summary>
        /// 音乐人姓名
        /// </summary>
        [Required(ErrorMessage = "请输入音乐人姓名")]
        [StringLength(256, ErrorMessage = "音乐人姓名不能超过256个字符")]
        [Display(Name = "音乐人姓名")]
        public string ArtistName { get; set; }

        /// <summary>
        /// 音乐人描述
        /// </summary>
        [Display(Name = "音乐人描述")]
        public string Description { get; set; }
        /// <summary>
        /// 音乐人流派
        /// </summary>
        [Display(Name = "音乐人流派")]
        public string ArtistGenreIds { get; set; }

        [NotMapped]
        public string AristGenres
        {
            get
            {
                if (!string.IsNullOrEmpty(ArtistGenreIds))
                {
                    var builder = new ContainerBuilder();
                    builder.RegisterType<GenreService>();
                    IContainer container = builder.Build();
                    var genreService = container.Resolve<GenreService>();
                    return genreService.GetGenreNames(ArtistGenreIds.Split(';'));
                }
                return string.Empty;
            }
        }


        [NotMapped]
        public int AlbumNum
        {
            get
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<AlbumService>();
                IContainer container = builder.Build();
                var albumService = container.Resolve<AlbumService>();
                return albumService.ArtistAlbumNum(ArtistId);
            }
        }


        /// <summary>
        /// 音乐流派包含的专辑列表
        /// </summary>
        public List<Album> Albums { get; set; }

        //public IEnumerable<string> ArtistGenreList
        //{
        //    get
        //    {
        //        return ArtistGenre.Split(';');
        //    }
        //}
    }
}
