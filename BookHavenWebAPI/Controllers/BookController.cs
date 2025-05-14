using AutoMapper;
using BookHavenWebAPI.Core.Abstractions;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.Models.RequestModels;
using BookHavenWebAPI.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BookHavenWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IMapper mapper;
        private readonly IBookService bookService;

        public BookController(IMapper mapper, IBookService bookService)
        {
            this.mapper = mapper; 
            this.bookService = bookService;
        }


        /// <summary>
        /// Create Book
        /// </summary>
        /// <returns>OK</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBookAsync([FromBody] BookRequestModel request)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                if (await bookService.IsBookExistAsync(request.Name))
                    return StatusCode(409, new { Message = "Book is exist" });

                var res = await bookService.CreateBookAsync(mapper.Map<BookDTO>(request));

                return res > 0 ?
                    Ok(mapper.Map<BookResponseModel>(await bookService.GetBookByIdAsnyc(res)))
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
        public async Task<IActionResult> UpdateBookAsync([FromBody] BookRequestModel request)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var ent = await bookService.GetBookByIdAsnyc(request.Id);
                if (ent is null)
                    return NotFound();

                if (request.Name != ent.Name && await bookService.IsBookExistAsync(request.Name))
                    return StatusCode(409, new { Message = "Book is exist" });

                var res = await bookService.UpdateBookAsync(mapper.Map<BookDTO>(request));

                return res > 0 ?
                    Ok(mapper.Map<BookResponseModel>(await bookService.GetBookByIdAsnyc(request.Id)))
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

                var dto = await bookService.GetBookByIdAsnyc(Id);  
                if (dto is null) return NotFound();

                var res = await bookService.RemoveBookAsync(dto);

                return res > 0 ? Ok() : StatusCode(500, "Something went wrong");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get Book by Id
        /// </summary>
        /// <returns>OK</returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBookByIdAsync(int Id)
        {
            try
            {
                if (Id <= 0) return BadRequest();

                var res = await bookService.GetBookByIdAsnyc(Id);

                return res is not null ? Ok(mapper.Map<BookResponseModel>(res)) : StatusCode(500, "Something went wrong");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get Book for search
        /// </summary>
        /// <returns>OK</returns>
        [HttpGet("Search")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBookForSearchAsync([FromQuery] string Name)
        {
            try
            {
                if (string.IsNullOrEmpty(Name)) return BadRequest();

                var res = await bookService.GetAllBooksForSearchAsnyc(Name);

                return Ok(res.Select(mapper.Map<BookResponseModel>));
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get all Books 
        /// </summary>
        /// <returns>OK</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            try
            {
                var res = await bookService.GetAllBooksAsnyc();

                return Ok(res.Select(mapper.Map<BookResponseModel>));
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}. {Environment.NewLine}  {ex.StackTrace}");
                return StatusCode(500);
            }
        }
    }
}
