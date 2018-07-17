using OpenDoorAPI.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft;
using System.Web.Script.Serialization;
using System.Text;
using System.Data;

namespace WebSite
{
    public partial class main : System.Web.UI.Page
    {
        static HttpClient client = null;
        public void startData(object sender, EventArgs e)
        {
            Response.Write("test");
        }

        private bool IsEditingUserData(string user)
        {
            JavaScriptSerializer seralizer = new JavaScriptSerializer();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync("UserCredntials/IsEditingUserData/", user).Result;
            if (response.IsSuccessStatusCode)
            {
                return seralizer.Deserialize<bool>(response.Content.ReadAsAsync<string>().Result);
            }
            return false;
        }
        private bool CheckLogin(string token)
        {
            JavaScriptSerializer seralizer = new JavaScriptSerializer();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync("UserCredntials/CheckLogin", token).Result;
            if (response.IsSuccessStatusCode)
            {
                return seralizer.Deserialize<bool>(response.Content.ReadAsAsync<string>().Result);
            }
            return false;
        }

        private IEnumerable<UserProfileDTO> GetUserList()
        {
            JavaScriptSerializer seralizer = new JavaScriptSerializer();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("UserProfile").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<IEnumerable<UserProfileDTO>>().Result;
            }
            return null;
        }

        private IEnumerable<ResultLogDTO> GetLogList()
        {
            JavaScriptSerializer seralizer = new JavaScriptSerializer();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("Log").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<IEnumerable<ResultLogDTO>>().Result;
            }
            return null;
        }

        private IEnumerable<RoleDTO> GetRoleList()
        {
            JavaScriptSerializer seralizer = new JavaScriptSerializer();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("Role").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<IEnumerable<RoleDTO>>().Result;
            }
            return null;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                client = null;
                client = new HttpClient();
                JavaScriptSerializer seralizer = new JavaScriptSerializer();
                client.BaseAddress = new Uri("http://localhost:54999/api/");
                client.DefaultRequestHeaders.Accept.Clear();

                var token = Request.Cookies["Token"];
                if (token == null)
                {
                    Page.Visible = false;
                    Response.Redirect("Index.html");
                }

                var userName = Request.Cookies["UserName"].Value;

                (Master as OpenDoor).FullNamelabel = userName;

                if (!CheckLogin(token.Value.ToString()))
                {
                    Page.Visible = false;
                    Response.Redirect("Index.html");
                }
                menuDiv.Visible = IsEditingUserData(userName);


                var PageShow = Request.QueryString["P"];
                if (PageShow != null)
                    PageShow = PageShow.ToLower();

                switch (PageShow)
                {
                    case "logs":
                        LogsBindData();
                        break;
                    case "users":
                        UsersBindData();
                        break;
                    case "roles":
                        RolesBindData();
                        break;
                    default:
                        LogsBindData();
                        break;
                }

            }

        }


        private void LogsBindData()
        {
            TableTitleDiv.InnerText = "Logs History";
            IEnumerable<ResultLogDTO> List = GetLogList();

            string LogTableHtml = " <table class='table table-striped table-hover table-responsive table-condensed'>" +
                            "        <tr>" +
                            "            <th>" +
                            "                <h3 style='font-size:x-large'><span style='font-weight:bolder'>LogID</span></h3>" +
                            "            </th>" +
                            "            <th>" +
                            "                <h3 style='font-size:x-large'><span style='font-weight:bolder'>UserID</span></h3>" +
                            "            </th>" +
                            "            <th>" +
                            "                <h3 style='font-size:x-large'><span style='font-weight:bolder'>FullName</span></h3>" +
                            "            </th>" +
                            "            <th>" +
                            "                <h3 style='font-size:x-large'><span style='font-weight:bolder'>RFC</span></h3>" +
                            "            </th>" +
                            "            <th>" +
                            "                <h3 style='font-size:x-large'><span style='font-weight:bolder'>Date Time</span></h3>" +
                            "            </th>" +
                            "             <th>" +
                            "                <h3 style='font-size:x-large'><span style='font-weight:bolder'>Log Status</span></h3>" +
                            "            </th>" +
                            "             <th>" +
                            "                <h3 style='font-size:x-large'><span style='font-weight:bolder'>Actions</span></h3>" +
                            "            </th>" +
                            "            <th></th>" +
                            "        </tr>";
            if (List != null)
            {
                foreach (var item in List)
                {
                    LogTableHtml += "<tr>" +

                                      "                <td class='col-lg-1'>" +
                                      "                    <span style='font-size: 17px;'>" + item.LogID + "</span>" +
                                      "                </td>" +
                                      "                <td class='col-lg-1'>" +
                                      "                    <span style='font-size: 17px;'>" + item.UserProfileId + "</span>" +
                                      "                </td>" +
                                      "                <td class='col-lg-2'>" +
                                      "                    <span style='font-size: 17px;'>" + item.UserFullName + "</span>" +
                                      "                </td>" +
                                      "                <td class='col-lg-1'>" +
                                      "                    <span style='font-size: 17px;'>" + item.RFCCard + "</span>" +
                                      "                </td>" +
                                      "                <td class='col-lg-2'>" +
                                      "                    <span style='font-size: 17px;'>" + item.LoginDateTime + "</span>" +
                                      "                </td>" +
                                      "                 <td class='col-lg-2'>";
                    if (item.IsOpen)
                        LogTableHtml += "                    <span style='font-size: 17px;'><button type='button' class='btn btn-success IsOpenStatusLog'>Success</button></span>";
                    else
                        LogTableHtml += "                    <span style='font-size: 17px;'><button type='button' class='btn btn-danger IsOpenStatusLog'>Faild</button></span>";

                    LogTableHtml += "                </td>" +
                    "                <td class='col-lg-3'>";
                    if (item.LogPicIsExist)
                    {
                        LogTableHtml += "                    <button type='button' class='btn btn-info col-lg-3 col-lg-offset-1' onclick='LogImgView(" + item.LogID + ")'><span style='margin-right: 5px width:15px;' class='glyphicon glyphicon-paperclip'></span> img</button>";
                    }
                    LogTableHtml += "                </td>" +
                                    "            </tr>";

                }

            }



            LogTableHtml += "</table>";



            LogTableDiv.InnerHtml = LogTableHtml;
        }
        private void UsersBindData()
        {
            TableTitleDiv.InnerText = "Users";
            IEnumerable<UserProfileDTO> List = GetUserList();

            string UserTableHtml =
                                " <div class='row'>" +
                "            <div class='col-xs-12' id='Div1' runat='server'>" +
                "                <center>" +
                "                <button type='button' style='margin: 3px; width: 99.5%' class=' btn btn-danger col-lg-3 col-xs-3' onclick='AddNewUser()'><span style='font-size: larger;'><span style='margin-right: 5px' class='glyphicon glyphicon-plus-sign'></span>Add New User</span></button>" +
                "            </center></div>" +
                "        </div>" +
                " <table class='table table-striped table-hover table-responsive table-condensed'>" +
                                "        <tr>" +
                                "            <th>" +
                                "                <h3 style='font-size:x-large'><span style='font-weight:bolder'>UserID</span></h3>" +
                                "            </th>" +
                                "            <th>" +
                                "                <h3 style='font-size:x-large'><span style='font-weight:bolder'>Full Name</span></h3>" +
                                "            </th>" +
                                "            <th>" +
                                "                <h3 style='font-size:x-large'><span style='font-weight:bolder'>Email</span></h3>" +
                                "            </th>" +
                                "            <th>" +
                                "                <h3 style='font-size:x-large'><span style='font-weight:bolder'>Phone</span></h3>" +
                                "            </th>" +
                                "            <th>" +
                                "                <h3 style='font-size:x-large'><span style='font-weight:bolder'>Address</span></h3>" +
                                "            </th>" +
                                "             <th>" +
                                "                <h3 style='font-size:x-large'><span style='font-weight:bolder'>Actions</span></h3>" +
                                "            </th>" +
                                "            <th></th>" +
                                "        </tr>";
            if (List != null)
            {
                foreach (var item in List)
                {
                    UserTableHtml += "<tr>" +

                                      "                <td class='col-lg-1'>" +
                                      "                    <span style='font-size: 17px;'>" + item.UserID + "</span>" +
                                      "                </td>" +
                                      "                <td class='col-lg-2'>" +
                                      "                    <span style='font-size: 17px;'>" + item.Fname + " " + item.Lname + "</span>" +
                                      "                </td>" +
                                      "                <td class='col-lg-2'>" +
                                      "                    <span style='font-size: 17px;'>" + item.Email + "</span>" +
                                      "                </td>" +
                                      "                <td class='col-lg-2'>" +
                                      "                    <span style='font-size: 17px;'>" + item.Phone + "</span>" +
                                      "                </td>" +
                                      "                <td class='col-lg-2'>" +
                                      "                    <span style='font-size: 17px;'>" + item.Address + "</span>" +
                                      "                </td>" +
                                      "                 <td class='col-lg-3'>" +
                                      "                    <button type='button' class='btn btn-info col-lg-3 col-lg-offset-1 btnEditU' onclick='UserEdit(" + item.UserID + ")'><span style='margin-right: 5px width:15px;' class='glyphicon glyphicon-pencil'></span> Edit</button>" +
                                      "                    <button type='button' class='btn btn-info col-lg-3 col-lg-offset-1 btnDelU' onclick='UserDelete(" + item.UserID + ")'><span style='margin-right: 5px width:15px;' class='glyphicon glyphicon-remove'></span> Delete</button>" +
                                      "                </td>" +
                                      "            </tr>";

                }

            }



            UserTableHtml += "</table>";



            UsersTableDiv.InnerHtml = UserTableHtml;
        }
        private void RolesBindData()
        {
            TableTitleDiv.InnerText = "Roles";
            IEnumerable<RoleDTO> List = GetRoleList();

            string RoleTableHtml =
                                " <div class='row'>" +
                "            <div class='col-xs-12' id='Div1' runat='server'>" +
                "                <center>" +
                "                <button type='button' style='margin: 3px; width: 99.5%' class=' btn btn-danger col-lg-3 col-xs-3' onclick='AddNewRole()'><span style='font-size: larger;'><span style='margin-right: 5px' class='glyphicon glyphicon-plus-sign'></span>Add New Role</span></button>" +
                "            </center></div>" +
                "        </div>" +
                " <table class='table table-striped table-hover table-responsive table-condensed'>" +
                                "        <tr>" +
                                "            <th>" +
                                "                <h3 style='font-size:x-large'><span style='font-weight:bolder'>RoleID</span></h3>" +
                                "            </th>" +
                                "            <th>" +
                                "                <h3 style='font-size:x-large'><span style='font-weight:bolder'>Description</span></h3>" +
                                "            </th>" +
                                "        </tr>";
            if (List != null)
            {
                foreach (var item in List)
                {
                    RoleTableHtml +=
                        "<tr>" +
                        "                <td class='col-lg-1'>" +
                        "                    <span style='font-size: 17px;'>" + item.RoleID + "</span>" +
                        "                </td>" +
                        "                <td class='col-lg-2'>" +
                        "                    <span style='font-size: 17px;'>" + item.Description + "</span>" +
                        "                </td>" +
                        "            </tr>";
                }
            }

            RoleTableHtml += "</table>";



            RolesTableDiv.InnerHtml = RoleTableHtml;
        }
        void ClearDivsData()
        {
            TableTitleDiv.InnerText = "Roles";
            RolesTableDiv.InnerHtml = "";
            LogTableDiv.InnerHtml = "";
            UsersTableDiv.InnerHtml = "";
        }

    }
}