﻿using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete;

public class CargoOperationManager : ICargoOperationService
{
    private readonly ICargoOperationDal _cargoOperationDal;

    public CargoOperationManager(ICargoOperationDal cargoOperationDal)
    {
        _cargoOperationDal = cargoOperationDal;
    }

    public void TAdd(CargoOperation entity)
    {
        _cargoOperationDal.Add(entity);
    }

    public void TUpdate(CargoOperation entity)
    {
        _cargoOperationDal.Update(entity);
    }

    public void TDelete(int id)
    {
        _cargoOperationDal.Delete(id);
    }

    public CargoOperation TGetById(int id)
    {
        return _cargoOperationDal.GetById(id);
    }

    public List<CargoOperation> TGetAll()
    {
        return _cargoOperationDal.GetAll();
    }
}