# HiisiPuuro

Overview:

HiisiPuuro is a 2D top-down camp survival game.
Stir the puuro, while fighting off hungry creatures.

There is an overheat-bar that ends the game if full.
Stir the puuro so reset the bar.

Other way to end the game is by getting killed by creatures.

Player:

You play a chef in the woods preparing puuro(porridge) for your campmates.

    Controls:
        Move ----------- WASD
        Stir ----------- Right mouse button
        Shoot crossbow - Left mouse button
        Stab ----------- Space
        Dash/Dodge ----- Left shift
    
Enemies:

    Wolf:
        Goes straight for the puuro.
        Flees if hit.
        Attacks only when AlphaWolf is present.
        Chance to drop arrows.
        Weak/fast
    
    AlphaWolf:
        Goes straight for the puuro.
        Attacks and chases when hit.
        Chance to drop arrows.
        Fast
    
    Bear:
        Goes straight for the puuro.
        Attacks and chases when hit.
        Always drops health.
        Strong/Slow/tough
    
    Hiisi:
        Targets the player.
        Always drops arrows.
        Deadly in close range.
        Strong/slow/medium toughness

Progression:

    Three static spawners spawn enemies fom the edges of the map.
    Enemies are randomized from an array.

    Timer handles difficulty progression.
    Every 30 seconds the spawn interval of spawners is reduced by 1 second.

    Survive as long as you can.
    Best time is stored upon death and displayed in the HUD.

    PRAY FOR RNG GODS!

Tech stuff:

    The game was originally made hastely for a game jam in 2024 and you can encounter some stupid stuff that I have not fixed due to them still working.

    Stupid stuff found:

        Scene management done extremely poorly. (multiple entities handling scene management)
        No pause menu.
        Audio management done questionably. (some sounds get overrriden)
        Project not entirely cleaned from useless stuff.

Recently added stuff:

    Arrow pickup now gives a random range of arrows between 5-10
    Added health pickup that heals 50% of health
    Improved hiisi combat logic slightly
    Added difficulty bulidup
    Addded some juice (Camera shake and stab landig sound)
    Balanced enemy behaviour.
    Moved all scripts to dedicated scripts folder and sub-folders.
    Some tinkering when migrating from Unity 2022 verison to Unity 6
    Added controls to the menu scene.


