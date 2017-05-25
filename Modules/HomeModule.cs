using Nancy;
using System.Collections.Generic;
using CD_organizer.Objects;

namespace CD_organizer
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      Get["/view_all_cds"] = _ => {
        List<Cds> allCds = Cds.GetAll();
        return View["view_all_cds.cshtml", allCds];
      };

      Post["/cds_added"] = _ => {
        Cds newCd = new Cds(Request.Form["title"], Request.Form["artist"]);
        return View["cds_added.cshtml", newCd];
      };

      Post["/cds_cleared"] = _ => {
        Cds.ClearAll();
        return View["cds_cleared.cshtml"];
      };
    }
  }
}
