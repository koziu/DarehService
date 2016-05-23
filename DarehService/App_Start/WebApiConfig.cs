using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DarehService.API
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      var cors = new EnableCorsAttribute("*", "*", "*");
      config.EnableCors(cors);
      config.MapHttpAttributeRoutes();
      config.Formatters.JsonFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("json", "application/json"));
      config.Formatters.XmlFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("xml", "application/xml"));
      config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
      config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());

      // change property name ex. FirstName -> firstName
      //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); 

      config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
      config.Routes.MapHttpRoute(
        "DefaultApiWithExtensions",
        "{controller}.{ext}/{action}",
        new {ext = "json", action = "Get", showHelp = true}
        );

      config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}",
        new {ext = "json", id = RouteParameter.Optional}
        );
      var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
      jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    }
  }
}