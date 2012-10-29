using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swampy.Admin.MVC.Models.Mappers
{
    public interface IViewModelMapper<TIn,TOut>
    {
        TOut Map(TIn toMap);
    }
}
