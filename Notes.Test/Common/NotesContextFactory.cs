using Notes.Persistence;
using System;
using Microsoft.EntityFrameworkCore;
using Notes.Domain;

namespace Notes.Test.Common
{
    public class NotesContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid NoteIdForDelete = Guid.NewGuid();
        public static Guid NoteIdForUpdate = Guid.NewGuid();

        public static NotesDbContext Create()
        {
            var options = new DbContextOptionsBuilder<NotesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new NotesDbContext(options);
            context.Database.EnsureCreated();
            context.Notes.AddRange(
                    new Note
                    {
                        CreationDate = DateTime.Today,
                        Details = "Details1",
                        EditDate = null,
                        Id = Guid.Parse("2673B4F0-F650-4625-B1D6-59790D4B03DF"),
                        Title = "Title1",
                        UserId = UserAId
                    },
                    new Note
                    {
                        CreationDate = DateTime.Today,
                        Details = "Details2",
                        EditDate = null,
                        Id = Guid.Parse("0ED1715A-6710-40A2-8A66-D23B11C5A55E"),
                        Title = "Title2",
                        UserId= UserBId
                    },
                    new Note
                    {
                        CreationDate = DateTime.Today,
                        Details = "Details3",
                        EditDate = null,
                        Id = NoteIdForDelete,
                        Title = "Title3",
                        UserId = UserAId
                    },
                    new Note
                    {
                        CreationDate = DateTime.Today,
                        Details = "Details4",
                        EditDate = null,
                        Id = NoteIdForUpdate,
                        Title = "Title4",
                        UserId = UserBId
                    }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(NotesDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
