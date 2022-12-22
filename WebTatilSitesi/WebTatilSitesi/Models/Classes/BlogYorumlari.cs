namespace WebTatilSitesi.Models.Classes

{
    public class BlogYorumlari
    {
        //IEnumarable ile bir view içinde birden fazla tabloda değer çekilebilir
        public IEnumerable<BlogSinifi> blogSinifis { get; set; }
        public IEnumerable<YorumSinifi> yorumSinifis { get; set; }
        public IEnumerable<BlogSinifi> blogSinifis2 { get; set; }
    }
}
