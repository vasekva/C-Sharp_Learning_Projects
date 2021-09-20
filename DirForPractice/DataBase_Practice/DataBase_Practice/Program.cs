using System;
using System.Collections.Generic;
using System.Linq;


/*
 * Нужные команды:
 * 
 * 1) enable-migrations - !! при создании проекта !!
 * 2) add-migration <name>
 * 3) update-database
 * 
 */

namespace DataBase_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {


                var group = new Group()
                {
                    Name = "Rammstein",
                    Year = 1994
                };

                var group2 = new Group()
                {
                    Name = "LinkinPark",
                };

                context.Groups.Add(group);
                context.Groups.Add(group2);
                context.SaveChanges(); // Все локальные изменения бд необходимо сохранять!

                var songs = new List<Song>
                {
                    new Song { Name = "InTheEnd", GroupId = group2.Id },
                    new Song { Name = "Numb", GroupId = group2.Id },
                    new Song { Name = "Mutter", GroupId = group.Id }
                };
                context.Songs.AddRange(songs);
                context.SaveChanges();

                // способ изменения данных в бд
                var s = context.Groups.Single(g => g.Id == group.Id);
                s.Name = "DeleteRammstein";
                context.SaveChanges();

                foreach (var song in songs)
                {
                    Console.WriteLine($"Song name: {song.Name}, Group name: {song.Group.Name}");
                }
                Console.ReadLine();
            }
        }
    }
}
