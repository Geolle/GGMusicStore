using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MusicInfo
{
    /// <summary>
    /// 音乐流派
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// 音乐流派Id
        /// </summary>
        public int GenreId { get; set; }

        /// <summary>
        /// 流派名称
        /// </summary>
        [Display(Name ="流派名称")]
        [StringLength(256, ErrorMessage = "流派名称最大长度为256")]
        [Required(ErrorMessage ="请输入流派名称")]
        public string GenreName { get; set; }

        /// <summary>
        /// 音乐流派描述
        /// </summary>
        [Display(Name ="流派描述")]
        public string Description { get; set; }

        [NotMapped]
        public int AlbumNum
        {
            get
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<AlbumService>();
                IContainer container = builder.Build();
                var albumService = container.Resolve<AlbumService>();
                return albumService.GenreAlbumNum(GenreId);
            }
        }

        /// <summary>
        /// 音乐流派包含的专辑列表
        /// </summary>
        public List<Album> Albums { get; set; }


    }
}
