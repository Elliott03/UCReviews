import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICourse } from 'src/app/Models/Course';
import { QueryParams } from '../types/QueryParams';
import { buildQueryParams } from '../helpers/buildQueryParams';

@Injectable({
  providedIn: 'root',
})
export class CourseService {
  constructor(private _http: HttpClient) {}

  getCourses({
    perPage,
    prev,
  }: QueryParams): Observable<ICourse[]> {
    const queryParams = buildQueryParams({
      perPage: perPage,
      prev: prev,
    });
    const courses = this._http.get<ICourse[]>(
      `/api/Course?${queryParams}`
    );
    return courses;
  }

  getCourse(slug_or_id: string): Observable<ICourse> {
    const course = this._http.get<ICourse>(
      `/api/Course/${slug_or_id}`
    );
    return course;
  }

  saveCourse(course: ICourse): Observable<ICourse> {
    return this._http.post<ICourse>('/api/Course', course);
  }
}
