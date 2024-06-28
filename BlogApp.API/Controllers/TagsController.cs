using AutoMapper;
using BlogApp.BusinessLyaer.Abstract;
using BlogApp.EntityLayer.Dtos.TagDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;

        }

        [HttpPost]
        public IActionResult CreateTag(AddTagDto addTagDto)
        {
            _tagService.Add(addTagDto);
            return Ok(addTagDto);
        }

        [HttpPut]
        public IActionResult UpdateTag(UpdateTagDto updateTagDto)
        {
            _tagService.Update(updateTagDto);
            return Ok(updateTagDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTag(int id)
        {
            var deletedTag = _tagService.GetById(id);
            _tagService.Delete(deletedTag);
            return Ok(deletedTag);
        }
    }
}
