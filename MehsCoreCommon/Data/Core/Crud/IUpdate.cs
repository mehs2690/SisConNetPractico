namespace MehsCoreCommon.Data.Core.Crud
{
    public interface IUpdate<Dto>
    {
        Dto UpdateEntity(Dto dto);
    }
}
