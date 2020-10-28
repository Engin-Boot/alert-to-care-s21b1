using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace BackendApiTests
{
    public class PatientControllerTests
    {
        private readonly MockServer _mockServer;
        private static readonly string _url = "http://localhost:5000/api/patients";
        public PatientControllerTests()
        {
            _mockServer = new MockServer();
        }
        Backend.Models.PatientModel _patient = new Backend.Models.PatientModel()
        {
            IcuId = "IC2",
            BedId="IC2L01",
            Name="Tom",
            Age=21,
            PatientId="p12",
            Address="TomsAddress",
            Gender="Male",
            ContactNo="somethin"
        };

        [Fact]
        public async Task TestExpectingNewPatientToBeAddedIfItIsValid()
        {
            var response = await _mockServer.Client.PostAsync(_url, new StringContent(JsonConvert.SerializeObject(_patient), Encoding.UTF8, "application/json"));
            var jsonString = await response.Content.ReadAsStringAsync();
            Assert.Equal("Patient added to the bed", JsonConvert.DeserializeObject<string>(jsonString));
            await _mockServer.Client.DeleteAsync(_url + "/" + _patient.PatientId);
        }
        [Fact]
        public async Task TestExpectingFalseForPatientToBeAddedIfItIsInValid()
        {
            await _mockServer.Client.PostAsync(_url, new StringContent(JsonConvert.SerializeObject(_patient), Encoding.UTF8, "application/json"));
            var response = await _mockServer.Client.PostAsync(_url, new StringContent(JsonConvert.SerializeObject(_patient), Encoding.UTF8, "application/json"));
            var jsonString = await response.Content.ReadAsStringAsync();
            Assert.Equal("Patient couldnot be added", JsonConvert.DeserializeObject<string>(jsonString));
            await _mockServer.Client.DeleteAsync(_url + "/" + _patient.PatientId);
        }
        [Fact]
        public async Task TestExpectingListOfAllPatientsWhenCalled()
        {
            await _mockServer.Client.PostAsync(_url, new StringContent(JsonConvert.SerializeObject(_patient), Encoding.UTF8, "application/json"));
            var response = await _mockServer.Client.GetAsync(_url);
            var jsonString = await response.Content.ReadAsStringAsync();
            var beds = JsonConvert.DeserializeObject<List<Backend.Models.PatientModel>>(jsonString);
            Assert.Contains("p12", jsonString);
            await _mockServer.Client.DeleteAsync(_url + "/" + _patient.PatientId);
        }
        [Fact]
        public async Task TestExpectingAPatientWhenCalledWithAnPatientId()
        {
            await _mockServer.Client.PostAsync(_url, new StringContent(JsonConvert.SerializeObject(_patient), Encoding.UTF8, "application/json"));
            var response = await _mockServer.Client.GetAsync(_url + "/p12");
            var jsonString = await response.Content.ReadAsStringAsync();
            var patient = JsonConvert.DeserializeObject<Backend.Models.PatientModel>(jsonString);
            Assert.Equal("IC2", patient.IcuId);
            await _mockServer.Client.DeleteAsync(_url + "/" + _patient.PatientId);
        }
        [Fact]
        public async Task TestExpectingFalseWhenPatientDoesNotExistWhenCalledWithAnInvalidPatientId()
        {
            var response = await _mockServer.Client.GetAsync(_url + "/random_id");
            var jsonString = await response.Content.ReadAsStringAsync();
            var patient = JsonConvert.DeserializeObject<Backend.Models.PatientModel>(jsonString);
            Assert.Null(patient);
        }
        [Fact]
        public async Task TestExpectingPatientToBeRemovedWhenCalledWithValidId()
        {
            await _mockServer.Client.PostAsync(_url, new StringContent(JsonConvert.SerializeObject(_patient), Encoding.UTF8, "application/json"));
            var response = await _mockServer.Client.DeleteAsync(_url + "/" + _patient.PatientId);
            var jsonString = await response.Content.ReadAsStringAsync();
            Assert.Equal("Patient Discharged!", JsonConvert.DeserializeObject<string>(jsonString));
        }
        [Fact]
        public async Task TestExpectingFalseForPatientToBeRemovedWhenCalledWithInValidId()
        {
            var response = await _mockServer.Client.DeleteAsync(_url + "/" + _patient.PatientId);
            var jsonString = await response.Content.ReadAsStringAsync();
            Assert.Equal("Patient could not be discharged", JsonConvert.DeserializeObject<string>(jsonString));
        }
    }
}
