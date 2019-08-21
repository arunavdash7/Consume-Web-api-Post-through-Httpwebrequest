using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace PostCaseDataToExternalApplication.cs
{
    class Program
    {
        public static void Main(string[] args)
        {
            string url, auth;
            string authToken = GetBase64Token(out url, out auth);

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Headers.Add("Authorization", authToken);
            request.Method = "Post";
            string getJsonData = PostCaseDataToExternalWebApi(request);
            GetResponseFromExternalWebApi(request);
        }

        private static string GetBase64Token(out string url, out string auth)
        {
            string username = "Username";
            string password = "Password";
            url = "External Web Api Url";
            auth = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password));
            return auth;
        }

        private static string  PostCaseDataToExternalWebApi(HttpWebRequest request)
        {
            using (MemoryStream SerializememoryStream = new MemoryStream())
            {
                //create a sample data of type CaseDetails Class add details
                CaseRequest caseD = new CaseRequest();
                caseD.Description = "Description1";
                caseD.ServiceNowAssignmentGroup = "ServiceDesk";
                caseD.ServiceNowCallerId = "mycallerid";
                caseD.ServiceNowCatalogueName = "My Application Name";
                caseD.ServiceNowCategory = "Incident";
                caseD.ServiceNowContactType = "webservice";
                caseD.ServiceNowIncidentImpact = 3;
                caseD.ServiceNowIncidentPriority = 3;
                caseD.ServiceNowSubCategory = "Incident";
                caseD.ServiceNowTicketShortDescription = "Arunav Dash - Sample Exception generated";

                //initialize DataContractJsonSerializer object and pass Student class type to it
                var serializer = new DataContractJsonSerializer(caseD.GetType(), new DataContractJsonSerializerSettings
                {
                    UseSimpleDictionaryFormat = true
                });
                //write newly created object(NewStudent) into memory stream
                serializer.WriteObject(SerializememoryStream, caseD);

                SerializememoryStream.Position = 0;

                //use stream reader to read serialized data from memory stream
                StreamReader sr = new StreamReader(SerializememoryStream);
                //get JSON data serialized in string format in string variable
                string Serializedresult = sr.ReadToEnd();
                return Serializedresult;
            }

            //GetResponseFromExternalWebApi(request);
        }

        private static void GetResponseFromExternalWebApi(HttpWebRequest request)
        {
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                var res = new StreamReader(response.GetResponseStream()).ReadToEnd();
                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(res)))
                {
                    // Deserialization from JSON  
                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(CaseResponse));
                    CaseResponse caseObjResponse = (CaseResponse)deserializer.ReadObject(ms);
                    Console.WriteLine("Case Number: " + caseObjResponse.result.number);
                    Console.ReadLine();
                }
            }
        }
    }
}
