ini_open("pelt_durability.ini")
global.peltloss_modifier = array_create(13);
global.peltloss_modifier[0] = ini_read_real("globals", "slashing", 0.75)
global.peltloss_modifier[1] = ini_read_real("globals", "piercing", 0)
global.peltloss_modifier[2] = ini_read_real("globals", "blunt", 0.05)
global.peltloss_modifier[3] = ini_read_real("globals", "rending", 2)
global.peltloss_modifier[4] = ini_read_real("globals", "fire", 3)
global.peltloss_modifier[5] = ini_read_real("globals", "poison", 1.5)
global.peltloss_modifier[6] = ini_read_real("globals", "frost", 0.75)
global.peltloss_modifier[7] = ini_read_real("globals", "caustic", 3)
global.peltloss_modifier[8] = ini_read_real("globals", "shock", 1.5)
global.peltloss_modifier[9] = ini_read_real("globals", "arcane", 1.5)
global.peltloss_modifier[10] = ini_read_real("globals", "psionic", 0)
global.peltloss_modifier[11] = ini_read_real("globals", "unholy", 3)
global.peltloss_modifier[12] = ini_read_real("globals", "sacred", 0)
ini_close()