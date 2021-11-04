namespace PasswordSaver.Services.CredentialsManager
{
    public sealed class RawCredentials
    {
        public string Site { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public RawCredentials(string site, string userName, string password)
        {
            Site = site;
            UserName = userName;
            Password = password;
        }
    }
}
