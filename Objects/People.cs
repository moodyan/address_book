using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class People
  {
    private string _name;
    private string _phone;
    private int _id;
    private static List<People> _listPeople = new List<People>();
    public People(string name, string phone)
      {
        SetName(name);
        SetPhone(phone);
        _listPeople.Add(this);
        _id = _listPeople.Count;
      }
    public string GetName()
    {
      return _name;
    }

    public void SetName(string name)
    {
      _name = name;
    }

    public string GetPhone()
    {
      return _phone;

    }

    public void SetPhone(string phone)
    {
      _phone = phone;
    }

    public int GetId()
    {
      return _id;
    }
    //show list
    public static List<People> GetAll()
    {
      return _listPeople;
    }
    // clear list
    public static void ClearAll()
    {
      _listPeople.Clear();
    }
    //find items in the list that has the matched ID
    public static People Find(int searchID)
    {
      return _listPeople[searchID - 1];
    }
    //find the name matched user input, return true if matched
    // public bool Search(string userInput)
    // {
    //   return _name.Contains(userInput); //NOTE: Does not know how to ignore case
    // }

  }
}
