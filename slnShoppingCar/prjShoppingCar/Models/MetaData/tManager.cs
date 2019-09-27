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
    [MetadataType(typeof(tManager_metadata))]
    public partial class tManager
    {
        private class tManager_metadata
        {

            public int fId { get; set; }

            [DisplayName("管理者名稱")]
            public string fMName { get; set; }

            [DisplayName("管理者帳號")]
            [Required(ErrorMessage = "帳號不可空白")]
            public string fMUserId { get; set; }

            [DisplayName("管理者密碼")]
            [Required(ErrorMessage = "密碼不可空白")]
            public string fMPwd { get; set; }
        }

    }
}