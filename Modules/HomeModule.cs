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
      Post["/genres"] = _ => {
        Genres newGenre = new Genres(Request.Form["genre-name"]);
        List<Genres> allGenres = Genres.GetAll();
        return View["genres.cshtml", allGenres];
      };
      //View all the CDs in a genre
      Get["/genres/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Genres selectedGenre = Genres.Find(parameters.id);
        List<Cds> genreCds = selectedGenre.GetCds();
        model.Add("genre", selectedGenre);
        model.Add("cds", genreCds);
        return View["genre.cshtml", model];
      };
      //Add CDs to a genre
      Get["/genres/{id}/cds/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Genres selectedGenre = Genres.Find(parameters.id);
        List<Cds> allCds = selectedGenre.GetCds();
        model.Add("genre", selectedGenre);
        model.Add("cds", allCds);
        return View["genre_cd_form.cshtml", model];
      };
      //Add a new CD
      Post["/view_all_cds"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Genres selectedGenre = Genres.Find(Request.Form["genre-id"]);
        List<Cds> genreCds = selectedGenre.GetCds();
        string cdDescription = Request.Form["cd-description"];
        Cds newCd = new Cds(cdDescription);
        genreCds.Add(newCd);
        model.Add("cds", genreCds);
        model.Add("genre", selectedGenre);
        return View["genre.cshtml", model];
      };

      // Post["/cds_cleared"] = _ => {
      //   Cds.ClearAll();
      //   return View["cds_cleared.cshtml"];
      // };

      // Post["/cds_added"] = _ => {
      //   Cds newCd = new Cds(Request.Form["title"], Request.Form["artist"]);
      //   return View["cds_added.cshtml", newCd];
      // };
      //
      // Post["/cds_cleared"] = _ => {
      //   Cds.ClearAll();
      //   return View["cds_cleared.cshtml"];
      // };
    }
  }
}
