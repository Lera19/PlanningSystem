using AutoMapper;
using PlanningSystem.Interface;
using PlanningSystemBL.Models;
using PlanningSystemDAL.Interfaces;
using PlanningSystemDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanningSystemDAL
{
    public class TaskManager : ITaskManager
    {
        public ITaskRepository _repository;
        public readonly Mapper _mapper;
        public TaskManager(ITaskRepository repository)
        {
            _repository = repository;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Task, TaskModel>();
            });
            _mapper = new Mapper(config);
        }

        public IList<TaskModel> GetTasks()
        {
            var result = _mapper.Map<IList<TaskModel>>(_repository.GetTasks());
            return result;
        }
        public void AddTask(TaskModel taskModel)
        {
            var result = _mapper.Map<Task>(taskModel);
            _repository.AddTask(result);
            
        }
        public void DeleteTask(int id)
        {
            var result = _mapper.Map<Task>(id);
            _repository.DeleteTask(result.ID);
        }
        public void UpdateTask(TaskModel taskModel)
        {
            var result = _mapper.Map<Task>(taskModel);
            _repository.UpdateTask(result);
        }
    }
}
