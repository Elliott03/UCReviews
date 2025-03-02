import { Component } from '@angular/core';

@Component({
    selector: 'foot',
    templateUrl: './footer.component.html',
    styleUrl: './footer.component.scss',
    standalone: false
})
export class FooterComponent {
  currentYear = new Date().getFullYear();
}
