import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './Home/Home.component';
import { RouterModule, Routes } from '@angular/router';
import { HomeService } from './Home/Home.service';
import { HttpClientModule } from '@angular/common/http';
import { PostCardComponent } from './postCard/postCard.component';

const appRoutes: Routes = [
  {
    path: '',
    component: HomeComponent
  },

]

@NgModule({
  declarations: [	
    AppComponent,
    NavBarComponent,
      HomeComponent,
      PostCardComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoutes),
    BsDropdownModule.forRoot(),
    BrowserAnimationsModule,
    HttpClientModule
  ],
  providers: [HomeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
