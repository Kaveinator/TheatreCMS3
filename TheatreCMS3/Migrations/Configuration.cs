namespace TheatreCMS3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.IO;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<TheatreCMS3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TheatreCMS3.Models.ApplicationDbContext context)
        {
            context.CastMembers.AddOrUpdate(x => x.CastMemberId,
                new Models.CastMembers()
                {
                    CastMemberId = 1,
                    Name = "Ben Crawford",
                    Character = "The Phantom",
                    MainRole = 0,
                    CurrenMember = true,
                    Bio = "" +
                    "Ben Crawford was born and raised in Tucson, Arizona and received a BFA in Music Theatre from The University" +
                    " of Arizona. His Broadway credits include Charlie and the Chocolate Factory (Mr. Salt), the titular character" +
                    " in Shrek The Musical, Big Fish (Edward Bloom u/s, Don Price), Les Misérables (Javert/Valjean u/s) and On the " +
                    "Twentieth Century (Bruce Granit u/s). Phantom marks Ben’s sixth Broadway show and he is beyond grateful to be " +
                    "able to jump into this iconic role. Ben has also starred in over twenty regional theatre productions ranging " +
                    "from Che in Evita (Studio Tenn), Starbuck in 110 in the Shade (Ford’s Theatre), Luther Billis in South Pacific " +
                    "(Ogunquit Playhouse), Frederick Barrett in Titanic (MUNY) and Jud Fry in Oklahoma! (Fox Theatre)."
                },
                new Models.CastMembers()
                {
                    CastMemberId = 2,
                    Name = "Meghan Picerno",
                    Character = "Christine",
                    MainRole = 0,
                    CurrenMember = true,
                    Bio = "" +
                    "Meghan Picerno makes her Broadway debut in The Phantom of the Opera after starring in the Phantom of the Opera" +
                    "world tour. She also originated the role of Christine in the North American premiere of Love Never Dies, the" +
                    "sequel to The Phantom of the Opera."
                },
                new Models.CastMembers()
                {
                    CastMemberId = 3,
                    Name = "John Riddle",
                    Character = "Raoul",
                    MainRole = 0, 
                    CurrenMember = true,
                    Bio = "" +
                    "John Riddle has been seen on Broadway in Frozen (Hans), The Visit (Young Anton) and on the national tour of Evita." +
                    "Other favorites credits include Tony in West Side Story (Casa Mañana), Joe Hardy in Damn Yankees (PCLO), Eric in The " +
                    "Little Mermaid (Muny), Little Dancer (Kennedy Center) and My Paris (Long Wharf). He has appeared in the concert " +
                    "performances of The Secret Garden (Lincoln Center) and with the Cincinnati Pops, as well as performed his solo show " +
                    "Keep It Simple at Feinstein’s/54 Below."
                }
                );
    
        }
    }
}
