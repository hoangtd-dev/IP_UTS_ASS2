using RentalCar.Enums;

namespace RentalCar.DTOs
{
    public class SearchSuggestionDTO
    {
        public string? Suggestion { get; set; }
        public SuggestionType SuggestionType { get; set; }
    }
}
