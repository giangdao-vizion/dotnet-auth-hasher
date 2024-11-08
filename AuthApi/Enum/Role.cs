using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AuthApi.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Role
    {
        Admin = 1,
        CompanyAdmin,
        CompanyUser,
        PartnerAdmin,
        PartnerUser,
    }
}