﻿using AutoMapper;
using maERP.Application.Contracts.Logging;
using maERP.Application.Contracts.Persistence;
using MediatR;

namespace maERP.Application.Features.User.Queries.GetUsers;

public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<GetUsersResponse>>
{
    private readonly IMapper _mapper;
    private readonly IAppLogger<GetUsersHandler> _logger;
    private readonly IUserRepository _userRepository;

    public GetUsersHandler(IMapper mapper,
        IAppLogger<GetUsersHandler> logger, 
        IUserRepository userRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _userRepository = userRepository; 
    }

    public async Task<List<GetUsersResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var useres = await _userRepository.GetAllAsync();

        // Convert data objects to DTO objects
        var data = _mapper.Map<List<GetUsersResponse>>(useres);

        // Return list of DTO objects
        _logger.LogInformation("All Useres are retrieved successfully.");
        return data;
    }
}