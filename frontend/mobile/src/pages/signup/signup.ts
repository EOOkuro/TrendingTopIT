
import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, MenuController } from 'ionic-angular';
import firebase from 'firebase';
import { User } from './../../models/user';
import { Validators, FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { PasswordValidation } from "../../validators/password.validator";

@IonicPage()
@Component({
  selector: 'page-signup',
  templateUrl: 'signup.html',
})
export class SignupPage {
  user = {} as User;
  showPassword: boolean = false;
  terms: boolean = false;
  sform: FormGroup;

  validation_messages = {
    'email': [
      { type: 'required', message: 'Email is required.' },
      { type: 'pattern', message: 'Please enter a valid email' }
    ],
    'password': [
      { type: 'required', message: 'Password is required.' },
      { type: 'minlength', message: 'Password must be at least 6 characters long.' },
      { type: 'pattern', message: 'Your password must contain at least one upper case, one lower case, one digit and one special character.' }
    ],
    'confirm_password': [
      { type: 'MatchPassword', message: 'Password does not match.' }
    ],
    'terms': [
      { type: 'true', message: 'You must accept the Terms of use.' }
    ],

    //more messages
  }
  submitAttempt: boolean = false;
  constructor(public navCtrl: NavController, public navParams: NavParams, public formBuilder: FormBuilder, public menu:MenuController) {
  menu.swipeEnable(false);
  }
  ionViewWillLoad() {

    this.sform = new FormGroup({
      email: new FormControl('', Validators.compose([
        Validators.required,
        Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
      ])),
      password: new FormControl('', Validators.compose([
        Validators.minLength(6),
        Validators.required,
        Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$')
      ])),
      terms: new FormControl(true, Validators.pattern('true')),
      showPassword: new FormControl(''),
      confirm_password: new FormControl('', Validators.required)
    }, (formGroup: FormGroup) => {
      return PasswordValidation.MatchPassword(formGroup);
    });

  }
  ionViewDidLoad() {
    console.log('ionViewDidLoad SignupPage');
  }
  public register() {

    if (this.sform.valid) {
      firebase.auth().createUserWithEmailAndPassword(this.user.email, this.user.password)
        .then(firebaseSuccess => {
          this.navCtrl.setRoot('LoginPage');
        })
        .catch(firebaseFailed => {
          console.log('error ' + firebaseFailed);
        })

    }
    else {
      this.submitAttempt = true;
    }

  }

}
