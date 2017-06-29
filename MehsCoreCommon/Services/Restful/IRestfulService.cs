namespace MehsCoreCommon.Services.Restful
{
    public interface IRestfulService<Dto, Identity, IResponse>
    {
        IResponse Get();
        IResponse Get(Identity id);
        IResponse Post(Dto dto);
        IResponse Put(Dto dto);
        IResponse Delete(Identity id);
        IResponse Options();
    }
}
