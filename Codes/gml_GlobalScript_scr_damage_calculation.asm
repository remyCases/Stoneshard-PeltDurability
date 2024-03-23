pushi.e 0
push.v [array]self.peltloss_modifier
pushloc.v local._slashing
mul.d.v
pushi.e 1
push.v [array]self.peltloss_modifier
pushloc.v local._piercing
mul.i.v
add.v.v
pushi.e 2
push.v [array]self.peltloss_modifier
pushloc.v local._blunt
mul.d.v
add.v.v
pushi.e 3
push.v [array]self.peltloss_modifier
pushloc.v local._rending
mul.i.v
add.v.v
pushi.e 4
push.v [array]self.peltloss_modifier
pushloc.v local._fire
mul.i.v
add.v.v
pushi.e 5
push.v [array]self.peltloss_modifier
pushloc.v local._poison
mul.d.v
add.v.v
pushi.e 6
push.v [array]self.peltloss_modifier
pushloc.v local._frost
mul.d.v
add.v.v
pushi.e 7
push.v [array]self.peltloss_modifier
pushloc.v local._caustic
mul.i.v
add.v.v
pushi.e 8
push.v [array]self.peltloss_modifier
pushloc.v local._shock
mul.d.v
add.v.v
pushi.e 9
push.v [array]self.peltloss_modifier
pushloc.v local._arcane
mul.d.v
add.v.v
pushi.e 10
push.v [array]self.peltloss_modifier
pushloc.v local._psionic
mul.i.v
add.v.v
pushi.e 11
push.v [array]self.peltloss_modifier
pushloc.v local._unholy
mul.i.v
add.v.v
pushi.e 12
push.v [array]self.peltloss_modifier
pushloc.v local._sacred
mul.i.v
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