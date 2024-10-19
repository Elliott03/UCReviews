import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../core/services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ReviewService } from '../core/services/review.service';
import { GarageService } from '../core/services/garage.service';
import { firstValueFrom } from 'rxjs';
import { IParkingGarage, ParkingGarage } from '../Models/ParkingGarage';
import { NgxStarsComponent } from 'ngx-stars';
import { emailToUsername as _emailToUsername } from '../core/helpers/emailToUsername';
import { convertDateToReadable as _convertDateToReadable } from '../core/helpers/convertDateToReadable';
import { IUser } from '../Models/User';
import { IReview, SaveParkingGarageReview, SaveReview } from '../Models/Review';

@Component({
  selector: 'garage-page',
  templateUrl: './garage-page.component.html',
  styleUrl: './garage-page.component.scss',
})
export class GaragePageComponent implements OnInit {
  garage?: IParkingGarage;
  reviews: IReview[] | undefined;
  JSON: any;
  user: IUser | undefined;
  username: string | undefined;
  reviewText: string = '';
  maxCharacterCount: number = 1000;
  currentCharacterCount: number = 0;

  emailToUsername = _emailToUsername;
  convertDateToReadable = _convertDateToReadable;

  @ViewChild('garageRating')
  garageStarsComponent: NgxStarsComponent = new NgxStarsComponent();

  @ViewChild('reviewRating')
  reviewStarsComponent: NgxStarsComponent = new NgxStarsComponent();

  constructor(
    private route: ActivatedRoute,
    private _garageService: GarageService,
    private _reviewService: ReviewService,
    private _authService: AuthService,
    private _router: Router
  ) {}

  async ngOnInit() {
    if (!this._authService.isLoggedIn()) {
      this._router.navigate(['/signup']);
      return;
    }
    const slug = this.route.snapshot.params['slug'];
    this.JSON = JSON;
    this.garage = await firstValueFrom(
      this._garageService.getParkingGarage(slug, true)
    );

    if (!this.garage) {
      this._router.navigate(['/dashboard', 'garages']);
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

    this.garage.reviews = this.garage.reviews.reverse(); // Recent reviews first
  }

  async sendReview() {
    const userId = this._authService.getUserId();
    if (!this.reviewText || userId === -1 || !this.garage) return;
    const reviewList = await firstValueFrom(
      this._reviewService.addReview(
        new SaveParkingGarageReview(
          this.reviewText,
          this.reviewStarsComponent.rating.toString(),
          userId,
          this.garage.id
        )
      )
    );
    this.reviews = reviewList.reverse();
    const ratingSum = reviewList.reduce((acc, obj) => acc + obj.starRating, 0);
    const averageRating = ratingSum / reviewList.length;
    this.garageStarsComponent.setRating(averageRating);
    this.reviewText = '';
    this.currentCharacterCount = 0;
  }

  updateCharacterCount(event: any) {
    const currentText: string = event.target.value;
    this.currentCharacterCount = currentText.length;
  }
}
