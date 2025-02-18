import { Component, EventEmitter, Input, Output } from '@angular/core';
import { emailToUsername as _emailToUsername } from '../../core/helpers/emailToUsername';
import { convertDateToReadable as _convertDateToReadable } from '../../core/helpers/convertDateToReadable';
import { NgxStarsModule } from 'ngx-stars';
import { MatCardModule } from '@angular/material/card';
import { IReview, UserVoteType } from 'src/app/Models/Review';
import { InfiniteScrollDirective } from 'ngx-infinite-scroll';
import { ReviewService } from 'src/app/core/services/review.service';
import { PageableQueryParam } from 'src/app/core/types/QueryParams';

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
  reviews: Map<number, IReview> = new Map();
  
  JSON = JSON;

  @Input() loadReviewsMethod!: (
    params: PageableQueryParam
  ) => Promise<IReview[]>;

  constructor(private _reviewService: ReviewService) {}

  ngOnInit(): void {
    this.loadReviews();
  }

  onScroll(): void {
    this.loadReviews();
  }

  reviewsToMap(reviews: IReview[]): Map<number, IReview> {
    return new Map(reviews.map((review) => [review.id, review]));
  }
  public upvoteReviewColor(review: IReview): string {
    if (review.userVoteType === UserVoteType.UserUpvoted) {
      return "red";
    } 
    return "black";
  }
  public downvoteReviewColor(review: IReview): string {
    if (review.userVoteType === UserVoteType.UserDownvoted) {
      return "red";
    } 
    return "black";
  }
  async loadReviews() {
    const reviews = this.reviewsToMap(
      await this.loadReviewsMethod({
        prev: this.prev,
        perPage: this.perPage,
      })
    );
    for (const review of reviews.values()) {
      if (!this.reviews?.has(review.id)) {
        this.reviews?.set(review.id, review);
        this.prev = review.id;
      }
      console.log(review);
    }
  }

  addReviewToFront(review: IReview): void {
    if (!this.reviews.has(review.id)) {
      this.reviews = new Map([[review.id, review], ...this.reviews]);
    }
  }
  public upvote(review: IReview) {
    if (review.userVoteType === UserVoteType.UserUpvoted) {
      // un upvote
      this.vote(review, "novote");
    } else {
      // upvote
      this.vote(review, "upvote");
    }
  }
  public downvote(review: IReview) {
    if (review.userVoteType === UserVoteType.UserDownvoted) {
      this.vote(review, "novote");
    } else {
      this.vote(review, "downvote");
    }
    
  }
  public vote(review: IReview, vote: string) {
    this._reviewService.updateVote(review, vote).subscribe((review: IReview) => {
      console.log(review);
      this.reviews.forEach((val, index) => {
        if (val.id == review.id) {
          val.averageVote = review.averageVote;
          val.userVoteType = review.userVoteType;
        }
      })
    });
  }

}
