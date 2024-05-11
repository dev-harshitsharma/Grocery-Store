namespace API.Helpers
{
    //This class is responsible for holding the pagination logic
    public class Pagination<T> where T : class
    {
        public Pagination(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            this.data = data;
        }

        public int PageIndex{get;set;}

        public int PageSize{get; set;}

        public int Count{get; set;}

        public IReadOnlyList<T> data {get; set;}
        
    }
}