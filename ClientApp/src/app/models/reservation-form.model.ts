export interface ReservationForm {
  username: string;
  phone: string;
  email: string;
  driverLicense: string;
  startDate: Date;
  rentalPeriod: number;
}

export class CreateReservationForm implements ReservationForm {
  username!: string;
  phone!: string;
  email!: string;
  driverLicense!: string;
  startDate!: Date;
  rentalPeriod!: number;
}
