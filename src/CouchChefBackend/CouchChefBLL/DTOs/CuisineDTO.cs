using CouchChefDAL.Entities;

namespace CouchChefBLL.DTOs;

public class CuisineDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}
