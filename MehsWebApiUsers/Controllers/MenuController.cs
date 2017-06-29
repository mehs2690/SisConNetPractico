using MehsCoreCommon.Rules.Interfaces.RulesMenu;
using MehsCoreCommon.Services.Restful;
using System;
using Microsoft.Practices.Unity;
using System.Web.Http;
using MehsCoreCommon.Dtos.Menu;

namespace MehsWebApiUsers.Controllers
{
    [RoutePrefix("api/v1/usr/menu")]
    public class MenuController : UserMainController, IRestfulService<DtoMenu, int, IHttpActionResult>
    {
        private IRepositoryMenu repository;

        public MenuController()
        {
            repository = UserIoCConfig.Contenedor.Resolve<IRepositoryMenu>();
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

        [Route("{by}")]
        public IHttpActionResult Patch(string by)
        {
            try
            {
                return Ok(repository.ReadAll(by));
            }
            catch (Exception e)
            {
                throw GenerateHttpException(e, "Error user get", "read by usertype");
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
        public IHttpActionResult Options()
        {
            return null;
        }

        [Route("")]
        public IHttpActionResult Post(DtoMenu dto)
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
        public IHttpActionResult Put(DtoMenu dto)
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
