import { Component } from '@angular/core';
import { AsyncPipe } from '@angular/common';
import { Observable } from 'rxjs';
import { SpinnerService } from './spinner.service';

@Component({
  selector: 'app-spinner',
  standalone: true,
  imports: [AsyncPipe],
  template: `
    @if (isLoading$ | async; as isLoading) {
    <div
      class="fixed z-50 top-0 left-0 w-full min-h-screen flex justify-center items-center"
    >
      <div class="flex min-h-screen w-full bg-gray-200 opacity-25"></div>

      <div
        class="absolute flex h-14 w-14 items-center justify-center rounded-full bg-gradient-to-tr from-indigo-500 to-pink-500 animate-spin"
      >
        <div class="h-9 w-9 rounded-full bg-gray-200"></div>
      </div>
    </div>
    }
  `,
  styles: [],
})
export class SpinnerComponent {
  isLoading$: Observable<boolean>;

  constructor(private spinnerService: SpinnerService) {
    this.isLoading$ = this.spinnerService.isLoading$;
  }
}
