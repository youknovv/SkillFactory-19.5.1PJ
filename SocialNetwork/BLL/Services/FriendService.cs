using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;
        public FriendService() 
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }
        public IEnumerable<Friend> GetFriendsByUserId(int userId)
        {
            var friends = new List<Friend>();

            friendRepository.FindAllByUserId(userId).ToList().ForEach(m =>
            {
                var senderRequestUserEntity = userRepository.FindById(m.user_id);
                var recipientRequestUserEntity = userRepository.FindById(m.friend_id);

                friends.Add(new Friend(m.id, senderRequestUserEntity.email, recipientRequestUserEntity.email));
            });
            return friends;
        }

        public void AddFriend(FriendAddingData friendAddingData)
        {

            if (String.IsNullOrEmpty(friendAddingData.RequestRecipientEmail))
                throw new ArgumentNullException();

            var findUserEntity = this.userRepository.FindByEmail(friendAddingData.RequestRecipientEmail);
            if (findUserEntity is null) 
                throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendAddingData.RequestSenderId,
                friend_id = findUserEntity.id
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
        public void RemoveFriend(FriendAddingData friendAddingData) 
        {
            //add the code here to delete a user from friends
        }
    }
}
