using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.PLL.Helpers;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views
{
    public class FriendAddingView
    {
        UserService userService;
        FriendService friendService;

        public FriendAddingView(UserService userService, FriendService friendService)
        {  
            this.userService = userService;
            this.friendService = friendService;            
        }
        public void Show(User user)
        {
            FriendAddingData friendAddingData = new (user);

            Console.WriteLine("Enter an email of the user to add him to ur friendlist");
            friendAddingData.RequestRecipientEmail = Console.ReadLine();
            try
            {
                friendService.AddFriend(friendAddingData);
                SuccessMessage.Show("User " + userService.FindByEmail(friendAddingData.RequestRecipientEmail).FirstName + " added to ur friend list"); ;
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("User with the email " + friendAddingData.RequestRecipientEmail +" doesnt exist");
            }
            catch (Exception ex)
            {
                AlertMessage.Show("Произошла ошибка при отправке сообщения!");
                AlertMessage.Show(ex.Message);
            }
        }
    }
}
