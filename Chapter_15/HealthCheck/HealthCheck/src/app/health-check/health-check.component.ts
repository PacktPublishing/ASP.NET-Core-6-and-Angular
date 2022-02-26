import { Component, Inject, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { HealthCheckService, Result } from './health-check.service';

@Component({
  selector: 'app-health-check',
  templateUrl: './health-check.component.html',
  styleUrls: ['./health-check.component.scss']
})
export class HealthCheckComponent implements OnInit {

  public result: Observable<Result | null>;

  constructor(
    public service: HealthCheckService) {
      this.result = this.service.result;
  }

  ngOnInit() {
    this.service.startConnection();
    this.service.addDataListeners();  
  }

  onRefresh() {
    this.service.sendClientUpdate();
  }
}
