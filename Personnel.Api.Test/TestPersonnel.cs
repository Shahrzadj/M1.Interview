using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Personnel.Entities.Personnel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Personnel.Api.Test
{
    [TestClass]
   public  class TestPersonnel
    {
        [TestMethod]
        public void TestGetAllPersonnel()
        {
            var mockEmps = new List<PersonnelModel>();
            mockEmps.Add(new PersonnelModel
            { Id = 1, Name = "F1", Age = 20, Phone = "00989191677925" });
            mockEmps.Add(new PersonnelModel
            { Id = 2, Name = "F2", Age = 32, Phone = "00989191111123" });

            var personnelRepositoryMock = TestInitializer.MockPersonnelRepository;
            personnelRepositoryMock.Setup
                  (x => x.GetAllPersonnel()).Returns(Task.FromResult(mockEmps));

            var response = TestInitializer.TestHttpClient.GetAsync("/api/personnel").Result;

            var resp = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert.DeserializeObject<List<PersonnelModel>>(resp);
            Assert.AreEqual(3, responseData.Count);
            Assert.AreEqual(mockEmps[0].Id, responseData[0].Id);
        }
    }
}
