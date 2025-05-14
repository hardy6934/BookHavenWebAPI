using AutoMapper;
using BookHavenWebAPI.Core.Abstractions;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.Database.Entities;
using BookHavenWebAPI.Models.RequestModels;
using BookHavenWebAPI.Models.ResponseModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Claims;

namespace BookHavenWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CollectionController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICollectionService collectionService;

        public CollectionController(IMapper mapper, ICollectionService collectionService)
        {
            this.mapper = mapper;
            this.collectionService = collectionService;
        }


        /// <summary>
        /// Create Collection
        /// </summary>
        /// <returns>OK</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCollectionAsync([FromBody] CollectionRequestModel request)
        {
            try
            {
                var accountIdClaim = User.FindFirst("AccountId").Value;
                 
                if (!ModelState.IsValid) return BadRequest();

                if (int.TryParse(accountIdClaim, out int intAccountIdClaim))
                {
                    if (await collectionService.IsCollectionExistAsync(request.Name, intAccountIdClaim))
                    return StatusCode(409, new { Message = "Collection is exist" });
                     

                    var dto = mapper.Map<CollectionDTO>(request);
                    dto.AccountId = intAccountIdClaim;
                    var res = await collectionService.CreateCollectionAsync(dto);

                    return res > 0 ?
                        Ok(mapper.Map<CollectionResponseModel>(await collectionService.GetCollectionByIdAsnyc(res, intAccountIdClaim)))
                        : StatusCode(500, "Something went wrong");
                }
                else return BadRequest("Not a valid token");
                
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }


        /// <summary>
        /// Update Collection
        /// </summary>
        /// <returns>OK</returns>
        [HttpPut]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCollectionAsync([FromBody] CollectionRequestModel request)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var accountIdClaim = User.FindFirst("AccountId").Value; 
                if (!int.TryParse(accountIdClaim, out int intAccountIdClaim))
                    return BadRequest("Token was invalid");

                var ent = await collectionService.GetCollectionByIdAsnyc(request.Id, intAccountIdClaim);
                if (ent is null)
                    return NotFound();

                if (request.Name != ent.Name && await collectionService.IsCollectionExistAsync(request.Name, intAccountIdClaim))
                    return StatusCode(409, new { Message = "Collection is exist" });


                var dto = mapper.Map<CollectionDTO>(request);
                dto.AccountId = ent.AccountId;
                var res = await collectionService.UpdateCollectionAsync(dto);

                return res > 0 ?
                    Ok(mapper.Map<CollectionResponseModel>(await collectionService.GetCollectionByIdAsnyc(request.Id, intAccountIdClaim)))
                    : StatusCode(500, "Something went wrong");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Remove Collection
        /// </summary>
        /// <returns>OK</returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveCollectionAsync(int Id)
        {
            try
            { 
                if (Id <= 0) return BadRequest();

                var accountIdClaim = User.FindFirst("AccountId").Value;
                if (!int.TryParse(accountIdClaim, out int intAccountIdClaim))
                    return BadRequest("Token was invalid");

                var dto = await collectionService.GetCollectionByIdAsnyc(Id, intAccountIdClaim);
                if (dto is null) return NotFound();

                var res = await collectionService.RemoveCollectionAsync(dto);

                return res > 0 ? Ok() : StatusCode(500, "Something went wrong");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get Collection by Id
        /// </summary>
        /// <returns>OK</returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCollectionByIdAsync(int Id)
        {
            try
            {
                if (Id <= 0) return BadRequest();

                var accountIdClaim = User.FindFirst("AccountId").Value;
                if (!int.TryParse(accountIdClaim, out int intAccountIdClaim))
                    return BadRequest("Token was invalid");

                var res = await collectionService.GetCollectionByIdAsnyc(Id, intAccountIdClaim);

                return res is not null ? Ok(mapper.Map<CollectionResponseModel>(res)) : StatusCode(500, "Something went wrong");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get Collection for search
        /// </summary>
        /// <returns>OK</returns>
        [HttpGet("Search")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCollectionForSearchAsync([FromQuery] string Name)
        {
            try
            {
                if (string.IsNullOrEmpty(Name)) return BadRequest();

                var accountIdClaim = User.FindFirst("AccountId").Value;
                if (!int.TryParse(accountIdClaim, out int intAccountIdClaim))
                    return BadRequest("Token was invalid");

                var res = await collectionService.GetAllCollectionsForSearchAsnyc(Name, intAccountIdClaim);

                return Ok(res.Select(mapper.Map<CollectionResponseModel>));
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get all Collection 
        /// </summary>
        /// <returns>OK</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCollectionsAsync()
        {
            try
            {
                var accountIdClaim = User.FindFirst("AccountId").Value;
                if (!int.TryParse(accountIdClaim, out int intAccountIdClaim))
                    return BadRequest("Token was invalid");

                var res = await collectionService.GetAllCollectionsAsnyc(intAccountIdClaim);

                return Ok(res.Select(mapper.Map<CollectionResponseModel>));
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

    }
}
