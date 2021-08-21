// -----------------------------------------------------------------------
// <copyright file="Parent.cs" company="SrLicht">
// Copyright (c) SrLicht. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp069.Commands
{
    using System;
    using CommandSystem;

    public class Parent : ParentCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parent"/> class.
        /// </summary>
        public Parent() => LoadGeneratedCommands();

        /// <inheritdoc />
        public override string Command { get; } = "096";

        /// <inheritdoc />
        public override string[] Aliases { get; } = { "scp096" };

        /// <inheritdoc />
        public override string Description { get; } = "Parent command for the Scp096 plugin.";

        /// <inheritdoc />
        public sealed override void LoadGeneratedCommands()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            throw new NotImplementedException();
        }
    }
}