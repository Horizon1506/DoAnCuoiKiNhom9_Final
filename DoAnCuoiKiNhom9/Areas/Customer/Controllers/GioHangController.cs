using DoAnCuoiKiNhom9.Data;
using DoAnCuoiKiNhom9.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DoAnCuoiKiNhom9.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class GioHangController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GioHangController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
            
            IEnumerable<GioHang> dsGioHang = _context.GioHang
                .Include("SanPham")
                .Where(gh => gh.ApplicationUserId == claim.Value)
                .ToList();

            return View(dsGioHang);
        }
    }
}
