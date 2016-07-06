﻿using System;
using System.Collections.Generic;
using Caliburn.Micro;

namespace Viticulture.Logic
{
    public abstract class Entity : PropertyChangedBase
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public Entity Clone()
        {
            var instance = CreateInstance();
            instance.Id = Id;
            OnClone(instance);
            return instance;
        }

        public void SetFromClone(Entity clone, IEnumerable<Entity> references)
        {
            OnSetFromClone(clone, references);
        }

        protected virtual void OnSetFromClone(Entity entity, IEnumerable<Entity> references)
        {
        }

        protected virtual void OnClone(Entity instance)
        {
        }

        protected virtual Entity CreateInstance()
        {
            return Activator.CreateInstance(GetType()) as Entity;
        }
    }
}