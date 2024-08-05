
using MediatR;

namespace Lavender.Services.ControlSettings
{
    public class GetColorsAndQuantitiesRequest : IRequest<List<ColorsAndQuantities>>
    {
        public int SItemTypeId { get; set; }
    }
    public class ColorsAndQuantities
    {
        public int Id { get; set; }
        public string? Color { get; set; }
        public decimal Quantity { get; set; } 
    }
}
