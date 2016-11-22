using SmartHouseMVC.Models;
using SmartHouseMVC.Models.AbstractDevices;
using SmartHouseMVC.Models.Factories;
using System.Web.Mvc;

namespace SmartHouseMVC.Controllers
{
    public class DevicesController : Controller
    {
        private DevicesContext db = new DevicesContext();

        // GET: Devices
        public ActionResult Index()
        {
            SelectListItem[] devicesList = new SelectListItem[4];
            devicesList[0] = new SelectListItem { Text = "Кондиционер", Value = "conditioner", Selected = true };
            devicesList[1] = new SelectListItem { Text = "Конвектор", Value = "convector" };
            devicesList[2] = new SelectListItem { Text = "Счетчик электроэнергии", Value = "energyMeter" };
            devicesList[3] = new SelectListItem { Text = "Датчик температуры", Value = "temperatureSensor" };
            ViewBag.DevicesList = devicesList;

            return View(db.Devices);
        }

        public ActionResult Add(string deviceType)
        {
            Device newDevice;
            Factory factory = new Factory();

            switch (deviceType)
            {
                default:
                    newDevice = factory.GetConditioner();
                    break;
                case "convector":
                    newDevice = factory.GetConvector();
                    break;
                case "energyMeter":
                    newDevice = factory.GetEnergyMeter();
                    break;
                case "temperatureSensor":
                    newDevice = factory.GetTemperatureSensor();
                    break;
            }

            db.Devices.Add(newDevice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}