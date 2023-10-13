using Dapper;
using Npgsql;
using Shared.Dtos;
using System.Data;

namespace Discount.API.Services
{
    public class DiscountService : IDiscountService
    {

        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;

            _connection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<Response<List<Models.Discount>>> GetAll()
        {
            var discounts = await _connection.QueryAsync<Models.Discount>("Select * from discount");

            return Response<List<Models.Discount>>.Success(discounts.ToList(), 200);
        }

        public async Task<Response<Models.Discount>> GetById(int id)
        {
            var discount = (await _connection.QueryAsync<Models.Discount>("Select * from discount where id=@Id", new { Id = id })).SingleOrDefault();

            if (discount == null)
            {
                return Response<Models.Discount>.Fail("Discount not found", 404);
            }

            return Response<Models.Discount>.Success(discount, 200);
        }

        public async Task<Response<NoContent>> Save(Models.Discount discount)
        {
            var status = await _connection.ExecuteAsync("INSERT into discount (userid,rate,code) VALUES (@Userid,@Rate,@Code)", discount);
            if (status > 0)
                return Response<NoContent>.Success(204);
            else
                return Response<NoContent>.Fail("An error occurred while adding", 500);
        }

        public async Task<Response<NoContent>> Update(Models.Discount discount)
        {
            var status = await _connection.ExecuteAsync("Update discount set userid = @UserId, code = @Code, rate = @Rate where id = @Id", discount);
            if (status > 0)
                return Response<NoContent>.Success(204);
            else
                return Response<NoContent>.Fail("Discount not found", 404);
        }
        public async Task<Response<NoContent>> Delete(int id)
        {
            var status = await _connection.ExecuteAsync("Delete from discount where id = @Id", new { Id = id });
            if (status > 0)
                return Response<NoContent>.Success(204);
            else
                return Response<NoContent>.Fail("Discount not found", 404);
        }
        public async Task<Response<Models.Discount>> GetByCodeAndUserId(string code, string userId)
        {
            var discount = (await _connection.QueryAsync<Models.Discount>("Select * from discount where userid=@UserId and code = @Code", new { UserId = userId, Code = code })).FirstOrDefault();

            if (discount == null)
            {
                return Response<Models.Discount>.Fail("Discount not found", 404);
            }
            else

                return Response<Models.Discount>.Success(discount, 200);
        }
    }
}
