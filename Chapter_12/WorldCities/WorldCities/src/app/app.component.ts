import { Component, OnInit } from '@angular/core';
import { AuthService } from './auth/auth.service';
import { ConnectionService } from 'angular-connection-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title = 'WorldCities';

  hasNetworkConnection: boolean = false;
  hasInternetAccess: boolean = false;

  constructor(private authService: AuthService,
    private connectionService: ConnectionService) {
    this.connectionService.monitor().subscribe((currentState: any) => {
      this.hasNetworkConnection = currentState.hasNetworkConnection;
      this.hasInternetAccess = currentState.hasInternetAccess;
    });
  }

  public isOnline() {
    return this.hasNetworkConnection && this.hasInternetAccess;
  }

  ngOnInit(): void {
    this.authService.init();
  }
}
