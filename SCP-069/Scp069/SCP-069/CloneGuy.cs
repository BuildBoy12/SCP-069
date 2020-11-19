﻿using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using UnityEngine;
using Scp049 = Exiled.Events.Handlers.Scp049;
using ServerEvents = Exiled.Events.Handlers.Server;
using PlayerEvents = Exiled.Events.Handlers.Player;
using System.Linq;
using Mirror;
using Scp069.System;
using Scp069.EventHandlers;

namespace Scp069.SCP_069
{
    public class CloneGuy : MonoBehaviour
    {

        private Player player;
        private float damageTimer, damageDealt = 0;

        private void Update()
        {
            if (damageTimer <= Time.time)
            {
                player.Hurt(damageDealt, DamageTypes.RagdollLess, "SCP-069");
                damageDealt += Plugin.Instance.Config.ClonerIncreaseDamageBy;
                damageTimer = Time.time + Plugin.Instance.Config.ClonerDamageEvery;
            }
        }

        private void Awake()
        {
            try
            {
                player = Player.Get(gameObject);

                if (player.Role != RoleType.Scp049)
                {
                    player.SetRole(RoleType.Scp049);
                }

                PlayerEvents.Dying += OnKill;
                PlayerEvents.Dying += OnDeath;
                PlayerEvents.ChangingRole += OnSetClass;
                PlayerEvents.Left += OnLeave;
                Scp049.StartingRecall += OnRecall;
            }
            catch (Exception e)
            {
                Log.Error("Awake Method: " + e.StackTrace);
            }
        }

        private void Start() 
        {
            try 
            {
                if(player == null)
                    player = Player.Get(gameObject);

                if(MainHandlers.cloneGuy != null) 
                {
                    Destroy(this);
                    return;
                }

                MainHandlers.cloneGuy = player;

                player.Health = Plugin.Instance.Config.ClonerkHealth;
                player.MaxHealth = Plugin.Instance.Config.ClonerkHealth;
            } catch(Exception e) 
            {
                Log.Error("Start Method: " + e.StackTrace);
            }
        }

        private void OnDestroy() 
        {
            try 
            {
                PlayerEvents.Dying -= OnKill;
                PlayerEvents.Dying -= OnDeath;
                PlayerEvents.ChangingRole -= OnSetClass;
                PlayerEvents.Left -= OnLeave;
                Scp049.StartingRecall -= OnRecall;

                MainHandlers.cloneGuy = null;
            } catch(Exception e) 
            {
                Log.Error("OnDestroy Method: " + e.StackTrace);
            }
        }

        private void OnLeave(LeftEventArgs ev)
        {
            try 
            {
                if(ev.Player == player)
                    Destroy(this);
            } catch(Exception e) 
            {
                Log.Error("OnLeave Method: " + e.StackTrace);
            }
        }

        private void OnRoleChange(ChangingRoleEventArgs ev)
        {
            try
            {
                if (ev.Player != player)
                    return;

                if (ev.NewRole != RoleType.Scp049)
                {
                    Destroy(this);
                }

            }
            catch (Exception e)
            {
                Log.Error("OnRoleChange Method: " + e.StackTrace);
            }
        }

        private void OnRecall(StartingRecallEventArgs ev)
        {
            if (ev.Scp049 != player)
                return;

            ev.IsAllowed = false;
        }

        private void OnDeath(DyingEventArgs ev)
        {
            try
            {
                if (ev.Target != player)
                    return;

                Destroy(this);
                ev.Target.DisplayNickname = null;
            }
            catch (Exception e)
            {
                Log.Error("OnDeath Method: " + e.StackTrace);
            }
        }

        private void OnKill(DyingEventArgs ev)
        {
            try
            {
                if (ev.Killer != player)
                    return;

                ev.Killer.ResetInventory(ev.Target.Inventory.items.ToList());

                ItemType t = ItemType.None;
                if (ev.Target.CurrentItem != null)
                {
                    t = ev.Target.CurrentItem.id;
                }

                ev.Target.ClearInventory();

                ev.Killer.Health += Plugin.Instance.Config.ClonerLifesteal;
                damageDealt = 10;
                MainHandlers.cloneGuyRole = ev.Target.Role;

                if (Plugin.Instance.Config.BroadcastDuration > 0)
                {
                    ev.Target.ClearBroadcasts();
                    ev.Target.Broadcast(Plugin.Instance.Config.BroadcastDuration, Plugin.Instance.Config.Killbroadcast);

                }

                foreach (Player p in Player.Get(Side.Scp))
                {
                    p.ReferenceHub.SendCustomSyncVar(ev.Killer.ReferenceHub.networkIdentity, typeof(CharacterClassManager), (targetwriter) => {
                        targetwriter.WritePackedUInt64(16UL);
                        targetwriter.WriteSByte((sbyte)MainHandlers.cloneGuyRole);
                    });

                    if (p != ev.Target && p != ev.Killer)
                        continue;

                    p.ReferenceHub.SendCustomSyncVar(ev.Killer.ReferenceHub.networkIdentity, typeof(NicknameSync), (targetwriter) => {
                        targetwriter.WritePackedUInt64(1UL);
                        targetwriter.WriteString(ev.Target.Nickname);
                    });

                    p.ReferenceHub.SendCustomSyncVar(ev.Killer.ReferenceHub.networkIdentity, typeof(Inventory), (targetwriter) => {
                        targetwriter.WritePackedUInt64(1UL);
                        targetwriter.WriteSByte((sbyte)t);
                    });
                }
            }
            catch (Exception e)
            {
                Log.Error("OnKill Method: " + e.StackTrace);
            }
        }
    }
}
