using HarmonyLib;
using Verse;
using UnityEngine;
using RimWorld;

namespace WandererHasPlayerIdeo {
    [StaticConstructorOnStartup]
    public class Main {
        static Main() {
            var harmony = new Harmony("kathanon.WandererHasPlayerIdeo");
            harmony.PatchAll();
        }
    }
}
