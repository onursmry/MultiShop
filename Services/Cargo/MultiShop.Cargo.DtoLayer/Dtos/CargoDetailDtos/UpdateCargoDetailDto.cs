namespace MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;

public class UpdateCargoDetailDto
{
    public int CargoDetailId { get; set; }
    public string CargoSender { get; set; }
    public string CargoReceiver { get; set; }
    public int Barcode { get; set; }
    public int CargoCompanyId { get; set; }
}