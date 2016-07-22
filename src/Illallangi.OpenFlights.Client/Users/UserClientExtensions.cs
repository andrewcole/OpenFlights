using System.Collections.Generic;
using AutoMapper;

namespace Illallangi.OpenFlights.Users
{
    public static class UserClientExtensions
    {
        public static IEnumerable<User> RetrieveUser(this OpenFlightsClient ofc)
        {
            return ofc.Retrieve<User>(@"users");
        }

        public static object CreateUser(this OpenFlightsClient ofc, IUser user)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<IUser, User>().ForMember(u => u.Password, o => o.ResolveUsing<UserPasswordResolver>()));
            
            return ofc.Create<User>(@"users", Mapper.Map<User>(user));
        }
    }
}