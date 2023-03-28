import { RegisterDTO } from './../model/RegisterDTO';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  username!: string;
  email!: string;
  password!: string;
  passwordConfirm!: string;

  constructor(public router : Router, public http : HttpClient) { }

  ngOnInit() {
  }

  async register() : Promise<void>{
    // Aller vers la page de connexion
    this.router.navigate(['/login']);

    let registerDTO = new RegisterDTO(this.username, this.email, this.password, this.passwordConfirm);

    let x = await lastValueFrom(this.http.post<RegisterDTO>("https://localhost:7278/api/Account/Register",registerDTO));
    console.log(x);
    }

}
