import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../core/services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ReviewService } from '../core/services/review.service';
import { GarageService } from '../core/services/garage.service';
import { firstValueFrom } from 'rxjs';
import { NgxStarsComponent } from 'ngx-stars';
import { emailToUsername as _emailToUsername } from '../core/helpers/emailToUsername';
import { convertDateToReadable as _convertDateToReadable } from '../core/helpers/convertDateToReadable';
import { IUser } from '../Models/User';
import { IReview, SaveReview } from '../Models/Review';
import { PageableQueryParam } from '../core/types/QueryParams';
import { ReviewsComponent } from '../shared/reviews/reviews.component';
import { IParkingGarage } from '../Models/ParkingGarage';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'garage-page',
  templateUrl: './garage-page.component.html',
  styleUrl: './garage-page.component.scss',
})
export class GaragePageComponent implements OnInit, AfterViewInit {
  garage?: IParkingGarage;
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

  @ViewChild('reviewsComponent')
  reviewsComponent!: ReviewsComponent;

  constructor(
    private _bcService: BreadcrumbService,
    private _route: ActivatedRoute,
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
    const slug = this._route.snapshot.params['slug'];
    // this.JSON = JSON;
    this.garage = await firstValueFrom(
      this._garageService.getParkingGarage(slug)
    );

    if (!this.garage) {
      this._router.navigate(['/dashboard', 'garages']);
      return;
    }

    console.log('garage', this.garage);

    this._bcService.set('@name', this.garage.name);
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
    // Wait for the garage data to be loaded
    if (this.garage) {
      this.setGarageRating();
    } else {
      // If garage is not yet loaded, listen for it
      this._route.params.subscribe(async (params) => {
        const slug = params['name'];
        this.garage = await firstValueFrom(
          this._garageService.getParkingGarage(slug)
        );
        this.setGarageRating();
      });
    }
  }

  private setGarageRating() {
    if (this.garageStarsComponent && this.garage) {
      this.garageStarsComponent.setRating(
        this.garage.reviewSummary?.averageRating || 0
      );
    }
  }

  async sendReview() {
    const userId = this._authService.getUserId();
    if (!this.reviewText || userId === -1 || !this.garage) return;
    const newReview = new SaveReview({
      reviewText: this.reviewText,
      rating: this.reviewStarsComponent.rating.toString(),
      userId,
      parkingGarageId: this.garage.id,
    });
    const addedReview = await firstValueFrom(
      this._reviewService.addReview(newReview)
    );
    this.reviewsComponent.addReviewToFront(addedReview.review);
    this.garageStarsComponent.setRating(addedReview.summary.averageRating);
    this.reviewStarsComponent.setRating(0); // Reset component
    this.reviewText = '';
    this.currentCharacterCount = 0;
  }

  updateCharacterCount(event: any) {
    const currentText: string = event.target.value;
    this.currentCharacterCount = currentText.length;
  }

  getReviewsLoader(): (params: PageableQueryParam) => Promise<IReview[]> {
    return async ({ prev, perPage }: PageableQueryParam) => {
      if (!this.garage) return [];
      const reviews = await firstValueFrom(
        this._reviewService.getReviewsByParkingGarageId({
          perPage,
          prev,
          parkingGarageId: String(this.garage.id),
        })
      );
      return reviews;
    };
  }
}
