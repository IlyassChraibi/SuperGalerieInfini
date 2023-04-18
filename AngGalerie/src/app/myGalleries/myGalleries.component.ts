import { GalerieService } from './../service/galerie.service';
import { Component, OnInit } from '@angular/core';
import { Galerie } from '../model/Galerie';

@Component({
  selector: 'app-myGalleries',
  templateUrl: './myGalleries.component.html',
  styleUrls: ['./myGalleries.component.css']
})
export class MyGalleriesComponent implements OnInit {

  galerieMy !: Galerie;
  name : string = "";
  isPublic !: boolean ;
  constructor(public galerieService : GalerieService) { }

  ngOnInit() {
    this.galerieService.getGAleries();
  }

  async create() : Promise<void>{

    this.galerieService.postGalerie(this.name, this.isPublic);
   
  }

  onSelectGalerie(galerie: Galerie) {
    // Réagir à la sélection d'une galerie
    this.galerieMy = galerie;
    console.log('Galerie sélectionnée :', galerie);
  }
}
