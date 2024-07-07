// Copyright (C)
// See LICENSE file for extended copyright information.
// This file is part of the repository from .

using ModShardLauncher;
using ModShardLauncher.Mods;

namespace PeltDurability;
public class PeltDurability : Mod
{
    public override string Author => "zizani";
    public override string Name => "Pelt Durability";
    public override string Description => "Customize how the different damage types affect the pelt.";
    public override string Version => "1.1.0";
    public override string TargetVersion => "0.8.2.10";

    public override void PatchMod()
    {
        // add in disclaimer
        Msl.AddCreditDisclaimerRoom(Name, Author);

        Msl.AddMenu("Damage Multiplier on pelt",
            new UIComponent(name:"Slashing (%)", associatedGlobal:"pelt_slashing_modifier", UIComponentType.Slider, (0, 300), 75),
            new UIComponent(name:"Piercing (%)", associatedGlobal:"pelt_piercing_modifier", UIComponentType.Slider, (0, 300), 0),
            new UIComponent(name:"Blunt (%)", associatedGlobal:"pelt_blunt_modifier", UIComponentType.Slider, (0, 300), 5),
            new UIComponent(name:"Rending (%)", associatedGlobal:"pelt_rending_modifier", UIComponentType.Slider, (0, 300), 200),
            new UIComponent(name:"Fire (%)", associatedGlobal:"pelt_fire_modifier", UIComponentType.Slider, (0, 300), 300),
            new UIComponent(name:"Poison (%)", associatedGlobal:"pelt_poison_modifier", UIComponentType.Slider, (0, 300), 150),
            new UIComponent(name:"Frost (%)", associatedGlobal:"pelt_frost_modifier", UIComponentType.Slider, (0, 300), 75),
            new UIComponent(name:"Caustic (%)", associatedGlobal:"pelt_caustic_modifier", UIComponentType.Slider, (0, 300), 300),
            new UIComponent(name:"Shock (%)", associatedGlobal:"pelt_shock_modifier", UIComponentType.Slider, (0, 300), 150),
            new UIComponent(name:"Arcane (%)", associatedGlobal:"pelt_arcane_modifier", UIComponentType.Slider, (0, 300), 150),
            new UIComponent(name:"Psionic (%)", associatedGlobal:"pelt_psionic_modifier", UIComponentType.Slider, (0, 300), 0),
            new UIComponent(name:"Unholy (%)", associatedGlobal:"pelt_unholy_modifier", UIComponentType.Slider, (0, 300), 300),
            new UIComponent(name:"Sacred (%)", associatedGlobal:"pelt_sacred_modifier", UIComponentType.Slider, (0, 300), 0)
        );
            
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
