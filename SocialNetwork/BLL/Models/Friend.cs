using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string User_email { get; set; }
        public string Friend_email { get; set; }

        public Friend(int id, string user_email, string friend_email)
        {
            Id = id;
            User_email = user_email;
            Friend_email = friend_email;
        }
    }
}
