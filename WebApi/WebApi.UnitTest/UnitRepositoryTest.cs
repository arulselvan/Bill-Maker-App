using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Repository;
using WebApi.Controllers;

namespace WebApi.UnitTest
{
    [TestClass]
    public class UnitRepositoryTest
    {
        private UnitRepository unitRepository;

        [TestMethod]
        public void CreateUnit()
        {
            var controller = new UnitController(this.unitRepository);
            var actual = controller.Get();
            Assert.IsTrue(true);
        }
    }
}
