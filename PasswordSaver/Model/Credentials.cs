namespace PasswordSaver.Model
{
    public class Credentials
    {
        public Credentials(string site, string userName, string password)
        {
            Site = site;
            UserName = userName;
            Password = password;
        }

        public string Site { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
