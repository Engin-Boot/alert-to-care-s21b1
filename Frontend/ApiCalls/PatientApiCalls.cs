using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Net;
using System.Collections.ObjectModel;
using Backend.Models;
using System.IO;
using Newtonsoft.Json;

namespace Frontend.ApiCalls
{
    public class PatientApiCalls
    {
        private readonly string _url = "http://localhost:5000/api/patients";
        public ObservableCollection<PatientModel> _patients = new ObservableCollection<PatientModel>();
        DataContractJsonSerializer _jsonSerializer;
        public PatientApiCalls()
        {
            //GetAllPatients();
        }
        public string AddPatient(PatientModel patientModel)
        {
            HttpWebRequest _httpPostReq = WebRequest.CreateHttp(_url);
            _httpPostReq.Method = "POST";
            _httpPostReq.ContentType = "application/json";
            DataContractJsonSerializer userDataJsonSerializer =
                new DataContractJsonSerializer(typeof(PatientModel));
            userDataJsonSerializer.WriteObject(_httpPostReq.GetRequestStream(), patientModel);
            HttpWebResponse response = _httpPostReq.GetResponse() as HttpWebResponse;
            _jsonSerializer = new DataContractJsonSerializer(typeof(string));
            return _jsonSerializer.ReadObject(response.GetResponseStream()) as string;
        }
        public string RemovePatient(string PatientId)
        {
            HttpWebRequest _httpPostReq = WebRequest.CreateHttp(_url + "/" + PatientId);
            _httpPostReq.Method = "DELETE";
            _httpPostReq.ContentType = "application/json";
            HttpWebResponse response = _httpPostReq.GetResponse() as HttpWebResponse;
            _jsonSerializer = new DataContractJsonSerializer(typeof(string));
            return _jsonSerializer.ReadObject(response.GetResponseStream()) as string;
        }
        public ObservableCollection<PatientModel> GetAllPatients()
        {
            HttpWebRequest _httpReq = WebRequest.CreateHttp(_url);
            _httpReq.Method = "GET";
            HttpWebResponse response = _httpReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                var result = reader.ReadToEnd();
                var patients = JsonConvert.DeserializeObject<ObservableCollection<PatientModel>>(result);
                return patients;
            }
            return _patients;
        }
        public PatientModel GetPatient(string patientId)
        {

            HttpWebRequest _httpReq = WebRequest.CreateHttp(_url+"/"+patientId);
            _httpReq.Method = "GET";
            HttpWebResponse response = _httpReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                var result = reader.ReadToEnd();
                var patient = JsonConvert.DeserializeObject<PatientModel>(result);
                return patient;
            }
            return null;
        }
    }
}
