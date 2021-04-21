using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using PartsHunter.Repositories.Interfaces;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PartsHunter.Repositories
{
    public class FirebaseRepositorie: IFirebaseRepositorie
    {
        private readonly NameValueCollection configuration = ConfigurationManager.AppSettings;

        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        private readonly IFirebaseConfig config;
        private readonly IFirebaseClient client;

        private dynamic JSON_Firebase;

        public FirebaseRepositorie()
        {
            config = new FirebaseConfig {
                BasePath = "path",
                AuthSecret = "secret"
            };
            client = new FireSharp.FirebaseClient(config);
        }

        public bool Autheticate()
        {
            if (client == null)
            {
                return false;
            }
            return true;
        }

        public void Push_New_Component(string category, string description, string drawer)
        {
            try
            {
                var todo = new
                {
                    Description = description,
                    Drawer = drawer
                };

                PushResponse response = client.Push(category, todo);

                string retorno = JsonConvert.SerializeObject(response).ToString();
            }
            catch
            {

            }
        }

        public void Load_Firebase_Database()
        {
            _ = GetComponent(String.Empty);
        }

        public void DeleteComponent(string drawer)
        {
            string todo = String.Empty;


            foreach (dynamic key in JSON_Firebase.Keys)
            {
                if (key != "void" && key != "HardwareDevice")
                {
                    foreach (dynamic key2 in JSON_Firebase[key].Keys)
                    {
                        if (JSON_Firebase[key][key2]["Drawer"] == drawer)
                        {
                            todo = key + "/" + key2;
                        }
                    }
                }
            }


            FirebaseResponse response = client.Delete(todo);
            _ = JsonConvert.SerializeObject(response).ToString();
        }

        public string GetAddressComponent(string drawer)
        {
            string r = String.Empty;

            foreach (dynamic key in JSON_Firebase.Keys)
            {
                if (key != "void" && key != "HardwareDevice")
                {
                    foreach (dynamic key2 in JSON_Firebase[key].Keys)
                    {
                        if (JSON_Firebase[key][key2]["Drawer"] == drawer)
                        {
                            r = key + "/" + key2;
                        }
                    }
                }
            }

            return r;
        }

        public void UpdateComponent(string drawer, string description)
        {
            string address = GetAddressComponent(drawer);

            var todo = new
            {
                Description = description,
                Drawer = drawer
            };


            FirebaseResponse response = client.Update(address, todo);
            _ = JsonConvert.SerializeObject(response).ToString();
        }

        public void SetHardwareDevice(string command_setup)
        {
            try
            {
                string address = "/";

                var todo = new
                {
                    HardwareDevice = command_setup
                };


                FirebaseResponse response = client.Update(address, todo);

                string retorno = JsonConvert.SerializeObject(response).ToString();
            }
            catch
            {

            }
        }

        public async Task<dynamic> GetComponent(string input)
        {
            FirebaseResponse response = null; 
            try
            {
                response = await client.GetAsync(input);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string result = response.Body;
                JSON_Firebase = serializer.DeserializeObject(result);

                if (!String.IsNullOrEmpty(JSON_Firebase))
                {
                    return JSON_Firebase;
                }
            }

            return serializer.DeserializeObject("{void:0}");
        }
    }
}
