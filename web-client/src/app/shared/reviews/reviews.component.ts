import { Component, EventEmitter, Input, Output } from '@angular/core';
import { emailToUsername as _emailToUsername } from '../../core/helpers/emailToUsername';
import { convertDateToReadable as _convertDateToReadable } from '../../core/helpers/convertDateToReadable';
import { NgxStarsModule } from 'ngx-stars';
import { MatCardModule } from '@angular/material/card';
import { InfiniteScrollDirective } from 'ngx-infinite-scroll';
import { ReviewService } from 'src/app/core/services/review.service';
import { PageableQueryParam } from 'src/app/core/types/QueryParams';
import { IReviewWithUser } from 'src/app/Models/ReviewWithUser';

@Component({
  selector: 'reviews',
  standalone: true,
  imports: [NgxStarsModule, MatCardModule, InfiniteScrollDirective],
  templateUrl: './reviews.component.html',
  styleUrl: './reviews.component.scss',
})
export class ReviewsComponent {
  emailToUsername = _emailToUsername;
  convertDateToReadable = _convertDateToReadable;
  perPage = 2;
  prev = 0;
  reviews: Map<number, IReviewWithUser> = new Map();

  JSON = JSON;

  @Input() loadReviewsMethod!: (
    params: PageableQueryParam
  ) => Promise<IReviewWithUser[]>;

  constructor(private _reviewService: ReviewService) {}

  ngOnInit(): void {
    this.loadReviews();
  }

  onScroll(): void {
    this.loadReviews();
  }

  reviewsToMap(reviews: IReviewWithUser[]): Map<number, IReviewWithUser> {
    return new Map(reviews.map((review) => [review.review.id, review]));
  }

  async loadReviews() {
    const reviews = this.reviewsToMap(
      await this.loadReviewsMethod({
        prev: this.prev,
        perPage: this.perPage,
      })
    );
    for (const reviewWithUser of reviews.values()) {
      const { review, user } = reviewWithUser;
      if (!this.reviews?.has(review.id)) {
        this.reviews?.set(review.id, reviewWithUser);
        this.prev = review.id;
      }
    }
  }

  addReviewToFront(reviewUser: IReviewWithUser): void {
    const { review, user } = reviewUser;
    if (!this.reviews.has(reviewUser.review.id)) {
      this.reviews = new Map([
        [reviewUser.review.id, reviewUser],
        ...Array.from(this.reviews).map(
          ([_, reviewUsr]): [number, IReviewWithUser] => [
            reviewUsr.review.id,
            reviewUsr,
          ]
        ),
      ]);
    }
  }
}
