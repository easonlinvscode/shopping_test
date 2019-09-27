using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjShoppingCar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    [MetadataType(typeof(tShoppingCarDateil_metadate))]

    public partial class tShoppingCarDateil
    {
        private class tShoppingCarDateil_metadate
        {
        public int Id { get; set; }
        public Nullable<int> fShoppingGuid { get; set; }
        public Nullable<int> fPId { get; set; }
        public string fName { get; set; }
        public string fImg { get; set; }
        public Nullable<int> fQty { get; set; }
        public Nullable<int> fPrice { get; set; }

        }
        
    }
}
