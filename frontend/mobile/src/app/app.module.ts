import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';

import { MyApp } from './app.component';

import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import {Facebook} from '@ionic-native/facebook';
import { GooglePlus } from '@ionic-native/google-plus';
import firebase from 'firebase';

export const firebaseConfig={
  apiKey: "AIzaSyCPh7XxXvd-I7IavnYanc9rGxpqZYU-Cig",
    authDomain: "trendingtopit-cb54b.firebaseapp.com",
    databaseURL: "https://trendingtopit-cb54b.firebaseio.com",
    projectId: "trendingtopit-cb54b",
    storageBucket: "trendingtopit-cb54b.appspot.com",
    messagingSenderId: "1063971484486"
}
  firebase.initializeApp(firebaseConfig);
@NgModule({
  declarations: [
    MyApp
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(MyApp),
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp
  ],
  providers: [
    StatusBar,
    SplashScreen,
    Facebook,
    GooglePlus,
    {provide: ErrorHandler, useClass: IonicErrorHandler}
  ]
})
export class AppModule {}
