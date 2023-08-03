﻿using System;

namespace IATecTasks.Domain.Tasks
{
    public class Task
    {
        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string UserId { get; private set; }
        public bool IsInProgress { get; private set; }
        public bool IsDone { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTimeOffset CreatedDate { get; private set; }
        public DateTimeOffset UpdatedDate { get; private set; }

        public Task(string title, string description, string userId, bool isInProgress, bool isDone, bool isDeleted)
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentException("Required field title");

            if (string.IsNullOrEmpty(userId)) throw new ArgumentException("Required field userId");

            Id = Guid.NewGuid().ToString();

            Title = title;
            Description = description;
            UserId = userId;
            IsInProgress = isInProgress;
            IsDone = isDone;
            IsDeleted = isDeleted;

            CreatedDate = DateTimeOffset.Now;
            UpdatedDate = DateTimeOffset.Now;
        }
    }
}