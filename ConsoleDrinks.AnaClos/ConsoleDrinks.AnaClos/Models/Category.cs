﻿using Newtonsoft.Json;

namespace ConsoleDrinks.AnaClos.Models;

public class Category
{
    public string strCategory { get; set; }
}

public class Categories
{
    [JsonProperty("drinks")]
    public List<Category> CategoriesList { get; set; }
}