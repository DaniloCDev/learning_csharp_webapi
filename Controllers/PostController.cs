using Microsoft.AspNetCore.Mvc;
using PostApi.Models;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly PostRepository _postyRepository;

    public PostController(PostRepository postRepository)
    {
        _postyRepository = postRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Post>>> Get()
    {
        var posts = await _postyRepository.GetAllPostsAsync();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> Get(string id)
    {
        var post = await _postyRepository.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        return Ok(post);
    }

    [HttpPost]
    public async Task<ActionResult<Post>> Create([FromBody] Post post)
    {
        await _postyRepository.CreatePostAsync(post);
        return CreatedAtAction(nameof(Get), new { id = post.Id }, post);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] Post post)
    {
        var existingPost = await _postyRepository.GetPostByIdAsync(id);
        if (existingPost == null)
        {
            return NotFound();
        }

        await _postyRepository.UpdatePostAsync(id, post);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var post = await _postyRepository.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        await _postyRepository.DeletePostAsync(id);
        return NoContent();
    }

}