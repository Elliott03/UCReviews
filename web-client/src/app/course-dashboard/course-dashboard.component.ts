import { Component, OnInit } from '@angular/core';
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
export class CourseDashboardComponent implements OnInit {
  hasChildRoute = false;
  courses: ICourse[] = [];
  searchTerm: string = '';
  prev = 0;
  perPage = 20;
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
        searchTerm: this.searchTerm,
      })
      .subscribe((courses) => {
        courses.sort((a, b) => a.id - b.id);
        this.courses.push(...courses);
      });
  }

  trackById(index: number, course: ICourse): number {
    return course.id;
  }

  onSearchChange(searchTerm: string) {
    this.searchTerm = searchTerm;
    this.courses = [];
    this.prev = 0;
    this.loadCourses();
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

  filteredCourses(): ICourse[] {
    return this.courses.filter((course) => {
      return course.nameQueryParameter.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      course.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
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
