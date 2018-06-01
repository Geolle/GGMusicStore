using Autofac;
using Core.MusicInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Shopping
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int AlbumId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }

        [NotMapped]
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
            //set
            //{
            //    var builder = new ContainerBuilder();
            //    builder.RegisterType<AlbumService>();
            //    IContainer container = builder.Build();
            //    var albumService = container.Resolve<AlbumService>();
            //    Album = albumService.Get(AlbumId);
            //}
            //get; set;
        }
    }
}
