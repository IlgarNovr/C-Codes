using System;
using Admin;
using User;
using PostSpace;

namespace SocialPlatform
{
    public class Accounts
    {

        AdminAccount[] admins;
        UserAccount[] users;
        private int countAdmin;
        private int countUser;
        private int nextID;

        public void AddAdmin(AdminAccount admin)
        {
            admin.ID = nextID++;
            Array.Resize(ref admins, ++countAdmin);
            admins[countAdmin - 1] = admin;
        }

        public void AddUser(UserAccount user)
        {
            user.ID = countUser;
            Array.Resize(ref users, ++countUser);
            users[countUser - 1] = user;
        }

        public void LikePost(int postID, int userID, int userLikedID)
        {
            if (userID <= countUser)
            {
                users[userID].Like(postID);
                foreach (var admin in admins)
                {
                    admin.Like(users[userLikedID].username, users[userID].username);
                }

            }
            else
                throw new Exception("User not found");
        }

        public void ViewPost(int postID, int userID, int userViewedID)
        {
            if (userID <= countUser)
            {
                users[userID].View(postID);
                foreach (var admin in admins)
                {
                    admin.View(users[userViewedID].username, users[userID].username);
                }

            }
            else
                throw new Exception("User not found");
        }

        public UserAccount GetUserByID(int ID)
        {
            if (ID <= countUser)
                return users[ID];
            throw new Exception("User Not found");
        }

        public AdminAccount GetAdminByID(int ID)
        {
            if (ID <= countAdmin)
                return admins[ID];
            throw new Exception("Admin not found");
        }

        public int LoginAdmin(string username, string password)
        {
            foreach (var admin in admins)
            {
                if (admin.username == username && admin.password == password)
                    return admin.ID;
            }
            throw new Exception("Password or username is wrong");
        }

        public int LoginUser(string username, string password)
        {
            foreach (var user in users)
            {
                if (user.username == username && user.password == password)
                    return user.ID;
            }
            throw new Exception("Password or username is wrong");
        }

        public Post[] GetAllPosts()
        {
            Post[] posts = new Post[0];
            foreach (var user in users)
            {
                foreach (var post in user.GetPosts())
                {
                    Array.Resize(ref posts, posts.Length + 1);
                    posts[posts.Length - 1] = post;
                }
            }
            return posts;
        }

        public int CountAllPosts()
        {
            int count = 0;
            foreach (var user in users)
            {
                foreach (var post in user.GetPosts())
                {
                    count++;
                }
            }
            return count;
        }
        public Accounts()
        {
            admins = new AdminAccount[0];
            users = new UserAccount[0];
            countUser = 0;
            countAdmin = 0;
        }

    }

}
