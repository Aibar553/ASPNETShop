
using Abby.DataAccess.Repository.IRepository;
using AbbyWeb.DataAccess.Data;
using AbbyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;
		public DeleteModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public Category Category { get; set; }
		public void OnGet(int id)
        {
            Category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
		}
		public async Task<IActionResult> OnPost()
		{
			var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(u=>u.Id==Category.Id);
			if (categoryFromDb != null)
			{
				_unitOfWork.Category.Remove(categoryFromDb);
				_unitOfWork.Save();
				TempData["success"] = "Category deleted successfully";
				return RedirectToPage("Index");
			}
            return Page();
		}
	}
}