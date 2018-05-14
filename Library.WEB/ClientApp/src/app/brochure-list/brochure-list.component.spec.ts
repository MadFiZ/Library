import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BrochureListComponent } from './brochure-list.component';

describe('BrochureListComponent', () => {
  let component: BrochureListComponent;
  let fixture: ComponentFixture<BrochureListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BrochureListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BrochureListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
