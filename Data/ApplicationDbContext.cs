using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Twenty.Data.Domain;
using Twenty.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Twenty.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<MatchTeam> MatchTeams { get; set; }
        public DbSet<TeamPlayer> TeamPlayers { get; set; }
        public DbSet<PlayerChoice> PlayerChoices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<MatchTeam>(team =>
            {
                team.HasKey(mt => new { mt.MatchId, mt.TeamId });

                team.HasOne(mt => mt.Match)
                    .WithMany(m => m.Teams)
                    .HasForeignKey(mt => mt.MatchId)
                    .IsRequired();

                team.HasOne(mt => mt.Team)
                    .WithMany(m => m.Matches)
                    .HasForeignKey(mt => mt.TeamId)
                    .IsRequired();
            });

            builder.Entity<TeamPlayer>(team =>
            {
                team.HasKey(tp => new { tp.PlayerId, tp.TeamId });

                team.HasOne(tp => tp.Player)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(tp => tp.PlayerId)
                    .IsRequired();

                team.HasOne(tp => tp.Team)
                    .WithMany(t => t.Players)
                    .HasForeignKey(tp => tp.TeamId)
                    .IsRequired();
            });

            builder.Entity<PlayerChoice>(choice =>
            {
                choice.HasKey(pc => new { pc.PlayerId, pc.ChoiceId });

                choice.HasOne(pc => pc.Player)
                    .WithMany(p => p.Choices)
                    .HasForeignKey(pc => pc.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                choice.HasOne(pc => pc.Choice)
                    .WithMany(c => c.PlayerChoices)
                    .HasForeignKey(pc => pc.ChoiceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                choice.HasOne(pc => pc.Game)
                    .WithMany(g => g.PlayerChoices)
                    .HasForeignKey(pc => pc.GameId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder
                .Entity<Match>()
                .HasOne(match => match.Winner)
                .WithMany(team => team.Wins)
                .HasForeignKey(match => match.WinnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Question>()
                .HasMany(q => q.Choices)
                .WithOne(c => c.Question)
                .HasForeignKey(c => c.QuestionId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder
                .Entity<Player>()
                .HasMany(p => p.TeamsOrganized)
                .WithOne(t => t.Organizer)
                .HasForeignKey(t => t.OrganizerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder
                .Entity<Game>()
                .HasMany(g => g.Questions)
                .WithOne(q => q.Game)
                .HasForeignKey(q => q.GameId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.SeedAdmin();
        }

        public override int SaveChanges()
        {
            var changedEntities = ChangeTracker.Entries();

            foreach (var changedEntity in changedEntities)
            {
                if (changedEntity.Entity is Entity)
                {
                    var entity = changedEntity.Entity as Entity;
                    if (changedEntity.State == EntityState.Added)
                    {
                        entity.Created = DateTime.Now;
                        entity.Updated = DateTime.Now;
                        
                    }
                    else if (changedEntity.State == EntityState.Modified)
                    {
                        entity.Updated = DateTime.Now;
                    }
                }

            }
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var changedEntities = ChangeTracker.Entries();

            foreach (var changedEntity in changedEntities)
            {
                if (changedEntity.Entity is Entity)
                {
                    var entity = changedEntity.Entity as Entity;
                    if (changedEntity.State == EntityState.Added)
                    {
                        entity.Created = DateTime.Now;
                        entity.Updated = DateTime.Now;
                        
                    }
                    else if (changedEntity.State == EntityState.Modified)
                    {
                        entity.Updated = DateTime.Now;
                    }
                }
            }
            return (await base.SaveChangesAsync(true, cancellationToken));
        }

        public DbSet<Twenty.Data.Domain.Choice> Choice { get; set; }
        

    }
}