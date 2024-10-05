import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ILargeDorm } from '../Models/Dorm';
import { DormService } from '../core/services/dorm.service';
import { NgxStarsComponent } from 'ngx-stars';
import { IUser } from '../Models/User';
import { IReview, SaveReview } from '../Models/Review';
import { AuthService } from '../core/services/auth.service';
import { ReviewService } from '../core/services/review.service';

@Component({
  selector: 'dorm-page',
  templateUrl: './dorm-page.component.html',
  styleUrls: ['./dorm-page.component.scss']
})
export class DormPageComponent implements OnInit{
  dorm: ILargeDorm | undefined;
  reviews: IReview[] | undefined;
  user: IUser | undefined;
  username: string | undefined;
  reviewText: string = "";
  maxCharacterCount: number = 1000;
  currentCharacterCount: number = 0;

  @ViewChild('dormRating')
  dormStarsComponent: NgxStarsComponent = new NgxStarsComponent();

  @ViewChild('reviewRating')
  reviewStarsComponent: NgxStarsComponent = new NgxStarsComponent();
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
        this.dormStarsComponent.setRating(dorm.averageRating);
        this.reviews = this.reverseReviewList(this.dorm.reviews);
      });
      const stringUser = localStorage.getItem('user');
      if (stringUser) {
        this.user = JSON.parse(stringUser);
        const numberOfCharactersForEmailEnding = -12;
        this.username = this.user?.email.slice(0, numberOfCharactersForEmailEnding);
      }
    } else {
      this._router.navigate(['/signup']);
    }
  }
  updateCharacterCount(event: any) {
    const currentText: string = event.target.value;
    this.currentCharacterCount = currentText.length;
  }
  emailToUsername(email: string) {
    const numberOfCharactersForEmailEnding = -12;
    return email.slice(0, numberOfCharactersForEmailEnding);
  }
  sendReview() {
    const userId = this._authService.getUserId();
    if(this.reviewText && userId != -1 && this.dorm) {
      this._reviewService.addReview(
        new SaveReview(
          this.reviewText,
          this.reviewStarsComponent.rating.toString(),
          userId,
          this.dorm.id
        ))
        .subscribe((reviewList) => {
          this.reviews = this.reverseReviewList(reviewList);
          const ratingSum = reviewList.reduce((acc, obj) => acc + obj.starRating, 0);
          const averageRating = ratingSum / reviewList.length;
          this.dormStarsComponent.setRating(averageRating);
          this.reviewText = "";
          this.currentCharacterCount = 0;
        });
    }
  }

  reverseReviewList(reviewList: IReview[]): IReview[] {
    return reviewList.reverse();
  }

  convertDateToReadable(reviewDate: Date) {
    // 'T' separates the date and time in the ISO 8601 DateTime format
    const dateTimeList: string[] = reviewDate.toString().split("T");
    const date = dateTimeList[0];
    const dateList: string[] = date.split("-");
    const year: string = dateList[0];
    const month: string = dateList[1];
    const day: string = dateList[2];
    let readableMonth: string = "";
    switch(month) {
      case Months.January:
        readableMonth = "January";
        break;
      case Months.February:
        readableMonth = "February";
        break;
      case Months.March:
        readableMonth = "March";
        break;
      case Months.April:
        readableMonth = "April"
        break;
      case Months.May:
        readableMonth = "May";
        break;
      case Months.June:
        readableMonth = "June";
        break;
      case Months.July:
        readableMonth = "July";
        break;
      case Months.August:
        readableMonth = "August";
        break;
      case Months.September:
        readableMonth = "September";
        break;
      case Months.October:
        readableMonth = "October";
        break;
      case Months.November:
        readableMonth = "November";
        break;
      case Months.December:
        readableMonth = "December";
        break;
    }

    return `${readableMonth} ${day}, ${year}`;

  }
}

enum Months {
  January = "01",
  February = "02",
  March = "03",
  April = "04",
  May = "05",
  June = "06",
  July = "07",
  August = "08",
  September = "09",
  October = "10",
  November = "11",
  December = "12"
}

