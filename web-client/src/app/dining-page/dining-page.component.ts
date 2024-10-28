import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../core/services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ReviewService } from '../core/services/review.service';
import { DiningService } from '../core/services/dining.service';
import { firstValueFrom } from 'rxjs';
import {
  IDiningHallWithRating,
} from '../Models/DiningHall';
import { NgxStarsComponent } from 'ngx-stars';
import { emailToUsername as _emailToUsername } from '../core/helpers/emailToUsername';
import { convertDateToReadable as _convertDateToReadable } from '../core/helpers/convertDateToReadable';
import { IUser } from '../Models/User';
import { IReview, SaveReview } from '../Models/Review';

@Component({
  selector: 'dining-page',
  templateUrl: './dining-page.component.html',
  styleUrl: './dining-page.component.scss',
})
export class DiningPageComponent implements OnInit, AfterViewInit {
  diningHall?: IDiningHallWithRating;
  reviews: IReview[] | undefined;
  JSON: any;
  user: IUser | undefined;
  username: string | undefined;
  reviewText: string = '';
  maxCharacterCount: number = 1000;
  currentCharacterCount: number = 0;

  emailToUsername = _emailToUsername;
  convertDateToReadable = _convertDateToReadable;

  @ViewChild('diningHallRating')
  diningHallStarsComponent: NgxStarsComponent = new NgxStarsComponent();

  @ViewChild('reviewRating')
  reviewStarsComponent: NgxStarsComponent = new NgxStarsComponent();

  constructor(
    private route: ActivatedRoute,
    private _diningService: DiningService,
    private _reviewService: ReviewService,
    private _authService: AuthService,
    private _router: Router
  ) {}

  async ngOnInit() {
    if (!this._authService.isLoggedIn()) {
      this._router.navigate(['/signup']);
      return;
    }
    const nameQueryParameter = this.route.snapshot.params['nameQueryParameter'];
    this.JSON = JSON;
    this.diningHall = await firstValueFrom(
      this._diningService.getDiningHall(nameQueryParameter)
    );

    if (!this.diningHall) {
      this._router.navigate(['/dashboard', 'dining']);
      return;
    }

    const stringUser = localStorage.getItem('user');

    if (stringUser) {
      this.user = JSON.parse(stringUser);
      const numberOfCharactersForEmailEnding = -12;
      this.username = this.user?.email.slice(
        0,
        numberOfCharactersForEmailEnding
      );
    }

    this.reviews = this.diningHall.reviews.reverse(); // Recent reviews first
  }

  ngAfterViewInit() {
    // Wait for the diningHall data to be loaded
    if (this.diningHall) {
      this.setDiningHallRating();
    } else {
      // If diningHall is not yet loaded, listen for it
      this.route.params.subscribe(async (params) => {
        const nameQueryParameter = params['nameQueryParameter'];
        this.diningHall = await firstValueFrom(
          this._diningService.getDiningHall(nameQueryParameter)
        );
        this.setDiningHallRating();
      });
    }
  }

  private setDiningHallRating() {
    if (this.diningHallStarsComponent && this.diningHall) {
      this.diningHallStarsComponent.setRating(this.diningHall.averageRating || 0);
    }
  }

  async sendReview() {
    const userId = this._authService.getUserId();
    if (!this.reviewText || userId === -1 || !this.diningHall) return;
    const newReview = new SaveReview({
      reviewText: this.reviewText,
      rating: this.reviewStarsComponent.rating.toString(),
      userId,
      diningHallId: this.diningHall.id,
    });
    const reviewList = await firstValueFrom(
      this._reviewService.addReview(newReview)
    );
    this.reviews = reviewList.reverse();
    const ratingSum = reviewList.reduce((acc, obj) => acc + obj.starRating, 0);
    const averageRating = ratingSum / reviewList.length;
    this.diningHallStarsComponent.setRating(averageRating);
    this.reviewStarsComponent.setRating(0); // Reset component
    this.reviewText = '';
    this.currentCharacterCount = 0;
  }

  updateCharacterCount(event: any) {
    const currentText: string = event.target.value;
    this.currentCharacterCount = currentText.length;
  }
}
