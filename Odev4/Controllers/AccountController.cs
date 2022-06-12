using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Odev4.Contexts;
using Odev4.JwtToken;
using Odev4.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Odev4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Members
        List<Claim> claims = new List<Claim>();
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        CreateJwtToken createJwtToken;
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;
        private readonly MyDbContext _dbContext;
        #endregion
        #region Constructor
        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IDistributedCache distributedCache, IMemoryCache memoryCache, MyDbContext dbContext) =>
            (_userManager, _roleManager, _distributedCache, _memoryCache, _dbContext) = (userManager, roleManager, distributedCache, memoryCache, dbContext);
        #endregion
        #region Methods
        /// <summary>
        /// Id' ye göre history postları memorycache ve distributedcache de tutan metod
        /// </summary>
        /// <param name="historyPostId"></param>
        /// <returns></returns>
        [HttpGet("GetHistoryPostCache")]
        [ResponseCache(Duration = 1000, VaryByHeader = "HistoryPost", VaryByQueryKeys = new string[] { "historyPostId" })]
        public IEnumerable<HistoryPosts> GetHistoryPost(int historyPostId)
        {
            HistoryPosts[] historyPosts = _dbContext.HistoryPosts.Where(x => x.HistoryPostId == historyPostId).ToArray();
            if (_memoryCache.TryGetValue("historyposts", out historyPosts))
            {
                return historyPosts;
            }
            var historyPostsByts = _distributedCache.Get("historyposts");
            var historyPostsJson = Encoding.UTF8.GetString(historyPostsByts);
            var historyPostsArr = JsonSerializer.Deserialize<HistoryPosts[]>(historyPostsJson);

            MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions();
            memoryCacheEntryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(8);
            memoryCacheEntryOptions.SlidingExpiration = TimeSpan.FromHours(3);
            memoryCacheEntryOptions.Priority = CacheItemPriority.Normal;

            _memoryCache.Set("historyposts", historyPosts, memoryCacheEntryOptions);
            var distHistoryPostArr = JsonSerializer.Serialize(historyPosts);
            _distributedCache.Set("historyposts", Encoding.UTF8.GetBytes(distHistoryPostArr));
            return historyPosts;
        }
        /// <summary>
        /// Login Metodu
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null) throw new Exception("");

            var result = await _userManager.CheckPasswordAsync(user, login.Password);
            if (result)
            {
                var roles = await _userManager.GetRolesAsync(user);
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                claims.Add(new Claim(ClaimTypes.Name, user.Email));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                var token = createJwtToken.GetToken(claims);
                var handler = new JwtSecurityTokenHandler();
                string jwt = handler.WriteToken(token);
                return Ok(new
                {
                    token = jwt,
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
        #endregion
    }
}
