using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Contact
  {
    private static List<Contact> _contacts = new List<Contact>{};
    private string _name;
    private string _phone;
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _zip;
    private int _id;

    public Contact(string name, string phone, string streetAddress, string city, string state, string zip)
    {
      _name = name;
      _phone = phone;
      _streetAddress = streetAddress;
      _city = city;
      _state = state;
      _zip = zip;
      _contacts.Add(this);
      _id = _contacts.Count;
    }

    public string GetName()
    {
      return _name;
    }
    public string GetPhone()
    {
      return _phone;
    }
    public string GetStreetAddress()
    {
      return _streetAddress;
    }
    public string GetCity()
    {
      return _city;
    }
    public string GetState()
    {
      return _state;
    }
    public string GetZip()
    {
      return _zip;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Contact> GetAll()
    {
      return _contacts;
    }

    // public static void Clear()
    // {
    //   _contacts.Clear();
    // }
    // public void Remove()
    // {
    //   _contacts.Remove(this);
    // }
    public static Contact Find(int searchID)
    {
      return _contacts[searchID - 1];
    }
  }
}
