﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdHandler(ILogger<GetRestaurantByIdHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto?>
{
    public async Task<RestaurantDto?> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting restaurant with ID {RestaurantId} from the repository.", request.Id);

        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);

        var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);

        return restaurantDto;
    }
    
}