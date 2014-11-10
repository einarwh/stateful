﻿using System;
using System.Collections.Generic;

namespace Automata
{
    public interface IAmState<T>
    {
        string Name { get; }

        Action Action { get;  }

        IEnumerable<IAmTransition<T>> Transitions { get; }
    }
}