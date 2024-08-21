pushloc.v local._sacred
pushloc.v local._unholy
pushloc.v local._psionic
pushloc.v local._arcane
pushloc.v local._shock
pushloc.v local._caustic
pushloc.v local._frost
pushloc.v local._poison
pushloc.v local._fire
pushloc.v local._rending
pushloc.v local._blunt
pushloc.v local._piercing
pushloc.v local._slashing
call.i gml_Script_scr_pd_damage_pelt_calculation(argc=13)
push.v arg.argument0
pushi.e -9
push.v [stacktop]self.max_hp
div.v.v
pushi.e 100
mul.i.v
pushloc.v local._flaying_modifier
mul.v.v
pop.v.v local._pd_loss