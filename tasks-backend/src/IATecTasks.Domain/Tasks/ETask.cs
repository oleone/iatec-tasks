using IATecTasks.Domain.Identity;
using System;

namespace IATecTasks.Domain
{
    public class ETask
    {
        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string UserId { get; private set; }
        public User User { get; set; }
        public bool IsInProgress { get; private set; }
        public bool IsDone { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTimeOffset CreatedDate { get; private set; }
        public DateTimeOffset UpdatedDate { get; private set; }

        public ETask(string title, string description, string userId)
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentException("Required field title");

            if (string.IsNullOrEmpty(userId)) throw new ArgumentException("Required field userId");

            if (!bool.Parse(Guid.TryParse(userId, out _).ToString())) throw new ArgumentException("Required field userId with valid Guid");

            Id = Guid.NewGuid().ToString();
            UserId = Guid.Parse(userId).ToString();

            Title = title;
            Description = description;
            IsInProgress = false;
            IsDone = false;
            IsDeleted = false;

            CreatedDate = DateTimeOffset.Now;
            UpdatedDate = DateTimeOffset.Now;
        }

        public ETask(string title, string description, string userId, bool isInProgress, bool isDone, bool isDeleted)
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentException("Required field title");

            if (string.IsNullOrEmpty(userId)) throw new ArgumentException("Required field userId");

            if (!bool.Parse(Guid.TryParse(userId, out _).ToString())) throw new ArgumentException("Required field userId with valid Guid");

            Id = Guid.NewGuid().ToString();
            UserId = Guid.Parse(userId).ToString();

            Title = title;
            Description = description;
            IsInProgress = isInProgress;
            IsDone = isDone;
            IsDeleted = isDeleted;

            CreatedDate = DateTimeOffset.Now;
            UpdatedDate = DateTimeOffset.Now;
        }

        public ETask(string id, string title, string description, string userId, bool isInProgress, bool isDone, bool isDeleted)
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentException("Required field title");

            if (string.IsNullOrEmpty(userId)) throw new ArgumentException("Required field userId");

            if (!bool.Parse(Guid.TryParse(userId, out _).ToString())) throw new ArgumentException("Required field userId with valid Guid");

            Id = id;
            UserId = Guid.Parse(userId).ToString();

            Title = title;
            Description = description;
            IsInProgress = isInProgress;
            IsDone = isDone;
            IsDeleted = isDeleted;

            UpdatedDate = DateTimeOffset.Now;
        }
    }
}
