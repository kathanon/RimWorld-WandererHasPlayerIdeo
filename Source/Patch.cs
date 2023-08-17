using HarmonyLib;
using RimWorld;
using RimWorld.QuestGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace WandererHasPlayerIdeo;

[HarmonyPatch] 
public static class Patch {
    private static bool active = false;

    [HarmonyPrefix]
    [HarmonyPatch(typeof(QuestNode_Root_WandererJoin), "RunInt")]
    public static void Run() 
        => active = true;

    [HarmonyPrefix]
    [HarmonyPatch(typeof(PawnGenerator), nameof(PawnGenerator.GeneratePawn), typeof(PawnGenerationRequest))]
    public static void Generate(ref PawnGenerationRequest request) {
        if (active) {
            request.FixedIdeo = Faction.OfPlayer.ideos.PrimaryIdeo;
            active = false;
        }
    }
}
