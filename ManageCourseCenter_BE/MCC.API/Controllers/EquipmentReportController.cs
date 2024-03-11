﻿using MCC.DAL.Dto.EquipmentDto;
using MCC.DAL.Service.Implements;
using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace MCC.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class EquipmentReportController : ControllerBase
{
    private IEquipmentReportService _equiprpService;

    public EquipmentReportController(IEquipmentReportService equiprpService)
    {
        _equiprpService = equiprpService;
    }

    [HttpGet("get-all-equip-report")]
    public async Task<IActionResult> GetAllEquipmentReportAsync()
    {
        var result = await _equiprpService.GetAllEquipmentReportAsync();
        return Ok(result);
    }
    [HttpGet("get-equip-report-by-id")]
    public async Task<IActionResult> GetEquipmentReportByIdAsync(int id)
    {
        var result = await _equiprpService.GetEquipmentReportByIdAsync(id);
        return Ok(result);
    }
    [HttpGet("get-equip-report-by-equip-id")]
    public async Task<IActionResult> GetEquipmentReportByEquipmentIdAsync(int equipmentid)
    {
        var result = await _equiprpService.GetEquipmentReportByEquipmentIdAsync(equipmentid);
        return Ok(result);
    }

    [HttpGet("get-equip-report-by-room-id")]
    public async Task<IActionResult> GetEquipmentReportByRoomIdAsync(int roomid)
    {
        var result = await _equiprpService.GetEquipmentReportByRoomIdAsync(roomid);
        return Ok(result);
    }

    [HttpGet("get-equip-report-by-room-no")]
    public async Task<IActionResult> GetEquipmentReportByRoomNoAsync(int roomno)
    {
        var result = await _equiprpService.GetEquipmentReportByRoomNoAsync(roomno);
        return Ok(result);
    }

    [HttpGet("get-equipm-report-by-equip-name")]
    public async Task<IActionResult> GetEquipmentReportByEquipmentNameAsync(string equipmentname)
    {
        var result = await _equiprpService.GetEquipmentReportByEquipmentNameAsync(equipmentname);
        return Ok(result);
    }

    [HttpPost("create-equipment-report")]
    public async Task<IActionResult> CreateEquipmentReportAsync(EquipmentReportCreateDto equipReportCreateDto)
    {
        var result = await _equiprpService.CreateEquipmentReportAsync(equipReportCreateDto);
        return Ok(result);
    }

    [HttpPut("update-equipment-report")]
    public async Task<IActionResult> UpdateEquipmentReportAsync(int equipmentReportId, EquipmentReportUpdateDto equipmentReportUpdateDto)
    {
        var result = await _equiprpService.UpdateEquipmentReportAsync(equipmentReportId, equipmentReportUpdateDto);

        return Ok(result);
    }
}
