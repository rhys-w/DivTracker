import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'accounts',
  templateUrl: './accounts.component.html',
})
export class AccountsComponent {
  public accounts: Account[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Account[]>(baseUrl + 'api/accounts').subscribe(result => {
      this.accounts = result;
    }, error => console.error(error));
  }
}

interface Account {
  id: string;
  name: string;
  description: string;
  isIsa: boolean;
}
