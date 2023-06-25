using System.Text;

namespace LONCHANICK.DrinksApp.Models
{
	public class FullPropertiesDrinkModel
	{
		public List<DrinkFullProperties>? drinks { get; set; }
		public override string ToString()
		{
			if (drinks != null)
			{
				StringBuilder sb = new StringBuilder();

				foreach (var d in drinks)
					sb.Append(d.ToString(true) + "\n");

				return sb.ToString();
			}
			else
				return "";
		}
	}

	public class DrinkFullProperties
	{
		public string idDrink { get; set; }
		public string strDrink { get; set; }
		public string strDrinkAlternate { get; set; }
		public string strTags { get; set; }
		public string strVideo { get; set; }
		public string strCategory { get; set; }
		public string strIBA { get; set; }
		public string strAlcoholic { get; set; }
		public string strGlass { get; set; }
		public string strInstructions { get; set; }
		public override string ToString()
		{
			string aux =
				"idDrink: " + idDrink + "\n"
				+ "strDrink: " + strDrink + "\n"
				+ "strDrinkAlternate: " + strDrinkAlternate + "\n"
				+ "strTags: " + strTags + "\n"
				+ "strVideo: " + strVideo + "\n"
				+ "strCategory: " + strCategory + "\n"
				+ "strIBA: " + strIBA + "\n"
				+ "strAlcoholic: " + strAlcoholic + "\n"
				+ "strGlass: " + strGlass + "\n"
				+ "strInstructions: " + strInstructions;

			return aux;
		}

		public string ToString(bool notEmptyFields)
		{
			StringBuilder sb = new StringBuilder();
			if (idDrink != null)
				sb.Append("idDrink: " + idDrink + "\n");

			if (strDrink != null)
				sb.Append("strDrink: " + strDrink + "\n");


			if (strDrinkAlternate != null)
				sb.Append("strDrinkAlternate: " + strDrinkAlternate + "\n");


			if (strTags != null)
				sb.Append("strTags: " + strTags + "\n");


			if (strVideo != null)
				sb.Append("strVideo: " + strVideo + "\n");


			if (strCategory != null)
				sb.Append("strCategory: " + strCategory + "\n");


			if (strIBA != null)
				sb.Append("strIBA: " + strIBA + "\n");


			if (strAlcoholic != null)
				sb.Append("strAlcoholic: " + strAlcoholic + "\n");

			if (strGlass != null)
				sb.Append("strGlass: " + strGlass + "\n");


			if (strInstructions != null)
				sb.Append("strInstructions: " + strInstructions + "\n");


			return sb.ToString();
		}

	}
}
