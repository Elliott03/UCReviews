import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { SignupPageComponent } from './signup-page/signup-page.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthInterceptor } from './core/interceptors/auth.interceptor';
import { DormPageComponent } from './dorm-page/dorm-page.component';
import { NgxStarsModule } from 'ngx-stars';
import { AuthGuard } from './core/guards/auth.guard';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TextFieldModule} from '@angular/cdk/text-field';



@NgModule({ declarations: [
        AppComponent,
        LoginPageComponent,
        SignupPageComponent,
        NavbarComponent,
        DashboardComponent,
        DormPageComponent
    ],
    bootstrap: [AppComponent], 
    imports: [BrowserModule,
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
        RouterModule.forRoot([
            { path: 'signup', component: SignupPageComponent },
            { path: 'login', component: LoginPageComponent },
            { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
            { path: 'dorm/:dorm', component: DormPageComponent, canActivate: [AuthGuard] },
            { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
            { path: '**', redirectTo: 'dashboard', pathMatch: 'full' }
        ])], providers: [
        { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
        AuthGuard,
        provideHttpClient(withInterceptorsFromDi())
    ] })
export class AppModule { }
