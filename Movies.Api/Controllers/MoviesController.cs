using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Contracts.Movie;
using Movies.Api.Repositories.Interfaces;

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : BaseController
    {
        private readonly IMoviesRepository _repository;
        private readonly Mappers _mapper;

        public MoviesController(IMoviesRepository repository, Mappers mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        ///<summary>Gets a list of existing movies.</summary>
        /// <param name="title">Optional. Part of the movie title for filtering existing movies.</param>
        /// <returns>List of movies found.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MovieResponse>>> Get(string? title)
        {
            // IMPORTANT!, this can be solved by using Composite filters.
            var results = new List<MovieResponse>();
            if (string.IsNullOrWhiteSpace(title))
            {
                return Ok(_mapper.MoviesToMovieResponseList(await _repository.GetAllAsync()));
            }
            return Ok(_mapper.MoviesToMovieResponseList(await _repository.FindByAsync(m => m.Title.ToUpperInvariant().Contains(title.Trim().ToUpperInvariant()))));
        }

        /// <summary>Gets a movie by its identifier.</summary>
        /// <param name="id">Movie identifier.</param>
        /// <returns>A movie.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieResponse>> Get(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.MovieToMovieResponse(entity));
        }


        /// <summary>Updates a movie.</summary>
        /// <param name="id">Movie identifier.</param>
        /// <param name="model">Movie information to be updated.</param>
        /// <returns>The updated movie.</returns>
        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(Guid id, UpdateMovieRequest model)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
            {
                return BadRequest();
            }

            //TODO: Implement mapper.
            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.Genre = (int)model.Genre;
            entity.ReleaseDate = (DateTime)model.ReleaseDate;

            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return Ok(entity);
        }

        /// <summary>Creates a movie.</summary>
        /// <param name="model">Movie information to be created.</param>
        /// <returns>The created movie.</returns>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Post(CreateMovieRequest model)
        {
            var newEntity = _mapper.CreateMovieRequestToMovie(model);
            newEntity.Id = Guid.NewGuid();

            _repository.Insert(newEntity);

            await _repository.SaveChangesAsync();

            return CreatedAtAction("Post", new { id = newEntity.Id }, newEntity);
        }

        /// <summary>Deletes a movie.</summary>
        /// <param name="id">Movie identifier.</param>
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
            {
                return BadRequest();
            }

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}
