using DoAnCuoiKiNhom9.Data;
using DoAnCuoiKiNhom9.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DoAnCuoiKiNhom9.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class ShopController : Controller
	{
		private readonly ApplicationDbContext _context;
		public ShopController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			IEnumerable<SanPham> sanpham = _context.SanPhams.Include(sp =>sp.TheLoai).ToList();
			return View(sanpham);
		}

		public IActionResult Details(int sanphamId)
		{
			GioHang giohang = new GioHang()
			{
				SanPhamId = sanphamId,
				SanPham = _context.SanPhams.Include("TheLoai").FirstOrDefault(sp => sp.Id == sanphamId),
				Quantity = 1
			};
			
			return View(giohang);
		}

		[HttpPost]
		[Authorize]
		public IActionResult Details(GioHang giohang)
		{
			//lay thong tin tai khoan
			var idetity = (ClaimsIdentity)User.Identity;
			var claim = idetity.FindFirst(ClaimTypes.NameIdentifier);

			
			//kiem tra san oham co trong gio hang chua 
			var  giohangdb=_context.GioHang.FirstOrDefault(sp =>sp.SanPhamId == giohang.SanPhamId
			&& sp.ApplicationUserId == giohang.ApplicationUserId);
			if(giohangdb == null) //neu chua co 
			{
				_context.GioHang.Add(giohang);//them vao
			}
			else
			{
				giohangdb.Quantity += giohang.Quantity;//cap nhap lai so luong
			}
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
