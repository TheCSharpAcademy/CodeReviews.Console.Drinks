
public class Rootobject
{
    public Class1[]? Property1 { get; set; }
}

public class Class1
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Tagline { get; set; }
    public string? FirstBrewed { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public float? Abv { get; set; }
    public float? Ibu { get; set; }
    public int? TargetFg { get; set; }
    public float? TargetOg { get; set; }
    public int? Ebc { get; set; }
    public float? Srm { get; set; }
    public float? Ph { get; set; }
    public float? AttenuationLevel { get; set; }
    public Volume? Volume { get; set; }
    public BoilVolume? BoilVolume { get; set; }
    public Method? Method { get; set; }
    public Ingredients? Ingredients { get; set; }
    public string[]? FoodPairing { get; set; }
    public string? BrewersTips { get; set; }
    public string? ContributedBy { get; set; }
}

public class Volume
{
    public int? Value { get; set; }
    public string? Unit { get; set; }
}

public class BoilVolume
{
    public int? Value { get; set; }
    public string? Unit { get; set; }
}

public class Method
{
    public MashTemp[]? MashTemp { get; set; }
    public Fermentation? Fermentation { get; set; }
    public string? Twist { get; set; }
}

public class Fermentation
{
    public Temp? Temp { get; set; }
}

public class Temp
{
    public int? Value { get; set; }
    public string? Unit { get; set; }
}

public class MashTemp
{
    public Temp1? Temp { get; set; }
    public int? Duration { get; set; }
}

public class Temp1
{
    public int? Value { get; set; }
    public string? Unit { get; set; }
}

public class Ingredients
{
    public Malt[]? Malt { get; set; }
    public Hop[]? Hops { get; set; }
    public string? Yeast { get; set; }
}

public class Malt
{
    public string? Name { get; set; }
    public Amount? Amount { get; set; }
}

public class Amount
{
    public float? Value { get; set; }
    public string? Unit { get; set; }
}

public class Hop
{
    public string? Name { get; set; }
    public Amount1? Amount { get; set; }
    public string? Add { get; set; }
    public string? Attribute { get; set; }
}

public class Amount1
{
    public float? Value { get; set; }
    public string? Unit { get; set; }
}
