using MehsCoreCommon.Serialization.Trasnforms;

namespace MehsCoreCommon.Data.Core
{
    public class AbsCrud<Dto, Poco, Context>
    {
        protected Context contexto;
        protected const string WARNING_DB_CONEXION = "el contexto es nulo, se usará la cadena de conexión por DEFAULT del sistema";
        protected const string TRANSACTION_MESSAGE = "proceso para transacción";
        protected const string ERROR_UPDATE = "Error al actualizar el registro de tipo {0} con Id: {1}";
        protected const string ERROR_DELETE = "Error al eliminar el registro de tipo {0} con Id: {1}";
        protected const string ERROR_READ_BY_ID = "Error al consulta el registro de tipo {0} con Id: {1}";
        protected const string ERROR_CREATE = "Error al crear un registro de tipo {0}";

        protected Poco Cast(Dto dto)
        {
            return TransformModelToModel.ToCast<Dto, Poco>(dto);
        }

        protected Dto CastInverse(Poco poco)
        {
            return TransformModelToModel.ToCast<Poco, Dto>(poco);
        }

        protected virtual void MappingProps(ref Poco poco, Dto dto)
        {
            poco = TransformModelToModel.ToCast<Dto, Poco>(dto);
        }
    }
}
