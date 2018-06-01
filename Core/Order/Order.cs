using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Shopping
{
    public partial class Order
    {
        /// <summary>
        /// 主键订单Id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "请输入用户名")]
        [StringLength(256, ErrorMessage = "用户名最大长度为256")]
        public string UserName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "真实姓名")]
        [Required(ErrorMessage = "请输入真实姓名")]
        [StringLength(256, ErrorMessage = "姓名最大长度为256")]
        public string TrueName { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Display(Name = "地址")]
        [Required(ErrorMessage = "请输入地址")]
        [StringLength(256, ErrorMessage = "地址最大长度为256")]
        public string Address { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        [Display(Name = "邮编")]
        [Required(ErrorMessage = "请输入邮编")]
        [StringLength(6, ErrorMessage = "邮编最大长度为6")]
        public string PostalCode { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Display(Name = "手机号")]
        [Required(ErrorMessage = "请输入手机号")]
        [StringLength(24, ErrorMessage = "流派名称最大长度为24")]
        public string Phone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [Display(Name = "电子邮箱")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// 总计
        /// </summary>
        [Display(Name = "订单金额")]
        public decimal Total { get; set; }

        /// <summary>
        /// 订单日期
        /// </summary>
        [Display(Name = "订单日期")]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [StringLength(256, ErrorMessage = "备注最大长度为256")]
        public string Description { get; set; }

        /// <summary>
        /// 是否发货
        /// </summary>
        public bool IsDeal { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
