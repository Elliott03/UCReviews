import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { SignupPageComponent } from './signup-page/signup-page.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AuthInterceptor } from './core/interceptors/auth.interceptor';
import { DormPageComponent } from './dorm-page/dorm-page.component';
import { NgxStarsModule } from 'ngx-stars';
import { AuthGuard } from './core/guards/auth.guard';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    SignupPageComponent,
    NavbarComponent,
    DashboardComponent,
    DormPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgxStarsModule,
    RouterModule.forRoot([
      { path: 'signup', component: SignupPageComponent},
      { path: 'login', component: LoginPageComponent},
      { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard]},
      { path: 'dorm/:dorm', component: DormPageComponent, canActivate: [AuthGuard]},
      { path: '', redirectTo: 'dashboard', pathMatch: 'full'},
      { path: '**', redirectTo: 'dashboard', pathMatch: 'full'}
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true},
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
