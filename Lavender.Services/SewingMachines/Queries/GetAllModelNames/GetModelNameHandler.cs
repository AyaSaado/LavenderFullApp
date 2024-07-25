﻿using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.SewingMachines
{
    public class GetModelNameHandler : IRequestHandler<GetModelNameRequest, List<ModelNameDto>>
    {
        private readonly ICRUDRepository<ModelName> _modelNameRepository;

        public GetModelNameHandler(ICRUDRepository<ModelName> modelNameRepository)
        {
            _modelNameRepository = modelNameRepository;
        }

        public async Task<List<ModelNameDto>> Handle(GetModelNameRequest request, CancellationToken cancellationToken)
        {
            var entities = await _modelNameRepository.Find(m=>( request.Id == 0 || m.Id== request.Id))
                                                     .ToListAsync(cancellationToken);

            return Mapping.Mapper.Map<List<ModelNameDto>>(entities);
        }
    }
}
