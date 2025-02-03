namespace Product.API.DTO
{
    public class ResoponseDto
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
        public object Result { get; set; }
    }
}
