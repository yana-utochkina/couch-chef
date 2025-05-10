using CouchChefBLL.DTOs;
using CouchChefBLL.Interfaces;
using CouchChefDAL.Data;
using CouchChefDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CouchChefBLL.Services;

public class CuisineService : ICuisineService
{
    private readonly CouchChefDbContext _context;

    public CuisineService(CouchChefDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddCuisineAsync(CuisineDTO cuisineDTO)
    {
        var cuisine = new Cuisine
        {
            Id = 0,
            Name = cuisineDTO.Name,
            Description = cuisineDTO.Description
        };
        await _context.Cuisines.AddAsync(cuisine);
        await _context.SaveChangesAsync();
        return cuisine.Id;
    }

    public async Task DeleteCuisineByIdAsync(int id)
    {
        var cuisine = await GetCuisineByIdAsync(id);
        _context.Remove(cuisine);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CuisineDTO>> GelAllCuisinesAsync()
    {
        var cuisines = await _context.Cuisines.ToListAsync();
        var cuisineDTOs = cuisines.Select(x => new CuisineDTO
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description
        }).ToList();
        return cuisineDTOs;
    }

    public async Task<CuisineDTO> GetCuisineAsync(int id)
    {
        var cuisine = await GetCuisineByIdAsync(id);
        CuisineDTO cuisineDTO = new CuisineDTO
        {
            Id = cuisine.Id,
            Name = cuisine.Name,
            Description = cuisine.Description
        };
        return cuisineDTO;
    }

    public async Task UpdateCuisineAsync(int id, CuisineDTO cuisineDTO)
    {
        var cuisine = await GetCuisineByIdAsync(id);
        cuisine.Name = cuisineDTO.Name;
        cuisine.Description = cuisineDTO.Description;
        await _context.SaveChangesAsync();
    }

    private async Task<Cuisine> GetCuisineByIdAsync(int id)
    {
        var cuisine = await _context.Cuisines.FirstOrDefaultAsync(x => x.Id == id);
        if (cuisine is null)
        {
            throw new KeyNotFoundException($"Cuisine with id {id} not found.");
        }
        return cuisine;
    }


}
