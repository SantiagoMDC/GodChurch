import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule,HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MenuComponent } from './Components/menu/menu.component';
import { ContentComponent } from './Components/content/content.component';
import { FooterComponent } from './Components/footer/footer.component';
import { HeadersComponent } from './Components/headers/headers.component';
import { AppRoutingModule } from './app-routing.module';
import { MiembroConsultaComponent } from './Gods-Church/miembro-consulta/miembro-consulta.component';
import { MiembroRegistroComponent } from './Gods-Church/miembro-registro/miembro-registro.component';
import { MiembroService } from './services/miembro.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    HeadersComponent,
    MenuComponent,
    ContentComponent,
    FooterComponent,
    MiembroConsultaComponent,
    MiembroRegistroComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    AppRoutingModule
  ],
  providers: [MiembroService],
  bootstrap: [AppComponent]
})
export class AppModule { }
