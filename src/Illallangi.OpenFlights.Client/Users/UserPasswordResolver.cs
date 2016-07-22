namespace Illallangi.OpenFlights.Users
{
    using AutoMapper;

    public class UserPasswordResolver : IValueResolver<IUser, User, string>
    {
        public string Resolve(IUser source, User destination, string destMember, ResolutionContext context)
        {
            return string.Concat(source.Name, source.Password).HexMd5();
        }
    }
}