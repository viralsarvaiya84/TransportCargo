import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTransportContainerComponent } from './add-transport-container.component';

describe('AddTransportContainerComponent', () => {
  let component: AddTransportContainerComponent;
  let fixture: ComponentFixture<AddTransportContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddTransportContainerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddTransportContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
