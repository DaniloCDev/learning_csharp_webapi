using MongoDB.Driver;
using Microsoft.Extensions.Options;
using PostApi.Models;
using MongoSettings.Models;


public class PostRepository
{
    private readonly IMongoCollection<Post> _postsCollection;

    public PostRepository(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _postsCollection = database.GetCollection<Post>("Posts");

    }

    public async Task<List<Post>> GetAllPostsAsync()
    {
        return await _postsCollection.Find(post => true).ToListAsync();
    }

    public async Task<Post> GetPostByIdAsync(string id)
    {
        return await _postsCollection.Find(post => post.Id == id).FirstOrDefaultAsync();

    }

    public async Task CreatePostAsync(Post post)
    {

        if (string.IsNullOrEmpty(post.Id))
        {
            post.Id = Guid.NewGuid().ToString();
        }

        await _postsCollection.InsertOneAsync(post);
    }

    public async Task UpdatePostAsync(string id, Post post)
    {
        var update = Builders<Post>.Update
              .Set(p => p.Title, post.Title)
              .Set(p => p.Content, post.Content);

        await _postsCollection.UpdateOneAsync(p => p.Id == id, update);

    }

    public async Task DeletePostAsync(string id)
    {
        await _postsCollection.DeleteOneAsync(post => post.Id == id);
    }

}