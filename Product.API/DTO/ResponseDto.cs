namespace Product.API.DTO
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public List<string> Errors { get; set; }
        public object Result { get; set; }
    }
}
