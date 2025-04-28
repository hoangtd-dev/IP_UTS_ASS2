import { CarBrand } from './car-brand.model';
import { CarType } from './car-type.model';

export interface Car {
  vin: string;
  name: string;
  imageUrl: string;
  pricePerDay: number;
  isAvailable: boolean;
  yearOfManufacture: number;
  mileage: number;
  fuelType: string;
  description: string;
  carModel: string;
  carBrand?: CarBrand;
  carType?: CarType;
}
