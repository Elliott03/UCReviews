import { Component, Input } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
    selector: 'dining-category-icon',
    imports: [MatIconModule, MatTooltipModule],
    templateUrl: './dining-category-icon.component.html',
    styleUrl: './dining-category-icon.component.scss'
})
export class DiningCategoryIconComponent {
  @Input() style!: string;
}
