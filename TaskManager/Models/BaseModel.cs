using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public BaseModel()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public virtual void Save()
        {
            // Placeholder method for saving instance to database
            // This should be implemented in derived classes
            throw new NotImplementedException("Save method not implemented.");
        }

        public virtual void Delete()
        {
            // Placeholder method for deleting instance from database
            // This should be implemented in derived classes
            throw new NotImplementedException("Delete method not implemented.");
        }

        public static BaseModel GetFirst()
        {
            // Placeholder method for getting the first instance from database
            // This should be implemented in derived classes
            throw new NotImplementedException("GetFirst method not implemented.");
        }

        public static List<BaseModel> GetAll()
        {
            // Placeholder method for getting all instances from database
            // This should be implemented in derived classes
            throw new NotImplementedException("GetAll method not implemented.");
        }
    }
}
