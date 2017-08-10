//import { AppState } from './app.global';
import { Component, ViewChild } from '@angular/core';
import { Nav, Platform, MenuController } from 'ionic-angular';
import firebase from 'firebase';
import { IonicPage, NavController, NavParams } from 'ionic-angular';

import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { Subject } from 'rxjs';

// import { IonicPage, NavController, NavParams } from 'ionic-angular';

// import { Nav, Platform, MenuController } from 'ionic-angular';


@Component({
  selector: 'page-app',
  templateUrl: 'app.html'
})
export class MyApp {

 

  
  @ViewChild(Nav) nav: Nav;

  

  rootPage: any = 'LoginPage';
  activePage = new Subject();

  pages: Array<{ title: string, component: any, active: boolean, icon: string }>;
  rightMenuItems: Array<{ icon: string, active: boolean }>;
  state: any;


  constructor(public platform: Platform, 
    public statusBar: StatusBar,
    
    public splashScreen: SplashScreen,
    //public global: AppState,
    public menuCtrl: MenuController
    ) {
    this.initializeApp();
 this.pages = [
      { title: 'My Profile', component: 'MyProfile', active: true, icon: 'play' },
      { title: 'Discover', component: 'MyProfile', active: true, icon: 'play' },
        { title: 'Friends', component: 'MyProfile', active: true, icon: 'play' },
          { title: 'Timeline', component: 'MyProfile', active: true, icon: 'play' },
      
 ];


 
  this.activePage.subscribe((selectedPage: any) => {
      this.pages.map(page => {
        page.active = page.title === selectedPage.title;
      });
    });
  }

  
  user = {
    name: 'Paula Bolliger',
    profileImage: 'assets/img/avatar/girl-avatar.png',
    coverImage: 'assets/img/background/background-5.jpg',
    occupation: 'Designer',
    location: 'Seattle, WA',
    description: 'A wise man once said: The more you do something, the better you will become at it.',
    followers: 456,
    following: 1052,
    posts: 35
  };


  initializeApp() {
    this.platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      this.statusBar.styleDefault();
      this.splashScreen.hide();
    });
  }
  

  openPage(page) {
    // Reset the content nav to have just this page
    // we wouldn't want the back button to show in this scenario
    this.nav.setRoot(page.component);
  }

  
tohome()
{
  this.nav.setRoot('HomePage');

}
  




}