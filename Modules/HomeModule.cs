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
      // List<Contacts> allContacts = Contacts.GetAll();
      return View["index.cshtml"];
      };

    }
  }
}
