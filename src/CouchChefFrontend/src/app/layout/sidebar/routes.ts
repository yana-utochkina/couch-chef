import { Routes } from "@angular/router";
import { from } from "rxjs";

const routes: Routes = [
    // {
    //     title: "Ingredients",
    //     path: "ingredients"
    // },
    {
        title: "Categories",
        path: "categories",
        loadComponent: () => import("@pages/categories/categories.component")
    },
    {
        title: "Cuisines",
        path: "cuisines",
        loadComponent: () => import("@pages/cuisines/cuisines.component")
    },
    {
        path: "",
        pathMatch: "full",
        redirectTo: "cuisines"
    }
    // {
    //     title: "Recipes",
    //     path: "recipes"
    // },
    // {
    //     title: "Daily advises",
    //     path: "dailyadvices"
    // }
]

export default routes;