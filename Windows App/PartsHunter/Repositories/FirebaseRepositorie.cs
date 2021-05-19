using System;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using PartsHunter.Models;
using PartsHunter.Repositories.Interfaces;

namespace PartsHunter.Repositories
{
    public class FirebaseRepositorie : IFirebaseRepositorie
    {
        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        private readonly IFirebaseConfig config;
        private readonly IFirebaseClient client;

        private string _basePath = Properties.Settings.Default.BasePath;
        private string _authSecret = Properties.Settings.Default.AuthSecret;

        public dynamic JSON_Firebase { get; set; }
        public string BasePath {
            get { return _basePath; }
            set { _basePath = value; }
        }
        public string AuthSecret {
            get { return _authSecret; }
            set { _authSecret = value; }
        }


        public FirebaseRepositorie()
        {
            config = new FirebaseConfig {
                BasePath = _basePath,
                AuthSecret = _authSecret
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
            Component component = new Component {
                Description = description,
                Drawer = drawer
            };

            try
            {
                PushResponse response = client.Push(category, component);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string retorno = JsonConvert.SerializeObject(response).ToString();
                }
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

                FirebaseResponse response = client.Update(address,
                    new
                    {
                        HardwareDevice = command_setup
                    });

                string retorno = JsonConvert.SerializeObject(response).ToString();
            }
            catch
            {

            }
        }

        public async Task<dynamic> GetComponent(string input)
        {
            FirebaseResponse response = await client.GetAsync(input);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string result = response.Body;
                JSON_Firebase = serializer.DeserializeObject(result);

                if (JSON_Firebase != null)
                {
                    return JSON_Firebase;
                }
            }

            return serializer.DeserializeObject("{void:0}");
        }
    }
}
