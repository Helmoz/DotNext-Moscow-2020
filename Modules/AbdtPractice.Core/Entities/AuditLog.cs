using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Infrastructure.Ddd;

namespace AbdtPractice.Core.Entities
{
    public class AuditLog : IntEntityBase
    {
        protected AuditLog()
        {
        }

        public AuditLog(string eventName, IIdentity identity, int? entityId = null)
        {
            if (identity == null) throw new ArgumentNullException(nameof(identity));
            var userName = identity.IsAuthenticated ? identity.Name : "Anonymous";
            EventName = eventName ?? throw new ArgumentNullException(nameof(eventName));
            UserName = userName!;
            EntityId = entityId;
        }

        [Required] 
        public string EventName { get; protected set; }

        [Required] 
        public string UserName { get; protected set; }

        public int? EntityId { get; protected set; }

        public override string ToString()
        {
            return $"{UserName} / {EventName} / {EntityId}";
        }
    }
}