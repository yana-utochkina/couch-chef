import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CategoryViewDTO } from '@entities/category.dto';
import { ControlsOf } from '@shared/forms';
import { Modal } from '@shared/modal-service/models/modal.model';

@Component({
  selector: 'app-manage-category',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './manage-category.component.html',
  styleUrl: './manage-category.component.scss'
})
export default class ManageCategoryComponent extends Modal {
  @Input({ required: true }) actionName: string | undefined;

  public readonly form = new FormGroup<ControlsOf<CategoryViewDTO>>({
    name: new FormControl("", [Validators.required]) as FormControl<string>
  })

  onInjectInputs(opt: any): void {
    if (opt.category === undefined) return;
    this.form.patchValue(opt.category);
  }

  confirm(): void {
    if (this.form.invalid)
      return this.form.markAllAsTouched();
    this.close(this.form.getRawValue());
  }

  cancel(): void {
    this.dismiss();
  }
}
