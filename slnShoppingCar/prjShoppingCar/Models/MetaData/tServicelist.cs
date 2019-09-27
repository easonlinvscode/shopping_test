using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjShoppingCar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(tServicelist_metadeta))]

    public partial class tServicelist
    {
        private class tServicelist_metadeta
        {
        public int Id { get; set; }
        public Nullable<System.DateTime> fServiceDate { get; set; }
        public Nullable<int> fServiceGuid { get; set; }
        public string fUserId { get; set; }
        public Nullable<int> fQuestionGuid { get; set; }
        public string fServiceEmail { get; set; }
        public string fServiceSort { get; set; }
        public string fServiceSub { get; set; }
        public string fServiceContent { get; set; }

        }
       
    }
}