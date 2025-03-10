﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class ProductImage
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ProductImageId { get; set; }
    public List<string> Images { get; set; } = new List<string>();
    public string ProductId { get; set; }
    [BsonIgnore]
    public Product Product { get; set; }
}