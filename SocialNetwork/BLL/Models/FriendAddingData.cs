using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class FriendAddingData
    {
        public FriendAddingData(User user)
        {
            RequestSenderId = user.Id;
        }
        public int RequestSenderId { get; set; }
        public string RequestRecipientEmail { get; set; }
    }
}
