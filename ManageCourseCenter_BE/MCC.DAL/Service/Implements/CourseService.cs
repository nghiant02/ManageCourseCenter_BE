﻿using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.CourceDto;
using MCC.DAL.Dto.EquipmentDto;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace MCC.DAL.Service.Implements;

public class CourseService : ICourseService
{
    private ICourseRepository _courseRepo;
    private IMapper _mapper;

    public CourseService(ICourseRepository courseRepo, IMapper mapper)
    {
        _courseRepo = courseRepo;
        _mapper = mapper;
    }

    public async Task<AppActionResult> GetAllCoureAsync()
    {
        var actionResult = new AppActionResult();
        var data = await _courseRepo.GetAllAsync();
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetCourseByIdAsync(int id)
    {
        var actionResult = new AppActionResult();
        var data = await _courseRepo.GetByIdAsync(id);
        if(data != null)
        {
            return actionResult.BuildResult(data);
        } else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetCourseByNameAsync(string name)
    {
        var actionResult = new AppActionResult();
        var data = await _courseRepo.GetCourseByNameAsync(name);
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> CreateCourseAsync(CourseCreateDto courseCreateDto)
    {
        var actionResult = new AppActionResult();

        var checkName = await _courseRepo.CheckExistingNameAsync(courseCreateDto.Name);
        if (!checkName)
        {
            return actionResult.BuildError("Duplicate name");
        }
        
        try
        {
            var course = _mapper.Map<Course>(courseCreateDto);
            await _courseRepo.AddAsync(course);
            await _courseRepo.SaveChangesAsync();
            return actionResult.SetInfo(true, "Add success");
        }
        catch
        {
            return actionResult.BuildError("Add fail");
        }
    }

    public async Task<AppActionResult> UpdateCourseAsync(int courseId, CourseUpdateDto courseUpdateDto)
    {
        var actionResult = new AppActionResult();

        var course = await _courseRepo.GetByIdAsync(courseId);
        if (course == null)
        {
            return actionResult.BuildError("Course not found.");
        }

        if (!string.IsNullOrEmpty(courseUpdateDto.Name) &&
            course.Name != courseUpdateDto.Name &&
            !(await _courseRepo.IsNameUniqueAsync(courseUpdateDto.Name, courseId)))
        {
            return actionResult.BuildError("Course name already in use.");
        }

        _mapper.Map(courseUpdateDto, course);

        var success = await _courseRepo.UpdateCourseAsync(course);
        if (!success)
        {
            return actionResult.BuildError("Failed to update course.");
        }
        return actionResult.BuildResult("Course updated successfully.");
    }
    public async Task<AppActionResult> SearchCourseByNameAsync(string name)
    {
        var actionResult = new AppActionResult();
        var data = await _courseRepo.GetCourseByNameAsync(name);
        return actionResult.BuildResult(data);
    }
    public async Task<AppActionResult> CountNumberCourse()
    {
        var actionResult = new AppActionResult();
        var data = await _courseRepo.GetAllAsync();
        int result = data.Count();
        return actionResult.BuildResult("Number Of Course = " + result);
    }
}
