using System;

namespace DEVinCar.Api.Models;
public class Delivery
{
    public int Id { get; internal set; }
    public int AddressId { get; set; }
    public int SaleId { get; set; }
    public DateTime DeliveryForecast { get; set; }

    public Delivery()
    {
    }

    public Delivery(int addressId, int saleId, DateTime deliveryForecast)
    {
        AddressId = addressId;
        SaleId = saleId;
        DeliveryForecast = deliveryForecast;

    }
}
