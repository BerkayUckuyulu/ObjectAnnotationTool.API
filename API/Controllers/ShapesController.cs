using Application.IRepositories.Picture;
using Application.IRepositories.Shape;
using Application.ViewModels.Shape;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShapesController : ControllerBase
    {
        private readonly IShapeWriteRepository _shapeWriteRepository;
        private readonly IShapeReadRepository _shapeReadRepository;
        private readonly IPictureReadRepository _pictureReadRepository;

        public ShapesController(IShapeWriteRepository shapeWriteRepository, IShapeReadRepository shapeReadRepository, IPictureReadRepository pictureReadRepository)
        {
            _shapeWriteRepository = shapeWriteRepository;
            _shapeReadRepository = shapeReadRepository;
            _pictureReadRepository = pictureReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {


            return Ok(_shapeReadRepository.GetAll(false));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {

            return Ok(await _shapeReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ShapeCreateVM model)
        {
            var shape = new Shape()
            {
                PictureId =Guid.Parse(model.PictureId),
                h = model.h,
                Type = model.Type,
                w = model.w,
                x = model.x,
                y = model.y
            };
            await _shapeWriteRepository.AddAsync(shape);

            await _shapeWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Shape model)
        {
            Shape shape = await _shapeReadRepository.GetByIdGuidAsync(model.Id);

            shape.h = model.h;
            shape.w = model.w;
            shape.x = model.x;
            shape.y = model.y;
            shape.PictureId = model.PictureId;
            shape.TicketId = model.TicketId;

            await _shapeWriteRepository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _shapeWriteRepository.RemoveAsync(id);
            await _shapeWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
