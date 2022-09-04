using System;
namespace PostSpace
{
    public class Post
    {

        public int postID { get; set; }

        public int creatorID { get; set; }

        public int viewCount { get; set; }

        public int likeCount { get; set; }

        public string content { get; set; }

        public void View()
        {
            viewCount++;
        }

        public void Like()
        {
            likeCount++;
        }

        public Post(int postID, int creatorID, int viewCount, int likeCount, string content)
        {
            this.postID = postID;
            this.creatorID = creatorID;
            this.viewCount = viewCount;
            this.likeCount = likeCount;
            this.content = content;
        }

        public Post()
        {
            postID = 0;
            creatorID = 0;
            viewCount = 0;
            likeCount = 0;
            content = "unknown";
        }
    }
}
