﻿using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EquipmentActivityController : ControllerBase
{
    private IEquipmentActivityService _equipmentActivityService;

    public EquipmentActivityController(IEquipmentActivityService equipmentActivityService)
    {
        _equipmentActivityService = equipmentActivityService;
    }
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _equipmentActivityService.GetAllEquipmentActivityAsync();
        return Ok(result);
    }
    [HttpGet("get-equipId")]
    public async Task<IActionResult> GetByEquipmentIdAsync(int equipId)
    {
        var result = await _equipmentActivityService.GetEquipmentByEquipmentId(equipId);
        return Ok(result);
    }
    [HttpGet("get-managerId")]
    public async Task<IActionResult> GetByManagerIdAsync(int managerId) 
    {
        var result = await _equipmentActivityService.GetEquipmentByManagerId(managerId);
        return Ok(result);
    }
    [HttpGet("get-roomNo")]
    public async Task<IActionResult> GetByRoomNoAsync(int roomNo)
    {
        var result = await _equipmentActivityService.GetEquipmentByRoomNo(roomNo);
        return Ok(result);
    }
    [HttpGet("get-roomId")]
    public async Task<IActionResult> GetByRoomId(int roomId)
    {
        var result = await _equipmentActivityService.GetEquipmentByRoomId(roomId);
        return Ok(result);
    }
    [HttpGet("get-time-range")]
    public async Task<IActionResult> GetByTimeRange(DateTime from, DateTime to)
    {
        var result = await _equipmentActivityService.GetEquipmentByTimeRange(from, to);
        return Ok(result);
    }
}
