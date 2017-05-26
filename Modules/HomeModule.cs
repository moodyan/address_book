using Nancy;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
      List<Contacts> allContacts = Contacts.GetAll();
      return View["index.cshtml", allContacts];
      };
      Get["/contacts"] = _ => {
        List<Contacts> allContacts = Contacts.GetAll();
        return View["contacts.cshtml", allContacts];
      };
      Get["/contacts/new"] = _ => {
        return View["contact_form.cshtml"];
      };
      Post["/contacts/added"] = _ => {
        Contacts newContact = new Contacts(Request.Query["name"]);
        List<Contacts> allContacts = Contacts.GetAll();
        return View["contact_added.cshtml", allContacts];
      };


    }
  }
}
