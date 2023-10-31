using DoAnCuoiKiNhom9.Data;
using DoAnCuoiKiNhom9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoAnCuoiKiNhom9.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SanPhamController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //lay thong tin trong bang san pham va bao gom them thong tin bang theloai
            IEnumerable<SanPham> sanpham = _context.SanPhams.Include("TheLoai").ToList();
            return View(sanpham);
        }

        [HttpGet]
        public IActionResult Upsert(int id)
        {
            SanPham sanpham = new SanPham();
            IEnumerable<SelectListItem> dstheloai = _context.TheLoai.Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                });
            ViewBag.DSTheLoai = dstheloai;
            if (id == 0)
            {
                return View();
            }
            else
            {
                sanpham = _context.SanPhams.Include("TheLoai").FirstOrDefault(sp => sp.Id == id);
                return View(sanpham);
            }

        }
        [HttpPost]
        public IActionResult Upsert(SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                if (sanpham.Id == 0)
                {
                    _context.SanPhams.Add(sanpham);
                }
                else
                {
                    _context.SanPhams.Update(sanpham);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

		[HttpPost]
		public IActionResult Delete(int id)
		{
			var sanpham = _context.SanPhams.FirstOrDefault(sp => sp.Id == id);
			if (sanpham == null)
			{
				return NotFound();
			}
			_context.SanPhams.Remove(sanpham);
			_context.SaveChanges();
			return Json(new { success = true });
		}
	}
}
