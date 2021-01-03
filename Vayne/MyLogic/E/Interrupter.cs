using EnsoulSharp.SDK;
using EnsoulSharp;
using System;

namespace PRADA_Vayne.MyLogic.E
{
    public static partial class Events
    {
        public static void OnPossibleToInterrupt(AIBaseClient sender, Interrupter.InterruptSpellArgs interrupter)
        {
            if (interrupter.DangerLevel == Interrupter.DangerLevel.High && Program.E.IsReady() &&
                Program.E.IsInRange(interrupter.Sender) && interrupter.Sender.CharacterName != "Shyvana" &&
                interrupter.Sender.CharacterName != "Vayne")
            {
                Program.E.Cast(interrupter.Sender);
            }
        }
    }
}