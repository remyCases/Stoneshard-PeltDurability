pushloc.v local._slashing
pushi.e -5
pushi.e 0
push.v [array]self.peltloss_modifier
mul.d.v
pushloc.v local._piercing
pushi.e -5
pushi.e 1
push.v [array]self.peltloss_modifier
mul.i.v
add.v.v
pushloc.v local._blunt
pushi.e -5
pushi.e 2
push.v [array]self.peltloss_modifier
mul.d.v
add.v.v
pushloc.v local._rending
pushi.e -5
pushi.e 3
push.v [array]self.peltloss_modifier
mul.i.v
add.v.v
pushloc.v local._fire
pushi.e -5
pushi.e 4
push.v [array]self.peltloss_modifier
mul.i.v
add.v.v
pushloc.v local._poison
pushi.e -5
pushi.e 5
push.v [array]self.peltloss_modifier
mul.d.v
add.v.v
pushloc.v local._frost
pushi.e -5
pushi.e 6
push.v [array]self.peltloss_modifier
mul.d.v
add.v.v
pushloc.v local._caustic
pushi.e -5
pushi.e 7
push.v [array]self.peltloss_modifier
mul.i.v
add.v.v
pushloc.v local._shock
pushi.e -5
pushi.e 8
push.v [array]self.peltloss_modifier
mul.d.v
add.v.v
pushloc.v local._arcane
pushi.e -5
pushi.e 9
push.v [array]self.peltloss_modifier
mul.d.v
add.v.v
pushloc.v local._psionic
pushi.e -5
pushi.e 10
push.v [array]self.peltloss_modifier
mul.i.v
add.v.v
pushloc.v local._unholy
pushi.e -5
pushi.e 11
push.v [array]self.peltloss_modifier
mul.i.v
add.v.v
pushloc.v local._sacred
pushi.e -5
pushi.e 12
push.v [array]self.peltloss_modifier
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