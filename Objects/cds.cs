using System.Collections.Generic;
namespace CD_organizer.Objects
{
  public class Cds
  {
    private string _title;
    private string _artist;
    private int _id;
    private static List<Cds> _listCD = new List<Cds>();
    public Cds(string title, string artist)
      {
        SetTitle(title);
        SetArtist(artist);
        _listCD.Add(this);
        _id = _listCD.Count;
      }
    public string GetTitle()
    {
      return _title;
    }

    public void SetTitle(string title)
    {
      _title = title;
    }

    public string GetArtist()
    {
      return _artist;

    }

    public void SetArtist(string artist)
    {
      _artist = artist;
    }

    public int GetId()
    {
      return _id;
    }
    //show list
    public static List<Cds> GetAll()
    {
      return _listCD;
    }
    // clear list
    public static void ClearAll()
    {
      _listCD.Clear();
    }
    //find items in the list that has the matched ID
    public static Cds Find(int searchID)
    {
      return _listCD[searchID - 1];
    }
  }
}
