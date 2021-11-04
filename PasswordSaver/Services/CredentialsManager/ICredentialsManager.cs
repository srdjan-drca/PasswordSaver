using System.Collections.Generic;

namespace PasswordSaver.Services.CredentialsManager
{
    public interface ICredentialsManager<T>
    {
        List<T> GetCredentialList();

        void SaveCredentials(T credentials);
    }
}
