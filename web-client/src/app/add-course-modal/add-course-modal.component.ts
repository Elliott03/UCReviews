import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Course, ICourse } from '../Models/Course';
import { CourseService } from '../core/services/course.service';

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
  errorMessage: string = '';

  constructor(
    public dialogRef: MatDialogRef<AddCourseModalComponent>,
    private _courseService: CourseService
  ) {}

  onCancel(): void {
    this.dialogRef.close();
  }

  onAddCourse(): void {
    if (!this.courseName || !this.courseSubject || !this.courseNumber) {
      this.errorMessage = 'Please fill in all fields.';
      return;
    }

    const subject: string = this.courseSubject.trim().toUpperCase();
    const number: string = this.courseNumber.trim().toUpperCase();
    const name: string = this.courseName.trim().toUpperCase();

    const courseNumberRegex = /^\d{4}[a-zA-Z]?$/;
    const courseSubjectRegex = /^[a-zA-Z]{2,4}$/;
    if (!courseNumberRegex.test(number)) {
      this.errorMessage = 'Course number must contain four digits and one optional alphabetic letter.';
      return;
    }
    if (!courseSubjectRegex.test(subject)) {
      this.errorMessage = 'Course subject must contain 2-4 alphabetic letters.';
      return;
    }

    this.course = {
      id: 0,
      subject: subject,
      number: number,
      name: name,
      nameQueryParameter: subject + number,
      reviewSummary: null
    };
    this._courseService.saveCourse(this.course).subscribe({
      next: (course) => {
        this.dialogRef.close(course);
      },
      error: (err) => {
        this.errorMessage = err.error.message;
      }
    });
  }
  // TODO: reload the page after a course is added
  //       put up error messages where they're appropriate
  //       once search is implemented here, an empty search should show "Can't find your course? Add it here"
  //       find a way to ensure there aren't any curse words in the course subject or name
}