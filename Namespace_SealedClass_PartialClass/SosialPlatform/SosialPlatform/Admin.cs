using System;
using Person;

namespace Admin
{
    public class AdminAccount : PersonInfo
    {
        private string[] viewer;
        private string[] liker;

        public void View(string userViewed, string userPost)
        {
            Array.Resize<string>(ref viewer, viewer.Length + 1);
            viewer[viewer.Length - 1] = userViewed + " viewed " + userPost + " post.";
        }

        public void Like(string userLiked, string userPost)
        {
            Array.Resize<string>(ref liker, liker.Length + 1);
            liker[liker.Length - 1] = userLiked + " liked " + userPost + " post.";
        }

        public void showAllNotification()
        {
            Console.WriteLine("Like: ");
            foreach (var like in liker)
            {
                Console.WriteLine(like);
            }
            Console.WriteLine("View: ");
            foreach (var view in viewer)
            {
                Console.WriteLine(view);
            }
        }

        public AdminAccount() : base()
        {
            viewer = new string[0];
            liker = new string[0];
        }

        public AdminAccount(string username, string email, string password, string name, string surname) : base(username, email, password, name, surname)
        {
            viewer = new string[0];
            liker = new string[0];
        }
    }
}
