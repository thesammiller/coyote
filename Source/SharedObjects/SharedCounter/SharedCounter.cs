﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.Coyote.Actors;
using Microsoft.Coyote.SystematicTesting;

namespace Microsoft.Coyote.SharedObjects
{
    /// <summary>
    /// Shared counter that can be safely shared by multiple Coyote machines.
    /// </summary>
    public static class SharedCounter
    {
        /// <summary>
        /// Creates a new shared counter.
        /// </summary>
        /// <param name="runtime">The actor runtime.</param>
        /// <param name="value">The initial value.</param>
        public static ISharedCounter Create(IActorRuntime runtime, int value = 0)
        {
            if (runtime is ActorRuntime)
            {
                return new ProductionSharedCounter(value);
            }
            else if (runtime is ControlledRuntime controlledRuntime)
            {
                return new MockSharedCounter(value, controlledRuntime);
            }
            else
            {
                throw new RuntimeException("Unknown runtime object of type: " + runtime.GetType().Name + ".");
            }
        }
    }
}
