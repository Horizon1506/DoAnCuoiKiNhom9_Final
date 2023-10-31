using DoAnCuoiKiNhom9.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DoAnCuoiKiNhom9.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<TheLoai> TheLoai { get; set; }
		public DbSet<SanPham> SanPhams { get; set; }
		public DbSet<ApplicationUser> ApplicationUser { get; set; }
		public DbSet<GioHang> GioHang { get; set;}
	}
}