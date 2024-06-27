using AutoMapper;
using BlogApp.BusinessLyaer.Abstract;
using BlogApp.EntityLayer.Dtos.CommentDto;
using BloggApp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentsController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult CreateComment(AddCommentDto addCommentDto) 
        { 
            _commentService.Add(addCommentDto);
            return Ok(addCommentDto);
        }

        [HttpPut]
        public IActionResult UpdateComment(UpdateCommentDto updateCommentDto)
        {
            _commentService.Update(updateCommentDto);
            return Ok(updateCommentDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var deletedComment = _commentService.GetById(id);
            _commentService.Delete(deletedComment); 
            return Ok(deletedComment);
        }
    }
}
