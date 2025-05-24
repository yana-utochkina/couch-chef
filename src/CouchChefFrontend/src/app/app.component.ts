import { Component, inject, OnInit } from '@angular/core';
import { SidebarComponent } from "./layout/sidebar/sidebar.component";
import { CategoriesService } from '@services/categories.service';
import { CategoryDTO } from '@entities/category.dto';
import { NgIf } from '@angular/common';
import { RouterModule } from '@angular/router';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [SidebarComponent, NgIf, RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  readonly api = inject(CategoriesService);
  data: CategoryDTO[] = [];
  isSidebarOpen = false;

  ngOnInit(): void {
    this.api.getCategoriesList().subscribe(
      res => {
        this.data = res;
      }
    )
  }

  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }

  closeSidebar() {
    this.isSidebarOpen = false;
  }
}
