import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import firebase from 'firebase';
import { Nav, Platform, MenuController } from 'ionic-angular';

@IonicPage()
@Component({
  selector: 'my-profile',
  templateUrl: 'myprofile.html'
})
export class MyProfile {

  pagez: Array<{ title: string, component: any, active: boolean, icon: string }>;


  constructor(public navCtrl: NavController) {
 
    this.pagez = [
      { title: 'INFO', component: 'MyProfile', active: true, icon: 'play' },
      { title: 'STATS', component: 'MyProfile', active: true, icon: 'play' },
        { title: 'FRIENDS', component: 'MyProfile', active: true, icon: 'play' },
          { title: '#RECENT POSTS', component: 'MyProfile', active: true, icon: 'play' },
           { title: 'GALLERY', component: 'MyProfile', active: true, icon: 'play' },
            { title: 'FRIENDS', component: 'MyProfile', active: true, icon: 'play' },
      
 ];
 
}
 

 
logout(){
  firebase.auth().signOut().then(res=>{
this.navCtrl.setRoot('LoginPage');
  });
}
tohome()
{
  this.navCtrl.setRoot('HomePage');

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
