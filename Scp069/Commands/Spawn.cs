// -----------------------------------------------------------------------
// <copyright file="Spawn.cs" company="SrLicht">
// Copyright (c) SrLicht. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp069.Commands
{
    using System;
    using CommandSystem;

    public class Spawn : ICommand
    {
        /// <inheritdoc />
        public string Command { get; } = "spawn";

        /// <inheritdoc />
        public string[] Aliases { get; } = { "s" };

        /// <inheritdoc />
        public string Description { get; }

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            throw new NotImplementedException();
        }
    }
}