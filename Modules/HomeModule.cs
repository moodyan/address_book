using Nancy;
using System;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Contact> allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
      Get["/contact/new"] = _ => {
        return View["contact_form.cshtml"];
      };
      Post["/contact"] = _ => {
        Contact newContact = new Contact(Request.Form["name"], Request.Form["phone"], Request.Form["street"], Request.Form["city"], Request.Form["state"], Request.Form["zip"]);
        return View["contact_added.cshtml", newContact];
      };
      Get["/contact/{id}"] = parameters => {
        Contact contact = Contact.Find(parameters.id);
        return View["/contact.cshtml", contact];
      };
      Post["/contact/cleared"] = _ => {
        Contact.Clear();
        return View["contacts_cleared.cshtml"];
      };
      Post["/contact/{id}"] = parameters => {
        Contact contact = Contact.Find(parameters.id);
        contact.Remove();
        List<Contact> allContacts = Contact.GetAll();
        return View["contact_removed.cshtml", allContacts];
      };
    }
  }
}
