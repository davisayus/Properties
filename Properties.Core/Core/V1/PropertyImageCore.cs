using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Properties.Contracts.Repository;
using Properties.Core.Core.V1.Utilities;
using Properties.Entities.Dtos;
using Properties.Entities.Entities;
using Properties.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Core.Core.V1
{
    public class PropertyImageCore
    {
        private readonly IPropertyImageRepository _repository;
        private readonly ILogger<PropertyImage> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _enviroment;
        private readonly Errors<PropertyImage> _errors;

        public PropertyImageCore(IPropertyImageRepository propertyRepository, ILogger<PropertyImage> logger, IMapper mapper, IWebHostEnvironment environment)
        {
            _repository = propertyRepository;
            _logger = logger;
            _mapper = mapper;
            _enviroment = environment;
            _errors = new Errors<PropertyImage>(_logger);
        }

        public async Task<ResponseService<PropertyImageDto>> AddAsync(PropertyImageCreateDto entityCreate)
        {
            PropertyImage entity = new PropertyImage();
            try
            {
                entity = _mapper.Map<PropertyImage>(entityCreate);
                entity.Image = await ImagesUtility.UploadLocal(entityCreate.Image, _enviroment.ContentRootPath);

                var result = await _repository.AddAsync(entity);
                return new ResponseService<PropertyImageDto>(false, result.Item2 ? "Successfully created PropertyImage" : "Record not created", System.Net.HttpStatusCode.Created, _mapper.Map<PropertyImageDto>(result.Item1));
            }
            catch (Exception e)
            {
                return _errors.Error(e, "AddPropertyImageAsync", new PropertyImageDto());
            }

        }
        public async Task<ResponseService<List<PropertyImageDto>>> AddCollectionAsync(List<PropertyImageCreateDto> entitiesCreate)
        {
            List<PropertyImageDto> entities = new List<PropertyImageDto>();
            try
            {

                foreach (var item in entitiesCreate)
                {
                    var result = await AddAsync(item);
                    entities.Add(_mapper.Map<PropertyImageDto>(result.Content));
                }

                return new ResponseService<List<PropertyImageDto>>(false, entities.Count != 0 ? "Successfully created PropertyImage" : "Record not created", System.Net.HttpStatusCode.Created, entities);
            }
            catch (Exception e)
            {
                return _errors.Error(e, "AddPropertyImageCollectionAsync", new List<PropertyImageDto>());
            }

        }
        public async Task<ResponseService<PropertyImageDto>> UpdateAsync(PropertyImageUpdateDto entityUpdate)
        {
            PropertyImage entity = new PropertyImage();
            try
            {
                entity = await _repository.QueryByIdAsync(entityUpdate.IdPropertyImage);
                if (entity.IdPropertyImage != entityUpdate.IdPropertyImage)
                    return _errors.Error(new Exception("PropertyImage not found"), "UpdatePropertyImageAsync", new PropertyImageDto());

                entity = _mapper.Map<PropertyImage>(entityUpdate);
                var result = await _repository.UpdateAsync(entity);
                return new ResponseService<PropertyImageDto>(false, result ? "Successfully updated PropertyImage" : "Record not updated", System.Net.HttpStatusCode.Created, _mapper.Map<PropertyImageDto>(entity));
            }
            catch (Exception e)
            {
                return _errors.Error(e, "UpdatePropertyImageAsync", new PropertyImageDto());
            }

        }
        public async Task<ResponseService<List<PropertyImageDto>>> GetAllAsync()
        {
            try
            {
                var result = await _repository.QueryAllAsync();
                var resultDto = _mapper.Map<List<PropertyImageDto>>(result);
                return new ResponseService<List<PropertyImageDto>>(false, result.Count() == 0 ? "No Records found" : $"{result.Count} records found", System.Net.HttpStatusCode.OK, resultDto);
            }
            catch (Exception e)
            {
                return _errors.Error(e, "GetAllPropertyImageAsync", new List<PropertyImageDto>());
            }
        }
        public async Task<ResponseService<PropertyImageDto>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _repository.QueryByIdAsync(id);
                var resultDto = _mapper.Map<PropertyImageDto>(result);

                return new ResponseService<PropertyImageDto>(false, result.IdProperty != id ? "No Records found" : $"Record found", System.Net.HttpStatusCode.OK, resultDto);
            }
            catch (Exception e)
            {
                return _errors.Error(e, "GetByIdPropertyAsync", new PropertyImageDto());
            }
        }
        public async Task<ResponseService<List<PropertyImageDto>>> GetByIdPropertyAsync(int idProperty)
        {
            try
            {
                var result = await _repository.QueryByFilterAsync(pi => pi.IdProperty == idProperty);
                var resultDto = _mapper.Map<List<PropertyImageDto>>(result);

                return new ResponseService<List<PropertyImageDto>>(false, result.Count == 0 ? "No Records found" : $"{result.Count} Record found", System.Net.HttpStatusCode.OK, resultDto);
            }
            catch (Exception e)
            {
                return _errors.Error(e, "GetByIdPropertyAsync", new List<PropertyImageDto>());
            }
        }

    }
}
