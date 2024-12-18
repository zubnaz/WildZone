using AutoMapper;
using Domain.Models.Entities;
using Domain.Models.Responses;

namespace JwtRegisterAndLogin.Common.Profiles;
public class StalkersProfile : Profile
{
    public StalkersProfile()
    {
        CreateMap<Stalker, LeaderOfGroupingResponse>()
            .ForMember(desp => desp.Id, src => src.MapFrom(s => s.Id))
            .ForMember(desp => desp.Allies, src => src.MapFrom(s => s.Alias))
            .ForMember(desp => desp.Grouping, src => src.MapFrom(s => s.Group!.Name))
            .ForMember(desp => desp.Rang, src => src.MapFrom(s => s.Rang!.Name))
            .ForMember(desp => desp.Avatar, src => src.MapFrom(s => s.Avatar!.Name))
            .ForMember(desp => desp.Power, src => src.MapFrom(s => s.Rang!.Power));

        CreateMap<Avatar, AvatarByGroupingIdResponse>()
            .ForMember(desp => desp.AvatarId, src => src.MapFrom(a => a.Id))
            .ForMember(desp => desp.Name, src => src.MapFrom(a => a.Name));

        CreateMap<Grouping, GroupingListItemResponse>()
            .ForMember(desp => desp.Id, src => src.MapFrom(g => g.Id))
            .ForMember(desp => desp.Name, src => src.MapFrom(g => g.Name))
            .ForMember(desp => desp.Logo, src => src.MapFrom(g => g.Logo));

    }
}

