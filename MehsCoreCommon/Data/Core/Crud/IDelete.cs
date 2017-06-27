namespace MehsCoreCommon.Data.Core.Crud
{
    public interface IDelete<Dto, DeleteBy>
    {
        Dto DeleteEntity(DeleteBy delete);
    }
}
