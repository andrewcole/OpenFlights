using System;

namespace Illallangi.OpenFlights.Users
{
    public interface IUser
    {
        UserEditor Editor { get; }

        UserEliteStatus EliteStatus { get; }

        DateTime EliteValidity { get; }

        string Email { get; }

        string GuestPassword { get; }

        UserLocale Locale { get; }

        string Name { get; }

        string Password { get; }

        UserPrivacy Privacy { get; }

        UserStartPane StartPane { get; }

        UserUnits Units { get; }

        int UserId { get; }

        int Views { get; }
    }
}