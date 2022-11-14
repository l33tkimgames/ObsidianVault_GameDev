* For the `Animated Portrais` in the `ripped area`
 [1:02]: https://www.youtube.com/watch?v=CNu8PcAmC2c
  + references using a mask to keep image within a certain area
  + maybe use UI components to have that image move back and forth?

1. Player Dialogue Choices are alwasy on `the right` (captrue4.png)
  + Previous npc dialogue is _shifted left_ so you can see it
  + The Player portrait in this decision making seem to `toggle around the rip section`

2. Player doesn't really talk too much, the `companion characters` & `NPCs` carry most conversation

3. Character `inner thoughts` are in `bubbles` and _have no portrait_

4. NPC Dialogue is _never longer_ than `3 lines`
  + The're _usually_ `1-2 lines`
  + Aslo the rips focusing on characters eyes blink

5. I want to integrate Persona looking dialogue, but implement Animal Crossing kind of emotion
   https://www.youtube.com/watch?v=ta_L_qoMaqc
  + I can use the FEEL asset with SUPER TEXT (roughly right name) to get this feeling
  + Talking will probably just be type writing sounds
   - But have separte sound when `...` shows up (one sound for each dot maybe?)
  + I also plan on having actualy snippet of voice acting at the beginning of when characters talks
    to get a feel of how the character is talking



6. Mix & Jam Stuff I want to use
  BRAWLER
  + FFVII Tactical Mode (link with brawler mode)
  + Persona 5 All-Out Attack

  DIALOGUE
  + Animal Crossing's Dialogue (partically)

  DUNGEON OR DOMESTIC AREA LAYOUT
  + Link Wall Merge
    - Go to SPUM 2D world
  + For the Trippy Stairs
  	 Mix rotunday System Camera: https://www.youtube.com/watch?v=bqXg5965XDA
  	 (may need to have camera not follow character, mabye camera just switches
  	  to in place camera)
       with
     Monument Valley Level Design: https://www.youtube.com/watch?v=hetaWVfaLQc



7. Maybe incorporate


  + Smash Bros Selection when selecting characters?
  + God of War's Axe Throw somehow
  + Integrage Traversal grappling hook with FFVX Warp Strike?


8. I want Genshin Style when you switch among characters by pressing button when
   in Bralwer Mode (maybe playing with UI Inventory may help with this) 

   + Maybe all Players are instantiated in same area, but only one is enabled
    - Have the selectable characters at gameplay  be stored as Global varibles (4 of them)

    - In the menu, you can use the `Character Model` _Action_ to swap the character model
    - ACTUALLY, SINCE BRAWLER HAS SPECIFIC HAND AND FEET POSITIONS, MAYBE I NEED MULTIPLE
      PLAYERS AND I JUST SWAP ENABLE THE LOT OF THEM
     * Pressing 1-4 or Up/Down/Left/Right lets me choose which character is playing
       (the action upon clicking button means disable the character referenced as the global variable
        which will be a separate global variable from the other 4 mentioned above and then activate
        the target player from the othter 4 global variables and store that player in the 5th global
        variabel that references the active player) 

    - Have something like the inventory UI where you select which playable character goes where
      (I'll just use RVR's character selector as a basise: https://www.youtube.com/watch?v=m0xNZ46nqpM)
         	OR
      (maybe have this section like the Smash Bros menu? it's proably more work than it's worth)

9. Integrating the controller when pressing buttons
   https://www.youtube.com/watch?v=SXBgBmUcTe0

   