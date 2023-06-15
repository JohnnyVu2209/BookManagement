

namespace BookManagement.Shared.Models.Dtos
{
    public class PaginationParameters
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SortBy { get; set; } = "UpdatedAt";
        public bool SortAscending { get; set; } = true;
    }
}
