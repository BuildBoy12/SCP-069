// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="SrLicht">
// Copyright (c) SrLicht. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp069
{
    using Exiled.API.Interfaces;

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool DisplayLogo { get; set; } = true;

        public bool ShowDebug { get; set; } = false;

        public Configs.Scp069 Scp069 { get; set; } = new Configs.Scp069();
    }
}
