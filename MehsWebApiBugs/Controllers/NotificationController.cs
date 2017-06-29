using MehsCoreCommon.Dtos.Notifications;
using MehsCoreCommon.Rules.Interfaces.RulesNotifications;
using MehsCoreCommon.Services.Restful;
using System;
using Microsoft.Practices.Unity;
using System.Web.Http;

namespace MehsWebApiBugs.Controllers
{
    [RoutePrefix("api/v1/bug/notification")]
    public class NotificationController : BugMainController, IRestfulService<DtoBugNotification, Guid, IHttpActionResult>
    {
        private IRepositoryNotification<DtoBugNotification, Guid> repository;

        public NotificationController()
        {
            repository = BugIoCConfig.Contenedor.Resolve<IRepositoryNotification<DtoBugNotification, Guid>>();
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
        public IHttpActionResult Post(DtoBugNotification dto)
        {
            throw new NotImplementedException();
        }

        [Route("")]
        public IHttpActionResult Put(DtoBugNotification dto)
        {
            throw new NotImplementedException();
        }
    }
}
