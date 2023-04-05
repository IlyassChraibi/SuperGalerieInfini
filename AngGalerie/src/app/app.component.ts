import { Component } from '@angular/core';
import { GalerieService } from './service/galerie.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(public galerieService : GalerieService) { }
}
