using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
//installed this
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AlertToCare.AutomationTesting
{
    [TestClass]
    public class MonitoringControllerIntegrationTest
    {
        private static string url = "http://localhost:65411/api/monitoring";

        [TestMethod]
        public void TestAlertOff()
        {
            string alerturl = url + "/Alert/";
            string bedId = "U1B1";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest() { Resource = alerturl + bedId };

            IRestResponse restResponse = restClient.Delete(restRequest);
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void TestAlertOn()
        {
            string alerturl = url + "/Alert";

            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(Method.GET) { Resource = alerturl };

            IRestResponse response = restClient.Execute(restRequest);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [TestMethod]
        public void TestUpdatePatientVitalsForAlerting()
        {
            string alerturl = url + "/UpdateVital/";
            string patientId = "PId001";
            float bpmvalue = 120;
            float spo2value = 98;
            float respRatevalue = 50;
            // alerturl=url+"/UpdateVital/PId001/120,98/50;
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(Method.GET) { Resource = alerturl + patientId + '/' + bpmvalue + '/' + spo2value + '/' + respRatevalue };

            IRestResponse restResponse = restClient.Execute(restRequest);
            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);
        }

        [TestMethod]
        public void TestGetParticularPatientInfoApi()
        {
            string _testurl = url + "PID001";
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
