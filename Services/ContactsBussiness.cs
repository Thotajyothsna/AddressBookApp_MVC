using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness_Layer.Interfaces;
using Model_Layer;
using Repository_Layer.Interfaces;

namespace Bussiness_Layer.Services
{
    public class ContactsBussiness : IContactsBussiness
    {
        private readonly IContactsRepo iContactsRepo; 
        public ContactsBussiness(IContactsRepo iContactsRepo)
        {
            this.iContactsRepo = iContactsRepo;   
        }
        public ContactsModel AddContact(ContactsModel contact)
        {
            return iContactsRepo.AddContact(contact);
        }
        public List<ContactsModel> GetAllContacts()
        {
            return iContactsRepo.GetAllContacts();
        }
        public ContactsModel GetByName(string? FirstName,string? LastName)
        {
            return iContactsRepo.GetByName(FirstName,LastName);
        }
        public ContactsModel EditContact(string? FirstName, string? LastName, ContactsModel mdl)
        {
            return iContactsRepo.EditContact(FirstName,LastName,mdl);
        }
        public bool DeleteContact(string? id1, string? id2)
        {
            return iContactsRepo.DeleteContact(id1,id2);
        }
        public List<ContactsModel> SearchByState(SearchByStateModel mdl)
        {
            return iContactsRepo.SearchByState(mdl);
        }
        public List<ContactsModel> SearchByCity(SearchByCityModel mdl)
        {
            return iContactsRepo.SearchByCity(mdl);
        }
        public List<ContactsModel> SearchByType(SearchByTypeModel mdl)
        {
            return iContactsRepo.SearchByType(mdl);
        }
        public List<ContactsModel> SearchByAnyName(SearchByAnyNameModel mdl)
        {
            return iContactsRepo.SearchByAnyName(mdl);
        }
        public List<CountryModel> GetContactsWithCountry()
        {
            return iContactsRepo.GetContactsWithCountry();
        }
        public ContactsModel InsertOrUpdate(ContactsModel mdl)
        {
            return iContactsRepo.InsertOrUpdate(mdl);
        }
        public List<TypeDescriptionModel> GetAllContactInfo()
        {
            return iContactsRepo.GetAllContactInfo();
        }
        public List<ContactsModel> SearchByphonePattern(string Phone)
        {
            return iContactsRepo.SearchByphonePattern(Phone);
        }
    }
}
