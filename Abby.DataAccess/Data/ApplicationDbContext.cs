﻿using Abby.Models;
using AbbyWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace AbbyWeb.DataAccess.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Category> Category { get; set; }
		public DbSet<FoodType> FoodType { get; set; }
		public DbSet<MenuItem> MenuItem { get; set; }
		public DbSet<ApplicationUser> ApplicationUser { get; set; }
		public DbSet<ShoppingCart> ShoppingCart { get; set; }
	}
}