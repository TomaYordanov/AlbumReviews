﻿using AlbumReviews.Data;
using AlbumReviews.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumReviews.Services
{
    public class AlbumService
    {
        private readonly AlbumReviewsContext _context;

        public AlbumService(AlbumReviewsContext _context) 
        { 
            this._context = _context;
        }
        public async Task<List<Album>> GetAlbumsAsync()
        {
            return await _context.Albums.ToListAsync();
        }
        public IQueryable<Album> GetAlbumsQueryable()
        {
            return _context.Albums.AsQueryable();
        }
        public async Task<PaginatedList<Album>> GetAlbumsPagedAsync(IQueryable<Album> query, int pageNumber, int pageSize)
        {
            var _query = _context.Albums.AsQueryable();
            return await PaginatedList<Album>.CreateAsync(query, pageNumber, pageSize);
        }

    }
}
