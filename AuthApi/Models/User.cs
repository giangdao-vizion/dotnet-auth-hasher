using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using AuthApi.Enum;

namespace AuthApi.Models
{
    // [BsonCollection("Users")]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Uid { get; set; } = string.Empty;
        // public DateTime CreatedAt => Id.CreationTime;
        public object? UpdatedAt { get; set; } = null;
        public bool IsDeleted { get; set; } = false;
        public object? DeletedAt { get; set; } = null;
        public string UserIdDeleted { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string HashPassword { get; set; } = string.Empty;
        public string NodeHash { get; set; } = string.Empty;
        public Role? UserRole { get; set; } = null;
        public bool Status { get; set; } = false;
        public string Title { get; set; } = string.Empty;
        public string TokenReset { get; set; } = string.Empty;
        public DateTime? TokenResetExpired { get; set; } = null;
    }
}
