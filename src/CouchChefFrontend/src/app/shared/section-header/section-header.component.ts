import { Component, Input, Output, EventEmitter, inject, Type, ContentChildren } from '@angular/core';
import { ModalService } from '@shared/modal-service/modal-service.service';
import { Modal } from '@shared/modal-service/models/modal.model';
import { first, Subscription } from 'rxjs';

@Component({
  selector: 'app-section-header',
  standalone: true,
  imports: [],
  templateUrl: './section-header.component.html',
  styleUrl: './section-header.component.scss'
})
export default class SectionHeaderComponent {
  @Input({ required: true }) itemsLabel: string = "";
  @Input({ required: true }) itemsCount: number = 0;
  @Input({ required: true }) buttonLabel: string = "Додати";
  @Input() modal: Type<Modal> | undefined;
  @Input() redirectTo: string = "";

  @Output() onClose = new EventEmitter<any>();

  private readonly modals = inject(ModalService);

  handleClick<T>() {
    if (this.modal === undefined)
      return this.handleRedirect<T>();
    return this.handleOpen<T>();
  }

  handleRedirect<T>() {

  }

  handleOpen<T>() {
    this.modals.open(this.modal as Type<Modal>).onResult().pipe(first()).subscribe(
      (res: any) => this.onClose.emit(res)
    );
  }
}