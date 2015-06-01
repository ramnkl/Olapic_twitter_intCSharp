using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Web;
using System.IO;

namespace Olapic.Lib
{
  public  class OlapicMgr
    {

        public string ApiKey { get; set; }
        public string MediaEndpoint { get; set; }
      public string StreamEndpoint { get; set; }

      public string GetBaseParameter()
      {
         var baseParam = string.Format("?auth_token={0}&version=v2.2" ,ApiKey);
         return baseParam;
      }


      public async Task<IEnumerable<string>> GetRecentPhotos()
        {

            var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get, string.Format("{0}{1}", MediaEndpoint, GetBaseParameter()));
            //requestUserTimeline.Headers.Add("Authorization", "Bearer " + accessToken);
            var httpClient = new HttpClient();
            HttpResponseMessage responseUserTimeLine = await httpClient.SendAsync(requestUserTimeline);
            var serializer = new JavaScriptSerializer();

           var  obj = ConstructData<RootObject>(responseUserTimeLine);
           return null;
           // var _httpWReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(string.Format("{0}{1}", MediaEndpoint, GetBaseParameter()));

           // var encoding = new ASCIIEncoding();
           //// var data = encoding.GetBytes("number=xxxx&password=xxxx");

           // _httpWReq.Method = "GET";
           // _httpWReq.ContentType = "application/json";
           // //_httpWReq.ContentLength = data.Length;

           // //using (var stream = _httpWReq.GetRequestStream())
           // //{
           // //    stream.Write(data, 0, data.Length);
           // //}

           // var x = (HttpWebResponse)_httpWReq.GetResponse(); //the exception :(
           // var strResult = new StreamReader(x.GetResponseStream()).ReadToEnd();
           // var serializer = new JavaScriptSerializer();
           // RootObject obj = JsonConvert.DeserializeObject<RootObject>(strResult);
           // //var obj = ConstructData<RootObject>(strResult);
           // return obj; 

            ////var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get, string.Format("{0}{1}", MediaEndpoint, GetBaseParameter()));
            ////requestUserTimeline.Headers.Add("Authorization", "Bearer " + accessToken);
            //Task< RootObject> obj = null;
            //HttpClient proxy = new HttpClient();
            
            //    proxy.GetAsync(string.Format("{0}{1}", MediaEndpoint, GetBaseParameter())).ContinueWith((r) =>
            //    {
            //        HttpResponseMessage response = r.Result;
            //        var serializer = new JavaScriptSerializer();
            //        obj = ConstructData<RootObject>(response);


            //    });
            
            //return obj;
            
           //// requestUserTimeline.Headers.Add()
           // using (var httpClient = new HttpClient())r
           // {
           //     //lient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           //     HttpResponseMessage responseUserTimeLine = await httpClient.SendAsync(requestUserTimeline);
           //     var serializer = new JavaScriptSerializer();
           //     var obj = ConstructData<RootObject>(responseUserTimeLine);
           //     //dynamic json = serializer.Deserialize<object>(await responseUserTimeLine.Content.ReadAsStringAsync());
           //     //var enumerableOlapic = (json as IEnumerable<dynamic>);

           //     //if (enumerableOlapic == null)
           //     //{
           //     //    return null;
           //     //}
           //     //return enumerableOlapic.Select(t => (string)(t["text"].ToString()));
           //     return null;
           // }

            
        }


        public async Task<T> ConstructData<T>(HttpResponseMessage response)
        {
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(data.Substring(0, 1)))
                        data = data.Substring(1);
                    T result = JsonConvert.DeserializeObject<T>(data);
                    return result;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(response.ToString());
                    throw new Exception(response.ToString());
                }
            }
            catch (Exception ex)
            {
                //var responseError = this.ConstructData<ResponseError>(response);
                //if (responseError.Result !=null)
                //{
                //   if( responseError.Result.Code !="200" || responseError.Result.HttpCode != "200")
                //   {
                //       throw new Exception("");
                //   }
                //}

                throw;
            }
        }

        //public async Task<string> GetAccessToken()
        //{
        //    var httpClient = new HttpClient();
        //    var request = new HttpRequestMessage(HttpMethod.Post, "https://api.twitter.com/oauth2/token ");
        //    var customerInfo = Convert.ToBase64String(new UTF8Encoding().GetBytes(OAuthConsumerKey + ":" + OAuthConsumerSecret));
        //    request.Headers.Add("Authorization", "Basic " + customerInfo);
        //    request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

        //    HttpResponseMessage response = await httpClient.SendAsync(request);

        //    string json = await response.Content.ReadAsStringAsync();
        //    var serializer = new JavaScriptSerializer();
        //    dynamic item = serializer.Deserialize<object>(json);
        //    return item["access_token"];
        //}


    }


//    https://photorankapi-a.akamaihd.net/customers/217064/media/photorank?auth_token=8eb975f77afdb5309af98507ce52477d137d1445bf1de2d0039deba508b12c51&version=v2.2

    public class Metadata
{
    public int code { get; set; }
    public string message { get; set; }
    public string version { get; set; }
}

public class Self
{
    public string href { get; set; }
}

public class First
{
    public string href { get; set; }
}

public class Prev
{
    public string href { get; set; }
}

public class Next
{
    public string href { get; set; }
}

public class Links
{
    public Self self { get; set; }
    public First first { get; set; }
    public Prev prev { get; set; }
    public Next next { get; set; }
}

public class Self2
{
    public string href { get; set; }
}

public class Links2
{
    public Self2 self { get; set; }
}

public class Location
{
    public double latitude { get; set; }
    public double longitude { get; set; }
}

public class InstagramLocation
{
    public string id { get; set; }
    public string hash { get; set; }
    public string name { get; set; }
}

public class Geopoint
{
    public double lon { get; set; }
    public double lat { get; set; }
}

public class SonarPlace
{
    public object geocode { get; set; }
    public string id { get; set; }
    public InstagramLocation instagram_location { get; set; }
    public object source { get; set; }
    public string name { get; set; }
    public Geopoint geopoint { get; set; }
    public object url { get; set; }
    public string name_raw { get; set; }
}

public class Images
{
    public string square { get; set; }
    public string thumbnail { get; set; }
    public string mobile { get; set; }
    public string normal { get; set; }
    public string original { get; set; }
}

public class Self3
{
    public string href { get; set; }
}

public class Links3
{
    public Self3 self { get; set; }
}

public class Instagram
{
    public string source_id { get; set; }
    public string username { get; set; }
}

public class Facebook
{
    public string source_id { get; set; }
    public object username { get; set; }
}

public class SocialConnections
{
    public Instagram instagram { get; set; }
    public Facebook facebook { get; set; }
}

public class Self4
{
    public string href { get; set; }
}

public class Links4
{
    public Self4 self { get; set; }
}

public class MediaRecent
{
    public Links4 _links { get; set; }
}

public class Embedded3
{
    public MediaRecent __invalid_name__media_recent { get; set; }
}

public class Action
{
    public string href { get; set; }
}

public class Field
{
    public string type { get; set; }
    public string prompt { get; set; }
    public string name { get; set; }
    public string value { get; set; }
    public string placeholder { get; set; }
}

public class MediaUpload
{
    public string title { get; set; }
    public Action action { get; set; }
    public string method { get; set; }
    public List<Field> fields { get; set; }
}

public class Forms
{
    public MediaUpload __invalid_name__media_upload { get; set; }
}

public class Uploader
{
    public Links3 _links { get; set; }
    public string id { get; set; }
    public bool _fixed { get; set; }
    public string name { get; set; }
    public string avatar_url { get; set; }
    public string language { get; set; }
    public string username { get; set; }
    public SocialConnections social_connections { get; set; }
    public Embedded3 _embedded { get; set; }
    public Forms _forms { get; set; }
}

public class Self5
{
    public string href { get; set; }
}

public class Links5
{
    public Self5 self { get; set; }
}

public class Embedded4
{
    public object stream { get; set; }
}

public class StreamsAll
{
    public Links5 _links { get; set; }
    public bool _fixed { get; set; }
    public Embedded4 _embedded { get; set; }
}

public class Self6
{
    public string href { get; set; }
}

public class Links6
{
    public Self6 self { get; set; }
}

public class Embedded5
{
    public object category { get; set; }
}

public class CategoriesAll
{
    public Links6 _links { get; set; }
    public bool _fixed { get; set; }
    public Embedded5 _embedded { get; set; }
}

public class Embedded2
{
    public Uploader uploader { get; set; }
    public StreamsAll __invalid_name__streams_all { get; set; }
    public CategoriesAll __invalid_name__categories_all { get; set; }
}

public class Action2
{
    public string href { get; set; }
}

public class Field2
{
    public string type { get; set; }
    public string prompt { get; set; }
    public string name { get; set; }
    public string value { get; set; }
    public string placeholder { get; set; }
}

public class Report
{
    public string title { get; set; }
    public Action2 action { get; set; }
    public string method { get; set; }
    public List<Field2> fields { get; set; }
}

public class Forms2
{
    public Report report { get; set; }
}

public class Analytics
{
    public string oid { get; set; }
    public string t { get; set; }
    public List<string> meta { get; set; }
}

public class Medium
{
    public Links2 _links { get; set; }
    public string id { get; set; }
    public bool _fixed { get; set; }
    public string type { get; set; }
    public string source { get; set; }
    public string source_id { get; set; }
    public string original_source { get; set; }
    public string caption { get; set; }
    public object video_url { get; set; }
    public string share_url { get; set; }
    public string date_submitted { get; set; }
    public string date_published { get; set; }
    public bool favorite { get; set; }
    public Location location { get; set; }
    public SonarPlace sonar_place { get; set; }
    public string original_image_width { get; set; }
    public string original_image_height { get; set; }
    public string status { get; set; }
    public string likes { get; set; }
    public object request_id { get; set; }
    public Images images { get; set; }
    public Embedded2 _embedded { get; set; }
    public Forms2 _forms { get; set; }
    public Analytics _analytics { get; set; }
}

public class Self7
{
    public string href { get; set; }
}

public class Links7
{
    public Self7 self { get; set; }
}

public class CustomerDependant
{
    public string viewer { get; set; }
    public string widget { get; set; }
    public string uploader { get; set; }
    public string assets2 { get; set; }
}

public class Settings
{
    public bool force_viewer_modal { get; set; }
    public string column_number { get; set; }
    public string items_per_page { get; set; }
    public string uploader_actions { get; set; }
    public string show_in_home { get; set; }
    public int show_in_home_id { get; set; }
    public bool force_https { get; set; }
    public int ab_testing { get; set; }
    public string olapicU { get; set; }
    public CustomerDependant customer_dependant { get; set; }
    public string analytics_cookie_domain { get; set; }
    public bool premoderation { get; set; }
    public bool tagging { get; set; }
    public string analytics_api_version { get; set; }
    public string analytics_checkout_file_prefix { get; set; }
    public bool analytics_dashboard_engagement { get; set; }
}

public class Views
{
    public string viewer { get; set; }
    public string uploader { get; set; }
}

public class Self8
{
    public string href { get; set; }
}

public class Links8
{
    public Self8 self { get; set; }
}

public class User
{
    public Links8 _links { get; set; }
    public string id { get; set; }
    public bool _fixed { get; set; }
}

public class Self9
{
    public string href { get; set; }
}

public class Links9
{
    public Self9 self { get; set; }
}

public class Media
{
    public Links9 _links { get; set; }
    public bool _fixed { get; set; }
}

public class Self10
{
    public string href { get; set; }
}

public class Links10
{
    public Self10 self { get; set; }
}

public class MediaRecent2
{
    public Links10 _links { get; set; }
    public bool _fixed { get; set; }
}

public class Self11
{
    public string href { get; set; }
}

public class Links11
{
    public Self11 self { get; set; }
}

public class MediaShuffled
{
    public Links11 _links { get; set; }
    public bool _fixed { get; set; }
}

public class Self12
{
    public string href { get; set; }
}

public class Links12
{
    public Self12 self { get; set; }
}

public class MediaPhotorank
{
    public Links12 _links { get; set; }
    public bool _fixed { get; set; }
}

public class Self13
{
    public string href { get; set; }
}

public class Links13
{
    public Self13 self { get; set; }
}

public class MediaRated
{
    public Links13 _links { get; set; }
    public bool _fixed { get; set; }
}

public class Embedded6
{
    public User user { get; set; }
    public Media media { get; set; }
    public MediaRecent2 __invalid_name__media_recent { get; set; }
    public MediaShuffled __invalid_name__media_shuffled { get; set; }
    public MediaPhotorank __invalid_name__media_photorank { get; set; }
    public MediaRated __invalid_name__media_rated { get; set; }
}

public class Action3
{
    public string href { get; set; }
}

public class Field3
{
    public string type { get; set; }
    public string prompt { get; set; }
    public string name { get; set; }
    public string value { get; set; }
    public string placeholder { get; set; }
}

public class StreamsSearch
{
    public string title { get; set; }
    public Action3 action { get; set; }
    public string method { get; set; }
    public List<Field3> fields { get; set; }
}

public class Action4
{
    public string href { get; set; }
}

public class Field4
{
    public string type { get; set; }
    public string prompt { get; set; }
    public string name { get; set; }
    public string value { get; set; }
    public string placeholder { get; set; }
}

public class CategoriesSearch
{
    public string title { get; set; }
    public Action4 action { get; set; }
    public string method { get; set; }
    public List<Field4> fields { get; set; }
}

public class Action5
{
    public string href { get; set; }
}

public class Field5
{
    public string type { get; set; }
    public string prompt { get; set; }
    public string name { get; set; }
    public string value { get; set; }
    public string placeholder { get; set; }
}

public class StashesCreate
{
    public string title { get; set; }
    public Action5 action { get; set; }
    public string method { get; set; }
    public List<Field5> fields { get; set; }
}

public class Action6
{
    public string href { get; set; }
}

public class Field6
{
    public string type { get; set; }
    public string prompt { get; set; }
    public string name { get; set; }
    public string value { get; set; }
    public string placeholder { get; set; }
}

public class UsersCreate
{
    public string title { get; set; }
    public Action6 action { get; set; }
    public string method { get; set; }
    public List<Field6> fields { get; set; }
}

public class Forms3
{
    public StreamsSearch __invalid_name__streams_search { get; set; }
    public CategoriesSearch __invalid_name__categories_search { get; set; }
    public StashesCreate __invalid_name__stashes_create { get; set; }
    public UsersCreate __invalid_name__users_create { get; set; }
}

public class Customer
{
    public Links7 _links { get; set; }
    public string id { get; set; }
    public bool _fixed { get; set; }
    public string name { get; set; }
    public string domain { get; set; }
    public string template_dir { get; set; }
    public string language { get; set; }
    public Settings settings { get; set; }
    public Views views { get; set; }
    public Embedded6 _embedded { get; set; }
    public Forms3 _forms { get; set; }
}

public class Embedded
{
    public List<Medium> media { get; set; }
    public Customer customer { get; set; }
}

public class Data
{
    public Links _links { get; set; }
    public Embedded _embedded { get; set; }
}

public class RootObject
{
    public Metadata metadata { get; set; }
    public Data data { get; set; }
}
}
