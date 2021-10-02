using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStatisticService
    {
        int ListWriter();
        int ListCategory();
        int ListHeading();
        int ListContent();
    }
}
