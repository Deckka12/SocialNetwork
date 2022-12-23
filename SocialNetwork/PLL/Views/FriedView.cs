using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views {
    public class FriedView {
        UserService userService;
        FriendService FriendService;
        public FriedView (UserService userService, FriendService friendService) {
            this.userService = userService;
            this.FriendService = friendService;
        }
        public void Show (User user) {
            var friend = new FriendData();

            Console.Write("Введите почтовый адрес пользователя: ");
            friend.Email = Console.ReadLine();
            friend.User_ID = user.Id;

            try {
                FriendService.AddFriend(friend);

                SuccessMessage.Show("Пользователь добавлен в друзья!");
            }

            catch(UserNotFoundException) {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch(ArgumentNullException) {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch(Exception) {
                AlertMessage.Show("Произошла ошибка при добавление!");
            }
        }
    }
}
