namespace MultiShop.DtoLayer.ReviewDtos;

public class ResultReviewDto
{
    public int UserReviewId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? ImageUrl { get; set; }
    public string Email { get; set; }
    public string ReviewDetail { get; set; }
    public int UserRating { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool Status { get; set; }
    public string ProductId { get; set; }
}