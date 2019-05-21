using System;
using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using Assert = NUnit.Framework.Assert;

namespace RestSharpAPIAutomationTest
{

    public class RestSharpAPITest
    {

        public int HTTP_RESPONSE_CODE_200 = 200; // OK --> The request was successfully completed.  
        public int HTTP_RESPONSE_CODE_201 = 201; // Created --> A new resource was successfully created.
        public int HTTP_RESPONSE_CODE_400 = 400; //Bad Request --> The request was invalid.
        public int HTTP_RESPONSE_CODE_202 = 202; //Accepted --> The request has been accepted for processing, but the processing has not been completed.
        public int HTTP_RESPONSE_CODE_204 = 204; // No Content --> The server has fulfilled the request but does not need to return an entity-body, and might want to return updated metainformation. 
        public int HTTP_RESPONSE_CODE_203 = 203; // Non-Authoritative Information --> 
        public int HTTP_RESPONSE_CODE_401 = 401; // Unauthorized --> The request requires user authentication

        public String HTTP_RESPONSE_STATUS_OK = "OK";
        public String HTTP_RESPONSE_STATUS_Created = "Created";
        public String HTTP_RESPONSE_STATUS_Bad_Request = "Bad Request";


        [Test]
        public void GetPhotoInfo()
        {
            try
            {
                // This will set the URL property for requests made by the clients instance
                RestClient restClientObj = new RestClient("https://jsonplaceholder.typicode.com/photos");

                // restClientObj.Authenticator = new HttpBasicAuthenticator(username, password);

                // This is the container for the data used to make request
                RestRequest restRequestObj = new RestRequest("2", Method.GET);

                // This is the container for data sent back from API
                IRestResponse irestResponseObj = restClientObj.Execute(restRequestObj);

                // This will get content of executed URL
                string contentOfURL = irestResponseObj.Content;
                Console.WriteLine(contentOfURL);

                if (!contentOfURL.Contains("reprehenderit est deserunt velit ipsam"))
                {
                    Assert.Fail("Photo information is not displayed");
                }

                // This will contains the values of status codes defined for HTTP
                HttpStatusCode objHttpStatusCode = irestResponseObj.StatusCode;

                // This will verify the status code i.e, OK
                Console.WriteLine("Status of code is " + objHttpStatusCode.ToString());
                string expectedStatusCode = objHttpStatusCode.ToString();
                Assert.AreEqual(expectedStatusCode, "OK");

                // This will verify if response code i.e, 200
                int expectedResponseCode = (int)objHttpStatusCode;
                Console.WriteLine("Response code is : " + expectedResponseCode);
                Assert.AreEqual(expectedResponseCode, 200);

                // This will verify the status of response i.e, completed
                string exepctedResponseStatus = irestResponseObj.ResponseStatus.ToString();
                Console.WriteLine("Response of status is : " + exepctedResponseStatus);
                Assert.AreEqual(exepctedResponseStatus, "Completed");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Test]
        public void GETActivitiesInfo1()
        {
            try
            {
                RestClient restClientObj = new RestClient("http://fakerestapi.azurewebsites.net/api/Activities");
                RestRequest restRequestObj = new RestRequest("2", Method.GET);
                IRestResponse irestResponseObj = restClientObj.Execute(restRequestObj);

                HttpStatusCode status = irestResponseObj.StatusCode;
                int responseCode = (int)status;
                Console.WriteLine("Response Code is : " + responseCode);

                string responseStatus = status.ToString();
                Console.WriteLine("Status of response  is : " + responseStatus);

                // This will get all content by executing below request and stored in IRestResponse interface object
                RestRequest restRequestObj1 = new RestRequest(Method.GET);
                restRequestObj1.AddHeader("Accept", "application/json");
                IRestResponse irestResponseObj1 = restClientObj.Execute(restRequestObj1);

                String str2 = irestResponseObj1.Content;
                Console.WriteLine(str2);

                RestRequest postDataObj = new RestRequest(Method.POST);
                postDataObj.AddHeader("Content-Type", "application/json");
                postDataObj.AddParameter("ID", 90);
                postDataObj.AddParameter("Title", "Activity 90");
                postDataObj.AddJsonBody(postDataObj);

                IRestResponse postResponseObj = restClientObj.Execute(postDataObj);
                int statusOfCode = (int)postResponseObj.StatusCode;
                Console.WriteLine("Status of code executed of POST request is " + statusOfCode);

                String responseOfStatus = postResponseObj.StatusCode.ToString();
                Console.WriteLine("Status of response is : " + responseOfStatus);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        RestAPIHelper obj;

        [Test]
        public void GETActivitiesInfo()
        {

            String baseURL = "http://fakerestapi.azurewebsites.net";
            String endPointURL = "/api/Activities";
            try
            {
                obj = new RestAPIHelper();
                RestClient client = RestAPIHelper.URLSetUp(baseURL, endPointURL);
                RestRequest request = RestAPIHelper.CreateGETRequest();
                IRestResponse respponse = RestAPIHelper.GetResponse();
                String responseFromGetRequest = respponse.Content;
                Console.WriteLine(responseFromGetRequest);               
                HttpStatusCode statusCode = respponse.StatusCode;
                int statusCodeOfResponseIs = (int)statusCode;
                String StatusOfResponseIs = statusCode.ToString();
                Assert.AreEqual(statusCodeOfResponseIs, HTTP_RESPONSE_CODE_200, "Not getting success response code message");
                Assert.AreEqual(StatusOfResponseIs, HTTP_RESPONSE_STATUS_OK, "Not getting success response status message");

                Console.WriteLine("Response code is : " + statusCodeOfResponseIs + " after getting of all entities of GET request" );
                Console.WriteLine("The status of response is : " + StatusOfResponseIs + " after getting of all entities of GET request");

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Test]
        public void GETParticularEntityData()
        {
            String baseURL = "http://fakerestapi.azurewebsites.net";
            String endPointURL = "/api/Activities";
            String enterValue = "5";
            try
            {
                obj = new RestAPIHelper();
                RestClient client=RestAPIHelper.URLSetUp(baseURL, endPointURL);
                RestRequest request=RestAPIHelper.CreateRequestBasisOnParameter(enterValue);
                IRestResponse respponse=RestAPIHelper.GetResponse();
                String singleUserActivitiesInfo=respponse.Content;
                Console.WriteLine(singleUserActivitiesInfo);

                HttpStatusCode httpStatusCode =respponse.StatusCode;
                int responseCode = (int)httpStatusCode;
                string responseStatus = respponse.StatusCode.ToString();

                Console.WriteLine("Response code is : " + responseCode + " after getting an single user entity data --> " + enterValue);
                Console.WriteLine("The status of response is : " + responseStatus + " after getting an single user entity data --> " + enterValue);

                Assert.AreEqual(responseCode, HTTP_RESPONSE_CODE_200, "Not getting success response code message");
                Assert.AreEqual(responseStatus, HTTP_RESPONSE_STATUS_OK, "Not getting success response status message");
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [Test]
        public void POSTActivitiesInfo()
        {
            String baseURL = "http://fakerestapi.azurewebsites.net";
            String endPointURL = "/api/Activities";
            String enterIdNumber = "125";
            String activitiesNumber = "Activities 126";
            try
            {
                obj = new RestAPIHelper();
                RestClient client = RestAPIHelper.URLSetUp(baseURL, endPointURL);
                RestRequest request = RestAPIHelper.CreatePOSTRequest(enterIdNumber, activitiesNumber);
                IRestResponse respponse = RestAPIHelper.GetResponse();
                String singleUserActivitiesInfo = respponse.Content;
                Console.WriteLine(singleUserActivitiesInfo);

                HttpStatusCode httpStatusCode = respponse.StatusCode;
                int responseCode = (int)httpStatusCode;
                string responseStatus = respponse.StatusCode.ToString();

                Console.WriteLine("Response code is : " + responseCode + " after adding an entity ( Details : " + enterIdNumber + " " + activitiesNumber +")");
                Console.WriteLine("The status of response is : " + responseStatus + " after adding an entity ( Details : " + enterIdNumber + " " + activitiesNumber + ")");

                Assert.AreEqual(responseCode, HTTP_RESPONSE_CODE_200, "Not getting success response code message");
                Assert.AreEqual(responseStatus, HTTP_RESPONSE_STATUS_OK, "Not getting success response status message");
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [Test]
        public void DELETEActivitiesInfo()
        {

            String baseURL = "http://fakerestapi.azurewebsites.net";
            String endPointURL = "/api/Activities";
            String userIdNumber = "4";
            String enterValue = "/"+userIdNumber;
            try
            {
                obj = new RestAPIHelper();
                RestClient client = RestAPIHelper.URLSetUp(baseURL, endPointURL);
                RestRequest request = RestAPIHelper.CreateDELETERequest(enterValue);
                IRestResponse respponse = RestAPIHelper.GetResponse();
                String responseFromGetRequest = respponse.Content;
                Console.WriteLine(responseFromGetRequest);
                HttpStatusCode statusCode = respponse.StatusCode;
                int statusCodeOfResponseIs=(int)statusCode;
                String StatusOfResponseIs = statusCode.ToString();
                Console.WriteLine("Response code is : " + statusCodeOfResponseIs + " after deletion of an entity --> " + userIdNumber);
                Console.WriteLine("The status of response is : " + StatusOfResponseIs + " after deletion of an entity --> "+ userIdNumber);

                Assert.AreEqual(statusCodeOfResponseIs, HTTP_RESPONSE_CODE_200, "Not getting success response code message");
                Assert.AreEqual(StatusOfResponseIs, HTTP_RESPONSE_STATUS_OK, "Not getting success response status message");

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
