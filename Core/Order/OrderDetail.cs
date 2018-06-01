using Autofac;
using Core.MusicInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Shopping
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int AlbumId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Album Album
        {
            get
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<AlbumService>();
                IContainer container = builder.Build();
                var albumService = container.Resolve<AlbumService>();
                return albumService.Get(AlbumId);
            }
        }
        public virtual Order Order { get; set; }
    }
}
