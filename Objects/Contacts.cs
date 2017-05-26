using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Contacts
  {
    private static List<Contacts> _contacts = new List<Contacts>{};
    private string _contact;
    private int _id;
    private List<People> _listPeople;
    public Contacts(string contactType)
    {
      _contact = contactType;
      _contacts.Add(this);
      _id = _contacts.Count;
      _listPeople = new List<People>{};
    }

    public string GetContact()
    {
      return _contact;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<Contacts> GetAll()
    {
      return _contacts;
    }

    public static void Clear()
    {
      _contacts.Clear();
    }

    public static Contacts Find(int searchID)
    {
      return _contacts[searchID - 1];
    }
    //view all People in a collection
    public List<People> GetPeople()
    {
      return _listPeople;
    }
    //Add a new CD to a collection
    public void AddPeople(People people)
    {
      _listPeople.Add(people);
    }
  }
}
