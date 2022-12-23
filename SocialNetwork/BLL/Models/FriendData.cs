using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models {
    public class FriendData {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public int Friend_ID { get; set; }
        public string Email { get; set; }
    }
}
