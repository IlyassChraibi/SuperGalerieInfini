import { MyGalleriesComponent } from './../myGalleries/myGalleries.component';
import { Galerie } from './../model/Galerie';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FactoryOrValue, lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GalerieService {

  galeries : Galerie[] = [];
  newGalerie ?: Galerie;

constructor(public http: HttpClient) { }

logout(){
  localStorage.removeItem("token");
}

async postGalerie(name : string, isPublic : boolean): Promise<void>{

  /*let token = localStorage.getItem("token");
  const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'Bearer ' + token
    })
  };*/

   this.newGalerie = new Galerie(0, name, isPublic);

  let x = await lastValueFrom(this.http.post<Galerie>('https://localhost:7278/api/Galeries/PostGalerie' , this.newGalerie));

  console.log(x);
  
  this.galeries.push(x);
}

updateInfo(){
  this.getGAleries();
}

async getGAleries() : Promise<void>{
 /* let token = localStorage.getItem("token");
  const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'Bearer ' + token
    })
  };*/

  let x = await lastValueFrom(this.http.get<Galerie[]>("https://localhost:7278/api/Galeries/GetGalerie"));
  console.log(x);
  this.galeries = x;
}

async getGAleriesPublic() : Promise<void>{
  /* let token = localStorage.getItem("token");
   const httpOptions = {
     headers: new HttpHeaders({
       'Content-Type':  'application/json',
       'Authorization': 'Bearer ' + token
     })
   };*/
 
   let x = await lastValueFrom(this.http.get<Galerie[]>("https://localhost:7278/api/Galeries/GetGaleriePublic"));
   console.log(x);
   this.galeries = x;
 }

 async rendrePublique(id: number, name: string): Promise<void> {
  let updatedGalerie = new Galerie(id, name, true);
  let x = await lastValueFrom(this.http.put<Galerie>("https://localhost:7278/api/Galeries/PutGalerie/"+ id, updatedGalerie));
  console.log(x);
  updatedGalerie = x;
  this.updateInfo();
}

async rendrePrivee(id: number, name: string): Promise<void> {
  let updatedGalerie = new Galerie(id, name, false);
  let x = await lastValueFrom(this.http.put<Galerie>("https://localhost:7278/api/Galeries/PutGalerie/"+ id, updatedGalerie));
  console.log(x);
  updatedGalerie = x;
  this.updateInfo();
}

async deleteGalerie(id: number) : Promise<void>{

   let x = await lastValueFrom(this.http.delete<Galerie[]>("https://localhost:7278/api/Galeries/DeleteGalerie/"+ id));
   console.log(x);
   this.galeries = x;
   this.updateInfo();
 }

 async addCollabo(id: number, username: string, galerie : Galerie): Promise<void> {
  let updatedGalerie = galerie;
  let x = await lastValueFrom(this.http.put<Galerie>("https://localhost:7278/api/Galeries/PutGalerieCollabo/PutGalerie/"+ id+"/"+username, updatedGalerie));
 // console.log(id + username + updatedGalerie)
  console.log(x);
 // this.galeries = x;
  this.updateInfo();
}

}