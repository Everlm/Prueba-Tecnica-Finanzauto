namespace Finanzauto.Application.Commons.Bases.Response
{
    public class PagedResponse<T>
    {
        public IEnumerable<T> Data { get; set; } = new List<T>(); 
        public int Total { get; set; } 
        public int Page { get; set; } 
        public int Limit { get; set; } 

        public PagedResponse() { }

        public PagedResponse(IEnumerable<T> data, int total, int page, int limit)
        {
            Data = data;
            Total = total;
            Page = page;
            Limit = limit;
        }
    }
}
