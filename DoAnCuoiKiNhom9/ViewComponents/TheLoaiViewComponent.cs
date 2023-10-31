using DoAnCuoiKiNhom9.Data;
using Microsoft.AspNetCore.Mvc;

namespace DoAnCuoiKiNhom9.ViewComponents
{
    public class TheLoaiViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public TheLoaiViewComponent(ApplicationDbContext context)
        {
            _context = context; 
        }
        public IViewComponentResult Invoke()
        {
            var theloai = _context.TheLoai.ToList();
            return View(theloai);
        }
    }
}
