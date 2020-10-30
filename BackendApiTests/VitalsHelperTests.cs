using Backend.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BackendApiTests
{
    public class VitalsHelperTests
    {
        MockServer _mockServer;
        readonly string _url="http://localhost:5000/api/vitals";
        public VitalsHelperTests()
        {
            _mockServer = new MockServer();
        }
        [Fact]
        public async Task TestExpectingPatientsVitalsToBeUpdated()
        {
           var response =  await _mockServer.Client.GetAsync(_url);
            var jsonString = await response.Content.ReadAsStringAsync();
            var vitals = JsonConvert.DeserializeObject<List<Backend.Models.PatientVitalsModel>>(jsonString);
            var patientId = vitals[0].PatientId;
            var vitalListOld = vitals[0].Vitals;
            new Backend.Utility.VitalsHelper().UpdateVitalsRegularly();
            response = await _mockServer.Client.GetAsync(_url + "/" + patientId);
            jsonString = await response.Content.ReadAsStringAsync();
            var vitalList = JsonConvert.DeserializeObject<List<VitalsModel>>(jsonString);
            Assert.Equal(vitalListOld[0].VitalName, vitalList[0].VitalName);
            Assert.False(vitalListOld[0].Value == vitalList[0].Value);
        }
    }
}
