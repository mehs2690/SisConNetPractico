using MehsCoreCommon.Dtos.Applications;
using MehsCoreCommon.Rules.Interfaces.RulesApplication;
using MehsCoreCommon.Services.Restful;
using System;
using Microsoft.Practices.Unity;
using System.Web.Http;

namespace MehsWebApiUsers.Controllers
{
    [RoutePrefix("api/v1/usr/app")]
    public class ApplicationController : UserMainController, IRestfulService<DtoApplication, Guid, IHttpActionResult>
    {
        private IRepositoryApplication repository;

        public ApplicationController()
        {
            repository = UserIoCConfig.Contenedor.Resolve<IRepositoryApplication>();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                return Ok(repository.DeleteRecord(id));
            }
            catch (Exception e)
            {
                throw GenerateHttpException(e, "Error user delete", "delete");
            }
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(repository.ReadAll(string.Empty));
            }
            catch (Exception e)
            {
                throw GenerateHttpException(e, "Error user get", "read all");
            }
        }

        [Route("{id}")]
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                return Ok(repository.ReadRecord(id));
            }
            catch (Exception e)
            {
                throw GenerateHttpException(e, "Error user get id", "read by");
            }
        }

        [Route("")]
        public IHttpActionResult Options()
        {
            return null;
        }

        [Route("")]
        public IHttpActionResult Post(DtoApplication dto)
        {
            try
            {
                return Ok(repository.CreateRecord(dto));
            }
            catch (Exception e)
            {
                throw GenerateHttpException(e, "Error user post", "create");
            }
        }

        [Route("")]
        public IHttpActionResult Put(DtoApplication dto)
        {
            try
            {
                return Ok(repository.UpdateRecord(dto));
            }
            catch (Exception e)
            {
                throw GenerateHttpException(e, "Error user put", "update");
            }
        }
    }
}
