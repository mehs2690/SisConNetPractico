using log4net;
using MehsCoreCommon.Data.Core;
using MehsCoreCommon.Data.Interfaces.ApplicationCrud;
using MehsCoreCommon.Dtos.Applications;
using MehsDataUsers.Orm;
using MehsDataUsers.Pocos;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MehsDataUsers.Implements.Application
{
    public class ImplReadFilterApplication : AbsCrud<DtoApplication, ApplicationPoco, UserDataContext>, IReadFilterApplication
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplReadFilterApplication));

        public ImplReadFilterApplication()
        {

        }

        private List<DtoApplication> Filter(string by)
        {
            List<DtoApplication> result = new List<DtoApplication>();

            if (!string.IsNullOrEmpty(by))
            {

            }
            else
            {
                var bd = (from a in contexto.Applications
                          select a).ToList();
                foreach (var app in bd)
                {
                    result.Add(CastInverse(app));
                }
            }
            return result;
        }

        public List<DtoApplication> ReadAll(string by)
        {
            try
            {
                if (contexto == null)
                {
                    using (contexto = new UserDataContext())
                    {
                        return Filter(by);
                    }
                }
                else
                {
                    return Filter(by);
                }
            }
            catch (Exception e)
            {
                log.Error("Error en la consulta con filtro de Aplicaciones", e);
                return null;
            }
        }
    }
}
