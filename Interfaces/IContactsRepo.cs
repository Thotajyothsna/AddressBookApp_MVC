using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_Layer;

namespace Repository_Layer.Interfaces
{
    public interface IContactsRepo
    {
        public ContactsModel AddContact(ContactsModel contact);
        public List<ContactsModel> GetAllContacts();
        public ContactsModel GetByName(string? FirstName,string? LastName);
        public ContactsModel EditContact(string? FirstName, string? LastName,ContactsModel mdl);
        public bool DeleteContact(string? id1, string? id2);
        public List<ContactsModel> SearchByState(SearchByStateModel mdl);
        public List<ContactsModel> SearchByCity(SearchByCityModel mdl);
        public List<ContactsModel> SearchByType(SearchByTypeModel mdl);
        public List<ContactsModel> SearchByAnyName(SearchByAnyNameModel mdl);
        public List<CountryModel> GetContactsWithCountry();
        public ContactsModel InsertOrUpdate(ContactsModel mdl);
        public List<TypeDescriptionModel> GetAllContactInfo();
        public List<ContactsModel> SearchByphonePattern(string Phone);
    }
}
