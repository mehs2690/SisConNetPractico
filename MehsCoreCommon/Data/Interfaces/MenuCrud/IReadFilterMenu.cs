﻿using MehsCoreCommon.Data.Core.Crud;
using MehsCoreCommon.Dtos.Menu;

namespace MehsCoreCommon.Data.Interfaces.MenuCrud
{
    public interface IReadFilterMenu : IReadAllWithFilter<DtoMenu, string>
    {
    }
}
