import { GalerieService } from './../service/galerie.service';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Galerie } from '../model/Galerie';
import { lastValueFrom } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Picture } from '../model/Picture';

@Component({
  selector: 'app-myGalleries',
  templateUrl: './myGalleries.component.html',
  styleUrls: ['./myGalleries.component.css']
})
export class MyGalleriesComponent implements OnInit {

  galerieMy !: Galerie;
  name : string = "";
  pictures: Picture[] = [];
  username : string="";
  isPublic !: boolean ;
  @ViewChild('fileuploadviewchild', {static:false}) pictureInput ?: ElementRef;

  constructor(public galerieService : GalerieService, public http: HttpClient) { }

  ngOnInit() {
    this.galerieService.getGAleries();
  }

  async uploadViewChild() {
    if(this.pictureInput == undefined){
      console.log("Input HTML non chargé.");
      return;
    }
    
      let file = this.pictureInput.nativeElement.files[0];
      if(file == null){
        console.log("Input HTML ne contient aucune image.");
        return;
      }
      let formData = new FormData();
      formData.append('monImage', file, file.name);
    
      let x = await lastValueFrom(this.http.post<any>('https://localhost:7278/api/Pictures/PostPicture/'+ this.galerieMy.id,formData));

      if (x != null) {
        let newPicture = x as Picture;
        if (newPicture != null) {
          if(this.galerieMy.pictures == null)
          {
            this.galerieMy.pictures = [];
          }
          this.galerieMy.pictures.push(newPicture);
        }
      }

      console.log(x);
      console.log(this.galerieMy.pictures);
    }
    

  async create() : Promise<void>{

    this.galerieService.postGalerie(this.name, this.isPublic);
   
  }

  async partager() : Promise<void>{

    this.galerieService.addCollabo(this.galerieMy.id, this.username, this.galerieMy);
   
  }

  onSelectGalerie(galerie: Galerie) {
    // Réagir à la sélection d'une galerie
    this.galerieMy = galerie;
    console.log('Galerie sélectionnée :', galerie);
  }
}
