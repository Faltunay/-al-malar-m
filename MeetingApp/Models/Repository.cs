using System.Collections.Generic;

namespace MeetingApp.Models
{
    public static class Repository
    {
        public static List<UserInfo> _users = new List<UserInfo>();

        public static List<UserInfo> Users
        {
            get
            {
                return _users;
            }

        }

        static Repository()
        {
            _users.Add(new UserInfo() { Id = 1, Name = "Fatih", Email = "faltunay34@gmail.com", Phone = "0542 627 46 52", WillAttend = true });
            _users.Add(new UserInfo() { Id = 2, Name = "Esra", Email = "Ealtunay34@gmail.com", Phone = "0542 627 46 52", WillAttend = true });
            _users.Add(new UserInfo() { Id = 3, Name = "Nurettin", Email = "Naltunay34@gmail.com", Phone = "0542 627 46 52", WillAttend = false });
            _users.Add(new UserInfo() { Id = 4, Name = "Nermin", Email = "Naltunay34@gmail.com", Phone = "0542 627 46 52", WillAttend = false });
        }

        public static void CreateUser(UserInfo user)
        {       
            user.Id=_users.Count+1;
            _users.Add(user);
        }

        public static UserInfo? GetById (int id)
        {
            return _users.FirstOrDefault(u=> u.Id==id);
        }
    }
}
