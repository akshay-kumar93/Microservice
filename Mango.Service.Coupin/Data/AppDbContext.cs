using Mango.Service.Coupin.Model;
using Microsoft.EntityFrameworkCore;

namespace Mango.Service.Coupin.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Coupon> coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                    CouponId = 1,
                    CouponCode = "10F12",
                    DiscountAmount = 12,
                    MinAmount = 20,
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "F0F2",
                DiscountAmount = 15,
                MinAmount = 30,
            });
        }
    }
}
