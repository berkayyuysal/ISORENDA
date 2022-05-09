using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface IMentorEducationInformationService
    {
        IResult Add(MentorEducationInformation mentorEducationInformation);
        IResult Update(MentorEducationInformation mentorEducationInformation);
        IResult Delete(MentorEducationInformation mentorEducationInformation);
        IDataResult<List<MentorEducationInformation>> GetMentorEducationInformations();
        IDataResult<MentorEducationInformation> GetMentorEducationInformationById(Guid mentorEducationInformationId);
    }
}
