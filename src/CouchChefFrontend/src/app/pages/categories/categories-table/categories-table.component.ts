import { Component, inject, OnInit } from '@angular/core';
import RecordOperationsComponent from "@shared/record-operations/record-operations.component";
import { NgFor } from '@angular/common';
import { CategoriesService } from '@services/categories.service';
import { CategoryDTO } from '@entities/category.dto';

@Component({
  selector: 'app-categories-table',
  standalone: true,
  imports: [RecordOperationsComponent, NgFor],
  templateUrl: './categories-table.component.html',
  styleUrl: './categories-table.component.scss'
})
export default class CategoriesTableComponent implements OnInit {
  readonly api = inject(CategoriesService);
  categories: CategoryDTO[] = [];

  ngOnInit(): void {
    this.api.getCategoriesList().subscribe(
      res => {
        this.categories = res;
      }
    )
  }

  editCategory(id: number): void {

  }

  deleteCategory(id: number): void {

  }
}
