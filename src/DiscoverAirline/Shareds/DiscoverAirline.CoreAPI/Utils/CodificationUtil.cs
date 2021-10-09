using DiscoverAirline.CoreAPI.Models;
using System.Text;
using System.Text.Json;

namespace DiscoverAirline.CoreAPI.Utils
{
    public static class CodificationUtil
    {
        public static UserProfile Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            var jsonDecode = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            return JsonSerializer.Deserialize<UserProfile>(jsonDecode);
        }

        public static string Base64Encode(object profile)
        {
            var profileStr = JsonSerializer.Serialize(profile, profile.GetType());

            var profileBytes = Encoding.UTF8.GetBytes(profileStr.ToString());

            return System.Convert.ToBase64String(profileBytes);
        }
    }
}
