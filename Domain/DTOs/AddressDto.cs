namespace Domain.DTOs;

public class AddressDTO
{
    public int Id { get; set; }
    public int ZoneId { get; set; }
    public string? ZoneName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public bool IsPrimary { get; set; }
    public bool? ExpressDeliveryStatus { get; set; }
    public bool? NormalDeliveryStatus { get; set; }
}
