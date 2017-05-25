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
      
    }
  }
}
