using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        public readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "INSERT INTO Coupons(Code,Rate,IsActive,ValidDate) VALUES (@CODE,@RATE,@ISACTIVE,@VALIDDATE)";
            var parameters = new DynamicParameters();
            parameters.Add("@CODE", createCouponDto.Code);
            parameters.Add("@RATE", createCouponDto.Rate);
            parameters.Add("@ISACTIVE", createCouponDto.IsActive);
            parameters.Add("@VALIDDATE", createCouponDto.ValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
            
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "DELETE FROM Coupons WHERE CouponId = @COUPONID";
            var parameters = new DynamicParameters();
            parameters.Add("@COUPONID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "SELECT * FROM Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "SELECT * FROM Coupons WHERE CouponId = @COUPONID";
            var parameters = new DynamicParameters();
            parameters.Add("@COUPONID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parameters);
                return values;
            }

        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "UPDATE Coupons SET Code = @CODE,Rate = @RATE,IsActive = @ISACTIVE, ValidDate = @VALIDDATE WHERE CouponId = @COUPONID";
            var parameters = new DynamicParameters();
            parameters.Add("@CODE", updateCouponDto.Code);
            parameters.Add("@RATE", updateCouponDto.Rate);
            parameters.Add("@ISACTIVE", updateCouponDto.IsActive);
            parameters.Add("@VALIDDATE", updateCouponDto.ValidDate);
            parameters.Add("@COUPONID", updateCouponDto.CouponId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
