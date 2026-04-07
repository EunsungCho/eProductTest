using System.Text.Json;

namespace eProductTest.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetJson<T>(this ISession session, string key)
        {
            var sessonData = session.GetString(key);
            return sessonData == null ? default(T) : JsonSerializer.Deserialize<T>(sessonData);
        }
    }
}
