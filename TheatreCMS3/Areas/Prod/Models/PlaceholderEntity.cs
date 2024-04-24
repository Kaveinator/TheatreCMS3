using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models {
    public class PlaceholderEntity {
        [Key] public int InstanceId { get; set; }
        [Required] public string Value { get; set; }
    }
}