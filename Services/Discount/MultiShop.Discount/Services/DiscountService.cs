using Dapper;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;
        public DiscountService(DapperContext context)
        {
            _context = context;
        }
        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string guery = "insert into Coupons (Code, Rate, IsActive, ValidDate) values (@code, @rate, @IsActive, @validDate)";
            var paramters = new DynamicParameters();
            paramters.Add("@code", createCouponDto.Code);
            paramters.Add("@rate", createCouponDto.Rate);
            paramters.Add("@IsActive", createCouponDto.IsActive);
            paramters.Add("@validDate", createCouponDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(guery, paramters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetDiscountCouponByIdAsync(int id)
        {
            string query = "Select * From Coupons where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _context.CreateConnection())
            {
                var values =  await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
                return values;

            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "Update Coupons set Code=@code, Rate=@rate, IsActive=@IsActive, ValidDate=@validDate where CouponId=@couponId";
            var paramters = new DynamicParameters();
            paramters.Add("@code", updateCouponDto.Code);
            paramters.Add("@rate", updateCouponDto.Rate);
            paramters.Add("@IsActive", updateCouponDto.IsActive);
            paramters.Add("@validDate", updateCouponDto.ValidDate);
            paramters.Add("@couponId", updateCouponDto.CouponId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramters);
            }
        }
    }
}
