using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPet.Services.Data;
using MyPet.Web.ViewModels.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyPet.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : BaseController
    {
        private readonly ILikesService likesService;

        public LikesController(ILikesService likesService)
        {
            this.likesService = likesService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostLikeResponseModel>> Post(PostLikeInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (this.likesService.IsUserLikedIt(userId, input.PetId))
            {
                await this.likesService.DeleteLikeAsync(input.PetId, userId, input.Counter);
            }
            else
            {
                await this.likesService.SetLikeAsync(input.PetId, userId, input.Counter);
            }

            var totalLikes = this.likesService.GetTotalLikes(input.PetId);
            return new PostLikeResponseModel { TotalLikes = totalLikes };
        }
    }
}
