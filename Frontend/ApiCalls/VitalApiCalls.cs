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
    class VitalApiCalls
    {
        private readonly string _url = "http://localhost:5000/api/vitals";
        public ObservableCollection<PatientVitalsModel> _vitals = new ObservableCollection<PatientVitalsModel>();
        public ObservableCollection<PatientVitalsModel> GetAllVitals()
        {
            HttpWebRequest _httpReq = WebRequest.CreateHttp(_url);
            _httpReq.Method = "GET";
            HttpWebResponse response = _httpReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                var result = reader.ReadToEnd();
                _vitals = JsonConvert.DeserializeObject<ObservableCollection<PatientVitalsModel>>(result);
            }
            return _vitals;
        }
        public void StartVitalsUpdate()
        {
            HttpWebRequest _httpPostReq = WebRequest.CreateHttp(_url);
            _httpPostReq.Method = "PUT";
            _httpPostReq.GetResponse();
        }

    }
}
