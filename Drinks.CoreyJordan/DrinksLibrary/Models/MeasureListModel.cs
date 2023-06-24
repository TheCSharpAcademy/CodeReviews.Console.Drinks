namespace DrinksLibrary.Models;
public class MeasureListModel
{
    public string Measure1 { get; set; }
    public string Measure2 { get; set; }
    public string Measure3 { get; set; }
    public string Measure4 { get; set; }
    public object Measure5 { get; set; }
    public object Measure6 { get; set; }
    public object Measure7 { get; set; }
    public object Measure8 { get; set; }
    public object Measure9 { get; set; }
    public object Measure10 { get; set; }
    public object Measure11 { get; set; }
    public object Measure12 { get; set; }
    public object Measure13 { get; set; }
    public object Measure14 { get; set; }
    public object Measure15 { get; set; }

    public MeasureListModel(RawInfoModel drink)
    {
        Measure1 = drink.strMeasure1;
        Measure2 = drink.strMeasure2;
        Measure3 = drink.strMeasure3;
        Measure4 = drink.strMeasure4;
        Measure5 = drink.strMeasure5;
        Measure6 = drink.strMeasure6;
        Measure7 = drink.strMeasure7;
        Measure8 = drink.strMeasure8;
        Measure9 = drink.strMeasure9;
        Measure10 = drink.strMeasure10;
        Measure11 = drink.strMeasure11;
        Measure12 = drink.strMeasure12;
        Measure13 = drink.strMeasure13;
        Measure14 = drink.strMeasure14;
        Measure15 = drink.strMeasure15;
    }
}
