import { NgModule, isDevMode } from '@angular/core';
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
import { CourseDashboardComponent } from './course-dashboard/course-dashboard.component';
import { CoursePageComponent } from './course-page/course-page.component';
import { InfiniteScrollDirective } from 'ngx-infinite-scroll';
import { ReviewsComponent } from './shared/reviews/reviews.component';
import { FooterComponent } from './shared/footer/footer.component';
import { NgOtpInputModule } from 'ng-otp-input';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { DormStyleIconComponent } from './shared/dorm-style-icon/dorm-style-icon.component';
import { DiningCategoryIconComponent } from './shared/dining-category-icon/dining-category-icon.component';
import { MealPlanIconComponent } from './shared/meal-plan-icon/meal-plan-icon.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { BreadcrumbComponent, BreadcrumbItemDirective } from 'xng-breadcrumb';
import { AddCourseModalComponent } from './add-course-modal/add-course-modal.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { SearchComponent } from './components/search/search.component';
import { ServiceWorkerModule } from '@angular/service-worker';

@NgModule({
  declarations: [
    AppComponent,
    SearchComponent,
    LoginPageComponent,
    SignupPageComponent,
    NavbarComponent,
    FooterComponent,
    DormDashboardComponent,
    DormPageComponent,
    GarageDashboardComponent,
    GaragePageComponent,
    DiningDashboardComponent,
    DiningPageComponent,
    OverallDashboardComponent,
    CourseDashboardComponent,
    CoursePageComponent,
    AddCourseModalComponent
  ],
  bootstrap: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgxStarsModule,
    MatCardModule,
    MatFormFieldModule,
    MatDialogModule,
    MatInputModule,
    ReactiveFormsModule,
    MatButtonModule,
    BrowserAnimationsModule,
    TextFieldModule,
    RouterLink,
    InfiniteScrollDirective,
    MatIconModule,
    DormStyleIconComponent,
    DiningCategoryIconComponent,
    MealPlanIconComponent,
    MatTooltipModule,
    NgOtpInputModule,
    ReviewsComponent,
    RouterOutlet,
    MatCheckboxModule,
    BreadcrumbComponent,
    BreadcrumbItemDirective,
    MatProgressSpinnerModule,
    RouterModule.forRoot(
      [
        { path: 'signup', component: SignupPageComponent },
        { path: 'login', component: LoginPageComponent },
        {
          path: 'dashboard',
          component: OverallDashboardComponent,
          canActivate: [AuthGuard],
          data: { breadcrumb: 'Dashboard' },
          children: [
            {
              path: 'housing',
              component: DormDashboardComponent,
              canActivate: [AuthGuard],
              data: { breadcrumb: 'Housing' },
              children: [
                {
                  path: ':name',
                  component: DormPageComponent,
                  canActivate: [AuthGuard],
                },
              ],
            },
            {
              path: 'garages',
              component: GarageDashboardComponent,
              canActivate: [AuthGuard],
              data: { breadcrumb: 'Garages' },
              children: [
                {
                  path: ':slug',
                  component: GaragePageComponent,
                  canActivate: [AuthGuard],
                },
              ],
            },
            {
              path: 'dining',
              component: DiningDashboardComponent,
              canActivate: [AuthGuard],
              data: { breadcrumb: 'Dining' },
              children: [
                {
                  path: ':name',
                  component: DiningPageComponent,
                  canActivate: [AuthGuard],
                },
              ],
              },
              {
                  path: 'courses',
                  component: CourseDashboardComponent,
                  canActivate: [AuthGuard],
                  data: { breadcrumb: 'Courses' },
                  children: [
                      {
                          path: ':slug',
                          component: CoursePageComponent,
                          canActivate: [AuthGuard],
                      }
                  ]
              }
          ],
        },
        { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
        { path: '**', redirectTo: 'dashboard', pathMatch: 'full' },
      ],
      { onSameUrlNavigation: 'reload' }
    ),
    ServiceWorkerModule.register('ngsw-worker.js', {
      enabled: !isDevMode(),
      // Register the ServiceWorker as soon as the application is stable
      // or after 30 seconds (whichever comes first).
      registrationStrategy: 'registerWhenStable:30000'
    }),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    AuthGuard,
    provideHttpClient(withInterceptorsFromDi()),
  ],
})
export class AppModule {}
