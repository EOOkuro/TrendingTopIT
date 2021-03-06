import { LoginService } from './../../providers/login-service/login-service';
import { Http } from '@angular/http';

import { User } from './../../models/user';
import { Component } from '@angular/core';

import { AlertController, App, LoadingController, IonicPage, NavController, MenuController } from 'ionic-angular';
import { Facebook } from '@ionic-native/facebook';
import { GooglePlus } from '@ionic-native/google-plus';
import firebase from 'firebase';
import { TwitterConnect } from '@ionic-native/twitter-connect';

@IonicPage()
@Component({
  selector: 'page-login',
  templateUrl: 'login.html',
})
export class LoginPage {
  user = {} as User;
  public loginForm: any;
  public backgroundImage = 'assets/img/background/background-5.jpg';
  userProfile: any = null;
  constructor(public nav: NavController, public loadingCtrl: LoadingController,
    public alertCtrl: AlertController,
   public menu: MenuController,
   public loginService:LoginService,
    public app: App, public facebook: Facebook, private googlePlus: GooglePlus, private twitter: TwitterConnect) {
    menu.swipeEnable(false);
      firebase.auth().onAuthStateChanged(user => {
      if (user) {
        this.userProfile = user;
        
        this.nav.setRoot('HomePage');
        console.log("auth changed:"+user.email);
      } else {
        this.userProfile = null;
      }
    });
  }

  login() {
    var authService=this.loginService;
    firebase.auth().signInWithEmailAndPassword(this.user.email, this.user.password)
      .then(firebaseSuccess => {
        firebase.auth().currentUser.getIdToken().then(function(idToken) {
  console.log(idToken);
  //make secure call to api
authService.getinfo(idToken).then(data=>{
  console.log(data);
}).catch(error=>{
  console.log(error);
});
}).catch(function(error) {
  console.log("could not get the token");
});

        this.nav.setRoot('HomePage');
      }).catch(firebaseError => {
        console.log("Error with credentials is " + JSON.stringify(firebaseError));
      }).catch(err => {
        console.log("Error is " + JSON.stringify(err));
      });
  }
  facebookLogin() {
    console.log("login to facebook");
    this.facebook.login(['email']).then(res => {
      const facebookCredentials = firebase.auth.FacebookAuthProvider.credential(res.authResponse.accessToken);
      firebase.auth().signInWithCredential(facebookCredentials).then(firebaseSuccess => {
        this.nav.setRoot('HomePage');// User is signed in.
        
      }).catch(firebaseError => {
        console.log("Error with credentials is " + JSON.stringify(firebaseError));
      })
    }).catch(err => {
      console.log("Error is " + JSON.stringify(err));
    });

  }
  googleLogin() {
    console.log("login to google");
    this.googlePlus.login({
      'scopes': '',
      'webClientId': '1063971484486-9gpj9m0gppukt8ho33rb9na6ij6egf1r.apps.googleusercontent.com',
      'offline': true
    }).then(res => {
      console.log(res);
      firebase.auth().signInWithCredential(firebase.auth.GoogleAuthProvider.credential(res.idToken))
        .then(success => {
          
          this.nav.setRoot('HomePage');
        })
        .catch(error => console.log("Firebase failure: " + JSON.stringify(error)));
    }).catch(err => console.error("Error: ", + err));

  }

  twitterLogin() {
    this.twitter.login().then(response => {
      console.log(response);
      const twitterCredential = firebase.auth.TwitterAuthProvider
        .credential(response.token, response.secret);

      firebase.auth().signInWithCredential(twitterCredential)
        .then(success => {
          console.log("Firebase success: " + JSON.stringify(success));
          this.nav.setRoot('HomePage');
        })
        .catch(error => console.log("Firebase failure: " + JSON.stringify(error)));
    }, error => {
      console.log("Error connecting to twitter: ", error);
    });
  }

  goToSignup() {
    this.nav.push('SignupPage');
  }

}
