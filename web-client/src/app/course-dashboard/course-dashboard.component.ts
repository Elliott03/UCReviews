import { Component } from '@angular/core';
import { ICourse } from '../Models/Course';
import { CourseService } from '../core/services/course.service';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';
import { MatDialog } from '@angular/material/dialog';
import { AddCourseModalComponent } from '../add-course-modal/add-course-modal.component';

@Component({
  selector: 'course-dashboard',
  templateUrl: './course-dashboard.component.html',
  styleUrl: './course-dashboard.component.scss',
})
export class CourseDashboardComponent {
  hasChildRoute = false;
  courses: ICourse[] = [];
  prev = 0;
  perPage = 6;
  showAddButtons = true;

  constructor(
    private _courseService: CourseService,
    private _router: Router,
    public _authService: AuthService,
    private _route: ActivatedRoute,
    public dialog: MatDialog
  ) {}
  ngOnInit(): void {
    this.showAddButtons = true;

    if (this._authService.isLoggedIn()) {
      this.loadCourses();
    } else {
      this._router.navigate(['/signup']);
    }
    this._router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.hasChildRoute = this._route.children.length > 0;
        if (!this.hasChildRoute) {
          this.loadCourses();
          this.showAddButtons = true;
        }
      }
    });
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
  openAddCourseModal(): void {
    const dialogRef = this.dialog.open(AddCourseModalComponent);
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.showAddButtons = false;
      }
    });
  }
  onCardClick(): void {
    this.showAddButtons = false;
  }
}
