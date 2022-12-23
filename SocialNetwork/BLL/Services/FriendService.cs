using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services {
    public class FriendService {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendService () {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }
        

        public void AddFriend (FriendData friendData) {
            var findUserEntity = this.userRepository.FindByEmail(friendData.Email);
            if(findUserEntity is null)
                throw new UserNotFoundException();

            var messageEntity = new FriendEntity() {
                friend_id = findUserEntity.id,
                user_id = friendData.User_ID
            };

            if(this.friendRepository.Create(messageEntity) == 0)
                throw new Exception();
        }
    }
}
