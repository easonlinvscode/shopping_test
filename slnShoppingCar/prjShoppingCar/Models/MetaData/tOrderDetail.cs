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
    [MetadataType(typeof(tOrderDetail_metadate))]

    public partial class tOrderDetail
    {
        private class tOrderDetail_metadate
        {
            public int fId { get; set; }

            [DisplayName("訂單編號")]
            public string fOrderGuid { get; set; }

            [DisplayName("會員帳號")]
            public string fUserId { get; set; }

            [DisplayName("商品編號")]
            public string fPId { get; set; }

            [DisplayName("商品名稱")]
            public string fName { get; set; }

            [DisplayName("單價")]
            public Nullable<int> fPrice { get; set; }

            [DisplayName("訂購數量")]
            public Nullable<int> fQty { get; set; }


            [DisplayName("是否成為訂單")]
            public string fIsApproved { get; set; }


            [DisplayName("小計")]
            public Nullable<int> fAmount { get; set; }

            [DisplayName("總計")]
            public Nullable<int> fTotal { get; set; }


        }

        
    }
}