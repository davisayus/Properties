using Microsoft.Extensions.Logging;
using Properties.Entities.Entities;
using Properties.Entities.Models;
using Properties.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Core.Core.V1
{
    public class OwnerCore
    {
        public readonly IOwnerRepository _repository;
        public readonly ILogger<Owner> _logger;
        public readonly Errors<Owner> _errors;

        public OwnerCore(IOwnerRepository ownerRepository, ILogger<Owner> logger)
        {
            _repository = ownerRepository;
            _logger = logger;
            _errors = new Errors<Owner>(logger);
        }
        public async Task<ResponseService<Owner>> AddAsync(Owner entity)
        {
            try
            {
                var result = await _repository.AddAsync(entity);
                return new ResponseService<Owner>(false, result.Item2 ? "Successfully created Owner" : "Record not created", System.Net.HttpStatusCode.Created, result.Item1);
            }
            catch (Exception e)
            {
                return _errors.Error(e, "AddOwnerAsync", entity);
            }

        }
        public async Task<ResponseService<Owner>> UpdateAsync(Owner entity)
        {
            try
            {
                var result = await _repository.UpdateAsync(entity);
                return new ResponseService<Owner>(false, result ? "Successfully updated Owner" : "Record not updated", System.Net.HttpStatusCode.Created, entity);
            }
            catch (Exception e)
            {
                return _errors.Error(e, "UpdateOwnerAsync", entity);
            }

        }
        public async Task<ResponseService<List<Owner>>> GetAllAsync()
        {
            try
            {
                var result = await _repository.QueryAllAsync();
                return new ResponseService<List<Owner>>(false, result.Count() == 0 ? "No Records found" : $"{result.Count} records found", System.Net.HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                return _errors.Error(e, "GetAllOwnerAsync", new List<Owner>());
            }
        }
        public async Task<ResponseService<Owner>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _repository.QueryByIdAsync(id);
                return new ResponseService<Owner>(false, result.IdOwner != id ? "No Records found" : $"Record found", System.Net.HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                return _errors.Error(e, "GetByIdOwnerAsync", new Owner());
            }
        }
        public async Task<ResponseService<List<Owner>>> GetByName(string name)
        {
            try
            {
                var result = await _repository.QueryByFilterAsync(o=>o.Name.Contains(name));
                return new ResponseService<List<Owner>>(false, result.Count == 0 ? "No Records found" : $"Record found", System.Net.HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                return _errors.Error(e, "GetByNameOwnerAsync", new List<Owner>());
            }

        }

    }
}
