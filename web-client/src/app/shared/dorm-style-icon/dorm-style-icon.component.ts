import { Component, Input } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  selector: 'dorm-style-icon',
  standalone: true,
  imports: [MatIconModule, MatTooltipModule],
  templateUrl: './dorm-style-icon.component.html',
  styleUrl: './dorm-style-icon.component.scss',
})
export class DormStyleIconComponent {
  @Input() style!: string;
}
