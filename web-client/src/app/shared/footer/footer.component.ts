import { Component } from '@angular/core';

@Component({
  selector: 'foot',
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.scss'
})
export class FooterComponent {
  currentYear = new Date().getFullYear();
}
