using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace BusinessLogicLayer.Abstract
{
    public interface IMentorService
    {
        IResult Add(Mentor mentor, UserForRegisterDto userForRegisterDto);
        IResult Update(Mentor mentor);
        IResult Delete(Mentor mentor);
        IDataResult<List<Mentor>> GetClients();
        IDataResult<Mentor> GetClientById(Guid mentorId);
        IDataResult<Mentor> GetClientByUserId(Guid userId);
        IDataResult<List<Mentor>> GetClientsWithUserInformations();
        IDataResult<Mentor> GetOneClientWithUserInformations(Guid mentorId);
    }
}
