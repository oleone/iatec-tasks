﻿using System;
using Bogus;
using IATecTasks.Domain;

namespace IATecTasks.DomainTest.Builders
{
    public class TaskBuilder
    {
        private string _title;
        private string _description;
        private string _userId;
        private bool _isInProgress;
        private bool _isDone;
        private bool _isDeleted;

        public static TaskBuilder New()
        {
            return new TaskBuilder();
        }

        public TaskBuilder()
        {
            var faker = new Faker();

            _description = faker.Random.Words(50);
            _title = faker.Random.Words(25);
            _isDone = faker.Random.Bool();
            _isDeleted = faker.Random.Bool();
            _isInProgress = faker.Random.Bool();

            _userId = Guid.NewGuid().ToString();
        }

        public ETask Build()
        {
            return new ETask(_title, _description, _userId, _isInProgress, _isDone, _isDeleted);
        }

        public ETask Build(string title, string description, string userId, bool isInProgress, bool isDone, bool isDeleted)
        {
            _description = description;
            _title = title;
            _isDone = isDone;
            _isDeleted = isDeleted;
            _isInProgress = isInProgress;
            _userId = userId.ToString();

            return new ETask(_title, _description, _userId, _isInProgress, _isDone, _isDeleted);
        }

        public TaskBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public TaskBuilder WithUserId(string userId)
        {
            _userId = userId;
            return this;
        }

        public TaskBuilder WithUserIdGuid(string userId)
        {
            _userId = userId;
            return this;
        }
    }
}
