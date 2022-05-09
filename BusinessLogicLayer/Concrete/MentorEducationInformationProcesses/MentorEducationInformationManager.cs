using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete.MentorEducationInformationProcesses
{
    public class MentorEducationInformationManager : IMentorEducationInformationService
    {
        IMentorEducationInformationDal _mentorEducationInformationDal;
        public MentorEducationInformationManager(IMentorEducationInformationDal mentorEducationInformationDal)
        {
            _mentorEducationInformationDal = mentorEducationInformationDal;
        }

        public IResult Add(MentorEducationInformation mentorEducationInformation)
        {
            _mentorEducationInformationDal.Add(mentorEducationInformation);
            return new SuccessResult();
        }

        public IResult Update(MentorEducationInformation mentorEducationInformation)
        {
            _mentorEducationInformationDal.Update(mentorEducationInformation);
            return new SuccessResult();
        }

        public IResult Delete(MentorEducationInformation mentorEducationInformation)
        {
            _mentorEducationInformationDal.Delete(mentorEducationInformation);
            return new SuccessResult();
        }

        public IDataResult<MentorEducationInformation> GetMentorEducationInformationById(Guid mentorEducationInformationId)
        {
            var result = _mentorEducationInformationDal.GetById(mentorEducationInformationId);
            if (result != null)
            {
                return new SuccessDataResult<MentorEducationInformation>(result);
            }
            return new ErrorDataResult<MentorEducationInformation>();
        }

        public IDataResult<List<MentorEducationInformation>> GetMentorEducationInformations()
        {
            var result = _mentorEducationInformationDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<MentorEducationInformation>>(result);
            }
            return new ErrorDataResult<List<MentorEducationInformation>>();
        }
    }
}
