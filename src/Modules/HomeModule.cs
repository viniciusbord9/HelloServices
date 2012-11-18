using System.Linq;
using Nancy.Routing;
using Nancy;

namespace HelloServices.Modules
{
    public class HomeModule : NancyModule
    {

        public HomeModule ()
        {
            Get ["/"] = x => { 
                return View ["index"];
            };
        }
    }
    
}
