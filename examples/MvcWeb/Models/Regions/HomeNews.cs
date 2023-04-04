
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace MvcWeb.Models.Regions
{
    public class HomeNews
    {
        [Field(Placeholder = "Tin tức trang chủ.")]
        public PageField Page { get; set; }
    }
}
