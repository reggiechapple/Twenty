using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Twenty.Data.Domain;
using Twenty.Data.Identity;

namespace Twenty.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedAdmin(this ModelBuilder builder) 
        {
            var ADMIN_ROLEID = "54570c7c-baae-47ea-9e67-5ed5f9c07959";
            var ADMIN_USERID = "773a58c0-eee3-4076-bcc4-04be82a4bc97";
            
            builder.Entity<ApplicationRole>().HasData(new List<ApplicationRole>
            {
                new ApplicationRole {
                    Id = ADMIN_ROLEID,
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new ApplicationRole {
                    Id = "62ae0b19-e426-4c3a-9123-567b0354acbc",
                    Name = "User",
                    NormalizedName = "USER"
                },
            });

            var appUser = new ApplicationUser {
                Id = ADMIN_USERID,
                FullName = "Super User",
                Email = "sudo@local.com",
                UserName = "sudo"
            };

            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "P@ss1234");

            builder.Entity<ApplicationUser>().HasData(appUser);

            builder.Entity<ApplicationUserRole>().HasData(new ApplicationUserRole
            {
                RoleId = ADMIN_ROLEID,
                UserId = ADMIN_USERID
            });
        }

        public static void SeedTeams(this ModelBuilder builder)
        {
            builder.Entity<Team>().HasData(new List<Team>
            {
                new Team 
                {
                    Id = 1,
                    Name = "Arizona Cardinals",
                    Nickname = "Cardinals",
                    Website = "https://www.azcardinals.com/",
                    Logo = "/nfl-logos/nfl-arizona-cardinals-team-logo.png",
                    Record = "0-0"
                },
                new Team 
                {
                    Id = 2,
                    Name = "Atlanta Falcons",
                    Nickname = "Falcons",
                    Website = "https://www.atlantafalcons.com/",
                    Logo = "/nfl-logos/nfl-atlanta-falcons-team-logo.png",
                    Record = "0-0"
                },
                new Team 
                {
                    Id = 3,
                    Name = "Baltimore Ravens",
                    Nickname = "Ravens",
                    Website = "https://www.baltimoreravens.com/",
                    Logo = "/nfl-logos/nfl-baltimore-ravens-team-logo.png",
                    Record = "0-0"
                },
                new Team 
                {
                    Id = 4,
                    Name = "Buffalo Bills",
                    Nickname = "Bills",
                    Website = "https://www.buffalobills.com/",
                    Logo = "/nfl-logos/nfl-buffalo-bills-team-logo.png",
                    Record = "0-0"
                },
                new Team 
                {
                    Id = 5,
                    Name = "Carolina Panthers",
                    Nickname = "Panthers",
                    Website = "https://www.panthers.com/",
                    Logo = "/nfl-logos/nfl-carolina-panthers-team-logo.png",
                    Record = "0-0"
                },
                new Team 
                {
                    Id = 6,
                    Name = "Chicago Bears",
                    Nickname = "Bears",
                    Website = "https://www.chicagobears.com/",
                    Logo = "/nfl-logos/nfl-chicago-bears-team-logo.png",
                    Record = "0-0"
                },
                new Team 
                {
                    Id = 7,
                    Name = "Cincinnati Bengals",
                    Nickname = "Bengals",
                    Website = "https://www.bengals.com/",
                    Logo = "/nfl-logos/nfl-cincinnati-bengals-team-logo.png",
                    Record = "0-0"
                },
                new Team 
                {
                    Id = 8,
                    Name = "Cleveland Browns",
                    Nickname = "Browns",
                    Website = "https://www.clevelandbrowns.com/",
                    Logo = "/nfl-logos/nfl-cleveland-browns-team-logo.png",
                    Record = "0-0"
                },
            });
        }
    }
}