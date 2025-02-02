using EnsoulSharp;
using PRADA_Vayne.MyUtils;
using System;
using System.Linq;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;

namespace PRADA_Vayne.MyLogic.E
{
    public static partial class Events
    {
        public static void OnUpdate(EventArgs args)
        {
            if (Program.E.IsReady())
            {
                if (Program.ComboMenu["ManualE"].GetValue<MenuKeyBind>().Active)
                    foreach (var hero in Heroes.EnemyHeroes.Where(h => h.DistanceToPlayer() < 550))
                        if (hero != null)
                            for (var i = 40; i < 425; i += 125)
                            {
                                var flags = NavMesh.GetCollisionFlags(hero.Position.ToVector2().Extend(Heroes.Player.Position.ToVector2(), -i).ToVector3());
                                if (flags.HasFlag(CollisionFlags.Wall) || flags.HasFlag(CollisionFlags.Building))
                                {
                                    Program.E.Cast(hero);
                                    return;
                                }
                            }

                if (Program.ComboMenu["ECombo"].GetValue<MenuBool>().Enabled)
                    foreach (var enemy in Heroes.EnemyHeroes.Where(e => e.IsValidTarget(550)))
                        if (enemy != null && enemy.IsCondemnable())
                            Program.E.Cast(enemy);
                var kindredUltedDyingTarget = ObjectManager.Get<AIHeroClient>().FirstOrDefault(h => h.IsValidTarget(550) && h.HasBuff("KindredRNoDeathBuff") && h.Health < ObjectManager.Player.GetAutoAttackDamage(h));
                if (kindredUltedDyingTarget != null) Program.E.Cast(kindredUltedDyingTarget);
            }
        }
    }
}