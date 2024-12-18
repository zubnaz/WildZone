using Data;
using Data.Enums;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JwtRegisterAndLogin.Services;
public static class Initialization
{
    public async static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

        var service = scope.ServiceProvider;

        var context = service.GetRequiredService<StalkersDbContext>();

        context.Database.Migrate();

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Stalker>>();

        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        if (!context.Roles.Any())
        {
            await roleManager.CreateAsync(new IdentityRole<Guid> { Id = Guid.NewGuid(), Name= Enums.Roles.Leader.ToString() });
            await roleManager.CreateAsync(new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = Enums.Roles.Stalker.ToString() });
        }
       
        if(!context.Grouping.Any())
        {
            Grouping[] grouping =
            [
                new Grouping()
                {
                    Id = Guid.NewGuid(),
                    Name = "Free stalkers",
                    Power = 0,
                    Logo = "free_stalkers_logo"
                },
                new Grouping()
                {
                    Id = Guid.NewGuid(),
                    Name = "Bandits",
                    Power = 0,
                    Logo = "bandits_logo"
                },
                new Grouping()
                {
                    Id = Guid.NewGuid(),
                    Name = "Renegades",
                    Power = 0,
                    Logo = "renegades_logo"
                },
                new Grouping()
                {
                    Id = Guid.NewGuid(),
                    Name = "Volya",
                    Power = 0,
                    Logo = "volya_logo"
                },
                new Grouping()
                {
                    Id = Guid.NewGuid(),
                    Name = "Obovyazok",
                    Power = 0,
                    Logo = "obovyazok_logo"
                },
                new Grouping()
                {
                    Id = Guid.NewGuid(),
                    Name = "Clear sky",
                    Power = 0,
                    Logo = "clear_sky_logo"
                },
                new Grouping()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mercenaries",
                    Power = 0,
                    Logo = "mercenaries_logo"
                },
                new Grouping()
                {
                    Id = Guid.NewGuid(),
                    Name = "Scientists",
                    Power = 0,
                    Logo = "scientists_logo"
                },
                new Grouping()
                {
                    Id = Guid.NewGuid(),
                    Name = "Military",
                    Power = 0,
                    Logo = "military_logo"
                },
                new Grouping()
                {
                    Id = Guid.NewGuid(),
                    Name = "Monolith",
                    Power = 0,
                    Logo = "monolith_logo"
                }
            ];

            context.Grouping.AddRange(grouping);

            context.SaveChanges();
        }
        if (!context.Avatars.Any())
        {
            var freeStalkersId = context.Grouping.Single(g => g.Name == "Free stalkers").Id;
            var banditsId = context.Grouping.Single(g => g.Name == "Bandits").Id;
            var renegadesId = context.Grouping.Single(g => g.Name == "Renegades").Id;
            var volyaId = context.Grouping.Single(g => g.Name == "Volya").Id;
            var obovyazokId = context.Grouping.Single(g => g.Name == "Obovyazok").Id;
            var clearSkyId = context.Grouping.Single(g => g.Name == "Clear sky").Id;
            var mercenariesId = context.Grouping.Single(g => g.Name == "Mercenaries").Id;
            var scientistsId = context.Grouping.Single(g => g.Name == "Scientists").Id;
            var militaryId = context.Grouping.Single(g => g.Name == "Military").Id;
            var monolithId = context.Grouping.Single(g => g.Name == "Monolith").Id;
            Avatar[] freeStalkersAvatars = [
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_free_stalker_1",
                    GroupingId = freeStalkersId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_free_stalker_2",
                    GroupingId = freeStalkersId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_free_stalker_3",
                    GroupingId = freeStalkersId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_free_stalker_4",
                    GroupingId = freeStalkersId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_free_stalker_5",
                    GroupingId = freeStalkersId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_free_stalker_6",
                    GroupingId = freeStalkersId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_free_stalker_7",
                    GroupingId = freeStalkersId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_free_stalker_8",
                    GroupingId = freeStalkersId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_free_stalker_9",
                    GroupingId = freeStalkersId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_free_stalker_10",
                    GroupingId = freeStalkersId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_free_stalker_11",
                    GroupingId = freeStalkersId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_free_stalker_12",
                    GroupingId = freeStalkersId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_free_stalker_13",
                    GroupingId = freeStalkersId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_free_stalker_14",
                    GroupingId = freeStalkersId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_free_stalker_15",
                    GroupingId = freeStalkersId
                }
            ];
            Avatar[] banditsRenegadesAvatars = [
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_bandit_renegade_1",
                    GroupingId = banditsId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_bandit_renegade_2",
                    GroupingId = banditsId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_bandit_renegade_3",
                    GroupingId = banditsId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_bandit_renegade_4",
                    GroupingId = banditsId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_bandit_renegade_5",
                    GroupingId = banditsId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_bandit_renegade_6",
                    GroupingId = banditsId
                }
            ];
            Avatar[] volyaAvatars = [
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_volya_1",
                    GroupingId = volyaId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_volya_2",
                    GroupingId = volyaId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_volya_3",
                    GroupingId = volyaId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_volya_4",
                    GroupingId = volyaId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_volya_5",
                    GroupingId = volyaId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_volya_6",
                    GroupingId = volyaId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_volya_7",
                    GroupingId = volyaId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_volya_8",
                    GroupingId = volyaId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_volya_9",
                    GroupingId = volyaId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_volya_10",
                    GroupingId = volyaId
                }
            ];
            Avatar[] obovyazokAvatars = [
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_obovyazok_1",
                    GroupingId = obovyazokId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_obovyazok_2",
                    GroupingId = obovyazokId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_obovyazok_3",
                    GroupingId = obovyazokId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_obovyazok_4",
                    GroupingId = obovyazokId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_obovyazok_5",
                    GroupingId = obovyazokId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_obovyazok_6",
                    GroupingId = obovyazokId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_obovyazok_7",
                    GroupingId = obovyazokId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_obovyazok_8",
                    GroupingId = obovyazokId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_obovyazok_9",
                    GroupingId = obovyazokId
                }
            ];
            Avatar[] clearSkyAvatars = [
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_clear_sky_1",
                    GroupingId = clearSkyId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_clear_sky_2",
                    GroupingId = clearSkyId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_clear_sky_3",
                    GroupingId = clearSkyId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_clear_sky_4",
                    GroupingId = clearSkyId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_clear_sky_5",
                    GroupingId = clearSkyId
                }
            ];
            Avatar[] mercenariesAvatars = [
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_mercenaries_1",
                    GroupingId = mercenariesId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_mercenaries_2",
                    GroupingId = mercenariesId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_mercenaries_3",
                    GroupingId = mercenariesId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_mercenaries_4",
                    GroupingId = mercenariesId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_mercenaries_5",
                    GroupingId = mercenariesId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_mercenaries_6",
                    GroupingId = mercenariesId
                }
            ];
            Avatar[] scientistsAvatars = [
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_scientists_1",
                    GroupingId = scientistsId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_scientists_2",
                    GroupingId = scientistsId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_scientists_3",
                    GroupingId = scientistsId
                }
            ];
            Avatar[] militaryAvatars = [
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_military_1",
                    GroupingId = militaryId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_military_2",
                    GroupingId = militaryId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_military_3",
                    GroupingId = militaryId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_military_4",
                    GroupingId = militaryId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_military_5",
                    GroupingId = militaryId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_military_6",
                    GroupingId = militaryId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_military_7",
                    GroupingId = militaryId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_military_8",
                    GroupingId = militaryId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_military_9",
                    GroupingId = militaryId
                }
            ];
            Avatar[] monolithAvatars = [
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_monolith_1",
                    GroupingId = monolithId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_monolith_2",
                    GroupingId = monolithId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_monolith_3",
                    GroupingId = monolithId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_monolith_4",
                    GroupingId = monolithId
                },
                new Avatar()
                {
                    Id = Guid.NewGuid(),
                    Name = "avatar_monolith_5",
                    GroupingId = monolithId
                }
            ];

            context.Avatars.AddRange(freeStalkersAvatars);
            context.Avatars.AddRange(banditsRenegadesAvatars);
            context.Avatars.AddRange(volyaAvatars);
            context.Avatars.AddRange(obovyazokAvatars);
            context.Avatars.AddRange(clearSkyAvatars);
            context.Avatars.AddRange(mercenariesAvatars);
            context.Avatars.AddRange(scientistsAvatars);
            context.Avatars.AddRange(militaryAvatars);
            context.Avatars.AddRange(monolithAvatars);

            context.SaveChanges();
        }
        if (!context.Rangs.Any())
        {
            Rang[] rangs =
            [
                new Rang()
                {
                    Id = Guid.NewGuid(),
                    Name = "Newcomer",
                    Power = 100
                },
                new Rang()
                {
                    Id = Guid.NewGuid(),
                    Name = "Experienced",
                    Power = 150
                },
                new Rang()
                {
                    Id = Guid.NewGuid(),
                    Name = "Veteran",
                    Power = 300
                },
                new Rang()
                {
                    Id = Guid.NewGuid(),
                    Name = "Master",
                    Power = 550
                },
                new Rang()
                {
                    Id = Guid.NewGuid(),
                    Name = "Legendary stalker",
                    Power = 700
                },
            ];

            context.Rangs.AddRange(rangs);

            context.SaveChanges();

        }
        if(!context.Users.Any())
        {
            var legendaryRang = context.Rangs.Single(rang => rang.Name == "Legendary stalker");

            var groupingFreeStalkers = context.Grouping.Single(grouping => grouping.Name == "Free stalkers");
            var groupingBandits = context.Grouping.Single(grouping => grouping.Name == "Bandits");
            var groupingRenegades = context.Grouping.Single(grouping => grouping.Name == "Renegades");
            var groupingVolya = context.Grouping.Single(grouping => grouping.Name == "Volya");
            var groupingObovyazok = context.Grouping.Single(grouping => grouping.Name == "Obovyazok");
            var groupingClearSky = context.Grouping.Single(grouping => grouping.Name == "Clear sky");
            var groupingMercenaries = context.Grouping.Single(grouping => grouping.Name == "Mercenaries");
            var groupingScientists = context.Grouping.Single(grouping => grouping.Name == "Scientists");
            var groupingMilitary = context.Grouping.Single(grouping => grouping.Name == "Military");
            var groupingMonolith = context.Grouping.Single(grouping => grouping.Name == "Monolith");


            var leaderOfStalkers = new Stalker()
            {
                Alias = "Gonta",
                UserName = "Gonta",
                RangId = legendaryRang.Id,
                GroupingId = groupingFreeStalkers.Id,
                IsLeader = true,
                Email = "GontaLeader@gmail.com",
                AvatarId = context.Avatars.Single(avatar => avatar.Name == "avatar_free_stalker_7").Id,           
            };
            var leaderOfBandits = new Stalker()
            {
                Alias = "Blade",
                UserName = "Blade",
                RangId = legendaryRang.Id,
                GroupingId = groupingBandits.Id,
                IsLeader = true,
                Email = "BladeLeader@gmail.com",
                AvatarId = context.Avatars.Single(avatar => avatar.Name == "avatar_bandit_renegade_5").Id
            };
            var leaderOfRenegades = new Stalker()
            {
                Alias = "Barbarian",
                UserName = "Barbarian",
                RangId = legendaryRang.Id,
                GroupingId = groupingRenegades.Id,
                IsLeader = true,
                Email = "BarbarianLeader@gmail.com",
                AvatarId = context.Avatars.Single(avatar => avatar.Name == "avatar_bandit_renegade_6").Id
            };
            var leaderOfVolya = new Stalker()
            {
                Alias = "Loki",
                UserName = "Loki",
                RangId = legendaryRang.Id,
                GroupingId = groupingVolya.Id,
                IsLeader = true,
                Email = "LokiLeader@gmail.com",
                AvatarId = context.Avatars.Single(avatar => avatar.Name == "avatar_volya_10").Id
            };
            var leaderOfObovyazok = new Stalker()
            {
                Alias = "General Klymenko",
                UserName = "GeneralKlymenko",
                RangId = legendaryRang.Id,
                GroupingId = groupingObovyazok.Id,
                IsLeader = true,
                Email = "GeneralKlymenkoLeader@gmail.com",
                AvatarId = context.Avatars.Single(avatar => avatar.Name == "avatar_obovyazok_2").Id
            };
            var leaderOfClearSky = new Stalker()
            {
                Alias = "Lebedev",
                UserName = "Lebedev",
                RangId = legendaryRang.Id,
                GroupingId = groupingClearSky.Id,
                IsLeader = true,
                Email = "LebedevLeader@gmail.com",
                AvatarId = context.Avatars.Single(avatar => avatar.Name == "avatar_clear_sky_1").Id
            };
            var leaderOfMercenaries = new Stalker()
            {
                Alias = "Greek",
                UserName = "Greek",
                RangId = legendaryRang.Id,
                GroupingId = groupingMercenaries.Id,
                IsLeader = true,
                Email = "GreekLeader@gmail.com",
                AvatarId = context.Avatars.Single(avatar => avatar.Name == "avatar_mercenaries_6").Id
            };
            var leaderOfScientists = new Stalker()
            {
                Alias = "Professor Saharov",
                UserName = "ProfessorSaharov",
                RangId = legendaryRang.Id,
                GroupingId = groupingScientists.Id,
                IsLeader = true,
                Email = "ProfessorSaharovLeader@gmail.com",
                AvatarId = context.Avatars.Single(avatar => avatar.Name == "avatar_scientists_1").Id
            };
            var leaderOfMilitary = new Stalker()
            {
                Alias = "General Smoilevich",
                UserName = "GeneralSmoilevich",
                RangId = legendaryRang.Id,
                GroupingId = groupingMilitary.Id,
                IsLeader = true,
                Email = "GeneralSmoilevichLeader@gmail.com",
                AvatarId = context.Avatars.Single(avatar => avatar.Name == "avatar_military_1").Id
            };
            var leaderOfMonolith = new Stalker()
            {
                Alias = "Charon",
                UserName = "Charon",
                RangId = legendaryRang.Id,
                GroupingId = groupingMonolith.Id,
                IsLeader = true,
                Email = "CharonLeader@gmail.com",
                AvatarId = context.Avatars.Single(avatar => avatar.Name == "avatar_monolith_1").Id
            };

            
            IdentityResult result = await userManager.CreateAsync(leaderOfStalkers, "fK5fk2611624");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(leaderOfStalkers, Enums.Roles.Leader.ToString());
                groupingFreeStalkers.LeaderId = leaderOfStalkers.Id;
                context.Grouping.Update(groupingFreeStalkers);
                context.SaveChanges();
                Console.WriteLine($"{leaderOfStalkers.Alias} added.");
            }
            else if (result.Errors.Count() > 0)
            {
                Console.WriteLine($"Error ---> {result.Errors.First().Description}");
            }

            result = await userManager.CreateAsync(leaderOfBandits, "7xP901134u9o");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(leaderOfBandits, Enums.Roles.Leader.ToString());
                groupingBandits.LeaderId = leaderOfBandits.Id;
                context.Grouping.Update(groupingBandits);
                context.SaveChanges();
                Console.WriteLine($"{leaderOfBandits.Alias} added.");
            }
            else if (result.Errors.Count() > 0)
            {
                Console.WriteLine($"Error ---> {result.Errors.First().Description}");
            }

            result = await userManager.CreateAsync(leaderOfRenegades, "K4up0pZ9Gtl3");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(leaderOfRenegades, Enums.Roles.Leader.ToString());
                groupingRenegades.LeaderId = leaderOfRenegades.Id;
                context.Grouping.Update(groupingRenegades);
                context.SaveChanges();
                Console.WriteLine($"{leaderOfRenegades.Alias} added.");
            }
            else if (result.Errors.Count() > 0)
            {
                Console.WriteLine($"Error ---> {result.Errors.First().Description}");
            }

            result = await userManager.CreateAsync(leaderOfVolya, "3gJK5293kZ1p");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(leaderOfVolya, Enums.Roles.Leader.ToString());
                groupingVolya.LeaderId = leaderOfVolya.Id;
                context.Grouping.Update(groupingVolya);
                context.SaveChanges();
                Console.WriteLine($"{leaderOfVolya.Alias} added.");
            }
            else if (result.Errors.Count() > 0)
            {
                Console.WriteLine($"Error ---> {result.Errors.First().Description}");
            }

            result = await userManager.CreateAsync(leaderOfObovyazok, "0s02N658h2aQ");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(leaderOfObovyazok, Enums.Roles.Leader.ToString());
                groupingObovyazok.LeaderId = leaderOfObovyazok.Id;
                context.Grouping.Update(groupingObovyazok);
                context.SaveChanges();
                Console.WriteLine($"{leaderOfObovyazok.Alias} added.");
            }
            else if (result.Errors.Count() > 0)
            {
                Console.WriteLine($"Error ---> {result.Errors.First().Description}");
            }

            result = await userManager.CreateAsync(leaderOfClearSky, "1J5X25g6mMTV");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(leaderOfClearSky, Enums.Roles.Leader.ToString());
                groupingClearSky.LeaderId = leaderOfClearSky.Id;
                context.Grouping.Update(groupingClearSky);
                context.SaveChanges();
                Console.WriteLine($"{leaderOfClearSky.Alias} added.");
            }
            else if (result.Errors.Count() > 0)
            {
                Console.WriteLine($"Error ---> {result.Errors.First().Description}");
            }

            result = await userManager.CreateAsync(leaderOfMercenaries, "QdV1XDEv8f1t");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(leaderOfMercenaries, Enums.Roles.Leader.ToString());
                groupingMercenaries.LeaderId = leaderOfMercenaries.Id;
                context.Grouping.Update(groupingMercenaries);
                context.SaveChanges();
                Console.WriteLine($"{leaderOfMercenaries.Alias} added.");
            }
            else if (result.Errors.Count() > 0)
            {
                Console.WriteLine($"Error ---> {result.Errors.First().Description}");
            }

            result = await userManager.CreateAsync(leaderOfScientists, "I34CxryN02TK");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(leaderOfScientists, Enums.Roles.Leader.ToString());
                groupingScientists.LeaderId = leaderOfScientists.Id;
                context.Grouping.Update(groupingScientists);
                context.SaveChanges();
                Console.WriteLine($"{leaderOfScientists.Alias} added.");
            }
            else if (result.Errors.Count() > 0)
            {
                Console.WriteLine($"Error ---> {result.Errors.First().Description}");
            }

            result = await userManager.CreateAsync(leaderOfMilitary, "u1g0JmpUOr3z");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(leaderOfMilitary, Enums.Roles.Leader.ToString());
                groupingMilitary.LeaderId = leaderOfMilitary.Id;
                context.Grouping.Update(groupingMilitary);
                context.SaveChanges();
                Console.WriteLine($"{leaderOfMilitary.Alias} added.");
            }
            else if (result.Errors.Count() > 0)
            {
                Console.WriteLine($"Error ---> {result.Errors.First().Description}");
            }

            result = await userManager.CreateAsync(leaderOfMonolith, "791Db9xG61HS");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(leaderOfMonolith, Enums.Roles.Leader.ToString());
                groupingMonolith.LeaderId = leaderOfMonolith.Id;
                context.Grouping.Update(groupingMonolith);
                context.SaveChanges();
                Console.WriteLine($"{leaderOfMonolith.Alias} added.");
            }
            else if(result.Errors.Count() > 0)
            {
                Console.WriteLine($"Error ---> {result.Errors.First().Description}");
            }
        }
    }
}
