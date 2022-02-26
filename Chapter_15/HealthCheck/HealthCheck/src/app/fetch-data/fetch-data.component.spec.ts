import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FetchDataComponent } from './fetch-data.component';

describe('FetchDataComponent', () => {
  let component: FetchDataComponent;
  let fixture: ComponentFixture<FetchDataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FetchDataComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FetchDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
