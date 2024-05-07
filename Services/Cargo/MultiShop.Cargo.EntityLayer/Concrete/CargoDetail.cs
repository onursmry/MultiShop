namespace MultiShop.Cargo.EntityLayer.Concrete;

public class CargoDetail
{
    public int CargoDetailId { get; set; }
    public string CargoSender { get; set; }
    public string CargoReceiver { get; set; }
    public int Barcode { get; set; }
    public int CargoCompanyId { get; set; }
    public CargoCompany CargoCompany { get; set; }
}