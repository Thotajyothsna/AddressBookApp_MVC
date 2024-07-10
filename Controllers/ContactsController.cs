using Bussiness_Layer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model_Layer;

namespace AddressBookApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactsBussiness iContactsBL;
        public ContactsController(IContactsBussiness iContactsBL)
        {
            this.iContactsBL = iContactsBL;
        }
        [HttpGet]
        [Route("AllContacts")]
        public IActionResult Index()
        {
            List<ContactsModel> Contacts = new List<ContactsModel>();
            Contacts = iContactsBL.GetAllContacts();
            return View(Contacts);
        }
        [HttpGet]
        [Route("AddContact")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("AddContact")]
        public IActionResult Create(ContactsModel model)
        {
            if (ModelState.IsValid)
            {
                iContactsBL.AddContact(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        private static string? FirstName, LastName;
        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(string? id1, string? id2)
        {
            FirstName = new string(id1.ToCharArray());
            LastName = new string(id2.ToCharArray());
            ContactsModel Contact = new ContactsModel();
            Contact = iContactsBL.GetByName(id1, id2);
            return View(Contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit")]
        public IActionResult Edit([Bind] ContactsModel model)
        {

            if (ModelState.IsValid)
            {
                iContactsBL.EditContact(FirstName, LastName, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        [Route("Delete")]
        public IActionResult Delete(string? id1, string? id2)
        {
            FirstName = new string(id1.ToCharArray());
            LastName = new string(id2.ToCharArray());
            ContactsModel Contact = new ContactsModel();
            Contact = iContactsBL.GetByName(id1, id2);
            return View(Contact);
        }
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete([Bind] ContactsModel model)
        {
            //if (ModelState.IsValid)
            {
                iContactsBL.DeleteContact(FirstName, LastName);
                return RedirectToAction("Index");
            }
            //return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("SearchByState")]
        public IActionResult SearchByState()
        {
            return View("SearchByState");
        }
        [HttpPost]
        [Route("SearchByState")]
        public IActionResult SearchByState([Bind] SearchByStateModel mdl)
        {
                List<ContactsModel> Contacts = new List<ContactsModel>();
                Contacts = iContactsBL.SearchByState(mdl);
                return View("Index",Contacts);
        }

        [HttpGet]
        [Route("SearchByCity")]
        public IActionResult SearchByCity()
        {
            return View("SearchByCity");
        }
        [HttpPost]
        [Route("SearchByCity")]
        public IActionResult SearchByCity([Bind] SearchByCityModel mdl)
        {
            List<ContactsModel> Contacts = new List<ContactsModel>();
            Contacts = iContactsBL.SearchByCity(mdl);
            return View("Index", Contacts);
        }

        [HttpGet]
        [Route("SearchByType")]
        public IActionResult SearchByType()
        {
            return View("SearchByType");
        }
        [HttpPost]
        [Route("SearchByType")]
        public IActionResult SearchByType([Bind] SearchByTypeModel mdl)
        {
            List<ContactsModel> Contacts = new List<ContactsModel>();
            Contacts = iContactsBL.SearchByType(mdl);
            return View("Index", Contacts);
        }

        [HttpGet]
        [Route("SearchByAnyName")]
        public IActionResult SearchByAnyName()
        {
            return View("SearchByAnyName");
        }
        [HttpPost]
        [Route("SearchByAnyName")]
        public IActionResult SearchByAnyName([Bind] SearchByAnyNameModel mdl)
        {
            List<ContactsModel> Contacts = new List<ContactsModel>();
            Contacts = iContactsBL.SearchByAnyName(mdl);
            return View("Index", Contacts);
        }

        [HttpGet]
        [Route("ContactsWithCountry")]
        public IActionResult GetContactsJoin()
        {
            List<CountryModel> Contacts=new List<CountryModel>();
            Contacts = iContactsBL.GetContactsWithCountry();
            return View(Contacts);
        }

        [HttpGet]
        [Route("InsertOrUpdate")]
        public IActionResult InsertOrUpdate()
        {
            return View();
        }
        [HttpPost]
        [Route("InsertOrUpdate")]
        public IActionResult InsertOrUpdate(ContactsModel model)
        {
            if (ModelState.IsValid)
            {
                iContactsBL.InsertOrUpdate(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        [Route("ContactsAllInfo")]
        public IActionResult GetAllContactsInfo()
        {
            List<TypeDescriptionModel> Contacts = new List<TypeDescriptionModel>();
            Contacts = iContactsBL.GetAllContactInfo();
            return View(Contacts);
        }

        [HttpGet]
        [Route("SearchByPhone")]
        public IActionResult SearchByPhone(string phone)
        {
            return View("SearchByPhone");
        }
        [HttpPost]
        [Route("SearchByPhone")]
        public IActionResult SearchByphone([Bind] string phoneNumber)
        {
            List<ContactsModel> Contacts = new List<ContactsModel>();
            Contacts = iContactsBL.SearchByphonePattern(phoneNumber);
            return View("Index", Contacts);
        }
    }
}
