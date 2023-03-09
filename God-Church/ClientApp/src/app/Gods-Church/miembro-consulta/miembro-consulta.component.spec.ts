import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MiembroConsultaComponent } from './miembro-consulta.component';

describe('MiembroConsultaComponent', () => {
  let component: MiembroConsultaComponent;
  let fixture: ComponentFixture<MiembroConsultaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MiembroConsultaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MiembroConsultaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
