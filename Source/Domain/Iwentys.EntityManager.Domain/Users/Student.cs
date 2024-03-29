﻿namespace Iwentys.EntityManager.Domain;

public class Student : IwentysUser
{
    public Student(
        string firstName,
        string middleName,
        string lastName,
        bool isAdmin,
        string githubUsername,
        DateTime creationTime,
        DateTime lastOnlineTime,
        string avatarUrl,
        StudyGroup studyGroup,
        StudentType studentType,
        StudentStatus studentStatus)
        : base(firstName, middleName, lastName, isAdmin, githubUsername, creationTime, lastOnlineTime, avatarUrl)
    {
        ArgumentNullException.ThrowIfNull(studyGroup);

        Type = studentType;
        Group = studyGroup;
        GroupId = studyGroup.Id;
        StudentStatus = studentStatus;
    }

    protected Student() { }

    public StudentType Type { get; init; }
    public int? GroupId { get; set; }
    public virtual StudyGroup Group { get; set; }
    public virtual StudentStatus StudentStatus { get; set; }
}