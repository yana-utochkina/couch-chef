import { Component, inject, OnInit } from '@angular/core';
import { SidebarComponent } from "./layout/sidebar/sidebar.component";
import { CategoriesService } from './services/categories.service';
import { CategoryDTO } from './entities/category.dto';
import { NgFor } from '@angular/common';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [SidebarComponent, NgFor],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  readonly api = inject(CategoriesService);
  data: CategoryDTO[] = [];
  ngOnInit(): void {
    this.api.getCategoriesList().subscribe(
      res => {
        this.data = res;
      }
    )
  }
}
