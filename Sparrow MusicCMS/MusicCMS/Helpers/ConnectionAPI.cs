using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.WebRequestMethods;
using System.Windows.Threading;
using MusicCMS.Views.UserControls;
using System.Windows.Controls;
using UserAccount = MusicCMS.Models.Data.UserAccount;
using Microsoft.AspNetCore.Http;
using Grpc.Core;
using System.Diagnostics;
using System.Collections.ObjectModel;
using static IdentityServer4.Models.IdentityResources;
using System.Security.Policy;
using System.Threading;
using NetTopologySuite.Index.HPRtree;
using MusicCMS.Models.Data;
using MusicCMS_Entities.Concrete.DatabaseFirst;
using System.Net.Http.Json;
using Playlist = MusicCMS.Models.Data.Playlist;
using System.Net;
using static IdentityServer4.IdentityServerConstants;
using PlaylistMusic = MusicCMS.Models.Data.PlaylistMusic;

namespace MusicCMS.Helpers
{
    public static class ConnectionAPI
    {

        public async static Task<string> Registration(HttpClient httpClient, string username, string password, string email, string connectionurl)
        {
            Apiuser apiuser = new Apiuser();

            apiuser.username = username;
            apiuser.password = password;
            apiuser.email = email;


            UserAccount userAccount = new UserAccount();

            userAccount.Username = apiuser.username;
            userAccount.UserPassword = apiuser.password;
            userAccount.UserEmail = apiuser.email;


            string? responsedata = string.Empty;
            string? responseuser_ = string.Empty;

            try
            {
                if (username!="Username" && password != "Password" && email != "Email address")
                {


                    string apiuser_jsondata = JsonConvert.SerializeObject(apiuser, Formatting.Indented);

                    StringContent httpContent = new StringContent(apiuser_jsondata, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(connectionurl, httpContent);


                    var response2 = await httpClient.PostAsync("https://localhost:7270/api/Authenticate/login", httpContent);

                    if (response2.IsSuccessStatusCode)
                    {

                        var token = await response2.Content.ReadAsStringAsync();

                        JObject jObject = JObject.Parse(token);


                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jObject["token"].ToString());

                        MessageBox.Show($"You token: {jObject["token"].ToString()}");



                        responsedata = await httpClient.GetStringAsync($"https://localhost:7270/api/Authenticate/getusers");

                        var UserAccounts = JsonConvert.DeserializeObject<ObservableCollection<UserAccount>>(responsedata);

                        var jsonoption = new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true };


                    

                        responseuser_ = await httpClient.GetStringAsync($"https://localhost:7270/MusicCMS/GetUserAccount");
                        var UserAccounts_ = JsonConvert.DeserializeObject<ObservableCollection<UserAccount>>(responseuser_);

                        if (!UserAccounts_.Any(u=>u.Username==username && u.UserEmail==email&& u.UserPassword==password))
                        {



                            string userAccount_jsondata = JsonConvert.SerializeObject(userAccount, Formatting.Indented);
                            StringContent httpContent2 = new StringContent(userAccount_jsondata, Encoding.UTF8, "application/json");
                            var responseuser = await httpClient.PostAsync("https://localhost:7270/MusicCMS/postuseraccount", httpContent2);



                            if (responseuser.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                var body = await responseuser.Content.ReadAsStringAsync();

                                MessageBox.Show(body);

                                var errorFromAPI = StatusError.ExtractErrorsFromWebAPIResponse(body);

                                foreach (var fieldwitherrors in errorFromAPI)
                                {
                                    // MessageBox.Show(fieldwitherrors.Key);

                                    foreach (var error in fieldwitherrors.Value)
                                    {

                                        MessageBox.Show(error);
                                    }
                                }

                            }

                        }





                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //MessageBox.Show(responsedata);

            return (await Task.FromResult(responseuser_));


        }

        public async static Task<string> LogiIn(HttpClient httpClient, string username, string password, string email, string connectionurl, CancellationTokenSource cts)
        {
            Apiuser apiuser = new Apiuser();

            apiuser.username = username;
            apiuser.password = password;
            apiuser.email = email;


            string? responsedata = string.Empty;
            try
            {

                if (username != "Username" && password != "Password")
                {

                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {



                        // Save the token for further requests.


                        string apiuser_jsondata = JsonConvert.SerializeObject(apiuser);

                        StringContent httpContent = new StringContent(apiuser_jsondata, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync(connectionurl, httpContent,cts.Token);

                        // Save the token for further requests.
                        var token = await response.Content.ReadAsStringAsync();

                        JObject jObject = JObject.Parse(token);

                        if (response.IsSuccessStatusCode)
                        {
                            // Set the authentication header. 

                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jObject["token"].ToString());

                            Debug.WriteLine(jObject["token"].ToString());


                            responsedata = await httpClient.GetStringAsync($"https://localhost:7270/MusicCMS/GetUserAccount");

                        }



                        // Set the authentication header. 

                    }
                    
                }

            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
            }

            //MessageBox.Show(responsedata);

            return (await Task.FromResult(responsedata));


        }


        public async static Task<string> LogOut(HttpClient httpClient, string username, string password, string email, string connectionurl)
        {
            Apiuser apiuser = new Apiuser();

            apiuser.username = username;
            apiuser.password = password;
            apiuser.email = email;


            string? responsedata = string.Empty;
            try
            {





                        // Save the token for further requests.


                        string apiuser_jsondata = JsonConvert.SerializeObject(apiuser);

                        StringContent httpContent = new StringContent(apiuser_jsondata, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync(connectionurl, httpContent);

                        // Save the token for further requests.
                        //var token = await response.Content.ReadAsStringAsync();

                        //JObject jObject = JObject.Parse(token);

                        //if (response.IsSuccessStatusCode)
                        //{
                        //    // Set the authentication header. 

                        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jObject["token"].ToString());

                        //    Debug.WriteLine(jObject["token"].ToString());

                        //}



                        // Set the authentication header. 

           

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //MessageBox.Show(responsedata);

            return (await Task.FromResult(responsedata));


        }



        public async static Task<string> GetMusic(HttpClient httpClient, string username, string password, string connectionurl)
        {
            Apiuser apiuser = new Apiuser();

            apiuser.username = username;
            apiuser.password = password;

            string?  responsedata= string.Empty;


            try
            {

                if (username != "Username" && password != "Password")
                {

                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {


                        string apiuser_jsondata = JsonConvert.SerializeObject(apiuser);

                        // Obtain a JWT token.
                        StringContent httpContent = new StringContent(apiuser_jsondata, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync(connectionurl, httpContent);

                        // Save the token for further requests.
                        var token = await response.Content.ReadAsStringAsync();

                        JObject jObject = JObject.Parse(token);

                        if (response.IsSuccessStatusCode)
                        {

                            // Set the authentication header. 
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jObject["token"].ToString());

                            //MessageBox.Show(jObject["token"].ToString());

                            responsedata = await httpClient.GetStringAsync($"https://localhost:7270/MusicCMS/GetMusic");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                

            }

            //MessageBox.Show(responsedata);

            return await Task.FromResult( responsedata);


        }



        public async static Task<string> GetRadio(HttpClient httpClient, string username, string password, string connectionurl)
        {
            Apiuser apiuser = new Apiuser();

            apiuser.username = username;
            apiuser.password = password;

            string? responsedata = string.Empty;

            try
            {

                if (username != "Username" && password != "Password")
                {

                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {



                        string apiuser_jsondata = JsonConvert.SerializeObject(apiuser);

                        // Obtain a JWT token.
                        StringContent httpContent = new StringContent(apiuser_jsondata, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync(connectionurl, httpContent);

                        // Save the token for further requests.
                        var token = await response.Content.ReadAsStringAsync();

                        JObject jObject = JObject.Parse(token);


                        if (response.IsSuccessStatusCode)
                        {
                            // Set the authentication header. 
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jObject["token"].ToString());

                            //MessageBox.Show(jObject["token"].ToString());

                            responsedata = await httpClient.GetStringAsync($"https://localhost:7270/MusicCMS/GetRadio");

                        }
                        

                    }
                }

                

            }
            catch (Exception ex)
            {

             
            }

            //MessageBox.Show(responsedata);

            return await Task.FromResult(responsedata);


        }



        public async static Task<string> GetArtist(HttpClient httpClient, string username, string password, string connectionurl)
        {
            Apiuser apiuser = new Apiuser();

            apiuser.username = username;
            apiuser.password = password;

            string? responsedata = string.Empty;

            try
            {

                if (username != "Username" && password != "Password")
                {

                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {



                        string apiuser_jsondata = JsonConvert.SerializeObject(apiuser);

                        // Obtain a JWT token.
                        StringContent httpContent = new StringContent(apiuser_jsondata, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync(connectionurl, httpContent);

                        // Save the token for further requests.
                        var token = await response.Content.ReadAsStringAsync();

                        JObject jObject = JObject.Parse(token);


                        if (response.IsSuccessStatusCode)
                        {
                            // Set the authentication header. 
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jObject["token"].ToString());

                            //MessageBox.Show(jObject["token"].ToString());

                            responsedata = await httpClient.GetStringAsync($"https://localhost:7270/MusicCMS/GetArtist");

                        }


                    }
                }



            }
            catch (Exception ex)
            {


            }

            //MessageBox.Show(responsedata);

            return await Task.FromResult(responsedata);


        }



        public async static Task<string> GetAlbum(HttpClient httpClient, string username, string password, string connectionurl)
        {
            Apiuser apiuser = new Apiuser();

            apiuser.username = username;
            apiuser.password = password;

            string? responsedata = string.Empty;

            try
            {

                if (username != "Username" && password != "Password")
                {

                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {



                        string apiuser_jsondata = JsonConvert.SerializeObject(apiuser);

                        // Obtain a JWT token.
                        StringContent httpContent = new StringContent(apiuser_jsondata, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync(connectionurl, httpContent);

                        // Save the token for further requests.
                        var token = await response.Content.ReadAsStringAsync();

                        JObject jObject = JObject.Parse(token);


                        if (response.IsSuccessStatusCode)
                        {
                            // Set the authentication header. 
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jObject["token"].ToString());

                            //MessageBox.Show(jObject["token"].ToString());

                            responsedata = await httpClient.GetStringAsync($"https://localhost:7270/MusicCMS/GetAlbum");

                   

                        }


                    }
                }



            }
            catch (Exception ex)
            {


            }

            //MessageBox.Show(responsedata);

            return await Task.FromResult(responsedata);


        }



        public async static Task<string> GetArtistAlbum(HttpClient httpClient, string username, string password, string connectionurl)
        {
            Apiuser apiuser = new Apiuser();

            apiuser.username = username;
            apiuser.password = password;

            string? responsedata = string.Empty;

            try
            {

                if (username != "Username" && password != "Password")
                {

                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {



                        string apiuser_jsondata = JsonConvert.SerializeObject(apiuser);

                        // Obtain a JWT token.
                        StringContent httpContent = new StringContent(apiuser_jsondata, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync(connectionurl, httpContent);

                        // Save the token for further requests.
                        var token = await response.Content.ReadAsStringAsync();

                        JObject jObject = JObject.Parse(token);


                        if (response.IsSuccessStatusCode)
                        {
                            // Set the authentication header. 
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jObject["token"].ToString());

                            //MessageBox.Show(jObject["token"].ToString());

                            responsedata = await httpClient.GetStringAsync($"https://localhost:7270/MusicCMS/GetArtistAlbum");



                        }


                    }
                }



            }
            catch (Exception ex)
            {


            }

            //MessageBox.Show(responsedata);

            return await Task.FromResult(responsedata);


        }



        public async static Task<string> GetMusicAlbum(HttpClient httpClient, string username, string password, string connectionurl)
        {
            Apiuser apiuser = new Apiuser();

            apiuser.username = username;
            apiuser.password = password;

            string? responsedata = string.Empty;

            try
            {

                if (username != "Username" && password != "Password")
                {

                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {



                        string apiuser_jsondata = JsonConvert.SerializeObject(apiuser);

                        // Obtain a JWT token.
                        StringContent httpContent = new StringContent(apiuser_jsondata, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync(connectionurl, httpContent);

                        // Save the token for further requests.
                        var token = await response.Content.ReadAsStringAsync();

                        JObject jObject = JObject.Parse(token);


                        if (response.IsSuccessStatusCode)
                        {
                            // Set the authentication header. 
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jObject["token"].ToString());

                            //MessageBox.Show(jObject["token"].ToString());

                            responsedata = await httpClient.GetStringAsync($"https://localhost:7270/MusicCMS/GetMusicAlbum");



                        }


                    }
                }



            }
            catch (Exception ex)
            {


            }

            //MessageBox.Show(responsedata);

            return await Task.FromResult(responsedata);


        }


        public async static Task<string> GetUserAccount(HttpClient httpClient, string username, string password, string connectionurl)
        {
            Apiuser apiuser = new Apiuser();

            apiuser.username = username;
            apiuser.password = password;

            string? responsedata = string.Empty;

            try
            {

                if (username != "Username" && password != "Password")
                {

                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {



                        string apiuser_jsondata = JsonConvert.SerializeObject(apiuser);

                        // Obtain a JWT token.
                        StringContent httpContent = new StringContent(apiuser_jsondata, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync(connectionurl, httpContent);

                        // Save the token for further requests.
                        var token = await response.Content.ReadAsStringAsync();

                        JObject jObject = JObject.Parse(token);


                        if (response.IsSuccessStatusCode)
                        {
                            // Set the authentication header. 
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jObject["token"].ToString());

                            //MessageBox.Show(jObject["token"].ToString());

                            responsedata = await httpClient.GetStringAsync($"https://localhost:7270/MusicCMS/GetUserAccount");



                        }


                    }
                }



            }
            catch (Exception ex)
            {


            }

            //MessageBox.Show(responsedata);

            return await Task.FromResult(responsedata);


        }


        public async static Task<string> GetPlaylist(HttpClient httpClient, string username, string password, string connectionurl)
        {
            Apiuser apiuser = new Apiuser();

            apiuser.username = username;
            apiuser.password = password;

            string? responsedata = string.Empty;

            try
            {


                string apiuser_jsondata = JsonConvert.SerializeObject(apiuser);

                // Obtain a JWT token.
                StringContent httpContent = new StringContent(apiuser_jsondata, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(connectionurl, httpContent);

                // Save the token for further requests.
                var token = await response.Content.ReadAsStringAsync();

                JObject jObject = JObject.Parse(token);

                // Set the authentication header. 
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jObject["token"].ToString());

                //MessageBox.Show(jObject["token"].ToString());

                responsedata = await httpClient.GetStringAsync($"https://localhost:7270/MusicCMS/GetPlaylist");

            }
            catch (Exception ex)
            {


            }

            //MessageBox.Show(responsedata);

            return await Task.FromResult(responsedata);


        }


        public async static Task PostPlaylist(HttpClient httpClient, string username, string password, string connectionurl, Models.Data.Playlist playlist)
        {
            Apiuser apiuser = new Apiuser();

            apiuser.username = username;
            apiuser.password = password;

      

            try
            {


                string apiuser_jsondata = JsonConvert.SerializeObject(apiuser);

                // Obtain a JWT token.
                StringContent httpContent = new StringContent(apiuser_jsondata, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(connectionurl, httpContent);

                // Save the token for further requests.
                var token = await response.Content.ReadAsStringAsync();

                JObject jObject = JObject.Parse(token);

                // Set the authentication header. 
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jObject["token"].ToString());

                //MessageBox.Show(jObject["token"].ToString());

      
                string userAccount_jsondata = JsonConvert.SerializeObject(playlist, Formatting.Indented);
                StringContent httpContent2 = new StringContent(userAccount_jsondata, Encoding.UTF8, "application/json");
                var responseuser = await httpClient.PostAsync("https://localhost:7270/MusicCMS/postplaylist", httpContent2);



                if (responseuser.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var body = await responseuser.Content.ReadAsStringAsync();

                    MessageBox.Show(body);

                    var errorFromAPI = StatusError.ExtractErrorsFromWebAPIResponse(body);

                    foreach (var fieldwitherrors in errorFromAPI)
                    {
                         MessageBox.Show(fieldwitherrors.Key);

                        foreach (var error in fieldwitherrors.Value)
                        {

                            MessageBox.Show(error);
                        }
                    }

                }

            }
            catch (Exception ex)
            {


            }

            //MessageBox.Show(responsedata);

            //return await Task.FromResult(responsedata);


        }

        public async static Task DeletePlaylist(HttpClient httpClient, string username, string password, string connectionurl, Playlist playlist)
        {
            Apiuser apiuser = new Apiuser();

            apiuser.username = username;
            apiuser.password = password;

            string message = string.Empty;


            try
            {




                string apiuser_jsondata = JsonConvert.SerializeObject(apiuser);

                // Obtain a JWT token.
                StringContent httpContent = new StringContent(apiuser_jsondata, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(connectionurl, httpContent);

                // Save the token for further requests.
                var token = await response.Content.ReadAsStringAsync();

                JObject jObject = JObject.Parse(token);

                // Set the authentication header. 
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jObject["token"].ToString());

                //MessageBox.Show(jObject["token"].ToString());




                var response_ = await httpClient.DeleteAsync(@$"https://localhost:7270/MusicCMS/DeletePlaylist/{playlist.IdPlaylist}");




                //if (response_.StatusCode == System.Net.HttpStatusCode.BadRequest)
                //{
                //    var body = await response_.Content.ReadAsStringAsync();

                //    //MessageBox.Show(body);

                //    var errorFromAPI = StatusError.ExtractErrorsFromWebAPIResponse(body);

                //    foreach (var fieldwitherrors in errorFromAPI)
                //    {
                //        //MessageBox.Show(fieldwitherrors.Key);

                //        foreach (var error in fieldwitherrors.Value)
                //        {

                //            MessageBox.Show(error);
                //        }
                //    }

                //}

            }
            catch (HttpRequestException e)
            {
                message = e.InnerException.Message;

            }

            //MessageBox.Show(responsedata);

            //return await Task.FromResult(responsedata);


        }


        public async static Task PostPlaylistMusic(HttpClient httpClient, string username, string password, string connectionurl, PlaylistMusic playlistMusic)
        {
            Apiuser apiuser = new Apiuser();

            apiuser.username = username;
            apiuser.password = password;



            try
            {


                string apiuser_jsondata = JsonConvert.SerializeObject(apiuser);

                // Obtain a JWT token.
                StringContent httpContent = new StringContent(apiuser_jsondata, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(connectionurl, httpContent);

                // Save the token for further requests.
                var token = await response.Content.ReadAsStringAsync();

                JObject jObject = JObject.Parse(token);

                // Set the authentication header. 
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jObject["token"].ToString());

                //MessageBox.Show(jObject["token"].ToString());


                string userAccount_jsondata = JsonConvert.SerializeObject(playlistMusic, Formatting.Indented);
                StringContent httpContent2 = new StringContent(userAccount_jsondata, Encoding.UTF8, "application/json");
                var responseuser = await httpClient.PostAsync("https://localhost:7270/MusicCMS/PostPlaylistMusic", httpContent2);



                if (responseuser.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var body = await responseuser.Content.ReadAsStringAsync();

                    MessageBox.Show(body);

                    var errorFromAPI = StatusError.ExtractErrorsFromWebAPIResponse(body);

                    foreach (var fieldwitherrors in errorFromAPI)
                    {
                        MessageBox.Show(fieldwitherrors.Key);

                        foreach (var error in fieldwitherrors.Value)
                        {

                            MessageBox.Show(error);
                        }
                    }

                }

            }
            catch (Exception ex)
            {


            }

            //MessageBox.Show(responsedata);

            //return await Task.FromResult(responsedata);


        }


        public async static Task<string> GetPlaylistMusic(HttpClient httpClient, string username, string password, string connectionurl)
        {
            Apiuser apiuser = new Apiuser();

            apiuser.username = username;
            apiuser.password = password;

            string? responsedata = string.Empty;

            try
            {


                string apiuser_jsondata = JsonConvert.SerializeObject(apiuser);

                // Obtain a JWT token.
                StringContent httpContent = new StringContent(apiuser_jsondata, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(connectionurl, httpContent);

                // Save the token for further requests.
                var token = await response.Content.ReadAsStringAsync();

                JObject jObject = JObject.Parse(token);

                // Set the authentication header. 
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jObject["token"].ToString());

                //MessageBox.Show(jObject["token"].ToString());

                responsedata = await httpClient.GetStringAsync($"https://localhost:7270/MusicCMS/GetPlaylistMusic");

            }
            catch (Exception ex)
            {


            }

            //MessageBox.Show(responsedata);

            return await Task.FromResult(responsedata);


        }
    }


}
