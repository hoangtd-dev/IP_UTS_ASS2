export interface SearchSuggestion {
  suggestionType: SearchSuggestionType;
  suggestion: string;
}

export enum SearchSuggestionType {
  CarBrand,
  CarType,
  CarName,
}
