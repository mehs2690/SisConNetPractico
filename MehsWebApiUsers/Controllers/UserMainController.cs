using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MehsWebApiUsers.Controllers
{
    public class UserMainController : ApiController
    {
        protected HttpResponseException GenerateHttpException(Exception inner, string message, string reasonPhrase)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(JsonConvert.SerializeObject(new { Message = message, ErrorMessage = inner.Message })),
                ReasonPhrase = reasonPhrase
            };
            return new HttpResponseException(resp);
        }
    }
}
