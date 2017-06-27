namespace MehsCoreCommon.Data.Core.Crud
{
    public interface IRead<Dto, ReadBy>
    {
        Dto ReadEntity(ReadBy read);
    }
}
