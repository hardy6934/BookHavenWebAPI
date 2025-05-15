using AutoMapper;
using BookHavenWebAPI.Core.Abstractions;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.Models.RequestModels;
using BookHavenWebAPI.Models.ResponseModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BookHavenWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CollectionBookController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICollectionBookService collectionBookService;
        private readonly ICollectionService collectionService;

        public CollectionBookController(IMapper mapper, ICollectionBookService collectionBookService, ICollectionService collectionService)
        {
            this.mapper = mapper;
            this.collectionBookService = collectionBookService;
            this.collectionService = collectionService;
        }


        /// <summary>
        /// Create CollectionBook
        /// </summary>
        /// <returns>OK</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCollectionBookAsync([FromBody] CollectionBookRequestModel request)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var accountIdClaim = User.FindFirst("AccountId").Value;
                if (!int.TryParse(accountIdClaim, out int intAccountIdClaim))
                    return BadRequest("Token was invalid");

                if (await collectionBookService.IsCollectionBookExistAsync(request.BookId, request.CollectionId))
                    return StatusCode(409, new { Message = "CollectionBook is exist" });

                var res = await collectionBookService.CreateCollectionBookAsync(mapper.Map<CollectionBookDTO>(request));

                return res > 0 ?
                    Ok(mapper.Map<CollectionBookResponseModel>(await collectionBookService.GetCollectionBookByIdAsnyc(res, intAccountIdClaim)))
                    : StatusCode(500, "Something went wrong");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }


        /// <summary>
        /// Update Book
        /// </summary>
        /// <returns>OK</returns>
        [HttpPut]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBookAsync([FromBody] CollectionBookRequestModel request)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var accountIdClaim = User.FindFirst("AccountId").Value;
                if (!int.TryParse(accountIdClaim, out int intAccountIdClaim))
                    return BadRequest("Token was invalid");

                var ent = await collectionBookService.GetCollectionBookByIdAsnyc(request.Id, intAccountIdClaim);
                if (ent is null)
                    return NotFound();

                if (request.BookId != ent.BookId && request.CollectionId != ent.CollectionId)
                    return BadRequest("BookId and CollectionId is unchangeable fields!");
                 
                var res = await collectionBookService.UpdateCollectionBookAsync(mapper.Map<CollectionBookDTO>(request));

                return res > 0 ?
                    Ok(mapper.Map<CollectionBookResponseModel>(await collectionBookService.GetCollectionBookByIdAsnyc(request.Id, intAccountIdClaim)))
                    : StatusCode(500, "Something went wrong");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Remove Book
        /// </summary>
        /// <returns>OK</returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveBookAsync(int Id)
        {
            try
            {
                if (Id <= 0) return BadRequest();

                var accountIdClaim = User.FindFirst("AccountId").Value;
                if (!int.TryParse(accountIdClaim, out int intAccountIdClaim))
                    return BadRequest("Token was invalid");

                var dto = await collectionBookService.GetCollectionBookByIdAsnyc(Id, intAccountIdClaim);
                if (dto is null) return NotFound();

                var res = await collectionBookService.RemoveCollectionBookAsync(dto);

                return res > 0 ? Ok() : StatusCode(500, "Something went wrong");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }


        /// <summary>
        /// Get CollectionBook by Id
        /// </summary>
        /// <returns>OK</returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCollectionBookByIdAsync(int Id)
        {
            try
            {
                if (Id <= 0) return BadRequest();

                var accountIdClaim = User.FindFirst("AccountId").Value;
                if (!int.TryParse(accountIdClaim, out int intAccountIdClaim))
                    return BadRequest("Token was invalid");

                var res = await collectionBookService.GetCollectionBookByIdAsnyc(Id, intAccountIdClaim);

                return res is not null ? Ok(mapper.Map<CollectionBookResponseModel>(res)) : NotFound();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get CollectionBook for search in collection
        /// </summary>
        /// <returns>OK</returns>
        [HttpGet("Search")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCollectionBookForSearchAsync([FromQuery] string name, int collectionId)
        {
            try
            { 

                var accountIdClaim = User.FindFirst("AccountId").Value;
                if (!int.TryParse(accountIdClaim, out int intAccountIdClaim))
                    return BadRequest("Token was invalid");

                var res = await collectionBookService.GetAllCollectionBooksInColectionForSearchAsnyc(name, collectionId, intAccountIdClaim);

                return Ok(res.Select(mapper.Map<CollectionBookResponseModel>));
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get all CollectionBook for collection
        /// </summary>
        /// <returns>OK</returns>
        [HttpGet("ByCollectionId")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCollectionBooksAsync([FromQuery] int collectionId)
        {
            try
            {
                var accountIdClaim = User.FindFirst("AccountId").Value;
                if (!int.TryParse(accountIdClaim, out int intAccountIdClaim))
                    return BadRequest("Token was invalid");

                var res = await collectionBookService.GetAllCollectionBooksInColectionAsnyc(collectionId, intAccountIdClaim);

                return Ok(res.Select(mapper.Map<CollectionBookResponseModel>));
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }


    }
}
