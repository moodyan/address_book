using Nancy;
using System.Collections.Generic;
using CD_organizer.Objects;

namespace CD_organizer
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
      return View["index.cshtml"];
      };
      Get["/genres"] = _ => {
        List<Genres> allGenres = Genres.GetAll();
        return View["genres.cshtml", allGenres];
      };
      Get["/genres/new"] = _ => {
        return View["genre_form.cshtml"];
      };
      //Add a new genre
      Post["/genres"] = _ => {
        Genres newGenre = new Genres(Request.Form["genre-name"]);
        List<Genres> allGenres = Genres.GetAll();
        return View["genres.cshtml", allGenres];
      };
      //View all the genres
      Get["/genres/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Genres selectedGenre = Genres.Find(parameters.id);
        List<Cds> genreCds = selectedGenre.GetCds();
        model.Add("genre", selectedGenre);
        model.Add("cds", genreCds);
        return View["genre.cshtml", model];
      };
      //View CDs in a genre
      Get["/genres/{id}/cds/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Genres selectedGenre = Genres.Find(parameters.id);
        List<Cds> allCds = selectedGenre.GetCds();
        model.Add("genre", selectedGenre);
        model.Add("cds", allCds);
        return View["genre_cd_form.cshtml", model];
      };
      //Add a new CD to a genre
      Post["/view_all_cds"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Genres selectedGenre = Genres.Find(Request.Form["genre-id"]);
        List<Cds> genreCds = selectedGenre.GetCds();
        string cdTitle = Request.Form["cd-description"];
        string cdArtist = Request.Form["cd-artist"];
        Cds newCd = new Cds(cdTitle, cdArtist);
        genreCds.Add(newCd);
        model.Add("cds", genreCds);
        model.Add("genre", selectedGenre);
        return View["genre.cshtml", model];
      };

      Post["/cds_cleared"] = _ => {
        Cds.ClearAll();
        return View["cds_cleared.cshtml"];
      };

      Post["/genres_cleared"] = _ => {
        Genres.Clear();
        return View["genres_cleared.cshtml"];
      };

    }
  }
}
