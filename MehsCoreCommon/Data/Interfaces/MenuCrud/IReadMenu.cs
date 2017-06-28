using MehsCoreCommon.Data.Core.Crud;
using MehsCoreCommon.Dtos.Menu;
using System;

namespace FcCommonCore.Data.Interfaces.MenuCrud
{
    public interface IReadMenu : IRead<DtoMenu, Guid>
    {
    }
}
