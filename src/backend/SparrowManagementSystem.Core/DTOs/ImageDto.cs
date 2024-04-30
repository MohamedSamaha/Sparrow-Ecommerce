namespace SparrowManagementSystem.Core.DTOs
{
	public class ImageDto : BaseDto
	{
		public string ImageName { get; set; }
		public string ImageFilePath { get; set; }
		public ProductDto ProductDto { get; set; }
	}
}
