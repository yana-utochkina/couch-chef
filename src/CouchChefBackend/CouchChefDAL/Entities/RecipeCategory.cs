﻿namespace CouchChefDAL.Entities;

public class RecipeCategory : BaseEntity
{
    public int RecipeId { get; set; }
    public int CategoryId {  get; set; }

    public required Recipe Recipe { get; set; }
    public required Category Category { get; set; }
}
