import { NgIf, NgSwitch, NgSwitchCase } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-record-operations',
  standalone: true,
  imports: [NgSwitch, NgSwitchCase],
  templateUrl: './record-operations.component.html',
  styleUrl: './record-operations.component.scss'
})
export default class RecordOperationsComponent {
  @Input() name: 'details' | 'edit' | 'delete' = 'details';
  @Input() size: number = 20;
}
