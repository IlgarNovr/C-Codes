using System;
using System.Threading;
using Admin;
using User;
using PostSpace;
using SocialPlatform;

namespace SosialPlatform
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Accounts accounts = new Accounts();
            AddData(accounts);
            int index = -1;
            int adminPage = -1;
            int userPage = -1;
            int id = 0;
            string[] menu = new string[] { "Admin", "User", "Exit" };
            string[] adminMenu = new string[] { "Notification", "Back" };
            string[] userMenu = new string[] { "Like", "Back" };

            while (true)
            {
                Console.Clear();
                #region Post

                string[] posts = new string[accounts.CountAllPosts() + 2];
                posts[0] = "Post something...";
                Post[] posts1 = accounts.GetAllPosts();
                int i = 1;
                for (; i < accounts.CountAllPosts() + 1; i++)
                {
                    posts[i] = accounts.GetUserByID(posts1[i - 1].creatorID).username;
                    posts[i] += "\n";
                    if (posts1[i - 1].content.Length > 30)
                        posts[i] += posts1[i - 1].content.Substring(0, 30);
                    else
                        posts[i] += posts1[i - 1].content;
                    posts[i] += "...";
                }
                posts[i] = "Back";

                #endregion

                if (index == -1)
                {
                    index = Select.choose(menu);
                }
                Console.Clear();
                if (index == 0)
                {
                    if (adminPage == -1)
                    {
                        Console.Write("username: ");
                        string username = Console.ReadLine();
                        Console.Write("password: ");
                        string password = Console.ReadLine();
                        try
                        {
                            id = accounts.LoginAdmin(username, password);
                        }
                        catch (Exception ex)
                        {
                            Console.Clear();
                            Console.WriteLine(ex.Message);
                            index = -1;
                            Thread.Sleep(700);
                            continue;
                        }
                    }
                    Console.Clear();
                    adminPage = Select.choose(adminMenu);
                    Console.Clear();
                    if (adminPage == 0)
                    {
                        accounts.GetAdminByID(id).showAllNotification();
                        Console.WriteLine("\nPress Enter to return menu");
                        while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                    }
                    else if (adminPage == 1)
                    {
                        adminPage = -1;
                        index = -1;
                    }
                }
                else if (index == 1)
                {
                    if (userPage == -1)
                    {
                        Console.Write("username: ");
                        string username = Console.ReadLine();
                        Console.Write("password: ");
                        string password = Console.ReadLine();
                        try
                        {
                            id = accounts.LoginUser(username, password);
                        }
                        catch (Exception ex)
                        {
                            Console.Clear();
                            Console.WriteLine(ex.Message);
                            index = -1;
                            Thread.Sleep(700);
                            continue;
                        }
                        userPage = 0;
                    }
                    if (userPage == 0)
                    {
                        Console.Clear();
                        userPage = Select.choose(posts);
                        Console.Clear();
                    }
                    if (userPage == 0)
                    {
                        Console.Write("Content: ");
                        string content = Console.ReadLine();
                        accounts.GetUserByID(id).PostSomething(id, content);
                    }
                    else if (userPage == accounts.CountAllPosts() + 1)
                    {
                        userPage = -1;
                        index = -1;
                    }
                    else 
                    {
                        accounts.ViewPost(posts1[userPage - 1].postID, posts1[userPage - 1].creatorID, id);
                        int c = Select.choose(accounts.GetUserByID(posts1[userPage - 1].creatorID).GetPostByID(posts1[userPage - 1].postID).content, userMenu);
                        if (c == 0)
                        {
                            accounts.LikePost(posts1[userPage - 1].postID, posts1[userPage - 1].creatorID, id);
                        }
                        else
                        {
                            userPage = 0;
                        }
                    }
                }
                else if (index == 2)
                {
                    break;
                }
            }
        }


        public static void AddData(Accounts accounts)
        {
            //username - admin
            //password - admin123
            accounts.AddAdmin(new AdminAccount("admin", "admin@gmail.com", "admin123", "Murad", "Seyidov"));
            UserAccount[] users = new UserAccount[2];
            //username - qabil
            //password - qabil123
            users[0] = new UserAccount("qabil", "qabil@gmail", "qabil123", "Qabil", "Memmedov");
            users[0].PostSomething(0, @"C++ is a general-purpose programming language created by Bjarne Stroustrup as an extension of the C programming language, or C with Classes. The language has expanded significantly over time, and modern C++ now has object-oriented, generic, and functional features in addition to facilities for low-level memory manipulation. It is almost always implemented as a compiled language, and many vendors provide C++ compilers, including the Free Software Foundation, LLVM, Microsoft, Intel, Oracle, and IBM, so it is available on many platforms.");
            users[0].PostSomething(0, @"C#  is a general-purpose, multi-paradigm programming language. C# encompasses static typing, strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines.[15] C# was developed around 2000 by Microsoft as part of its .NET initiative and later approved as an international standard by Ecma (ECMA-334) in 2002 and ISO (ISO/IEC 23270) in 2003. It was designed by Anders Hejlsberg, and its development team is currently led by Mads Torgersen, being one of the programming languages designed for the Common Language Infrastructure (CLI). The most recent version is 9.0, which was released in 2020 in .NET 5.0 and included in Visual Studio 2019 version 16.8");
            users[0].PostSomething(0, @"SQL ((About this soundlisten) S-Q-L,[4] /ˈsiːkwəl/ sequel; Structured Query Language)[5] is a domain-specific language used in programming and designed for managing data held in a relational database management system (RDBMS), or for stream processing in a relational data stream management system (RDSMS). It is particularly useful in handling structured data, i.e. data incorporating relations among entities and variables.");
            accounts.AddUser(users[0]);
        }
    }

}

