using System.Security.AccessControl;
using System;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Api.Models;
public class Delivery //entrega
{
    public int Id { get; internal set; }
    public DateTime DeliveryForecast { get; set; }
    public int AddressId { get; set; }
    public int SaleId { get; set; }
    public virtual Address Address { get; set; }
    public virtual Sale Sale { get; set; }

  

    public Delivery()
    {
    }

    public Delivery(int addressId, int saleId, DateTime deliveryForecast)
    {
        AddressId = addressId;
        SaleId = saleId;
        DeliveryForecast = deliveryForecast;

    }

    public static implicit operator DbSet<object>(Delivery v)
    {
        throw new NotImplementedException();
    }
}
