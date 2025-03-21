﻿namespace _2280600149_HoangAn3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _2280600149_HoangAn3.Models;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser> 
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    { }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
}