using Newtonsoft.Json;

namespace DrinksInfo.Models;


public class InstructionList
{
    [JsonProperty("drinks")] public List<Instruction> Instructions { get; set; }
}
public class Instruction
{
    [JsonProperty("strInstructions")] public string StrInstructions { get; set; }
}