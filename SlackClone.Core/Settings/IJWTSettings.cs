namespace SlackClone.Core.Settings
{
    public interface IJWTSettings
    {
        public string Secret { get; set; }

        public byte[] GetSecretAsBytes();
    }
}
