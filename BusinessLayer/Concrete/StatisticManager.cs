using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StatisticManager : IStatisticService
    {
        ICategoryService _categoryService;
        IContentService _contentService;
        IHeadingService _headingService;
        IWriterService _writerService;

        public StatisticManager(ICategoryService categoryService, IContentService contentService, IHeadingService headingService, IWriterService writerService)
        {
            _categoryService = categoryService;
            _contentService = contentService;
            _headingService = headingService;
            _writerService = writerService;
        }

        public int ListCategory()
        {
            return _categoryService.GetList().Count();
        }

        public int ListContent()
        {
            return _contentService.GetList().Count();
        }

        public int ListHeading()
        {
            return _headingService.GetList().Count();
        }

        public int ListWriter()
        {
            return _writerService.GetList().Count();
        }
    }
}
