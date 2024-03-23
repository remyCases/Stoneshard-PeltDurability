// Copyright (C)
// See LICENSE file for extended copyright information.
// This file is part of the repository from .

using ModShardLauncher;
using ModShardLauncher.Mods;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;

namespace PeltDurability;
public class PeltDurability : Mod
{
    public override string Author => "zizani";
    public override string Name => "Pelt Durability";
    public override string Description => "mod_description";
    public override string Version => "1.0.0.0";
    public override string TargetVersion => "0.8.2.10";

    public override void PatchMod()
    {
        // ini variables first
        Msl.LoadGML("gml_GlobalScript_scr_sessionDataInit")
            .MatchFrom("scr_sessionDataInit\n{")
            .InsertBelow(ModFiles, "load_ini.gml")
            .Save();
            
        Msl.LoadAssemblyAsString("gml_GlobalScript_scr_damage_calculation")
            .Apply(DamageCalculatorIterator)
            .Save();
    }

    private IEnumerable<string> DamageCalculatorIterator(IEnumerable<string> enumerable)
    {
        bool foundFlaying = false;
        bool foundStart = false;
        bool foundEnd = false;
        bool once = false;
        string replacementCode = ModFiles.GetCode("gml_GlobalScript_scr_damage_calculation.asm");

        foreach (string element in enumerable)
        {
            if (!foundFlaying)
            {
                if (element.Contains("push.v self.Flaying_Modifier")) foundFlaying = true;
                yield return element;
            }
            else if (foundFlaying && !foundStart)
            {
                if (element.Contains("pushloc.v local._slashing")) foundStart = true;
                yield return element;
            }
            else if (foundFlaying && foundStart && !foundEnd)
            {
                if (element.Contains("pop.v.v local._pd_loss")) foundEnd = true;
            }
            else if (foundFlaying && foundStart && foundEnd && !once)
            {
                once = true;
                yield return replacementCode;
                yield return element;
            }
            else
            {
                yield return element;
            }
        }
    } 
}
