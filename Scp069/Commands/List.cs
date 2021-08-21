// -----------------------------------------------------------------------
// <copyright file="List.cs" company="SrLicht">
// Copyright (c) SrLicht. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp069.Commands
{
    using System;
    using CommandSystem;

    public class List : ICommand
    {
        /// <inheritdoc/>
        public string Command { get; } = "list";

        /// <inheritdoc />
        public string[] Aliases { get; } = { "l" };

        /// <inheritdoc />
        public string Description { get; }

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            throw new NotImplementedException();
        }
    }
}