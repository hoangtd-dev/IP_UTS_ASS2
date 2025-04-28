import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from './components/header/header.component';
import { RouterOutlet } from '@angular/router';
import { SpinnerComponent } from './components/spinner/spinner.component';
@Component({
  selector: 'app-root',
  imports: [HeaderComponent, RouterOutlet, SpinnerComponent],
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  ngOnInit(): void {}
}
