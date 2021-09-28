﻿using JkBook.Database;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JkBook.Database
{
    public class BookStoreContext : DbContext 
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)   
            :base(options)
        {

        }

        public DbSet<Books> Books { get; set; }
      
    }

}
