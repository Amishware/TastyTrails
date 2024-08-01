using FluentValidation;
using TastyTrails.API.Business.Models.Dtos;

namespace TastyTrails.API.Business.Models.Requests
{
    public class CreateOrderRequest
    {
        public int RestaurantId { get; set; }
        public int? CustomerId { get; set; }
        public virtual IEnumerable<OrderItemDto> OrderItems { get; set; }
    }

    public class CreateOrderRequestValidator<T> : AbstractValidator<T>
        where T : CreateOrderRequest
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(p => p.RestaurantId)
                .NotEmpty();

            RuleFor(p => p.OrderItems)
                .NotEmpty();

            RuleForEach(p => p.OrderItems)
                    .Cascade(CascadeMode.Stop)
                    .SetValidator(new OrderItemDtoValidator());
        }
    }
}
