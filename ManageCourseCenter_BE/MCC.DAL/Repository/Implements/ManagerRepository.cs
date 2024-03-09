﻿using MCC.DAL.DB.Models;
using MCC.DAL.DB.Context;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MCC.DAL.Constants;

namespace MCC.DAL.Repository.Implements;

public class ManagerRepository : RepositoryGeneric<Manager>, IManagerRepository
{
    public ManagerRepository(ManageCourseCenterContext context) : base(context)
    {
    }

    public async Task<bool> CheckExistingEmailAsync(string email)
    {
        var existing = await _dbSet.SingleOrDefaultAsync(m => m.Email == email);
        if(existing == null)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public async Task<bool> CheckExistingPhoneAsync(string phone)
    {
        var existing = await _dbSet.SingleOrDefaultAsync(m => m.Phone == phone);
        if (existing == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public async Task<Manager> GetManagerByUsernameAndPassword(string username, string password)
    {
        return await _dbSet.SingleOrDefaultAsync(c => c.Email == username && c.Password == password && c.Role == CoreConstants.ROLE_MANAGER);
    }
    public async Task<Manager> GetStaffByUsernameAndPassword(string username, string password)
    {
        return await _dbSet.SingleOrDefaultAsync(c => c.Email == username && c.Password == password && c.Role == CoreConstants.ROLE_STAFF);
    }
    public async Task<Manager> GetAdminByUsernameAndPassword(string username, string password)
    {
        return await _dbSet.SingleOrDefaultAsync(c => c.Email == username && c.Password == password && c.Role == CoreConstants.ROLE_ADMIN);
    }
}
