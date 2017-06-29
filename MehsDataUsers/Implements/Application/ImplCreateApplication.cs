using log4net;
using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.ApplicationCrud;
using MehsCoreCommon.Dtos.Applications;
using MehsDataUsers.Orm;
using MehsDataUsers.Pocos;
using System;

namespace MehsDataUsers.Implements.Application
{
    public class ImplCreateApplication : AbsCrud<DtoApplication, ApplicationPoco, UserDataContext>, ICreateApplication
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplCreateApplication));

        public ImplCreateApplication()
        {

        }

        private DtoApplication CreateApplication(DtoApplication dto)
        {
            ApplicationPoco poco = Cast(dto);
            contexto.Applications.Add(poco);
            contexto.SaveChanges();
            return CastInverse(poco);
        }

        public DtoApplication CreateEntity(DtoApplication dto)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new UserDataContext())
                    {
                        return CreateApplication(dto);
                    }
                }
                else
                {
                    return CreateApplication(dto);
                }
            }
            catch (Exception e)
            {
                log.Error(string.Format(ERROR_CREATE, typeof(ApplicationPoco)), e);
                return null;
            }
        }
    }
}
