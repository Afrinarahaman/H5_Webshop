import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-guest',
  templateUrl: './guest.component.html',
  styleUrls: ['./guest.component.css']
})
export class GuestComponent implements OnInit {

  users: User[] = [];
  user: User = this.newUser();
  message: string[] = [];
  error = '';
 

  

  constructor(
    private userService: UserService,
   
  ) { }

  ngOnInit(): void {
    this.getUsers();
  }

  newUser(): User {
    return { id: 0, email: '', password: '', firstName: '', lastName: '', address: '', telephone: ''};
  }

  getUsers(): void {
    this.userService.getUsers()
      .subscribe((a: User[]) => this.users = a);
  }

  cancel(): void {
    this.message = [];
    this.user = this.newUser();
  }

  save(): void {
    this.message = [];

    if (this.user.email == '') {
      this.message.push('Email field cannot be empty');
    }
    
    if (this.user.firstName == '') {
      this.message.push('Enter Username');
    }
    if (this.user.lastName == '') {
      this.message.push('Enter Lastname');
    }
    if (this.user.address == '') {
      this.message.push('Enter Address');
    }
    if (this.user.telephone == '') {
      this.message.push('Enter Telephone');
    }
  
    if (this.message.length == 0) {
      if (this.user.id == 0) {
        this.userService.addUser(this.user)
          .subscribe({
            next: (a: any) => {
            this.users.push(a)
            this.user = this.newUser();
            alert('Thanks for Signing Up!');
           },
           error: (err: any)=>{
                        alert("User already exists!");
          }
        });
      } else {
            this.userService.updateUser(this.user.id, this.user)
              .subscribe(() => {
                this.user = this.newUser();
              });
           }
  }}


}