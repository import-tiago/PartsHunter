using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using PartsHunter.Business.Interfaces;
using PartsHunter.Repositories.Interfaces;

namespace PartsHunter.Business
{
    public class AuthenticationBusiness : IAuthenticationBusiness
    {
        private readonly IFirebaseRepositorie _firebaseRepositorie;

        public AuthenticationBusiness(IFirebaseRepositorie firebaseRepositorie)
        {
            _firebaseRepositorie = firebaseRepositorie;
        }

        //TODO: SALVAR NO SETTINGS.SETTINGS
        public void SaveSecrets(string url, string key)
        {
            if (_firebaseRepositorie.Autheticate())
            {
                Hashtable variables = new Hashtable {
                    { "URL", url },
                    { "KEY", key }
                };

                FileStream fs = new FileStream("Firebase_Secrets.dat", FileMode.Create);

                BinaryFormatter formatter = new BinaryFormatter();

                try
                {
                    formatter.Serialize(fs, variables);
                    //MessageBox.Show("This will cloase, reload the application!");
                    fs.Close();

                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
        }

        public void LoadSecrets()
        {
            FileStream fs = new FileStream("Firebase_Secrets.dat", FileMode.OpenOrCreate);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Hashtable variables = (Hashtable)formatter.Deserialize(fs);
                string firebase_Database_URL = (string)variables["URL"];
                string firebase_Database_KEY = (string)variables["KEY"];
            }
            catch
            {

            }
            finally
            {
                fs.Close();
            }
        }
    }
}
