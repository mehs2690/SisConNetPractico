using MehsCoreCommon.Dtos.Users;
using MehsCoreCommon.Rules.Interfaces.RulesUser;
using MehsCoreCommon.Services.Restful;
using System;
using Microsoft.Practices.Unity;
using System.Web.Http;

namespace MehsWebApiUsers.Controllers
{
    [RoutePrefix("api/v1/usr/menu")]
    public class UserController : UserMainController, IRestfulService<DtoUser, Guid, IHttpActionResult>
    {
        private IRepositoryUser repository;

        public UserController()
        {
            repository = UserIoCConfig.Contenedor.Resolve<IRepositoryUser>();
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
        public IHttpActionResult Post(DtoUser dto)
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
        public IHttpActionResult Put(DtoUser dto)
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
