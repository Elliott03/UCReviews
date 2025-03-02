import { ChangeDetectionStrategy, Component, signal } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Course, ICourse } from '../Models/Course';
import { CourseService } from '../core/services/course.service';
import { Router } from '@angular/router';
import { Filter } from 'bad-words';
import { AbstractControl, FormControl, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { merge } from 'rxjs';
import { profanityValidator } from '../core/validators/profanity.validator';

@Component({
  selector: 'app-add-course-modal',
  templateUrl: './add-course-modal.component.html',
  styleUrls: ['./add-course-modal.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AddCourseModalComponent {
  course?: ICourse;
  isLoading: boolean = false;
  errorMessage: string = '';
  filter: Filter = new Filter();

  readonly courseSubject = new FormControl('', [
    Validators.required, 
    Validators.pattern(/^[a-zA-Z]{2,4}$/),
    profanityValidator()    
  ]);
  readonly courseName = new FormControl('', [Validators.required, profanityValidator()]);
  readonly courseNumber = new FormControl('', [Validators.required, Validators.pattern(/^\d{4}[a-zA-Z]?$/)]);

  courseSubjectError = signal('');
  courseNameError = signal('');
  courseNumberError = signal('');

  constructor(
    public dialogRef: MatDialogRef<AddCourseModalComponent>,
    private _courseService: CourseService,
    private router: Router
  ) {
    merge(this.courseSubject.statusChanges, this.courseSubject.valueChanges)
      .pipe(takeUntilDestroyed())
      .subscribe(() => this.updateSubjectError());
    merge(this.courseName.statusChanges, this.courseName.valueChanges)
      .pipe(takeUntilDestroyed())
      .subscribe(() => this.updateNameError());
    merge(this.courseNumber.statusChanges, this.courseNumber.valueChanges)
      .pipe(takeUntilDestroyed())
      .subscribe(() => this.updateNumberError());
  }

  updateSubjectError() {
    if (this.courseSubject.hasError('required')) {
      this.courseSubjectError.set('Course subject is required.');
    }
    else if (this.courseSubject.hasError('pattern')) {
      this.courseSubjectError.set('Course subject must contain 2-4 alphabetic letters.');
    }
    else if (this.courseSubject.hasError('profanity')) {
      this.courseSubjectError.set('Course subject contains inappropriate language.');
    }
    else {
      this.courseSubjectError.set('');
    }
  }

  updateNameError() {
    if (this.courseName.hasError('required')) {
      this.courseNameError.set('Course name is required.');
    }
    else if (this.courseName.hasError('profanity')) {
      this.courseNameError.set('Course name contains inappropriate language.');
    }
    else {
      this.courseNameError.set('');
    }
  }

  updateNumberError()  {
    if (this.courseNumber.hasError('required')) {
      this.courseNumberError.set('Course number is required.');
    }
    else if (this.courseNumber.hasError('pattern')) {
      this.courseNumberError.set('Course number must contain 4 digits followed by an optional letter.');
    }
    else {
      this.courseNumberError.set('');
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  onAddCourse(): void {
    if (this.courseSubject.invalid || this.courseName.invalid || this.courseNumber.invalid || 
      !this.courseSubject.value || !this.courseName.value || !this.courseNumber.value) {
      return;
    }

    this.isLoading = true;

    const subject = this.courseSubject.value.toUpperCase();
    const name = this.courseName.value.toUpperCase();
    const number = this.courseNumber.value.toUpperCase();

    const course: ICourse = this.course = {
      id: 0,
      subject: subject,
      number: number,
      name: name,
      nameQueryParameter: subject + number,
      reviewSummary: null
    };

    this._courseService.saveCourse(course).subscribe({
      next: (savedCourse) => {
        this.isLoading = false;
        this.dialogRef.close(savedCourse);
        this.router.navigate(['/dashboard/courses', savedCourse.nameQueryParameter]);
      },
      error: (err) => {
        this.isLoading = false;
        this.errorMessage = err.error.message;
        this.router.navigate(['/dashboard']);
      }
    });
  }
}