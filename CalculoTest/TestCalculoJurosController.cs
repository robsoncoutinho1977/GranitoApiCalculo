using System;
using System.Collections.Generic;
using System.Text;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using GranitoApiCalculo.Controllers;
using Xunit.Sdk;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using GranitoApiCalculo.Models;

namespace CalculoTest
{
    [TestClass]
    public class TestCalculoJurosController
    {
        [TestMethod]
        public void Get_ShouldReturnAllProducts()
        {
            //var testProducts = GetTaxa();
            var controller = new CalculaJurosController();

            var result = controller.GetTaxa(100, 5) as OkNegotiatedContentResult<decimal>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }
    }
}
