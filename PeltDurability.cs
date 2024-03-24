// Copyright (C)
// See LICENSE file for extended copyright information.
// This file is part of the repository from .

using ModShardLauncher;
using ModShardLauncher.Mods;
using System.Collections.Generic;

namespace PeltDurability;
public class PeltDurability : Mod
{
    public override string Author => "zizani";
    public override string Name => "Pelt Durability";
    public override string Description => "Customize how the different damage types affect the pelt.";
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
    private enum PeltState
    {
        StartFunction,
        Flaying,
        StartBlock,
        EndBlock,
        OutBlock
    }
    private IEnumerable<string> DamageCalculatorIterator(IEnumerable<string> enumerable)
    {
        PeltState peltState = PeltState.StartFunction;
        string replacementCode = ModFiles.GetCode("gml_GlobalScript_scr_damage_calculation.asm");

        foreach (string element in enumerable)
        {
            switch(peltState)
            {
                case PeltState.StartFunction:
                    if (element.Contains("push.v self.Flaying_Modifier")) peltState = PeltState.Flaying; // found clue
                    yield return element; // not in the block to be modified, yield
                break;

                case PeltState.Flaying:
                    if (element.Contains("pushloc.v local._slashing")) peltState = PeltState.StartBlock; // found start of the block
                    else yield return element; // yield if not
                break;

                case PeltState.StartBlock:
                    if (element.Contains("pop.v.v local._pd_loss")) peltState = PeltState.EndBlock; // found end of the block
                break;

                case PeltState.EndBlock:
                    yield return replacementCode;
                    yield return element;
                    peltState = PeltState.OutBlock;
                break;

                case PeltState.OutBlock:
                    yield return element;
                break;
            }
        }
    } 
}
