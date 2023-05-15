import { GalerieService } from './../service/galerie.service';
import { Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { Galerie } from '../model/Galerie';
import { Observable, lastValueFrom } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Picture } from '../model/Picture';
import { Router } from '@angular/router';

declare var Masonry : any;
declare var imagesLoaded : any;

@Component({
  selector: 'app-myGalleries',
  templateUrl: './myGalleries.component.html',
  styleUrls: ['./myGalleries.component.css']
})
export class MyGalleriesComponent implements OnInit {

  galerieMy !: Galerie;
  selectedPicture: any; 
  name : string = "";
  username : string="";
  isPublic !: boolean ;
  @ViewChild('fileuploadviewchild', {static:false}) pictureInput ?: ElementRef;
  @ViewChild('fileuploadcover', {static:false}) coverInput ?: ElementRef;

  @ViewChild('masongrid') masongrid ?: ElementRef;
  @ViewChildren('masongriditems') masongriditems ?: QueryList<any>;

  constructor(public galerieService : GalerieService, public http: HttpClient,private router: Router) { }

  ngOnInit() {
    this.galerieService.getGAleries();


    
  }

  ngAfterViewInit() { 
        this.masongriditems?.changes.subscribe(e => { 
          this.initMasonry(); 
        }); 
      
        if(this.masongriditems!.length > 0) { 
          this.initMasonry(); 
        } 
      } 
    
      initMasonry() { 
        var grid = this.masongrid?.nativeElement; 
        var msnry = new Masonry( grid, { 
          itemSelector: '.grid-item',
          columnWidth:320, // À modifier si le résultat est moche
          gutter:3
        });
       
        imagesLoaded( grid ).on( 'progress', function() { 
          msnry.layout(); 
        }); 
      } 

  closeFullSizeImage() {
    // Utilisez le Router pour naviguer vers une autre page ou fermer la fenêtre actuelle
    this.router.navigate(['/']); // Exemple de redirection vers la page d'accueil
    // Ou utilisez la méthode suivante pour fermer la fenêtre actuelle (valide uniquement si la fenêtre a été ouverte dans une nouvelle fenêtre/tab)
    // window.close();
  }

  getPictureUrl(picture: any): string {
    return `https://localhost:7278/api/Pictures/GetPicture/lg/${picture.id}`;
  }

  showFullSizeImage(picture: any) {
    this.selectedPicture = picture;
  }

  async uploadCover() {
    if(this.coverInput == undefined){
      console.log("Input HTML non chargé.");
      return;
    }
    
      let file = this.coverInput.nativeElement.files[0];
      if(file == null){
        console.log("Input HTML ne contient aucune image.");
        return;
      }
      let formData = new FormData();
      formData.append('monImage', file, file.name);
    
      let x = await lastValueFrom(this.http.post<any>('https://localhost:7278/api/Pictures/PostCoverPicture/'+ this.galerieMy.id,formData));
      console.log(x);
      console.log('URL:', 'https://localhost:7278/api/Pictures/GetPicture/sm/' + x.id);
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
          if (this.galerieMy.pictures) {
            this.galerieMy.pictures.push(newPicture);
          } else {
            this.galerieMy.pictures = [newPicture];
          }
          
        }
      }

      console.log(x);
      console.log(this.galerieMy.pictures);
    }
    

  async create() : Promise<void>{

    this.galerieService.postGalerie(this.name, this.isPublic);
   
  }

  async deletePicture(galerieId: number, pictureId: number): Promise<void> {

      let x = await lastValueFrom(this.http.delete<Picture>(`https://localhost:7278/api/Pictures/DeletePicture/${galerieId}/${pictureId}`));
      console.log("La photo a été supprimée avec succès de la galerie");
      console.log(x);
    
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
