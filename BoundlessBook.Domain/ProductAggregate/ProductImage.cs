﻿using BoundlessBook.Common;
using BoundlessBook.Common.Exceptions;

namespace BoundlessBook.Domain.ProductAggregate;

public class ProductImage:BaseEntity
{
    public ProductImage( string imageName, int sequence)
    {
        NullOrEmptyDomainException.CheckString( imageName,nameof(imageName));
        ImageName = imageName;
        Sequence = sequence;
    }
    public Guid ProductId { get; set; }
    public string ImageName { get; set; }
    public int Sequence { get; set; } 
}