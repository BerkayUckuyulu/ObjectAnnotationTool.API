using Application.IRepositories.Picture;
using Application.ViewModels.Picture;
using Application.ViewModels.Shape;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {

        private readonly IPictureWriteRepository _pictureWriteRepository;
        private readonly IPictureReadRepository _pictureReadRepository;



        public PicturesController(IPictureWriteRepository pictureWriteRepository, IPictureReadRepository pictureReadRepository)
        {
            _pictureWriteRepository = pictureWriteRepository;
            _pictureReadRepository = pictureReadRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {


            return Ok(_pictureReadRepository.GetAll(false));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {

            return Ok(await _pictureReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(PictureCreateVM model)
        {
            await _pictureWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Url = model.Url,


            });
            await _pictureWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Picture model)
        {
            Picture picture = await _pictureReadRepository.GetByIdGuidAsync(model.Id);

            picture.Name = model.Name;

            await _pictureWriteRepository.SaveAsync();

            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> AddShape(ShapeCreateVM model)
        {
            Picture picture = await _pictureReadRepository.GetByIdAsync(model.PictureId);

            picture.Shapes.Add(new()
            {
            
                h = model.h,
                Type = model.Type,
                w = model.w,
                x = model.x,
                y = model.y
            });


            

            await _pictureWriteRepository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _pictureWriteRepository.RemoveAsync(id);
            await _pictureWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
