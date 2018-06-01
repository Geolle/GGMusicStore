using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Core.MusicInfo;
using Core.Shopping;

namespace Core.Data
{
    public class MusicStoreEntities : DbContext
    {
        /// <summary>
        /// 音乐专辑表
        /// </summary>
        public DbSet<Album> Albums { get; set; }

        /// <summary>
        /// 音乐流派表
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// 音乐人表
        /// </summary>
        public DbSet<Artist> Artists { get; set; }

        /// <summary>
        /// 购物车表
        /// </summary>
        public DbSet<Cart> Carts { get; set; }

        /// <summary>
        /// 订购单表
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// 订购详情表
        /// </summary>
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
