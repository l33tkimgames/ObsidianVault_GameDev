
----------------------------------------------------------------------

# Initial Setup
# ====================================================================
1. Add the `Stats` component from _Game Creator_ from the `Inspector` window
  + Both Player and Character
  + May wanto install the _ETK Template_ Asset for stamina


[GLOBAL PORTAL]: Window -> ABC -> Global Portal
2. Use the `GLOBAL PORTAL` (and the Global Portal tab on top)
  + Toggle on all the radio buttons under the _Character & Ability/Weapon Setup_
   - Drag and drop the player to the `Global Portal`
   - Click the `Create Character` button
  
  + Make sure the weapons **integrate with Game Creator**
   - Open the `Global UI / Global Portal`
   - Go to the `Global Portal` tab on the top
   
   -------------------------------------------------------
   
  + `WEAPONS` _side tab_ on the left hand side
  
   - Press `Info` on the weapon you want (or do on all of them)
    * Click the **Modify Weapon** button in Inspector window
      and a _new window_ should pop open
   
   - Click the `General & Graphic` side tab in the _Weapon Window_
     that popped open
    * If you want the weapons to be **equipable in the Game Creator
      Inventory**, uncheck the _Equip Weapon_ & _Weapon Enabled_
   
   -------------------------------------------------------
   
  + `ANIMATOR OVERRIDES`  _side tab_ on the left hand side
  
   - _Check/Enable_ (toggle on) the _Enable GC State Integration_
   
   - Animator Override
    * _Uncheck_ the _Enable Animator Overrides_ **if you want ABC's default**
    * _Check_ the _Enable Animator Overides_ **if you have custom state to use**
    
   -------------------------------------------------------
   
  + You may want to use `Global Portal's` other _side tabs_:
   ``` 
   * Weapon Block
   * Weapon Parry
   * Animations (Equip / Melee Attack Reflected)
   * Ammo & Reload
   * Weapon Pickup/Drop
   ```
   
   -------------------------------------------------------
   
   

2. **(MAYBE)** Add the `ABC_State Manager` component to _Character_ & _Plaayer_
  + Click the `State Manager` button
  + Choose the `Settings` tab on the top
  + Click the `Health` tab on the left hand side
   - For the `Health Integration Type` drop-down, select _Game Creator_
   
  + You can _randomize hit anmations in here_ and also set probability a
    certain hit animation plays
  
3. Add the `ABC_Controller (Script)` component to _Player_

4. When setting up the `Character`, if **want to use ABC Movement**, you 
   **MUST DISABLE GAME CREATOR'S `Character` & `Character Animator`**
   components in the _Inspector_



----------------------------------------------------------------------
----------------------------------------------------------------------
----------------------------------------------------------------------



# ABC CONTROLLER 
# ====================================================================
1. In the `ABC_Controller`, click `Integrations` (on bottom) to 
   expand integration options
  + Click the `Enable GameCreator Integration`
  + Click the `Enable Game Creator Stats Integration`
  + **MAYBE** Click the `Enable Emerald AI Integration`
  + This will take a few minutes

2. Click the `Controller Manager`
  + Choose the `Settings` tab on the top
  + Click the `Mana` tab on the left hand side
   - For the `Mana Integration Type` drop-down, select _Game Creator_
   
3. Click `Ability Manager` from the `ABC_Controller (Script)`
     **See the ABILITY MANAGER section for more detail**

4. If you want multiple weapons
  + After importing the next weapon, open the `Controller Manager`
  + Go to the `Settings` tab on the top
  + Click the `Weapons` tab on the left hand side
  + Under `Weapon Input Settings`
   - You should see _Input Type_ and _<Next/Previous> Weapons Key_
     drop downs you can toggle
     
5. If you want to toggle b/w _Idle_ and _Armed_ Mode
  + Open the `Controller Manager` from the ABC Controller
  + Go to the `Settings` tab on the top
  + Click the `Genearl` tab on the left hand side
  + Look under `Ability Cancel/Interruption & Combat Toggle Settings`
   - Check the _In Idle Mode_
   - You can then choose the _Idle Toggle Key_
   
6. If you want to check what ABC windows are equipped
  + Click the `Controller Manager`
   - Choose the `Weapon Settings` tab on the top
   - Check the `Weapons` section on the left hand side (under side tabs)
   - You can _Add/Delete/Copy/Export/Import_ weapons settings here

# ABILITY MANAGER Window
# ====================================================================
1. Click `Ability Manager` from the `ABC_Controller (Script)`

2. **New Ability** options
  + It will initially only say `New Ability` _if a weapon hasn't been applied_
   - If so, click `Add New Ability`
   - Then you'll have the full functionaly of `Ability Manager`

[Option - Add Global Ability]: Select an ability that comes with ABC
  Go to **GLOBAL ABILITY** section for more detail
[Option - Add New Ability]:    Create a new ability from scratch
[Option - Copy Ability]:       Make a copy of a selected ability
[Option - Delete Ability]:     Delete Ability
[Option - Export Abilities]:   Expor the Abilities for use elsewhere

- - - - - - - - - - - - - - - - - - - - - - - -

<General Tab>               (should be on top of window) of selected ability

1. `Settings     - side tab`    (left-hand side)
  + _Name and Icon Image_
  + _Type_           : Melee / Projectile(magic) / Raycast(guns)
   - _Scroll Ability_: ability activated after selecting from a list
        **it's a `radio button` to the right of the type dropdown**
        (good for the FFVII Remake type skills)
        
  + _Prepare Time_ : charging time for ability (will ad to spell casting time)
  + _Ability Tags_ : Add tags to this ability to help filter it
  + _etc._
 
2. `Keys & Combo - side tab`    (left-hand side)
  + **Disable** the _Key Press Settings_ since we're using _Game Creator_
   -   On Key Press
   -   On Key Down
  + _Scroll Ability_ : if key press is enabled it will determine which key selects
                        the ability
                        
3. `Effects      - side tab`    (left-hand side)
  + This is where you can implement the actual effect the ability has
    (like taking damge, manipulating camera, modify health, etc.)
 
  + I can use the ones built into `ABC`
   - Keep in mind there is **More Settings** for built in _ABC effects_
   - For example there is _AdjustHealth_ has _Modify Potency Using Stats_
    * Use stats fro either the target or user to modify _potency_
    * You can use **Game Creator** stats in one of the drop down menus
    * You can also toggle the _Effect Graphic_ that lets you put a `prefab`
      as the `Main Graphic`
      * You can also check the box of **Effect On Hit Position**
  
  + **GAME CREATOR ACTION** `On Effect`
    **I can implement SP expenditure stuff here**
   - ABC has _integrated Game Creator's Action_ here
   - You can click the _Add Action_ button or the _paste action button_
   
</General Tab>

- - - - - - - - - - - - - - - - - - - - - - - -

<Position and Travel tab>     (should be on top of window) of selected ability

* Primarily used for _Magical Abilities_
* Can be useful for the _Brawler_ type combat mechanics
  
1. `Position & Travel Type - side tab`    (left-hand side)
  +  _Melee Settings_
   - Rotate To Target: rotate to target when initiating (_brawler_)
   - Keep Rotating to Target: make sure you're facing enemy the whole time (_brawler_)
   - Hit Prevention Will Immediately Stop Mellee Attack: can interrupt (_brawler_)
 
 </Position and Travel tab>
 
- - - - - - - - - - - - - - - - - - - - - - - -

<Collision and Impact tab>    (should be on top of window) of selected ability

1. `Collider - side tab`     (left-hand side)
  + _Add Collider_ : if disabled, the ability will initiate without a new collider
  + _Collider Offset_ : ??? not really sure
  
  + Collider Collision Type (options of how abilities take effect)
  
  + I think I'm subbosed to _uncheck_ the `Is Trigger`

2. `Collision - side tab`    (left-hand side)
  + Settings
   - _Override Weapon Parrying_ 
   - _Override Weapon Blocking_
   - _Reduce Weapons Block Durability_
   - _Ability Collide Required Tags_
   - _Ability Collide Ignore Tags_
  + Destroy Settings
   - _Imact Destroy_ : when/what to destroy (Destroy On All is default)
   - _Don't Destroy on Below Tags_ : don't destroy ones with a certain tab
  
3. `Impact - side tab`     (left-hand side)
    <todo></todo>

</Collision and Impact tab>

- - - - - - - - - - - - - - - - - - - - - - - -

<Aesthetic and Animation tab> (should be on top of window) of selected ability

1. `Preparing -          side tab`   (left-hand side)
  + _Prepare Time_ must be set to non-zero number in `General Tab`
  + Check the _Use Preparing Aesthetics_ radio button to add things like animation
     for prepare
     
2. `Initiating -         side tab`   (left-hand side)
  + You need to go to `General tab -> Effect side tab` to determine actual effect
    of abbility
    
  [More info]: https://www.youtube.com/watch?v=OyjwYwPs-w4&list=PL4nQzoXI-5QFL7KJp9q9EXrQarAlAZGj2&index=9

  + `Animation & Movement`
   - This where where the actual ability animation happens
   - _Animation Clip_
       *  Animate on _Entity_
       *  Animate on _Weapon_
       *  Animate on _Scroll Ability Graphic_
   - _Duration_ : how long the clip is
   - _Speed_ : the time scale (1 is normal speed and 0.5 is half speed)
   - _Delay_ : seconds of delay
   
  + `Graphic` - Settings for the graphic to show when initiating
   - Graphic Position:
```
    * Self
    * Target : can do blood splatter on the enemy that gets hit
    * On Object
    * On World
    * Camera Center
    * On Tag
    * On Self Tag
```
  
  + **Game Creator Action** `On Initiation`
   - ABC has _integrated Game Creator's Action_ here
   - You can click the _Add Action_ button or the _paste action button_



2. `Scrollable Ability - side tab`   (left-hand side)
[Scroll Ability Toggle Button]: General Tab -> Settings (side tab) -> should be on right
        **Scroll Ability needs to toggled on to use this side tab**
        (good for FFVII scroll ability type functionality)

* `Scroll Ability` needs to be toggle on (look at note above)

* Has an `Enable Animation Clip` : animation when player _EQUIPS_   this ability
* Has an `Disable Animation Clip`: animation when player _UNEQUIPS_ this ability


3. `Reload -             side tab`   (left-hand side)
  + If you have a **combo** how to show all elements
   - #show combo #drop down combo
   - Click the _Show/Hide Child Abilities_ button on the left hand side

</Aesthetic and Animation tab>
  
- - - - - - - - - - - - - - - - - - - - - - - -





## GLOBAL ABILITY - Ability Manager
## - - - - - - - - - - - - - - - - - - - - - - - - -

1. Click the _drop-down menu_ and select an ability
 + `Melee options`:
 ```
  -  Hand to Hand
  -  Template - H2H Combo
  -  Template - Dodge
  -  Template - Counter Attack
  -  etc.
 ```

2. Click the _down arrow_ button next to the drop down

3. An _Import options_ window should come up
    **Go to `Import Options` for more detail**



## IMPORT OPTIONS - Ability Manager
## - - - - - - - - - - - - - - - - - - - - - - - - -

1. `Import Type` (2 options)
[Link]: Just use the same ability that's global
[Copy]: Make a copy of the global ability
      
  
2. `Enable Game Type Modification`
    **You can toggle this option ON or OFF**

  **OFF**
  + Choose this option if you're planning of fully customize this move
   
  **ON**
  + You'll have a few `Game Type` options

[Action]: Activate on nearest target (even if no one's there)
[RPGMMO]: Requires a target before activating
[MOBA]:   Ability needs to be chonse before a second click determines the directio the ability will travel
            MOBA: Multiplayer Online Battle Arena
[FPS]: <todo>
[TPS]: <todo>
[Top Down Action]: <todo>



## GAME CREATOR ACTION - Use ABC Ability
## - - - - - - - - - - - - - - - - - - - - - - - - -
+ Click the `Add Action` button as you usually do for _Game Creator_
 - Enter `ABC` to search for the _ABC Actions_ you can call in _Game Creator_
 - **Game Creator Actions w/ ABC Abilities**
 ```
    * Activate Ability
    * Activate Weapon Block
    * Activate Weapon Parry
    * Save Manager
    * Toggle Ability
    * Toggle Idle Mode
    * Toggle Weapon
 ```

+ `ABC Activate Ability`
 - _Target_ :           who's using this ability
 - _Ability Ref Type_ : Ability Name / AbilityID
  * You can find the AbilityID in the `General` tab in `Ability Manager`



----------------------------------------------------------------------
----------------------------------------------------------------------
----------------------------------------------------------------------



# CUSTOM WEAPON CREATION
# ====================================================================

**NOTE THAT THE `Avatar Mask` IS FOR THE BODY PARTS THAT WON'T BE ANIMATED**
* If the arms are in a blocking animation, you can do a leg mask so the legs
  don't change
  

1. Use the `GLOBAL PORTAL` (and the Global Portal tab on top)
  + `WEAPONS` _side tab_ on the left hand side
   - Click _Info_ on **Template - Weapon**
   - Look at `Project` window
   
   - Copy and paste the _Template - Weapon_ or another
    * _Right-Click_ it and **rename** it an change the icon
      from the `Inspector Window`
    * Update the Description too
    
   - With the new weapon, click the `Modify Weapon` button
     _(go to the `Modify Weapon Window` section for more 
       detail)_
 


# MODIFY WEAPON
# ====================================================================
[Get to this]: Window -> ABC -> Global Portal
* Use the `GLOBAL PORTAL` (and the Global Portal tab on top)
* `WEAPONS` _side tab_ on the left hand side
 - Click the **weapon of choice**
 - In the `Inspector` window, click the **Modify Abilities** _button_
   

---------------------------------------------------------------------


## Modify Weapon (Button -> Window) - Custom Weapon Creation
## - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
* Only side tabs for this window (no tabs at the top of the window)

1. `GENERAL & GRAPHIC` side tab
  + You can change the _Weapon Name_, _Icon Image_, 
    & _Description_
    
**Note: If doing Hand to Hand or Equip Weapons from Inventory, you may
  need to DELETE the default Weapon Graphic in the Template**

  + If you want a `Weapon Graphic` you can **change/delete** the prefab
    of _Main Graphic_
   - Or you can **delete** the _default_ `Weapon Graphic`
   
   - You may alos have to **change/delete** the `Weapon Graphic` from the 
     **Controller Manager** 
    * Open the Controller Manager in the _ABC Controller (Script)_
    * Go to the `Weapon Settings` tab on top
    * Select the Modified Weapon in the _Weapons_ section
      (or import it if not already there)
    * Delete the `Weapon Graphics` section

    --------------------------------------------------------

2. `ANIMATOR OVERRIDES` side tab
  + You may want to check both _Enable Animator Overrides_ & 
                               _Enable GC State Integration_
   - Set the different States for botn:
    * _Equip State_ : The movement when fighting with this weapon
    * _UnEquip State_ : the state to go back to
    
   - If you don't _override_ then ABC's defalut will be used


3. Proceed to customize the weapon


---------------------------------------------------------------------


## Modify Abilities (Button -> Window) - Custom Ability Creation
## - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -


   --------------------------------------------------------

2. `POSITION & TRAVEL` 
  
  + `Position & Travel Type` side tab
   - Make sure the `Select Tag` under _Travel Type & Starting Position_
     has the right tag attached
    * Example: ABC/LeftHand

   --------------------------------------------------------
  
3. `COLLISION & IMPACT` tab on the top

  + `Collision` side tab
   - Check the _Activate Animation On Hit_ to trigger a hit animation on target
   - For the hit animation, I can do...
   
    * `Use Clip` which let's you drag and drop an animation
      **^use this fro brawler** since I can match the right hit animation
         for the corresponding attack (right hook get its respective animation)
        
    * `Hit Animation` where you write the name of the _HitReaction_
       (Hit Animations are denoted in the `State Manager`
        _State Manager -> Settings -> Hit Animations_)
       (good for more abstract animations)

   --------------------------------------------------------

4. `AESTHETIC & ANIMATION`

  + The `Initiating` _side tab_ is the actual **animation**

   - Make sure the `Duration` in both the ...
      ``` FORMAT: the_top_tab -> the_side_tab
      
         a. Aesthetic & Animation -> Initiating
             &
         b. General -> Settings
         
      ```
     are either:
     1. ...same (if this is the final move or a standalone move)
      OR
     2. ...the _General->Settings_ `duration` is **SHORTER**
         ^so player can do combo; this will take **trial and error**
           

   --------------------------------------------------------
   

----------------------------------------------------------------------
----------------------------------------------------------------------
----------------------------------------------------------------------

2. Modify the `Weapon's Abilities`
     
      
      
      !!!!!!!!!!
    * If doing _custom Hand to Hand_ make sure that each ability has
      `Main Graphic` is the **Melee Prefab**
      (you can use the prefab from the `Brawler_Prototype` scene
       like `LH_LeftHand` or `ABC_EmptyMelee`)
      !!!!!!!!!!


## - - - - - - - - - - - - - - - - - - - - - - - - -

# ====================================================================

## - - - - - - - - - - - - - - - - - - - - - - - - -

# ====================================================================

``` Archive============================================================
# ABC CONTROLLER ======================================================
1. _Drag and drop_ the player model into the `Global Portal` from ABC
2. **UNSELECT** the following (they will interfere with the game):
  - Setup Game Type Target Targetting
  - Add UI
  - Add Camera
  - Add Movement
3. Click `Create Character`
4. _Disable_ the `Nav Mesh Obstacle` component 
    (Brawler should make this work without it)
5. _Disable_ the `Capsule Collider` component that `Global Portal` added
6. 
```


