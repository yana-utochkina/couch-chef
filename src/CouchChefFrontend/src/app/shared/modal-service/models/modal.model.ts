import { ModalRef } from './modal-ref.model';

export abstract class Modal {

  modalInstance: ModalRef | undefined;

  abstract onInjectInputs(inputs: any): void;

  close(output?: any): void {
    if (this.modalInstance)
      this.modalInstance.close(output);
  }

  dismiss(output?: any): void {
    if (this.modalInstance)
      this.modalInstance.dismiss(output);
  }

}