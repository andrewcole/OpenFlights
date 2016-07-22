using System;

namespace Illallangi.RestifyDb
{
    public interface IProfile
    {
        Uri Uri { get; }
        string Context { get; }
    }
}
