using Microsoft.AspNetCore.Identity;
using TrippingPortal.Core.Interfaces;

namespace TrippingPortal.Core.Entities
{
    /**
     * An application user
     * Utility means a constituent
     * **/
    public class Utility : IdentityUser, IAggregateRoot
    {
    }
}
