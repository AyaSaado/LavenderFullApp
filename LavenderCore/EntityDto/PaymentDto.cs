using Lavender.Core.Entities;
using System.Linq.Expressions;


namespace Lavender.Core.EntityDto
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public decimal PaidMoney { get; set; }
        public DateOnly PayingDate { get; set; }
        public static Expression<Func<Payment, PaymentDto>> Selector() => c
         => new()
         {
             Id = c.Id,
             PaidMoney = c.PaidMoney,
             PayingDate = c.PayingDate,
         };

    }
}
