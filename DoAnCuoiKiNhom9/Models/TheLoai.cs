using System.ComponentModel.DataAnnotations;

namespace DoAnCuoiKiNhom9.Models
{
	public class TheLoai
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
	}
}
