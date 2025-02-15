import { Component, EventEmitter, Output } from '@angular/core';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
})
export class SearchComponent {
  searchTerm: string = '';
  private searchSubject = new Subject<string>(); // RxJS Subject for debouncing

  @Output() searchChanged = new EventEmitter<string>(); // Emit search updates

  constructor() {
    // Apply debounce time of 150ms
    this.searchSubject.pipe(debounceTime(150)).subscribe((term) => {
      this.searchChanged.emit(term);
    });
  }

  onSearchChange() {
    this.searchSubject.next(this.searchTerm); // Emit after debounce
  }
}