import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions} from '@angular/http';
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
  
getinfo(accessToken) {
return new Promise(resolve => {
var headers:any = new Headers();
let requestOptions = new RequestOptions({ headers: headers });
headers.append('Authorization', 'Bearer ' + accessToken);
this.http.get('http://localhost:5000/api/values/5', requestOptions).subscribe(data => {
resolve(data);

}) 
});

}
}