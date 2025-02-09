import { Component } from '@angular/core';
import { ICourse } from '../Models/Course';
import { CourseService } from '../core/services/course.service';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';

@Component({
  selector: 'course-dashboard',
  templateUrl: './course-dashboard.component.html',
  styleUrl: './course-dashboard.component.scss',
})
export class CourseDashboardComponent {
  courses: ICourse[] = [];
  prev = 0;
  perPage = 6;
  constructor(
    private _courseService: CourseService,
    private _router: Router,
    public _authService: AuthService
  ) {}
  ngOnInit(): void {
    if (this._authService.isLoggedIn()) {
      this.loadCourses();
    } else {
      this._router.navigate(['/signup']);
    }
  }
  loadCourses() {
    this._courseService
      .getCourses({
        perPage: this.perPage,
        prev: this.prev,
      })
      .subscribe((courses) => {
        courses.sort((a, b) => a.id - b.id);
        this.courses.push(...courses);
      });
  }
  getCourseRatingTitle(course: ICourse) {
    if (!course.reviewSummary?.averageRating) {
      return 'Not yet rated';
    }
    return `${course.reviewSummary.averageRating} stars`;
  }
  onScroll(): void {
    this.prev += this.perPage;
    this.loadCourses();
  }
}
