﻿using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Dtos.ProductImageDtos;

public class CreateProductImageDto
{
    public List<string> Images { get; set; } = new List<string>();
    public string ProductId { get; set; }
}