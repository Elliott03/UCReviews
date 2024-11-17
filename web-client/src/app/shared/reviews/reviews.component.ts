import { Component, Input } from '@angular/core';
import { emailToUsername as _emailToUsername } from '../../core/helpers/emailToUsername';
import { convertDateToReadable as _convertDateToReadable } from '../../core/helpers/convertDateToReadable';
import { NgxStarsModule } from 'ngx-stars';
import { MatCardModule } from '@angular/material/card';
import { IReview } from 'src/app/Models/Review';
import { InfiniteScrollDirective } from 'ngx-infinite-scroll';
import { ReviewService } from 'src/app/core/services/review.service';

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
  perPage = 1;
  prevPage = 0;

  @Input() reviews: IReview[] | undefined;

  constructor(private _reviewService: ReviewService) {}

  onScroll(): void {
    this.prevPage += this.perPage;
    this.loadReviews();
  }

  loadReviews() {
    console.log('loading reviews');
  }
}
