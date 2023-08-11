using System.Dynamic;
using System.Net;

namespace BrasilAPI.Response;

public class GenericResponse<T> where T : class
{
    public HttpStatusCode HttpStatusCode { get; set; }
    public T? Data { get; set; }
    public ExpandoObject? Error { get; set; }
}
