﻿using Abby.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AbbyWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuItemController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
		}
		[HttpGet]
		public IActionResult Index()
		{
			var menuItemList = _unitOfWork.MenuItem.GetAll(includeProperties: "Category,FoodType");
			return Json(new { data = menuItemList });
		}
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{ 
			var objFromDb = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == id);
			var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, objFromDb.Image.TrimStart('\\'));
			if (System.IO.File.Exists(oldImagePath))
			{
				System.IO.File.Delete(oldImagePath);
			}
			_unitOfWork.MenuItem.Remove(objFromDb);
			_unitOfWork.Save();
			return Json(new { success = true, message = "Deleted successfully" });
		}
	}
}
