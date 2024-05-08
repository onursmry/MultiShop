namespace MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;

public class CreateCargoDetailDto
{
    public string CargoSender { get; set; }
    public string CargoReceiver { get; set; }
    public int Barcode { get; set; }
    public int CargoCompanyId { get; set; }
}