using Application.RequestHandlers.StalkerRequests.Query.GetListOfAvatarsByGroupingId;
using Application.RequestHandlers.StalkerRequests.Query.GetListOfGrouping;
using Application.RequestHandlers.StalkerRequests.Query.GetListOfLeadersOfGroupings;
using AutoMapper;
using Domain.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtRegisterAndLogin.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StalkersController : ApiController
{
    
    private readonly ISender _sender; 
    private readonly IMapper _mapper;
    public StalkersController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetLeadersOfGroupings()
    {
        var leaders = await _sender.Send(new GetListOfLeadersOfGroupingQuery());
        return Ok(_mapper.Map<List<LeaderOfGroupingResponse>>(leaders));
    }

    [HttpGet("get-list-of-avatars-by-grouping-id-{groupingId}")]
    public async Task<IActionResult> GetListOfAvatarsByGroupingId([FromRoute] Guid groupingId)
    {
        var avatars = await _sender.Send(new GetListOfAvatarsByGroupingIdQuery(groupingId));
        return avatars.Match(
            avatars => Ok(_mapper.Map<List<AvatarByGroupingIdResponse>>(avatars)),
            errors => Problem(errors));
    }

    [HttpGet("get-list-of-grouping")]
    public async Task<IActionResult> GetListOfGrouping()
    {
        var listOfGrouping = await _sender.Send(new GetListOfGroupingQuery());
        return listOfGrouping.Match(
            listOfGrouping => Ok(_mapper.Map<List<GroupingListItemResponse>>(listOfGrouping)),
            errors => Problem(errors));
    }
}

