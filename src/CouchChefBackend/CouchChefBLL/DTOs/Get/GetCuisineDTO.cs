using CouchChefDAL.Entities;

namespace CouchChefBLL.DTOs.Get;

public class GetCuisineDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}
