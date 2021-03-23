﻿using System.Text;

namespace SlackClone.Core.Settings
{
    public class JWTSettings :
        IJWTSettings
    {
        public string Secret { get; set; }

        public byte[] GetSecretAsBytes()
            => Encoding.ASCII.GetBytes(Secret);
    }
}
