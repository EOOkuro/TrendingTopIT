import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, MenuController } from 'ionic-angular';
import firebase from 'firebase';

@IonicPage()
@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  pagezz: Array<{ title: string, Location: any, active: boolean, icon: string }>;
  rightMenuItems: Array<{ icon: string, active: boolean }>;
  state: any;

  constructor(public navCtrl: NavController,public menu:MenuController) {
menu.swipeEnable(true);
    this.pagezz = [
      { title: 'Crossing the mara', Location: 'MyProfile', active: true, icon: 'play' },
      { title: 'Soccer challenge', Location: 'MyProfile', active: true, icon: 'play' },
        { title: 'Snoaking', Location: 'MyProfile', active: true, icon: 'play' },
          { title: 'Swimming', Location: 'MyProfile', active: true, icon: 'play' },
      
 ];

}
logout(){
  firebase.auth().signOut().then(res=>{
this.navCtrl.setRoot('LoginPage');
  });

}
 following = false;
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

  

  
}
