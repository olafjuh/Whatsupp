using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Whatsupp.Models
{
    [Table("AccountChats")]
    public class Message
    {
        public int Id { get; set; }
        public int senderAccountId { get; set; }
        public int receiverAccountId { get; set; }
        public string message { get; set; }
        public DateTime addedAt { get; set; }
        public string senderName = null;
        public string receiverName = null;
        public bool flag = false;
         


        public Message(int senderAccountId, int receiverAccountId, string message, DateTime addedAt)
        {
            this.senderAccountId = senderAccountId;
            this.receiverAccountId = receiverAccountId;
            this.message = message;
            this.addedAt = addedAt;

        }

        public Message()
        {

        }
    }
}