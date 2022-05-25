using WhatWatch.Domain.Common;

namespace WhatWatch.Domain.Entities;

public class Movie : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}
