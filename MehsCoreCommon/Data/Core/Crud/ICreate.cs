namespace MehsCoreCommon.Data.Core.Crud
{
    public interface ICreate<Dto>
    {
        Dto CreateEntity(Dto dto);
    }
}
