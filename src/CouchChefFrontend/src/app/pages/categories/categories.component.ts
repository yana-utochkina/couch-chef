import { Component } from '@angular/core';
import CategoriesTableComponent from "./categories-table/categories-table.component";
import SectionHeaderComponent from "../../shared/section-header/section-header.component";
import ManageCategoryComponent from "./manage-category/manage-category.component";
import { CategoryViewDTO } from '@entities/category.dto';

@Component({
  selector: 'app-categories',
  standalone: true,
  imports: [CategoriesTableComponent, SectionHeaderComponent],
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.scss'
})
export default class CategoriesComponent {
  public modalComponent = ManageCategoryComponent;

  handleSubmit(category: CategoryViewDTO) {
    console.log(category);
  }
}
