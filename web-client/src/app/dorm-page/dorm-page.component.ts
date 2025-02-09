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
  reviewsComponent: ReviewsComponent = new ReviewsComponent(
    this._reviewService
  );

  constructor(
    private route: ActivatedRoute,
    private _dormService: DormService,
    private _reviewService: ReviewService,
    private _authService: AuthService,
    private _router: Router
  ) {}

  ngOnInit(): void {
    if (this._authService.isLoggedIn()) {
      const queryParam = this.route.snapshot.params['dorm'];
      this._dormService.getDorm(queryParam).subscribe((dorm) => {
        this.dorm = dorm;
        dorm.reviewSummary?.averageRating &&
          this.dormStarsComponent.setRating(dorm.reviewSummary.averageRating);
      });
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
    this.dormStarsComponent.setRating(addedReview.summary.averageRating);
    this.reviewStarsComponent.setRating(0); // Reset component
    this.reviewText = '';
    this.currentCharacterCount = 0;
  }

  getReviewsLoader(): (
    params: PageableQueryParam
  ) => Promise<IReviewWithUser[]> {
    return async ({ prev, perPage }: PageableQueryParam) => {
      if (!this.dorm) return [];
      const reviews = await firstValueFrom(
        this._reviewService.getReviewsByDormId({
          perPage,
          prev,
          dormId: String(this.dorm.id),
        })
      );
      return reviews;
    };
  }
}
