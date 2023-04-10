
public class Rootobject
{
    public Class1[]? Property1 { get; set; }
}

public class Class1
{
    public int? id { get; set; }
    public string? name { get; set; }
    public string? tagline { get; set; }
    public string? first_brewed { get; set; }
    public string? description { get; set; }
    public string? image_url { get; set; }
    public float? abv { get; set; }
    public float? ibu { get; set; }
    public int? target_fg { get; set; }
    public float? target_og { get; set; }
    public int? ebc { get; set; }
    public float? srm { get; set; }
    public float? ph { get; set; }
    public float? attenuation_level { get; set; }
    public Volume? volume { get; set; }
    public Boil_Volume? boil_volume { get; set; }
    public Method? method { get; set; }
    public Ingredients? ingredients { get; set; }
    public string[] food_pairing { get; set; }
    public string? brewers_tips { get; set; }
    public string? contributed_by { get; set; }
}

public class Volume
{
    public int? value { get; set; }
    public string? unit { get; set; }
}

public class Boil_Volume
{
    public int? value { get; set; }
    public string? unit { get; set; }
}

public class Method
{
    public Mash_Temp[]? mash_temp { get; set; }
    public Fermentation? fermentation { get; set; }
    public string? twist { get; set; }
}

public class Fermentation
{
    public Temp? temp { get; set; }
}

public class Temp
{
    public int? value { get; set; }
    public string? unit { get; set; }
}

public class Mash_Temp
{
    public Temp1? temp { get; set; }
    public int? duration { get; set; }
}

public class Temp1
{
    public int? value { get; set; }
    public string? unit { get; set; }
}

public class Ingredients
{
    public Malt[]? malt { get; set; }
    public Hop[]? hops { get; set; }
    public string? yeast { get; set; }
}

public class Malt
{
    public string? name { get; set; }
    public Amount? amount { get; set; }
}

public class Amount
{
    public float? value { get; set; }
    public string? unit { get; set; }
}

public class Hop
{
    public string? name { get; set; }
    public Amount1? amount { get; set; }
    public string? add { get; set; }
    public string? attribute { get; set; }
}

public class Amount1
{
    public float? value { get; set; }
    public string? unit { get; set; }
}
