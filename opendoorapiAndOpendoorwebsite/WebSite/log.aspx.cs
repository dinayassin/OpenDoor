using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpenDoorAPI.Contracts;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace WebSite
{
    public partial class log : System.Web.UI.Page
    {
        JavaScriptSerializer seralizer = new JavaScriptSerializer();
        const string API_BASE_URL = "http://localhost:54999/api/";

        protected void Page_Load(object sender, EventArgs e)
        {

            //GetAllLogs();

            //LogTableDiv.InnerHtml = "";

        }


        private void GetAllLogs2()
        {
            int z = 5;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API_BASE_URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync("Log").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsAsync<string>();

                var a = seralizer.Deserialize<ResultLogDTO[]>(response.Content.ReadAsFormDataAsync().ToString());
               
                z = 30;

                //var res = seralizer.JsonSerializerInternalReader(ResultLogDTO).Result;
                //var dataObjects = response.Content.ReadAsAsync<IEnumerable<ResultLogDTO>>().Result;
                //foreach (var d in res)
                //{
                //    Response.Write(d.UserFullName);
                //    //Console.ReadKey();
                //}
            }
            else
            {
                z = 3;
            }
        }

        private async Task GetAllLogs()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(API_BASE_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("Log");
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsAsync<ResultLogDTO[]>();
                    var z = 2;
                }
                else
                {
                    var b = 5;
                }
            }

        }

        protected void GridViewLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected  void Button1_Click(object sender, EventArgs e)
        {
             GetAllLogs2();
        }
    }
}