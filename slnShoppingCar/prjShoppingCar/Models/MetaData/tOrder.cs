using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjShoppingCar.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(tOrder_metadata))]
    public partial class tOrder
    {
        private class tOrder_metadata
        {
            public int fId { get; set; }

            [DisplayName("訂單編號")]
            public string fOrderGuid { get; set; }
            

            [DisplayName("會員帳號")]
            public string fUserId { get; set; }

            [DisplayName("收件人姓名")]
            [Required(ErrorMessage = "收件人姓名不可空白")]
            public string fReceiver { get; set; }

            [DisplayName("收件人Email")]
            [Required(ErrorMessage = "收件人Email不可空白")]
            public string fEmail { get; set; }

            [DisplayName("收件人住址")]
            [Required(ErrorMessage = "收件人住址不可空白")]
            public string fAddress { get; set; }

            [DisplayName("訂單日期")]
            public Nullable<System.DateTime> fDate { get; set; }

            [DisplayName("收件人電話")]
            [Required(ErrorMessage = "收件人電話不可空白")]
            public string fPhone { get; set; }
        }
     }
}