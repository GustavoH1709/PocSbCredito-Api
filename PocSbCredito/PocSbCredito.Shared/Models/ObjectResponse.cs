namespace PocSbCredito.Shared.Models
{
    public class ObjectResponse<TValue>
    {
        public TValue Value { get; set; } = default!;

        public ObjectResponse() { }
        public ObjectResponse(TValue value) { Value = value; }
    }
}
