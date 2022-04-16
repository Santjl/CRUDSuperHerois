using Newtonsoft.Json.Converters;

namespace CRUDSuperHeroisAPI.Domain.Services
{
    public class DateTimeConverterService : IsoDateTimeConverter
    {
        public DateTimeConverterService(string format)
        {
            DateTimeFormat = format;
        }
    }
}
