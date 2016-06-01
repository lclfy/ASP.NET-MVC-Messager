using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MessageManager.Web.Models
{
    public class Message
    {
        [Key]
        public string ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SendTime { get; set; }
        public int State { get; set; }
        public int DisplayType { get; set; }
    }
}