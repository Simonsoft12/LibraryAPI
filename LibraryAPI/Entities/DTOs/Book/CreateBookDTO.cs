﻿namespace LibraryAPI.Entities.DTOs.Book
{
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int StatuId { get; set; }
    }
}
