using MehsCoreCommon.Dtos.UserCatalog;
using MehsCoreCommon.Rules.Interfaces.RulesUserCatalog;
using MehsCoreCommon.Services.Restful;
using System;
using Microsoft.Practices.Unity;
using System.Web.Http;

namespace MehsWebApiUsers.Controllers
{
    [RoutePrefix("api/v1/usr/usertype")]
    public class UserCatalogController : UserMainController, IRestfulService<DtoUserCatalog, int, IHttpActionResult>
    {
        private IRepositoryUserCatalog repository;

        public UserCatalogController()
        {
            repository = UserIoCConfig.Contenedor.Resolve<IRepositoryUserCatalog>();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
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
        public IHttpActionResult Get(int id)
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
        public IHttpActionResult Post(DtoUserCatalog dto)
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
        public IHttpActionResult Put(DtoUserCatalog dto)
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

        [Route("")]
        public IHttpActionResult Options()
        {
            return null;
        }
    }
}
