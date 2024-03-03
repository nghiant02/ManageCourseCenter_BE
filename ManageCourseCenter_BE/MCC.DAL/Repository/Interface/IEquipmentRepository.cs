﻿using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface IEquipmentRepository : IRepositoryGeneric<Equipment>
{
    Task<bool> CheckExistingNameAsync(string name);
}
