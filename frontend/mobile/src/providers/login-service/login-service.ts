import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import firebase from 'firebase';
/*
  Generated class for the LoginServiceProvider provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular DI.
*/
@Injectable()
export class LoginService {

  constructor(public http: Http) {
    console.log('Hello LoginService Provider');
   
  }

  get isLoggedIn(): boolean {
    var user = firebase.auth().currentUser;

if (user) {
  return true;
} else {
  return false
}
  }

}
