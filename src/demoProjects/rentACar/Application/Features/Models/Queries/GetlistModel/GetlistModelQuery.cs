using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetlistModel
{
    public class GetlistModelQuery : IRequest<ModelListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetlistModelQueryHandler : IRequestHandler<GetlistModelQuery, ModelListModel>
        {
            private readonly IMapper _mapper;
            private readonly IModelRepository _modelRepository;

            public GetlistModelQueryHandler(IMapper mapper, IModelRepository modelRepository)
            {
                _mapper = mapper;
                _modelRepository = modelRepository;
            }

            public async Task<ModelListModel> Handle(GetlistModelQuery request, CancellationToken cancellationToken)
            {
               IPaginate<Model> models = await _modelRepository.GetListAsync(include:
                                                m => m.Include(c => c.Brand),
                                                index: request.PageRequest.Page,
                                                size : request.PageRequest.PageSize);
                ModelListModel model = _mapper.Map<ModelListModel>(models);
                return model;
            }
        }
    }
}
