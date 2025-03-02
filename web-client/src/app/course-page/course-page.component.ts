import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../core/services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ReviewService } from '../core/services/review.service';
import { CourseService } from '../core/services/course.service';
import { firstValueFrom } from 'rxjs';
import { NgxStarsComponent } from 'ngx-stars';
import { emailToUsername as _emailToUsername } from '../core/helpers/emailToUsername';
import { convertDateToReadable as _convertDateToReadable } from '../core/helpers/convertDateToReadable';
import { IUser } from '../Models/User';
import { IReview, SaveReview } from '../Models/Review';
import { PageableQueryParam } from '../core/types/QueryParams';
import { ReviewsComponent } from '../shared/reviews/reviews.component';
import { ICourse } from '../Models/Course';
import { IReviewWithUser } from '../Models/ReviewWithUser';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
    selector: 'course-page',
    templateUrl: './course-page.component.html',
    styleUrl: './course-page.component.scss',
    standalone: false
})
export class CoursePageComponent implements OnInit, AfterViewInit {
  course?: ICourse;
  user: IUser | undefined;
  username: string | undefined;
  reviewText: string = '';
  maxCharacterCount: number = 1000;
  currentCharacterCount: number = 0;

  emailToUsername = _emailToUsername;
  convertDateToReadable = _convertDateToReadable;

  @ViewChild('courseRating')
  courseStarsComponent: NgxStarsComponent = new NgxStarsComponent();

  @ViewChild('reviewRating')
  reviewStarsComponent: NgxStarsComponent = new NgxStarsComponent();

  @ViewChild('reviewsComponent')
  reviewsComponent!: ReviewsComponent;

  constructor(
    private _bcService: BreadcrumbService,
    private _route: ActivatedRoute,
    private _courseService: CourseService,
    private _reviewService: ReviewService,
    private _authService: AuthService,
    private _router: Router
  ) {}

  async ngOnInit() {
    if (!this._authService.isLoggedIn()) {
      this._router.navigate(['/signup']);
      return;
    }
    const slug = this._route.snapshot.params['slug'];
    this.course = await firstValueFrom(
      this._courseService.getCourse(slug)
    );

    if (!this.course) {
      this._router.navigate(['/dashboard', 'courses']);
      return;
    }

    this._bcService.set('dashboard/courses/:slug', this.course.name);
    const stringUser = localStorage.getItem('user');

    if (stringUser) {
      this.user = JSON.parse(stringUser);
      const numberOfCharactersForEmailEnding = -12;
      this.username = this.user?.email.slice(
        0,
        numberOfCharactersForEmailEnding
      );
    }
  }

  ngAfterViewInit() {
    // Wait for the course data to be loaded
    if (this.course) {
      this.setCourseRating();
    } else {
      // If course is not yet loaded, listen for it
      this._route.params.subscribe(async (params) => {
        const slug = params['name'];
        this.course = await firstValueFrom(
          this._courseService.getCourse(slug)
        );
        this.setCourseRating();
      });
    }
  }

  private setCourseRating() {
    if (this.courseStarsComponent && this.course) {
      this.courseStarsComponent.setRating(
        this.course.reviewSummary?.averageRating || 0
      );
    }
  }

  async sendReview() {
    const userId = this._authService.getUserId();
    if (!this.reviewText || userId === -1 || !this.course) return;
    const newReview = new SaveReview({
      reviewText: this.reviewText,
      rating: this.reviewStarsComponent.rating.toString(),
      userId,
      courseId: this.course.id,
    });
    const addedReview = await firstValueFrom(
      this._reviewService.addReview(newReview)
    );
    this.reviewsComponent.addReviewToFront({
      review: addedReview.review,
      user: {
        id: userId,
        email: this.user?.email || '',
      },
    });
    this.courseStarsComponent.setRating(addedReview.summary.averageRating);
    this.reviewStarsComponent.setRating(0); // Reset component
    this.reviewText = '';
    this.currentCharacterCount = 0;
  }

  updateCharacterCount(event: any) {
    const currentText: string = event.target.value;
    this.currentCharacterCount = currentText.length;
  }

  getReviewsLoader(): (params: PageableQueryParam) => Promise<IReviewWithUser[]> {
    return async ({ prev, perPage }: PageableQueryParam) => {
      if (!this.course) return [];
      const reviews = await firstValueFrom(
        this._reviewService.getReviewsByCourseId({
          perPage,
          prev,
          courseId: String(this.course.id),
        })
      );
      return reviews;
    };
  }
}
