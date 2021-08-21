// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="SrLicht">
// Copyright (c) SrLicht. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp069
{
    using System;
    using Exiled.API.Features;
    using Scp069.EventHandlers;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private static readonly Plugin InstanceValue = new Plugin();

        private Plugin()
        {
        }

        /// <summary>
        /// Gets the only existing instance of this plugin.
        /// </summary>
        public static Plugin Instance { get; } = InstanceValue;

        /// <inheritdoc />
        public override Version Version { get; } = new Version(3, 0, 0);

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(2, 11, 1);

        /// <inheritdoc />
        public override string Author { get; } = "SrLicht, Beryl, & Build";

        /// <summary>
        /// Gets an instance of the <see cref="EventHandlers.ServerEvents"/> class.
        /// </summary>
        public ServerEvents ServerEvents { get; private set; }

        /// <inheritdoc />
        public override void OnEnabled()
        {
            if (!Config.DisplayLogo)
                PrintLogo();

            ServerEvents = new ServerEvents(this);
            ServerEvents.SubscribeAll();
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            ServerEvents.UnsubscribeAll();
            ServerEvents = null;
            base.OnDisabled();
        }

        private void PrintLogo()
        {
            Log.Info("####################################################################");
            Log.Info(string.Empty);
            Log.Debug(" ######   ######  ########            #####    #######   #######  ");
            Log.Debug("##    ## ##    ## ##     ##          ##   ##  ##     ## ##     ## ");
            Log.Debug("##       ##       ##     ##         ##     ## ##        ##     ## ");
            Log.Debug(" ######  ##       ########  ####### ##     ## ########   ######## ");
            Log.Debug("      ## ##       ##                ##     ## ##     ##        ## ");
            Log.Debug("##    ## ##    ## ##                 ##   ##  ##     ## ##     ## ");
            Log.Debug(" ######   ######  ##                  #####    #######   #######  ");
            Log.Info(string.Empty);
            Log.Info("####################################################################");
        }
    }
}
