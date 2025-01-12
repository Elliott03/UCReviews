import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { SignupPageComponent } from './signup-page/signup-page.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { DormDashboardComponent } from './dorm-dashboard/dorm-dashboard.component';
import { RouterLink, RouterModule, RouterOutlet } from '@angular/router';
import {
  HTTP_INTERCEPTORS,
  provideHttpClient,
  withInterceptorsFromDi,
} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthInterceptor } from './core/interceptors/auth.interceptor';
import { DormPageComponent } from './dorm-page/dorm-page.component';
import { NgxStarsModule } from 'ngx-stars';
import { AuthGuard } from './core/guards/auth.guard';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TextFieldModule } from '@angular/cdk/text-field';
import { OverallDashboardComponent } from './overall-dashboard/overall-dashboard.component';
import { GaragePageComponent } from './garage-page/garage-page.component';
import { GarageDashboardComponent } from './garage-dashboard/garage-dashboard.component';
import { DiningDashboardComponent } from './dining-dashboard/dining-dashboard.component';
import { DiningPageComponent } from './dining-page/dining-page.component';
import { InfiniteScrollDirective } from 'ngx-infinite-scroll';
import { ReviewsComponent } from './shared/reviews/reviews.component';
import { FooterComponent } from './shared/footer/footer.component';
import { NgOtpInputModule } from 'ng-otp-input';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    SignupPageComponent,
    NavbarComponent,
    FooterComponent,
    DormDashboardComponent,
    DormPageComponent,
    GarageDashboardComponent,
    GaragePageComponent,
    OverallDashboardComponent,
    DiningDashboardComponent,
    DiningPageComponent,
  ],
  bootstrap: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgxStarsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatButtonModule,
    BrowserAnimationsModule,
    TextFieldModule,
    RouterLink,
    InfiniteScrollDirective,
    NgOtpInputModule,
    ReviewsComponent,
    RouterOutlet,
    RouterModule.forRoot([
      { path: 'signup', component: SignupPageComponent },
      { path: 'login', component: LoginPageComponent },
      {
        path: 'dashboard',
        component: OverallDashboardComponent,
        canActivate: [AuthGuard],
      },
      {
        path: 'dashboard/housing',
        component: DormDashboardComponent,
        canActivate: [AuthGuard],
      },
      {
        path: 'dashboard/housing/:dorm',
        component: DormPageComponent,
        canActivate: [AuthGuard],
      },
      {
        path: 'dashboard/garages',
        component: GarageDashboardComponent,
        canActivate: [AuthGuard],
      },
      {
        path: 'dashboard/garages/:slug',
        component: GaragePageComponent,
        canActivate: [AuthGuard],
      },
      {
        path: 'dashboard/dining',
        component: DiningDashboardComponent,
        canActivate: [AuthGuard],
      },
      {
        path: 'dashboard/dining/:nameQueryParameter',
        component: DiningPageComponent,
        canActivate: [AuthGuard],
      },
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: '**', redirectTo: 'dashboard', pathMatch: 'full' },
    ]),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    AuthGuard,
    provideHttpClient(withInterceptorsFromDi()),
  ],
})
export class AppModule {}
