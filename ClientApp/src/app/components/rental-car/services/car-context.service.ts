import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { SearchParams } from '../models/search.model';
import { Car } from '../../../models/car.model';
import { ReservationForm } from '../../../models/reservation-form.model';

@Injectable({
  providedIn: 'root',
})
export class CarContextService {
  private carKey = 'car';
  private reservationFormKey = 'reservationForm';
  private car = new BehaviorSubject<Car | null>(null);
  private reservationForm = new BehaviorSubject<ReservationForm | null>(null);
  private searchParams = new BehaviorSubject<SearchParams[]>([]);
  private rentalPeriod = new BehaviorSubject<number | null>(1);

  constructor() {
    this.getCar();
  }

  public getRentalPeriod(): Observable<number | null> {
    return this.rentalPeriod.asObservable();
  }

  public setRentalPeriod(period: number): void {
    this.rentalPeriod.next(period);
  }

  public getReservationForm(): Observable<ReservationForm | null> {
    const form = this.getReservationFormFromLocalStorage();

    if (form) {
      this.reservationForm.next(form);
    }

    return this.reservationForm.asObservable();
  }

  public setReservationForm(form: ReservationForm): void {
    localStorage.setItem(this.reservationFormKey, JSON.stringify(form));
    this.reservationForm.next(form);
  }

  public getReservationFormFromLocalStorage(): ReservationForm | null {
    const form = localStorage.getItem(this.reservationFormKey);
    return form ? JSON.parse(form) : null;
  }

  public clearReservationForm(): void {
    localStorage.removeItem(this.reservationFormKey);
    this.reservationForm.next(null);
  }

  public isCarSelected(vin: string): boolean {
    return this.car.value?.vin === vin;
  }

  public getCarValue(): Car | null {
    return this.car.value;
  }

  public getCar(): Observable<Car | null> {
    const car = this.getCarFromLocalStorage();

    if (car) {
      this.car.next(car);
    }

    return this.car.asObservable();
  }

  public setCar(car: Car): void {
    localStorage.setItem(this.carKey, JSON.stringify(car));
    this.car.next(car);
  }

  public getCarFromLocalStorage(): Car | null {
    const car = localStorage.getItem(this.carKey);
    return car ? JSON.parse(car) : null;
  }

  public clearCar(): void {
    localStorage.removeItem(this.carKey);
    this.car.next(null);
  }

  public getSearchParamsValue(): SearchParams[] | null {
    return this.searchParams.value;
  }

  public getSearchParams(): Observable<SearchParams[] | null> {
    return this.searchParams.asObservable();
  }

  public setSearchParams(params: SearchParams[]): void {
    this.searchParams.next(params);
  }
}
