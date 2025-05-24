import { Component } from '@angular/core';
import SectionHeaderComponent from "@shared/section-header/section-header.component";

@Component({
  selector: 'app-cuisines',
  standalone: true,
  imports: [SectionHeaderComponent],
  templateUrl: './cuisines.component.html',
  styleUrl: './cuisines.component.scss'
})
export default class CuisinesComponent {

}
