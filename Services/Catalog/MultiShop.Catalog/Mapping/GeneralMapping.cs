﻿using AutoMapper;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.DiscountOfferDtos;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

        CreateMap<Product, ResultProductDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, GetByIdProductDto>().ReverseMap();

        CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

        CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
        CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
        CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
        CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();

        CreateMap<Product, ResultProductsWithCategoryDto>().ReverseMap();

        CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
        CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
        CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
        CreateMap<FeatureSlider, GetFeatureSliderByIdDto>().ReverseMap();

        CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
        CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
        CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();
        CreateMap<SpecialOffer, GetSpecialOfferByIdDto>().ReverseMap();

        CreateMap<Feature, ResultFeatureDto>().ReverseMap();
        CreateMap<Feature, CreateFeatureDto>().ReverseMap();
        CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
        CreateMap<Feature, GetFeatureByIdDto>().ReverseMap();

        CreateMap<DiscountOffer, ResultDiscountOfferDto>().ReverseMap();
        CreateMap<DiscountOffer, CreateDiscountOfferDto>().ReverseMap();
        CreateMap<DiscountOffer, UpdateDiscountOfferDto>().ReverseMap();
        CreateMap<DiscountOffer, GetByIdDiscountOfferDto>().ReverseMap();

        CreateMap<Brand, ResultBrandDto>().ReverseMap();
        CreateMap<Brand, CreateBrandDto>().ReverseMap();
        CreateMap<Brand, UpdateBrandDto>().ReverseMap();
        CreateMap<Brand, GetByIdBrandDto>().ReverseMap();

        CreateMap<About, ResultAboutDto>().ReverseMap();
        CreateMap<About, CreateAboutDto>().ReverseMap();
        CreateMap<About, UpdateAboutDto>().ReverseMap();
        CreateMap<About, GetByIdAboutDto>().ReverseMap();
    }
}