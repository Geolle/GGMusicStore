using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Core.MusicInfo;

namespace GGMusicStore
{
    public class ArtistEditModel
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
        public IEnumerable<string> ArtistGenres { get; set; }

    }
}