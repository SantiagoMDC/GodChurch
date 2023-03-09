import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MiembroRegistroComponent } from './Gods-Church/miembro-registro/miembro-registro.component';
import { MiembroConsultaComponent } from './Gods-Church/miembro-consulta/miembro-consulta.component';

const routes:Routes = [
  {path: '', redirectTo:'/HomeComponent', pathMatch:'full'},
  {
    path: 'HomeComponent',
    component:HomeComponent
  },
  {
    path: 'miembroRegistro',
    component:MiembroRegistroComponent
  },
  {
    path: 'miembroConsulta',
    component:MiembroConsultaComponent
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
