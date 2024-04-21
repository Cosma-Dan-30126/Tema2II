using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Tema2II
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     //[System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private readonly CarContext _carContext;

        public WebService1()
        {
            _carContext = new CarContext(ConfigurationManager.ConnectionStrings["CarConnection"].ConnectionString);
        }

        [WebMethod]
        public List<Car> GetAllCars()
        {
            return _carContext.GetAllCars();
        }

        [WebMethod]
        public void AddCar(string brand, string type, string model, int numberOfOwners)
        {
            Car newCar = new Car { Brand = brand, Type = type, Model = model, NumberOfOwners = numberOfOwners };
            _carContext.AddCar(newCar);
        }

        [WebMethod]
        public void UpdateCar(int carId, string brand, string type, string model, int numberOfOwners)
        {
            Car updatedCar = new Car { Id = carId, Brand = brand, Type = type, Model = model, NumberOfOwners = numberOfOwners };
            _carContext.UpdateCar(updatedCar);
        }


        [WebMethod]
        public void RemoveCar(int carId)
        {
            _carContext.RemoveCar(carId);
        }

    }
}
