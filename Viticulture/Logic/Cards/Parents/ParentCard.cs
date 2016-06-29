﻿using System;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents
{
    public abstract class ParentCard : Card, IParentCard
    {
        public override string Text => string.Empty;

        public abstract void Setup(IGameState gameState);
    }
}