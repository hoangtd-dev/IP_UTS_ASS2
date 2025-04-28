export class SearchParams {
  SuggestionType!: 'carType' | 'carBrand' | 'carName';
  SearchTerm?: string;
  CarBrandId?: number;
  CarTypeId?: number;
}
