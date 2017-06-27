using System;
using System.Linq;
using System.Reflection;

namespace MehsCoreCommon.Serialization.Trasnforms
{
    public class TransformModelToModel
    {
        public static ModDestiny ToCast<ModOrigin, ModDestiny>(ModOrigin toCast)
        {
            try
            {
                var destinyClass = Activator.CreateInstance<ModDestiny>();
                foreach (PropertyInfo propInf in toCast.GetType().GetProperties())
                {
                    PropertyInfo val = destinyClass.GetType().GetProperties().Where(x => x.Name == propInf.Name).FirstOrDefault();
                    if (val != null)
                    {
                        var propValue = propInf.GetValue(toCast, null);
                        if (propValue != null)
                        {
                            val.SetValue(destinyClass, (val.PropertyType.Name == "Nullable`1" ? Convert.ChangeType(propValue, val.PropertyType.GetGenericArguments()[0]) : Convert.ChangeType(propValue, val.PropertyType)), null);
                        }
                    }
                }
                return destinyClass;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
