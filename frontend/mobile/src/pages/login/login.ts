
import { Component } from '@angular/core';


import { AlertController, App, LoadingController,IonicPage, NavController, NavParams } from 'ionic-angular';

/**
 * Generated class for the LoginPage page.
 *
 * See http://ionicframework.com/docs/components/#navigation for more info
 * on Ionic pages and navigation.
 */

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
    public app: App) {
  }

  login() {
   
this.navCtrl.setRoot('HomePage');
  }

  goToSignup() {
    this.navCtrl.push('SignupPage');
  }

}
