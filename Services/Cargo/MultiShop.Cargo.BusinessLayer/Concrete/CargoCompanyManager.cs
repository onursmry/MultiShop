using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete;

public class CargoCompanyManager : ICargoCompanyService
{
    private readonly ICargoCompanyDal _cargoCompanyDal;

    public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
    {
        _cargoCompanyDal = cargoCompanyDal;
    }

    public void TAdd(CargoCompany entity)
    {
        _cargoCompanyDal.Add(entity);
    }

    public void TUpdate(CargoCompany entity)
    {
        _cargoCompanyDal.Update(entity);
    }

    public void TDelete(int id)
    {
        _cargoCompanyDal.Delete(id);
    }

    public CargoCompany TGetById(int id)
    {
        return _cargoCompanyDal.GetById(id);
    }

    public List<CargoCompany> TGetAll()
    {
        return _cargoCompanyDal.GetAll();
    }
}
