
import { Component } from '@angular/core';


import { AlertController, App, LoadingController,IonicPage, NavController, NavParams } from 'ionic-angular';
import {Facebook} from '@ionic-native/facebook';
import firebase from 'firebase';

@IonicPage()
@Component({
  selector: 'page-login',
  templateUrl: 'login.html',
})
export class LoginPage {

public loginForm: any;
  public backgroundImage = 'assets/img/background/background-5.jpg';

  constructor(public navCtrl: NavController, public navParams: NavParams, public loadingCtrl: LoadingController,
    public alertCtrl: AlertController,
    public app: App,public facebook:Facebook) {
  }

  login() {
   
this.navCtrl.setRoot('HomePage');
  }
 facebookLogin() {
  this.facebook.login(['email']).then(res=>{
const facebookCredentials=firebase.auth.FacebookAuthProvider.credential(res.authResponse.accessToken);
firebase.auth().signInWithCredential(facebookCredentials).then(firebaseSuccess=>{
this.navCtrl.setRoot('HomePage');
}).catch(firebaseError=>{
  alert("Error with credentials is "+JSON.stringify(firebaseError));
})
  }).catch(err=>{
alert("Error is "+JSON.stringify(err));
  }); 


  }

  goToSignup() {
    this.navCtrl.push('SignupPage');
  }

}
