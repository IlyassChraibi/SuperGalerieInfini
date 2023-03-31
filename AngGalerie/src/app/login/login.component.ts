import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { LoginDTO } from '../model/LoginDTO';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginUsername!: string;
  loginPassword!: string;

  constructor(public router : Router, public http : HttpClient) { }

  ngOnInit() {
  }

  async login() : Promise<void>{
    // Retourner à la page d'accueil
    this.router.navigate(['/publicGalleries']);

    let loginDTO = new LoginDTO(this.loginUsername, this.loginPassword);

    let x = await lastValueFrom(this.http.post<any>("https://localhost:7278/api/Account/Login",loginDTO));
    console.log(x); 

    localStorage.setItem("token", x.token);
  }

}
