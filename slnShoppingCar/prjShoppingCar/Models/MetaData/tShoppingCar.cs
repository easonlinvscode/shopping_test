using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjShoppingCar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(tShoppingCar_metadate))]
    public partial class tShoppingCar
    {
        private class tShoppingCar_metadate
        {
        public int Id { get; set; }
        public Nullable<int> fShoppingGuid { get; set; }
        public string fUserId { get; set; }
        public Nullable<int> fTotal { get; set; }
        public Nullable<int> fShoppingStatus { get; set; }

        }
        
    }
}