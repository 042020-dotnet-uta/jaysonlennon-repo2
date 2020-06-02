import { Component, OnInit } from '@angular/core';
import { UserAccountType } from 'src/app/model/user-account-type';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { User } from '../../model/user';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  currentUser: User;

  constructor(public authService: AuthenticationService) {
    this.authService.currentUser.subscribe((u) => (this.currentUser = u));
  }

  public ngOnInit() {}

  get isManager(): boolean {
    return (
      this.currentUser &&
      Number(this.currentUser.userAccountType) === UserAccountType.Manager
    );
  }

  get isTenant(): boolean {
    return (
      this.currentUser &&
      this.currentUser.userAccountType === UserAccountType.Tenant
    );
  }
}
