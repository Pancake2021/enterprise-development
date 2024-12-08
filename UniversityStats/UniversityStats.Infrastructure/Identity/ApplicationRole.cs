using Microsoft.AspNetCore.Identity;

namespace UniversityStats.Infrastructure.Identity;

public class ApplicationRole : IdentityRole<int>
{
    public string Description { get; set; }
}
