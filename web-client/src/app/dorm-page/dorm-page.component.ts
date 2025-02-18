import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Dorm, ILargeDorm } from '../Models/Dorm';
import { DormService } from '../core/services/dorm.service';
import { NgxStarsComponent } from 'ngx-stars';
import { IUser } from '../Models/User';
import { IReview, SaveReview } from '../Models/Review';
import { AuthService } from '../core/services/auth.service';
import { ReviewService } from '../core/services/review.service';
import { emailToUsername as _emailToUsername } from '../core/helpers/emailToUsername';
import { convertDateToReadable as _convertDateToReadable } from '../core/helpers/convertDateToReadable';
import { PageableQueryParam } from '../core/types/QueryParams';
import { firstValueFrom } from 'rxjs';
import { ReviewsComponent } from '../shared/reviews/reviews.component';
import { IReviewWithUser } from '../Models/ReviewWithUser';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'dorm-page',
  templateUrl: './dorm-page.component.html',
  styleUrls: ['./dorm-page.component.scss'],
})
export class DormPageComponent implements OnInit {
  dorm: ILargeDorm | undefined;
  user: IUser | undefined;
  username: string | undefined;
  reviewText: string = '';
  maxCharacterCount: number = 1000;
  currentCharacterCount: number = 0;

  emailToUsername = _emailToUsername;
  convertDateToReadable = _convertDateToReadable;

  @ViewChild('dormRating')
  dormStarsComponent: NgxStarsComponent = new NgxStarsComponent();

  @ViewChild('reviewRating')
  reviewStarsComponent: NgxStarsComponent = new NgxStarsComponent();

  @ViewChild('reviewsComponent')
  reviewsComponent!: ReviewsComponent;

  constructor(
    private _bcService: BreadcrumbService,
    private _route: ActivatedRoute,
    private _dormService: DormService,
    private _reviewService: ReviewService,
    private _authService: AuthService,
    private _router: Router
  ) {}

  async ngOnInit() {
    if (this._authService.isLoggedIn()) {
      const queryParam = this._route.snapshot.params['name'];
      this.dorm = await firstValueFrom(this._dormService.getDorm(queryParam));
      this._bcService.set('dashboard/housing/:slug', this.dorm.name);
      const stringUser = localStorage.getItem('user');
      if (stringUser) {
        this.user = JSON.parse(stringUser);
        const numberOfCharactersForEmailEnding = -12;
        this.username = this.user?.email.slice(
          0,
          numberOfCharactersForEmailEnding
        );
      }
    } else {
      this._router.navigate(['/signup']);
      return;
    }

    // Get the dorm's slug from the route parameters
    const slug = this._route.snapshot.params['slug']; // Make sure your URL is correct

    // Fetch the dorm details using the slug
    this.dorm = await firstValueFrom(this._dormService.getDorm(slug));

    if (!this.dorm) {
      // If the dorm is not found, redirect to another page or show an error
      this._router.navigate(['/dashboard', 'housing']);
      return;
    }

    // Set the breadcrumb for the current dorm
    this._bcService.set('dashboard/housing/:slug', this.dorm.name);

    // Set the user's username if logged in
    const stringUser = localStorage.getItem('user');
    if (stringUser) {
      this.user = JSON.parse(stringUser);
      const numberOfCharactersForEmailEnding = -12;
      this.username = this.user?.email.slice(0, numberOfCharactersForEmailEnding);
    }
  }

  ngAfterViewInit() {
    // Wait for the dorm data to be loaded and set the rating
    if (this.dorm) {
      this.setDormRating();
    } else {
      this._route.params.subscribe(async (params) => {
<<<<<<< HEAD
        const nameQueryParameter = params['name'];
        this.dorm = await firstValueFrom(
          this._dormService.getDorm(nameQueryParameter)
        );
=======
        const nameQueryParameter = params['slug'];
        this.dorm = await firstValueFrom(this._dormService.getDorm(nameQueryParameter));
>>>>>>> main
        this.setDormRating();
      });
    }
  }

  setDormRating() {
    if (this.dormStarsComponent && this.dorm) {
      this.dormStarsComponent.setRating(this.dorm.reviewSummary?.averageRating || 0);
    }
  }

  updateCharacterCount(event: any) {
    const currentText: string = event.target.value;
    this.currentCharacterCount = currentText.length;
  }

  async sendReview() {
    const userId = this._authService.getUserId();
    if (!this.reviewText || userId === -1 || !this.dorm) return;
    const newReview = new SaveReview({
      reviewText: this.reviewText,
      rating: this.reviewStarsComponent.rating.toString(),
      userId,
      dormId: this.dorm.id,
    });
    const addedReview = await firstValueFrom(this._reviewService.addReview(newReview));
    this.reviewsComponent.addReviewToFront({
      review: addedReview.review,
      user: {
        id: userId,
        email: this.user?.email || '',
      },
    });
    this.dormStarsComponent.setRating(addedReview.summary.averageRating);
    this.reviewStarsComponent.setRating(0); // Reset component
    this.reviewText = '';
    this.currentCharacterCount = 0;
  }

  getReviewsLoader(): (params: PageableQueryParam) => Promise<IReviewWithUser[]> {
    return async ({ prev, perPage }: PageableQueryParam) => {
      if (!this.dorm) return [];
      const reviews = await firstValueFrom(this._reviewService.getReviewsByDormId({
        perPage,
        prev,
        dormId: String(this.dorm.id),
      }));
      return reviews;
    };
  }
}