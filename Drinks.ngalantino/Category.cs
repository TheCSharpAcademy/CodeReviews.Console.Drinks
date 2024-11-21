using Newtonsoft.Json;

public class Category {
    public string strCategory { get; set; }
}

public class Categories {
    // This attribute is used to control how properties of a class are serialized and 
    // deserialized when converting between JSON and .NET objects.
    // Attributes are like tags.
    [JsonProperty("drinks")]

    public List<Category> CategoriesList { get; set; }
}


// YouTube video 8:10