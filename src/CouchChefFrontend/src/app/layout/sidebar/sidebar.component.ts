import { Component } from '@angular/core';
import { NgFor } from '@angular/common';
import routes from './routes';
import { isString } from '@ng-bootstrap/ng-bootstrap/util/util';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [NgFor],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss'
})
export class SidebarComponent {
  readonly ROUTES = routes.map(
    route => ({ path: route.path || "/", title: route.title?.toString() || "" })
  );

  readonly routesI18: Record<string, string> = {
    "Ingredients": "Інгредієнти",
    "Categories": "Категорії",
    "Cuisines": "Кухні світу",
    "Recipes": "Рецепти",
    "Daily advises": "Щоденні поради"
  }

  translate(title: string) {
    return this.routesI18[title];
  }


}
