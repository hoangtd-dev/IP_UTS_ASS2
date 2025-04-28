import { FormControl } from '@angular/forms';

export interface IFilter {
  id: number;
  name: string;
}

export class Filter implements IFilter {
  id!: number;
  name!: string;

  filterProperty!: 'carType' | 'carBrand';
  filterControl!: FormControl;

  constructor(filter: Partial<Filter>) {
    Object.assign(this, filter);
    this.filterControl = new FormControl({
      id: filter.id,
      filterProperty: filter.filterProperty,
      value: false,
    });
  }

  public static createFromProperty(
    property: 'carType' | 'carBrand',
    filter: IFilter
  ): Filter {
    return new Filter({ ...filter, filterProperty: property });
  }
}
