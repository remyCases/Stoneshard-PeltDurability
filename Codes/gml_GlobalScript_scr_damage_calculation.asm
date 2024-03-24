pushloc.v local._slashing
pushglb.v global.pelt_slashing_modifier
mul.v.v
pushloc.v local._piercing
pushglb.v global.pelt_piercing_modifier
mul.v.v
add.v.v
pushloc.v local._blunt
pushglb.v global.pelt_blunt_modifier
mul.v.v
add.v.v
pushloc.v local._rending
pushglb.v global.pelt_rending_modifier
mul.v.v
add.v.v
pushloc.v local._fire
pushglb.v global.pelt_fire_modifier
mul.v.v
add.v.v
pushloc.v local._poison
pushglb.v global.pelt_poison_modifier
mul.v.v
add.v.v
pushloc.v local._frost
pushglb.v global.pelt_frost_modifier
mul.v.v
add.v.v
pushloc.v local._caustic
pushglb.v global.pelt_caustic_modifier
mul.v.v
add.v.v
pushloc.v local._shock
pushglb.v global.pelt_shock_modifier
mul.v.v
add.v.v
pushloc.v local._arcane
pushglb.v global.pelt_arcane_modifier
mul.v.v
add.v.v
pushloc.v local._psionic
pushglb.v global.pelt_psionic_modifier
mul.v.v
add.v.v
pushloc.v local._unholy
pushglb.v global.pelt_unholy_modifier
mul.v.v
add.v.v
pushloc.v local._sacred
pushglb.v global.pelt_sacred_modifier
mul.v.v
add.v.v
push.v arg.argument0
pushi.e -9
push.v [stacktop]self.max_hp
div.v.v
pushi.e 100
mul.i.v
pushloc.v local._flaying_modifier
mul.v.v
pop.v.v local._pd_loss