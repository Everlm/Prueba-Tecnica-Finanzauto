using Finanzauto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Infrastructure.Persistences.SeedData
{
    public static class FinanzautoContextSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, FirstName = "John", LastName = "Doe", DocumentNumber = 12345678 },
                new Student { Id = 2, FirstName = "Jane", LastName = "Smith", DocumentNumber = 87654321 },
                new Student { Id = 3, FirstName = "Carlos", LastName = "Gonzalez", DocumentNumber = 11223344 },
                new Student { Id = 4, FirstName = "Maria", LastName = "Fernandez", DocumentNumber = 22334455 },
                new Student { Id = 5, FirstName = "Luis", LastName = "Ramirez", DocumentNumber = 33445566 },
                new Student { Id = 6, FirstName = "Ana", LastName = "Torres", DocumentNumber = 44556677 },
                new Student { Id = 7, FirstName = "Pedro", LastName = "Mendoza", DocumentNumber = 55667788 },
                new Student { Id = 8, FirstName = "Lucia", LastName = "Ortega", DocumentNumber = 66778899 },
                new Student { Id = 9, FirstName = "Javier", LastName = "Silva", DocumentNumber = 77889900 },
                new Student { Id = 10, FirstName = "Andrea", LastName = "Castillo", DocumentNumber = 88990011 },
                new Student { Id = 11, FirstName = "Fernando", LastName = "Reyes", DocumentNumber = 99001122 },
                new Student { Id = 12, FirstName = "Patricia", LastName = "Cruz", DocumentNumber = 10002233 },
                new Student { Id = 13, FirstName = "Sergio", LastName = "Rojas", DocumentNumber = 11003344 },
                new Student { Id = 14, FirstName = "Gabriela", LastName = "Vega", DocumentNumber = 12004455 },
                new Student { Id = 15, FirstName = "Ricardo", LastName = "Lopez", DocumentNumber = 13005566 },
                new Student { Id = 16, FirstName = "Monica", LastName = "Guerrero", DocumentNumber = 14006677 },
                new Student { Id = 17, FirstName = "Alberto", LastName = "Acosta", DocumentNumber = 15007788 },
                new Student { Id = 18, FirstName = "Diana", LastName = "Salazar", DocumentNumber = 16008899 },
                new Student { Id = 19, FirstName = "Hector", LastName = "Miranda", DocumentNumber = 17009900 },
                new Student { Id = 20, FirstName = "Elena", LastName = "Soto", DocumentNumber = 18001122 },
                new Student { Id = 21, FirstName = "Oscar", LastName = "Nuñez", DocumentNumber = 19002233 },
                new Student { Id = 22, FirstName = "Valeria", LastName = "Ibarra", DocumentNumber = 20003344 },
                new Student { Id = 23, FirstName = "Rodrigo", LastName = "Herrera", DocumentNumber = 21004455 },
                new Student { Id = 24, FirstName = "Camila", LastName = "Espinoza", DocumentNumber = 22005566 },
                new Student { Id = 25, FirstName = "Manuel", LastName = "Paredes", DocumentNumber = 23006677 }
            );
        }
    }
}
