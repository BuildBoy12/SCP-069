// -----------------------------------------------------------------------
// <copyright file="Scp069Events.cs" company="SrLicht">
// Copyright (c) SrLicht. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp069.EventHandlers
{
    using Scp069.Components;

    public class Scp069Events
    {
        private readonly Scp069Component scp069Component;

        public Scp069Events(Scp069Component scp069Component) => this.scp069Component = scp069Component;
    }
}