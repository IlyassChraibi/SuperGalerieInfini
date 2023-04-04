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

}
