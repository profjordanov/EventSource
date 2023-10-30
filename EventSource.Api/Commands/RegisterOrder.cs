namespace EventSource.Api.Commands;

public class RegisterOrder
{
    public int OrderNumber { get; set; }
    public string CustomerName { get; set; }
    public decimal ItemValue { get; set; }
}