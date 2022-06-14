using System;
using System.IO;
using System.Threading.Tasks;

namespace MoviesAppConcept.Helpers
{
    internal static class ResourceHelper
    {
        public static async Task<string> GetStringFromEmbeddedResource(string resourceName)
        {
            using (var stream = typeof(ResourceHelper).Assembly.GetManifestResourceStream($"{nameof(MoviesAppConcept)}.{resourceName}"))
            using (var reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
