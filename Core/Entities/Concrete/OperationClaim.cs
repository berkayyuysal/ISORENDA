using System;

namespace Core.Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public Guid OperationClaimId { get; set; }
        public string OperationClaimName { get; set; }

    }
}