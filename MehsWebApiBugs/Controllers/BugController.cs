using MehsCoreCommon.Dtos.Bugs;
using MehsCoreCommon.Services.Restful;
using System;
using System.Web.Http;

namespace MehsWebApiBugs.Controllers
{
    [RoutePrefix("api/v1/bug/bugs")]
    public class BugController : BugMainController, IRestfulService<DtoBug, Guid, IHttpActionResult>
    {
        public BugController()
        {

        }

        [Route("{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            throw new NotImplementedException();
        }

        [Route("{id}")]
        public IHttpActionResult Get(Guid id)
        {
            throw new NotImplementedException();
        }

        [Route("")]
        public IHttpActionResult Options()
        {
            return null;
        }

        [Route("")]
        public IHttpActionResult Post(DtoBug dto)
        {
            try
            {
                return Ok("");
            }
            catch (Exception e)
            {
                throw GenerateHttpException(e, "Error en el método post para los bugs", "creación de un bug");
            }
        }

        [Route("")]
        public IHttpActionResult Put(DtoBug dto)
        {
            throw new NotImplementedException();
        }
    }
}
