// -----------------------------------------------------------------------
// <copyright file="Scp069.cs" company="SrLicht">
// Copyright (c) SrLicht. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp069.Configs
{
    using System.ComponentModel;

    public class Scp069
    {
        [Description("The color that the SCP-069 Tag will have")]
        public string RankColor { get; set; } = "#F11F1F";

        [Description("Determines if SCP-069 victims should leave bodies upon killing someone")]
        public bool spawnVictimsRagdolls { get; set; } = false;

        [Description("The intensity of SCP-207 that will be given to SCP-069 when killing, if the amount is 0 no movement speed will be given.")]
        public byte movementSpeedIntesify { get; set; } = 1;

        [Description("The duration of the movement speed to be given to SCP-069. This will be ignored if movementSpeedIntesify = 0.")]
        public float movementSpeedDuration { get; set; } = 15f;

        [Description("The duration of the movement speed should be accumulated ?")]
        public bool movementSpeedShoulbeAccumulated { get; set; } = true;

        [Description("SCP-069 took damage every X seconds. (X being the number specified below)")]
        public float ClonerDamageEvery { get; set; } = 10;

        [Description("For every second that passes, the damage increases by the amount you put here")]
        public float ClonerIncreaseDamageBy { get; set; } = 10;

        [Description("After this time, SCP-069 will begin to take damage for every second. Technically it is a Spawn protect.")]
        public float GracePeriodStart { get; set; } = 30;

        [Description("When SCP-069 kills someone, they will not take damage per second, for as long as you specify (In seconds obviously)")]
        public float GracePeriodOnKill { get; set; } = 15;

        [Description("The probability that SCP-069 will appear, if the above requirement is met")]
        public int SpawnChance { get; set; } = 55;

        [Description("The amount of HP Scp069 spawns with.")]
        public int Health { get; set; } = 1540;

        [Description("The maximum HP that SCP-069 can achieve")]
        public int MaxHealth { get; set; } = 2000;

        [Description("The amount of life that is healed by killing.")]
        public int ClonerLifesteal { get; set; } = 150;

        [Description("If this setting is greater than 0, the number you set will be the duration of the broadcast you send to the victim of SCP-069")]
        public ushort BroadcastDuration { get; set; } = 8;
        public string Killbroadcast { get; set; } = "<b>You were killed by <color=red>SCP-069</color></b>";
        public ushort SpawnBroadcastDuration { get; set; } = 8;
        public string SpawnBroadcast { get; set; } = "<b><size=25>You're <color=red>SCP-069</color>. When killing a human, you will steal it's shape, inventory and size. You will also receive {dmg} damage every few seconds until you find a new victim, also healing for {heal}hp on every kill.</size></b>";
    }
}