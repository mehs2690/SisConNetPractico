using System;
using System.Linq;
using System.Reflection;

namespace MehsCoreCommon.Serialization.Trasnforms
{
    public class GetPropsFromString
    {
        private string arrayProps;
        private char tokenSplit;
        private char tokenProp;
        private string[] parameters;

        public GetPropsFromString(string arrayProps, char tokenSplit, char tokenProp)
        {
            this.arrayProps = arrayProps;
            this.tokenSplit = tokenSplit;
            this.tokenProp = tokenProp;
        }

        private void SplitParameters()
        {
            parameters = arrayProps.Split(tokenSplit);
        }

        public void GetObject<T>(ref T objectResult)
        {
            SplitParameters();
            try
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    foreach (PropertyInfo propInf in objectResult.GetType().GetProperties())
                    {
                        string[] propAndValue = parameters[i].Split(tokenProp);
                        PropertyInfo val = objectResult.GetType().GetProperties().Where(p => p.Name.Equals(propAndValue[0])).FirstOrDefault();
                        if (val != null)
                        {
                            var valor = propAndValue[1];
                            if (valor != null)
                                val.SetValue(objectResult, (val.PropertyType.Name == "Nullable`1" ? Convert.ChangeType(valor, val.PropertyType.GetGenericArguments()[0]) : Convert.ChangeType(valor, val.PropertyType)), null);
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
