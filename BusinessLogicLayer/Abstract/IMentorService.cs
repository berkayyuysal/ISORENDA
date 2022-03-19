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
        IDataResult<List<Mentor>> GetMentors();
        IDataResult<Mentor> GetMentorById(Guid mentorId);
        IDataResult<Mentor> GetMentorByUserId(Guid userId);
        IDataResult<List<Mentor>> GetMentorsWithUserInformations();
        IDataResult<Mentor> GetOneMentorWithUserInformations(Guid mentorId);
    }
}
