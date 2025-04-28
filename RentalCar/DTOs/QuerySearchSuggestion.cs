using RentalCar.Enums;

namespace RentalCar.DTOs
{
    public class QuerySearchSuggestion
    {
        public SuggestionType SuggestionType { get; set; }
        public string? SearchTerm { get; set; }
        public int? CarBrandId { get; set; }
        public int? CarTypeId { get; set; }
    }
}
