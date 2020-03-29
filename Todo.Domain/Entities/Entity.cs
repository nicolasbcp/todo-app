using System;

namespace Todo.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        // Interface implementada pelo IEquatable para verificar
        // igualdade entre duas entidades
        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}