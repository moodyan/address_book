using System.Collections.Generic;

namespace CD_organizer.Objects
{
  public class Genres
  {
    private static List<Genres> _genres = new List<Genres>{};
    private string _genre;
    private int _id;
    private List<Cds> _listCD;
    public Genres(string genreType)
    {
      _genre = genreType;
      _genres.Add(this);
      _id = _genres.Count;
      _listCD = new List<Cds>{};
    }

    public string GetGenre()
    {
      return _genre;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<Genres> GetAll()
    {
      return _genres;
    }

    public static void Clear()
    {
      _genres.Clear();
    }

    public static Genres Find(int searchID)
    {
      return _genres[searchID - 1];
    }
    //view all CDs in a collection
    public List<Cds> GetCds()
    {
      return _listCD;
    }
    //Add a new CD to a collection
    public void AddCD(Cds cd)
    {
      _listCD.Add(cd);
    }


  }
}
