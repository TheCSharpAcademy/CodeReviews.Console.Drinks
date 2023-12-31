using System.Reflection;

namespace DrinksProgram;

class DataController
{
    public static void MainMenuController()
    {
        
    }


    public static List<List<object>> RemoveNullValues<T>(T? list) where T : class
    {
        List<List<object>> listNotNullValues = [];
        
        if(list != null)
        {
            foreach(PropertyInfo property in list.GetType().GetProperties())
            {
                if(property.GetValue(list) != null)
                {
                    listNotNullValues.Add([property.Name, property.GetValue(list) ?? ""]);
                }
            }
        }
        return listNotNullValues;
    }
}