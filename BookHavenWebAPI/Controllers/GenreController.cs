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
    public class GenreController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IGenreService genreService;

        public GenreController(IMapper mapper, IGenreService genreService)
        {
            this.mapper = mapper;
            this.genreService = genreService;
        }


        /// <summary>
        /// Create genre
        /// </summary>
        /// <returns>OK</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateGenreAsync([FromBody] GenreRequestModel request)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                if (await genreService.IsGenreExistAsync(request.Name))
                    return StatusCode(409, new { Message = "Genre is exist" });

                var res = await genreService.CreateGenreAsync(mapper.Map<GenreDTO>(request));

                return res > 0 ? 
                    Ok(mapper.Map<GenreResponseModel>(await genreService.GetGenreByIdAsnyc(res))) 
                    : StatusCode(500, "Something went wrong"); 
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Update genre
        /// </summary>
        /// <returns>OK</returns>
        [HttpPut]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateGenreAsync([FromBody] GenreRequestModel request)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                if (await genreService.IsGenreExistAsync(request.Name))
                    return StatusCode(409, new { Message = "Genre is exist" });

                var res = await genreService.UpdateGenreAsync(mapper.Map<GenreDTO>(request));

                return res > 0 ? 
                    Ok(mapper.Map<GenreResponseModel>(await genreService.GetGenreByIdAsnyc(request.Id))) 
                    : StatusCode(500, "Something went wrong");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Remove genre
        /// </summary>
        /// <returns>OK</returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveGenreAsync(int Id)
        {
            try
            {
                if (Id <= 0) return BadRequest();

                var dto = await genreService.GetGenreByIdAsnyc(Id);

                if (dto is null) return NotFound();

                var res = await genreService.RemoveGenreAsync(dto);

                return res > 0 ? Ok() : StatusCode(500, "Something went wrong"); 
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get genre by Id
        /// </summary>
        /// <returns>OK</returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGenreByIdAsync(int Id)
        {
            try
            {
                if (Id <= 0) return BadRequest(); 

                var res = await genreService.GetGenreByIdAsnyc(Id);

                return res is not null ? Ok(mapper.Map<GenreResponseModel>(res)) : StatusCode(500, "Something went wrong"); 
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get genre for search
        /// </summary>
        /// <returns>OK</returns>
        [HttpGet("Search")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGenreForSearchAsync(string Name)
        {
            try
            {
                if (string.IsNullOrEmpty(Name)) return BadRequest(); 

                var res = await genreService.GetAllGenresForSearchAsnyc(Name);

                return Ok(res.Select(mapper.Map<GenreResponseModel>));
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get all genres 
        /// </summary>
        /// <returns>OK</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllGenresAsync()
        {
            try
            { 
                var res = await genreService.GetAllGenresAsnyc();

                return Ok(res.Select(mapper.Map<GenreResponseModel>)); 
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

    }
}
