using ClientConvertisseurV1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV1.Service
{

    public class WSService
    {
        private HttpClient client = new HttpClient();

        public async Task<List<Device>> GetAllDevice()
        {
            client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5000/api/device");

            List<Device> devices = null;
            if (response.IsSuccessStatusCode)
            {
                devices = await response.Content.ReadAsAsync<List<Device>>();
            }

            return devices;
        }


    }
}
