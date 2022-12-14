using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BaseX;
using CodeX;
using FrooxEngine;
using FrooxEngine.LogiX;
using FrooxEngine.LogiX.Data;
using FrooxEngine.LogiX.ProgramFlow;
using FrooxEngine.UIX;
using HarmonyLib;
using NeosModLoader;

namespace CorrectGizmoScaling
{
    public class CorrectGizmoScaling : NeosMod
    {
        public override string Author => "Banane9";
        public override string Link => "https://github.com/Banane9/NeosCorrectGizmoScaling";
        public override string Name => "CorrectGizmoScaling";
        public override string Version => "1.0.0";

        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony($"{Author}.{Name}");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(MaterialGizmo), "PositionInFrontOfUser")]
        private static class MaterialGizmoPatch
        {
            private static void Prefix(RelayRef<Slot> ____inspectorRoot)
            {
                ____inspectorRoot.Target.LocalScale = float3.One;
            }
        }
    }
}