using System;

namespace Model
{
    public class Car
    {
        private Car()
        {
            // EF Core
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public bool IsElectric{ get; private set; }

        public static Car Create(string name, bool isComplete)
        {
            var instance = new Car { Id = Guid.NewGuid() };
            instance.Update(name, isComplete);
            return instance;
        }

        public void Update(string name, bool isElectric)
        {
            Name = name;
            IsElectric = isElectric;         
        }
    }
}
