namespace Drinks;

class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public CategoryDto(int id, string name)
    {
        Id = id;
        Name = name;
    }
}