using FluentValidation;

namespace TastyTrails.API.Business.Models.Requests
{
    public class CreateChannelOrderRequest : CreateOrderRequest
    {
        public int PartnerId { get; set; }
    }

    public class CreateChannelOrderRequestValidator : CreateOrderRequestValidator<CreateChannelOrderRequest>
    {
        public CreateChannelOrderRequestValidator()
        {
            RuleFor(p => p.PartnerId)
                .NotEmpty();
        }
    }
}
