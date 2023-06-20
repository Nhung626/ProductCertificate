namespace HoangHongNhung152465.Dtos
{
    public class PageResult152465De2<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public List<T> Items { get; set; }
    }
}
