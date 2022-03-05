﻿using Iwentys.EntityManager.Common;
using Iwentys.EntityManager.Domain.GithubOrganizations;

namespace Iwentys.EntityManager.Domain;

public class GroupSubject
{
    public int Id { get; init; }

    public int SubjectId { get; init; }
    public virtual Subject Subject { get; init; }
    public StudySemester StudySemester { get; init; }

    public int StudyGroupId { get; init; }
    public virtual StudyGroup StudyGroup { get; init; }
    public GithubOrganization GithubOrganization { get; set; }
    public virtual List<GroupSubjectTeacher> Teachers { get; init; }

    public GroupSubject(Subject subject, StudyGroup studyGroup, StudySemester studySemester, IwentysUser lecturer)
    {
        ArgumentNullException.ThrowIfNull(subject);
        ArgumentNullException.ThrowIfNull(studyGroup);
        ArgumentNullException.ThrowIfNull(lecturer);

        Subject = subject;
        SubjectId = subject.Id;
        StudyGroup = studyGroup;
        StudyGroupId = studyGroup.Id;
        StudySemester = studySemester;
        Teachers = new List<GroupSubjectTeacher>
        {
            new GroupSubjectTeacher(lecturer, this, TeacherType.Lecturer),
        };
    }

    protected GroupSubject()
    {
    }

    public void AddPracticeTeacher(IwentysUser practiceTeacher)
    {
        AddTeacher(practiceTeacher, TeacherType.Practice);
    }

    public void AddTeacher(IwentysUser teacher, TeacherType teacherType)
    {
        ArgumentNullException.ThrowIfNull(teacher);

        if (!IsUserAlreadyAdded(teacher, teacherType))
        {
            throw new IwentysException("User is already practice teacher");
        }

        Teachers.Add(new GroupSubjectTeacher(teacher, this, teacherType));
    }

    private bool IsUserAlreadyAdded(IwentysUser teacher, TeacherType teacherType)
    {
        ArgumentNullException.ThrowIfNull(teacher);
        return !Teachers.Any(t => t.TeacherId == teacher.Id && t.TeacherType.HasFlag(teacherType));
    }

    public bool HasTeacherPermission(IwentysUser user)
    {
        ArgumentNullException.ThrowIfNull(user);
        return Teachers.Any(t => t.TeacherId == user.Id);
    }

    public void SetGithubOrganization(GithubOrganization githubOrganization)
    {
        ArgumentNullException.ThrowIfNull(githubOrganization);
        GithubOrganization = githubOrganization;
    }

    public void RemoveGithubOrganization()
    {
        GithubOrganization = new NoGithubOrganization();
    }
}