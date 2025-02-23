import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Course, ICourse } from '../Models/Course';
import { CourseService } from '../core/services/course.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-course-modal',
  templateUrl: './add-course-modal.component.html',
  styleUrls: ['./add-course-modal.component.scss']
})
export class AddCourseModalComponent {
  course?: ICourse;
  courseName: string = '';
  courseSubject: string = '';
  courseNumber: string = '';
  courseNameError: string = '';
  courseSubjectError: string = '';
  courseNumberError: string = '';
  errorMessage: string = '';
  isLoading: boolean = false;

  constructor(
    public dialogRef: MatDialogRef<AddCourseModalComponent>,
    private _courseService: CourseService,
    private router: Router
  ) {}

  onCancel(): void {
    this.dialogRef.close();
  }

  onAddCourse(): void {
    this.courseSubjectError = '';
    this.courseNumberError = '';
    this.errorMessage = '';

    if (!this.courseName || !this.courseSubject || !this.courseNumber) {
      this.errorMessage = 'All fields are required.';
    }

    const subject: string = this.courseSubject.trim().toUpperCase();
    const number: string = this.courseNumber.trim().toUpperCase();
    const name: string = this.courseName.trim().toUpperCase();

    const courseNumberRegex = /^\d{4}[a-zA-Z]?$/;
    if (!courseNumberRegex.test(number)) {
      this.courseNumberError = 'Course number must contain four digits and one optional alphabetic letter.';
    }

    const courseSubjectRegex = /^[a-zA-Z]{2,4}$/;
    if (!courseSubjectRegex.test(subject)) {
      this.courseSubjectError = 'Course subject must contain 2-4 alphabetic letters.';
    }

    if (this.courseNumberError || this.courseSubjectError || this.errorMessage) {
      return;
    }

    this.isLoading = true;

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
  // TODO:
  //       find a way to ensure there aren't any curse words in the course subject or name
}