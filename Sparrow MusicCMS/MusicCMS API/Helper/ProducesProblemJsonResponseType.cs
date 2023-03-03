using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace MusicCMS_API.Helper
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ProducesProblemJsonResponseType : Attribute, IApiResponseMetadataProvider
    {
        public ProducesProblemJsonResponseType(Type type, int statusCode)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            StatusCode = statusCode;
        }

        public Type Type { get; set; }
        public int StatusCode { get; set; }

        void IApiResponseMetadataProvider.SetContentTypes(MediaTypeCollection contentTypes)
            => contentTypes.Add("application/problem+json");
    }
}
