using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace PasswordSaver.Services.CredentialsManager
{
    public class JsonCredentialsManager : ICredentialsManager<RawCredentials>
    {
        private List<RawCredentials> _rawCredentialsList;

        public List<RawCredentials> GetCredentialList()
        {
            string fileContent = File.ReadAllText("./creds.json");
            _rawCredentialsList = JsonConvert.DeserializeObject<List<RawCredentials>>(fileContent);

            return _rawCredentialsList;
        }

        public void SaveCredentials(RawCredentials rawCredentials)
        {
            _rawCredentialsList.Add(rawCredentials);

            string jsonCredentials = JsonConvert.SerializeObject(_rawCredentialsList);
            File.WriteAllText("./creds.json", jsonCredentials);
        }

        //private string GetResourceTextFile(string filename)
        //{
        //    string fileContent = string.Empty;

        //    using (Stream stream = this.GetType().Assembly. GetManifestResourceStream("PasswordSaver.Resources." + filename))
        //    {
        //        using (var streamReader = new StreamReader(stream))
        //        {
        //            fileContent = streamReader.ReadToEnd();
        //        }
        //    }

        //    return fileContent;
        //}
    }
}
