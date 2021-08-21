// -----------------------------------------------------------------------
// <copyright file="ServerEvents.cs" company="SrLicht">
// Copyright (c) SrLicht. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp069.EventHandlers
{
    public class ServerEvents
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerEvents"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public ServerEvents(Plugin plugin) => this.plugin = plugin;

        public void SubscribeAll()
        {
        }

        public void UnsubscribeAll()
        {
        }

        private void OnRoundStarted()
        {
        }
    }
}