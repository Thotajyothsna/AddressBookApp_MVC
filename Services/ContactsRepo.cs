using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Model_Layer;
using Repository_Layer.Interfaces;

namespace Repository_Layer.Services
{
    public class ContactsRepo : IContactsRepo
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-BP7OD30\SQLEXPRESS;Initial Catalog=Address_Book;Integrated Security=True;TrustServerCertificate=True");
        public ContactsRepo()
        {

        }
        public ContactsModel AddContact(ContactsModel mdl)
        {
            try
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("InsertContact", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", mdl.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", mdl.LastName);
                    cmd.Parameters.AddWithValue("@Type", mdl.Type);
                    cmd.Parameters.AddWithValue("@PhoneNumber", mdl.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", mdl.Email);
                    cmd.Parameters.AddWithValue("@Address", mdl.Address);
                    cmd.Parameters.AddWithValue("@City", mdl.City);
                    cmd.Parameters.AddWithValue("@State", mdl.State);
                    cmd.Parameters.AddWithValue("@Zipcode", mdl.PostalCode);

                    cmd.ExecuteNonQuery();
                }

                connection.Close();
                return mdl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ContactsModel> GetAllContacts()
        {
            try
            {
                connection.Open();
                String RetrieveQuery = "EXEC GetContacts;";
                SqlCommand cmd = new SqlCommand(RetrieveQuery, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                List<ContactsModel> contactsList = new List<ContactsModel>();
                while (reader.Read())
                {
                    ContactsModel contact = new ContactsModel()
                    {
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Type = reader["Type"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        City = reader["City"].ToString(),
                        State = reader["State"].ToString(),
                        PostalCode = reader["Zipcode"].ToString()

                    };
                    contactsList.Add(contact);
                }


                return contactsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ContactsModel GetByName(string? FirstName, string? LastName)
        {
            try
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("GetByName", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ContactsModel contact = new ContactsModel()
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Type = reader["Type"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Email = reader["Email"].ToString(),
                                Address = reader["Address"].ToString(),
                                City = reader["City"].ToString(),
                                State = reader["State"].ToString(),
                                PostalCode = reader["Zipcode"].ToString()

                            };
                            return contact;
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ContactsModel EditContact(string id1, string id2, ContactsModel mdl)
        {
            try
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("EditContact", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", mdl.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", mdl.LastName);
                    cmd.Parameters.AddWithValue("@Type", mdl.Type);
                    cmd.Parameters.AddWithValue("@PhoneNumber", mdl.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", mdl.Email);
                    cmd.Parameters.AddWithValue("@address", mdl.Address);
                    cmd.Parameters.AddWithValue("@City", mdl.City);
                    cmd.Parameters.AddWithValue("@State", mdl.State);
                    cmd.Parameters.AddWithValue("@Zipcode", mdl.PostalCode);
                    cmd.Parameters.AddWithValue("@id1", id1);
                    cmd.Parameters.AddWithValue("@id2", id2);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return mdl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteContact(string? id1, string? id2)
        {
            try
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("DeleteContact", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id1", id1);
                    cmd.Parameters.AddWithValue("@id2", id2);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ContactsModel> SearchByState(SearchByStateModel mdl)
        {
            try
            {
                List<ContactsModel> Contacts = new List<ContactsModel>();
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("GetByState", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@State", mdl.State);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ContactsModel contact = new ContactsModel()
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Type = reader["Type"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Email = reader["Email"].ToString(),
                                Address = reader["Address"].ToString(),
                                City = reader["City"].ToString(),
                                State = reader["State"].ToString(),
                                PostalCode = reader["Zipcode"].ToString()

                            };
                            Contacts.Add(contact);
                        }
                    }
                }
                connection.Close();
                return Contacts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ContactsModel> SearchByCity(SearchByCityModel mdl)
        {
            try
            {
                List<ContactsModel> Contacts = new List<ContactsModel>();
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("GetByCity", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City", mdl.City);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ContactsModel contact = new ContactsModel()
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Type = reader["Type"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Email = reader["Email"].ToString(),
                                Address = reader["Address"].ToString(),
                                City = reader["City"].ToString(),
                                State = reader["State"].ToString(),
                                PostalCode = reader["Zipcode"].ToString()

                            };
                            Contacts.Add(contact);
                        }
                    }
                }
                connection.Close();
                return Contacts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ContactsModel> SearchByType(SearchByTypeModel mdl)
        {
            try
            {
                List<ContactsModel> Contacts = new List<ContactsModel>();
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("GetByType", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Type", mdl.Type);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ContactsModel contact = new ContactsModel()
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Type = reader["Type"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Email = reader["Email"].ToString(),
                                Address = reader["Address"].ToString(),
                                City = reader["City"].ToString(),
                                State = reader["State"].ToString(),
                                PostalCode = reader["Zipcode"].ToString()

                            };
                            Contacts.Add(contact);
                        }
                    }
                }
                connection.Close();
                return Contacts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ContactsModel> SearchByAnyName(SearchByAnyNameModel mdl)
        {
            try
            {
                List<ContactsModel> Contacts = new List<ContactsModel>();
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("GetByAnyName", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", mdl.FirstName);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ContactsModel contact = new ContactsModel()
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Type = reader["Type"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Email = reader["Email"].ToString(),
                                Address = reader["Address"].ToString(),
                                City = reader["City"].ToString(),
                                State = reader["State"].ToString(),
                                PostalCode = reader["Zipcode"].ToString()

                            };
                            Contacts.Add(contact);
                        }
                    }
                }
                connection.Close();
                return Contacts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CountryModel> GetContactsWithCountry()
        {
            connection.Open();
            List<CountryModel> Contacts = new List<CountryModel>();
            using (SqlCommand cmd = new SqlCommand("GetContactsWithCountry", connection))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CountryModel contact = new CountryModel()
                    {
                        Firstname = reader["FirstName"].ToString(),
                        Lastname = reader["lastName"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        State = reader["State"].ToString(),
                        Country = reader["Country"].ToString()
                    };
                    Contacts.Add(contact);
                }
            }
            connection.Close();
            return Contacts;
        }

        public ContactsModel InsertOrUpdate(ContactsModel mdl)
        {
            try
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("InsertOrUpdate", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", mdl.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", mdl.LastName);
                    cmd.Parameters.AddWithValue("@Type", mdl.Type);
                    cmd.Parameters.AddWithValue("@PhoneNumber", mdl.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", mdl.Email);
                    cmd.Parameters.AddWithValue("@Address", mdl.Address);
                    cmd.Parameters.AddWithValue("@City", mdl.City);
                    cmd.Parameters.AddWithValue("@State", mdl.State);
                    cmd.Parameters.AddWithValue("@Zipcode", mdl.PostalCode);

                    cmd.ExecuteNonQuery();
                }

                connection.Close();
                return mdl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TypeDescriptionModel> GetAllContactInfo()
        {
            connection.Open();
            List<TypeDescriptionModel> Contacts = new List<TypeDescriptionModel>();
            using (SqlCommand cmd = new SqlCommand("ContactsAllInfo", connection))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TypeDescriptionModel contact = new TypeDescriptionModel()
                    {
                        Firstname = reader["FirstName"].ToString(),
                        Lastname = reader["lastName"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        State = reader["State"].ToString(),
                        Country = reader["Country"].ToString(),
                        TypeDescription = reader["TypeDescription"].ToString()
                    };
                    Contacts.Add(contact);
                }
            }
            connection.Close();
            return Contacts;
        }

        public List<ContactsModel> SearchByphonePattern(string Phone)
        {
            try
            {
                List<ContactsModel> Contacts = new List<ContactsModel>();
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("GetByPhonePattern", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PhoneNumber", Phone);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ContactsModel contact = new ContactsModel()
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Type = reader["Type"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Email = reader["Email"].ToString(),
                                Address = reader["Address"].ToString(),
                                City = reader["City"].ToString(),
                                State = reader["State"].ToString(),
                                PostalCode = reader["Zipcode"].ToString()

                            };
                            Contacts.Add(contact);
                        }
                    }
                }
                connection.Close();
                return Contacts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
