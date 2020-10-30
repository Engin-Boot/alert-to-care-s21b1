using System.Collections.ObjectModel;
using System.Runtime.Serialization.Json;
using System.Net;
using Backend.Models;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Documents;
using System.Linq;

namespace Frontend.ApiCalls
{
    public class IcuApiCalls
    {
        private readonly string _url ="http://localhost:5000/api/icus";
        public ObservableCollection<PatientVitalsModels> _icus = new ObservableCollection<PatientVitalsModels>();
        DataContractJsonSerializer _jsonSerializer;
        public IcuApiCalls()
        {
            //GetAllIcus();
        }
        public string AddIcu(PatientVitalsModels icuModel)
        {
            HttpWebRequest _httpPostReq =WebRequest.CreateHttp(_url);
            _httpPostReq.Method = "POST";
            _httpPostReq.ContentType = "application/json";
            DataContractJsonSerializer userDataJsonSerializer =
                new DataContractJsonSerializer(typeof(PatientVitalsModels));
            userDataJsonSerializer.WriteObject(_httpPostReq.GetRequestStream(), icuModel);
            HttpWebResponse response = _httpPostReq.GetResponse() as HttpWebResponse;
            _jsonSerializer = new DataContractJsonSerializer(typeof(string));
            return _jsonSerializer.ReadObject(response.GetResponseStream()) as string;
        }
        public string RemoveIcu(string icuId)
        {
            HttpWebRequest _httpPostReq = WebRequest.CreateHttp(_url+"/"+icuId);
            _httpPostReq.Method = "DELETE";
            _httpPostReq.ContentType = "application/json";
            HttpWebResponse response = _httpPostReq.GetResponse() as HttpWebResponse;
            _jsonSerializer = new DataContractJsonSerializer(typeof(string));
            return _jsonSerializer.ReadObject(response.GetResponseStream()) as string;
        }
        public ObservableCollection<PatientVitalsModels> GetAllIcus()
        {
            HttpWebRequest _httpReq = WebRequest.CreateHttp(_url);
            _httpReq.Method = "GET";
            HttpWebResponse response = _httpReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                var result = reader.ReadToEnd();
                _icus = JsonConvert.DeserializeObject<ObservableCollection<PatientVitalsModels>>(result);
                _icus = new ObservableCollection<PatientVitalsModels>(_icus.OrderBy(i => i.IcuId));   
            }
            return _icus;
        }
        public PatientVitalsModels GetIcu(string icuId)
        {
            HttpWebRequest _httpReq = WebRequest.CreateHttp(_url + "/" + icuId);
            _httpReq.Method = "GET";
            HttpWebResponse response = _httpReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                var result = reader.ReadToEnd();
                var icu = JsonConvert.DeserializeObject<PatientVitalsModels>(result);
                return icu;
            }
            return null;
        }
    }
}
