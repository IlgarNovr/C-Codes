using System;
using Person;
using PostSpace;

namespace User
{
    public class UserAccount : PersonInfo
    {
        Post[] posts;
        private int countPosts;

        public Post[] GetPosts() => posts;
        public void PostSomething(int userID, string content)
        {
            Post post = new Post(countPosts, userID, 0, 0, content);
            Array.Resize<Post>(ref posts, ++countPosts);
            posts[countPosts - 1] = post;
        }

        public void View(int postID)
        {
            if (postID <= countPosts)
                posts[postID].View();
            else
                throw new Exception("Post not found");
        }

        public void Like(int postID)
        {
            if (postID <= countPosts)
                posts[postID].Like();
            else
                throw new Exception("Post not found");
        }
        public Post GetPostByID(int postID)
        {
            if (postID <= countPosts)
                return posts[postID];
            throw new Exception("Post not found");
        }
        public UserAccount() : base()
        {
            posts = new Post[0];
            countPosts = 0;

        }

        public UserAccount(string username, string email, string password, string name, string surname) : base(username, email, password, name, surname)
        {
            posts = new Post[0];
            countPosts = 0;
        }

    }
}
