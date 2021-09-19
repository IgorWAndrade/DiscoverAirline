using Microsoft.OpenApi.Models;

namespace DiscoverAirline.CoreAPI.Settings
{
    public class DocumentationSettings
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public OpenApiContact Contact { get; set; }
        public OpenApiLicense License { get; set; }

        public static DocumentationSettings Create()
        {
            return new DocumentationSettings
            {

            };
        }
    }
}
