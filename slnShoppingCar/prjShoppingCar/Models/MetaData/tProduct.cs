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

    [MetadataType(typeof(tProduct_metadate))]

    public partial class tProduct
    {
        private class tProduct_metadate
        {
            public int fId { get; set; }

            [DisplayName("商品編號")]
            public string fPId { get; set; }

            [DisplayName("商品名稱")]
            public string fName { get; set; }

            [DisplayName("單價")]
            public Nullable<int> fPrice { get; set; }

            [DisplayName("商品圖示")]
            public string fImg { get; set; }

            [DisplayName("商品類型")]
            public string fPType { get; set; }

            [DisplayName("商品介紹")]
            public string fPContent { get; set; }

            [DisplayName("商品圖示2")]
            public string fImg_1 { get; set; }

        }
        
    }
}