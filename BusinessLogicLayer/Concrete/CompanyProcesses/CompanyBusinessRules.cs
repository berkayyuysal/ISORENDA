using System;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Concrete.CompanyProcesses
{
    public partial class CompanyManager
    {
        private IResult CheckIsTaxNumberExists(string taxNumber)
        {
            var company = _companyDal.GetOne(c => c.TaxNumber == taxNumber);
            if (company != null)
            {
                return new ErrorResult("Bu vergi numarası sisteme kayıtlıdır.");
            }
            return new SuccessResult();
        }
    }
}
