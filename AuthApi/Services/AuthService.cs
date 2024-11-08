using AuthApi.Models;
using MongoDB.Driver;

namespace AuthApi.Services;

public class AuthService
{
    private IMongoCollection<User> _usersCollection;

    private readonly string _mongoDbConString = "";
    private readonly string _prodDB = "";
    private readonly string _stagDB = "";

    public AuthService() {}

    public void Connect(bool isProd)
    {
        var mongoClient = new MongoClient(_mongoDbConString);

        var mongoDatabase = mongoClient.GetDatabase(isProd ? _prodDB : _stagDB);

        _usersCollection = mongoDatabase.GetCollection<User>("Users");
    }

    public async Task<List<User>> GetAsync() =>
        await _usersCollection.Find(x => !x.IsDeleted).ToListAsync();

    public async Task<User?> GetByIdAsync(string id) =>
        await _usersCollection.Find(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();

    public async Task<User?> GetByEmailAsync(string email) =>
        await _usersCollection.Find(x => x.Email == email && !x.IsDeleted).FirstOrDefaultAsync();
}