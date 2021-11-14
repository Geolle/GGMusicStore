using Autofac;
using Core.Shopping;
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
    /// 音乐专辑
    /// </summary>
    public class Album
    {
        /// <summary>
        /// 音乐专辑Id
        /// </summary>
        public int AlbumId { get; set; }

        /// <summary>
        /// 音乐流派Id
        /// </summary>
        [Display(Name = "音乐流派")]
        public int GenreId { get; set; }

        /// <summary>
        /// 音乐人Id
        /// </summary>
        [Display(Name = "音乐人")]
        public int ArtistId { get; set; }

        /// <summary>
        /// 音乐专辑名称
        /// </summary>
        [Display(Name = "专辑名称")]
        [Required(ErrorMessage = "请输入专辑名称")]
        [StringLength(256, ErrorMessage = "专辑名称最大长度为256")]
        public string AlbumName { get; set; }

        /// <summary>
        /// 音乐专辑描述
        /// </summary>
        [Display(Name = "专辑描述")]
        public string Description { get; set; }

        /// <summary>
        /// 音乐专辑剩余数量
        /// </summary>
        [Display(Name = "专辑数量")]
        [Range(0, int.MaxValue, ErrorMessage = "请输入一个有效的专辑数量")]
        public int AlbumNum { get; set; }

        /// <summary>
        /// 音乐专辑状态(1:上架0:下架)
        /// </summary>
        [Display(Name = "是否上架")]
        public bool AlbumStatus { get; set; }

        /// <summary>
        /// 上架时间
        /// </summary>
        public DateTime GroundingTime { get; set; }

        /// <summary>
        /// 音乐专辑价格
        /// </summary>
        [Display(Name = "价格")]
        [Required(ErrorMessage = "请输入专辑价格")]
        //[Range(0, 100.00, ErrorMessage = "价格必须在0~100之间")]
        public decimal Price { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        [Display(Name = "折扣")]
        [Required(ErrorMessage = "请输入折扣")]
        [Range(0, 10.00, ErrorMessage = "折扣必须在0~10之间")]
        public decimal Discount { get; set; } = 10;

        /// <summary>
        /// 折后价格
        /// </summary>
        [Display(Name = "折后价格")]
        [Required(ErrorMessage = "请输入折后价格")]
        //[Range(0, 100.00, ErrorMessage = "折扣必须在0~10之间")]
        public decimal DiscountPrice { get; set; }
 
        /// <summary>
        /// 音乐专辑标题图URL
        /// </summary>
        [Display(Name = "专辑封面")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }

        /// <summary>
        /// 音乐专辑所属流派
        /// </summary>
        public virtual Genre Genre { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }


        ///// <summary>
        ///// 音乐专辑作家
        ///// </summary>
        //public Artist Artist
        //{
        //    get
        //    {
        //        var builder = new ContainerBuilder();
        //        builder.RegisterType<ArtistService>();
        //        IContainer container = builder.Build();
        //        var artistService = container.Resolve<ArtistService>();
        //        return artistService.Get(ArtistId);
        //    }
        //    set
        //    {

        //    }
        //}

        ///// <summary>
        ///// 订单详情
        ///// </summary>
        //public List<OrderDetail> OrderDetails
        //{
        //    get
        //    {
        //        var builder = new ContainerBuilder();
        //        builder.RegisterType<OrderService>();
        //        IContainer container = builder.Build();
        //        var orderService = container.Resolve<OrderService>();
        //        return orderService.Gets(AlbumId);
        //    }
        //}

    }
}
