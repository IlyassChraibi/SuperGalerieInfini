import { Component, OnInit } from '@angular/core';
import { GalerieService } from '../service/galerie.service';

@Component({
  selector: 'app-publicGalleries',
  templateUrl: './publicGalleries.component.html',
  styleUrls: ['./publicGalleries.component.css']
})
export class PublicGalleriesComponent implements OnInit {

  constructor(public galerieService : GalerieService) { }

  ngOnInit() {
    this.galerieService.getGAleriesPublic();
  }
}
