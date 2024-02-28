﻿using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Repository.Implements;

public class FeedbackRepository : RepositoryGeneric<Feedback>, IFeedbackRepository
{
    public FeedbackRepository(ManageCourseCenterContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Feedback>> GetFeedbackByChildrenIDAsync(int childrenId)
    {
        return await _context.Set<Feedback>()
            .Include(f => f.ChildrenClass)
            .Where(f => f.ChildrenClass.ChildrenId == childrenId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Feedback>> GetFeedbackByChildrenNameAsync(string childrenName)
    {
        return await _context.Set<Feedback>()
            .Include(f => f.ChildrenClass)
            .ThenInclude(cc => cc.Children)
            .Where(f => f.ChildrenClass.Children.FullName.Contains(childrenName))
            .ToListAsync();
    }

    public async Task<IEnumerable<Feedback>> GetFeedbackByClassIDAsync(int classId)
    {
        return await _context.Set<Feedback>()
            .Include(f => f.ChildrenClass)
            .Where(f => f.ChildrenClass.ClassId == classId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Feedback>> GetFeedbackByClassNameAsync(string className)
    {
        return await _context.Set<Feedback>()
            .Include(f => f.ChildrenClass)
            .ThenInclude(cc => cc.Class)
            .Where(f => f.ChildrenClass.Class.Name.Contains(className))
            .ToListAsync();
    }

    public async Task<IEnumerable<Feedback>> GetFeedbackByCourseIDAsync(int courseId)
    {
        return await _context.Set<Feedback>()
            .Include(f => f.ChildrenClass)
            .ThenInclude(cc => cc.Class)
            .Where(f => f.ChildrenClass.Class.CourseId == courseId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Feedback>> GetFeedbackByCourseNameAsync(string courseName)
    {
        return await _context.Set<Feedback>()
        .Include(f => f.ChildrenClass)
        .ThenInclude(cc => cc.Class)
        .ThenInclude(c => c.Course)
        .Where(f => f.ChildrenClass.Class.Course.Name.Contains(courseName))
        .ToListAsync();
    }
}
