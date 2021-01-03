using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using PRADA_Vayne.MyUtils;

namespace PRADA_Vayne.MyLogic.Q
{
    public static partial class Events
    {
        public static void OnGapcloser(AIBaseClient sender, AntiGapcloser.GapcloserArgs args)
        {
            if (Program.EscapeMenu["antigapcloser"].GetValue<MenuBool>("antigc" + sender.CharacterName).Enabled)
                if (Heroes.Player.Distance(args.EndPosition) < 425) Tumble.Cast(Heroes.Player.Position.Extend(args.EndPosition, -300));
        }
    }
}