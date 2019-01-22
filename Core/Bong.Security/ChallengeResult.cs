using Microsoft.AspNetCore.Mvc;

namespace Bong.Security
{
    public class ChallengeResult
    {
        public bool IsAuthenticated { get; set; }

        public IActionResult Action { get; set; }
    }
}