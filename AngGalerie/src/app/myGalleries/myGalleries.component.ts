import { GalerieService } from './../service/galerie.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-myGalleries',
  templateUrl: './myGalleries.component.html',
  styleUrls: ['./myGalleries.component.css']
})
export class MyGalleriesComponent implements OnInit {

  name : string = "";
  isPublic !: boolean ;
  constructor(public galerieService : GalerieService) { }

  ngOnInit() {
  }

  async create() : Promise<void>{

    this.galerieService.postGalerie(this.name, this.isPublic);
   
  }

}
