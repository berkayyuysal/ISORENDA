using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IFileAuthenticateDal : IEntityRepository<FileAuthenticate>
    {
    }
}
