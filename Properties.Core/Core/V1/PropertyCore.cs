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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Core.Core.V1
{
    public class PropertyCore
    {
        private readonly IPropertyRepository _repository;
        private readonly ILogger<Property> _logger;
        private readonly IMapper _mapper;
        private readonly Errors<Property> _errors;

        public PropertyCore(IPropertyRepository propertyRepository, ILogger<Property> logger, IMapper mapper)
        {
            _repository = propertyRepository;
            _logger = logger;
            _mapper = mapper;
            _errors = new Errors<Property>(_logger);
        }

        public async Task<ResponseService<Property>> AddAsync(PropertyCreateDto entityCreate, string contentRootPath)
        {
            Property entity = new Property();

            try
            {

                entity = _mapper.Map<Property>(entityCreate);

                if (entityCreate.MainImage.Length > 0)
                    entity.MainImage = await ImagesUtility.UploadLocal(entityCreate.MainImage, contentRootPath);

                entity.DateTimeProcess = DateTime.Now;
                entity.UserProcess = "sysadmin";

                var result = await _repository.AddAsync(entity);
                return new ResponseService<Property>(false, result.Item2 ? "Successfully created Property" : "Record not created", System.Net.HttpStatusCode.Created, result.Item1);
            }
            catch (Exception e)
            {
                return _errors.Error(e, "AddPropertyAsync", entity);
            }

        }
        public async Task<ResponseService<PropertyDto>> UpdateAsync(PropertyUpdateDto entityUpdate)
        {
            Property entity = new Property();
            try
            {
                var resultFound = await _repository.QueryByIdAsync(entityUpdate.IdProperty);
                if (resultFound.IdProperty != entityUpdate.IdProperty)
                    return _errors.Error(new Exception("Property not found"), "UpdatePropertyAsync", new PropertyDto());

                entity = resultFound;
                entity = _mapper.Map<Property>(entityUpdate);

                var result = await _repository.UpdateAsync(entity);
                return new ResponseService<PropertyDto>(false, result ? "Successfully updated Property" : "Record not updated", System.Net.HttpStatusCode.Created, _mapper.Map<PropertyDto>(entity));
            }
            catch (Exception e)
            {
                return _errors.Error(e, "UpdatePropertyAsync", new PropertyDto());
            }

        }
        public async Task<ResponseService<List<PropertyDto>>> GetAllAsync()
        {
            try
            {
                var result = await _repository.QueryAllAsync();
                var resultDto = _mapper.Map<List<PropertyDto>>(result);
                return new ResponseService<List<PropertyDto>>(false, result.Count() == 0 ? "No Records found" : $"{result.Count} records found", System.Net.HttpStatusCode.OK, resultDto);
            }
            catch (Exception e)
            {
                return _errors.Error(e, "GetAllPropertyAsync", new List<PropertyDto>());
            }
        }
        public async Task<ResponseService<PropertyDto>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _repository.QueryByIdAsync(id);
                var resultDto = _mapper.Map<PropertyDto>(result);

                return new ResponseService<PropertyDto>(false, result.IdProperty != id ? "No Records found" : $"Record found", System.Net.HttpStatusCode.OK, resultDto);
            }
            catch (Exception e)
            {
                return _errors.Error(e, "GetByIdPropertyAsync", new PropertyDto());
            }
        }
        public async Task<ResponseService<List<PropertyDto>>> GetByDescription(string description)
        {
            try
            {
                var result = await _repository.QueryByFilterAsync(o => o.Description.Contains(description));
                var resultDto = _mapper.Map<List<PropertyDto>>(result);

                return new ResponseService<List<PropertyDto>>(false, result.Count == 0 ? "No Records found" : $"{result.Count} Records found", System.Net.HttpStatusCode.OK, resultDto);
            }
            catch (Exception e)
            {
                return _errors.Error(e, "GetByDescriptionPropertyAsync", new List<PropertyDto>());
            }

        }
        public async Task<ResponseService<List<PropertyDto>>> GetByAllAsync(FilterPropertiesDto filterProperties)
        {
            try
            {
                StringBuilder sqlWhere = new StringBuilder("Where ");
                StringBuilder sqlStmt = new StringBuilder("Select p.* From Properties p ");

                //Validamos los valores del objeto
                if (!(string.IsNullOrEmpty(filterProperties.Name) || filterProperties.Name.Length == 0))
                    sqlWhere.Append($"p.Name like '%{filterProperties.Name}%' And ");

                if (!(string.IsNullOrEmpty(filterProperties.Description) || filterProperties.Description.Length == 0))
                    sqlWhere.Append($"p.Description like '%{filterProperties.Description}%' And ");

                if (!(string.IsNullOrEmpty(filterProperties.City) || filterProperties.City.Length == 0))
                    sqlWhere.Append($"p.City = '{filterProperties.City}' And ");

                if (!(string.IsNullOrEmpty(filterProperties.State) || filterProperties.State.Length == 0))
                    sqlWhere.Append($"p.State = '{filterProperties.State}' And ");

                if (!(string.IsNullOrEmpty(filterProperties.ZipCode) || filterProperties.ZipCode.Length == 0))
                    sqlWhere.Append($"p.ZipCode = '{filterProperties.ZipCode}' And ");

                if (filterProperties.AreaFrom != 0 && filterProperties.AreaTo != 0)
                    sqlWhere.Append($"p.Area between {filterProperties.AreaFrom} And {filterProperties.AreaTo} And ");

                if (filterProperties.YearFrom != 0 && filterProperties.YearTo != 0)
                    sqlWhere.Append($"p.Year between {filterProperties.YearFrom} And {filterProperties.YearTo} And ");


                foreach (var item in filterProperties.Features)
                {
                    if (!(string.IsNullOrEmpty(item.FeatureValue.ToString()) || item.FeatureValue.ToString().Length == 0))
                        sqlWhere.Append($" pf.IdFeature = {item.IdFeature} And pf.Value = '{item.FeatureValue}' And ");
                }

                if (sqlWhere.ToString().Contains("pf"))
                {
                    sqlStmt.Append("inner join PropertyFeatures pf On p.IdProperty = pf.IdProperty "); 
                }

                sqlStmt.Append(sqlWhere.ToString().Substring(0, sqlWhere.Length - 4));

                var result = await _repository.QueryBySqlStmtAsync(sqlStmt.ToString());
                var resultDto = _mapper.Map<List<PropertyDto>>(result);
                
                return new ResponseService<List<PropertyDto>>(false, result.Count == 0 ? "No Records found" : $"{result.Count} Records found", System.Net.HttpStatusCode.OK, resultDto);
            }
            catch (Exception e)
            {
                return _errors.Error(e, "GetByDescriptionPropertyAsync", new List<PropertyDto>());
            }

        }
        public async Task<ResponseService<Property>> UpdatePriceAsync(PropertyUpdatePriceDto entityUpdate)
        {
            try
            {
                var resultFound = await _repository.QueryByIdAsync(entityUpdate.IdProperty);

                if (resultFound.IdProperty != entityUpdate.IdProperty)
                    return _errors.Error(new Exception("Property not found"), "UpdatePriceAsync", new Property());

                resultFound.Price = entityUpdate.NewPrice;
                var result = await _repository.UpdateAsync(resultFound);
                return new ResponseService<Property>(false, result ? "Successfully updated Property" : "Record not updated", System.Net.HttpStatusCode.Created, resultFound);
            }
            catch (Exception e)
            {
                return _errors.Error(e, "UpdatePropertyAsync", new Property());
            }

        }

    }
}
