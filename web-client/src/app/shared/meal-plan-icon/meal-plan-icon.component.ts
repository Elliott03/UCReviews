import { Component, Input } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
    selector: 'meal-plan-icon',
    imports: [MatIconModule, MatTooltipModule],
    templateUrl: './meal-plan-icon.component.html',
    styleUrl: './meal-plan-icon.component.scss'
})
export class MealPlanIconComponent {
  @Input() style!: string;
}
