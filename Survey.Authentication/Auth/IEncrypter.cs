using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Authentication.Auth
{
    public interface IEncrypter
    {
        byte[] GetSalt();
        byte[] GetHash(string value, byte[] salt);
    }
}
