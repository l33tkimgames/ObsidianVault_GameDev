# Potitial Error Points
+ Perfect Block Reaction -> On Execute -> False component CharacterController
 - CharacterController may not be valid

# ============================================================== #
# ================== THINGS TO KEEP TRACK OF =================== #
# ============================================================== #

[Modifier Key - For Colored Folders 2]: Alt
[Global Variables are stored in]: GameCreator -> Preferences -> Variables

**When Duplicating a melee clip, make sure to to use the DUPLICATE BUTTON built into the clip in the Inspector window!!!!**



# ============================================================== #
# ===================== GLOBAL VARIABLES ======================= #
# ============================================================== #

[Where]: GameCreator -> Preferences -> Variables
+ Click the `+` button to add a _global variable_


**Brawler_Player**
+ Type: GameObject
+ Tags: Brawler


**Brawler_Target**
+ Type: GameObject
+ Tags: Brawler


**Brawler_CounterTarget**
+ Type: GameObject
+ Tags: Brawler


**Brawlwer_EnemyAttacking**
+ Type: Bool
+ Tags: Brawler



`These are used to store a combo effect so it can be destroyed later`
**Brawler_ImpactPrefab_1**
+ Type: GameObject
+ Tags: Brawler
**Brawler_ImpactPrefab_2**
+ Type: GameObject
+ Tags: Brawler
**Brawler_ImpactPrefab_3**
+ Type: GameObject
+ Tags: Brawler


#-------------------------------------------------------------------------------------------------#

#-------------------------------------------------------------------------------------------------#


# ============================================================== #
# ========================== BRAWLER =========================== #
# ============================================================== #

[Brawler Comat 1]: https://www.youtube.com/watch?v=fIwV54qcGqY
[Brawler Comat 2]: https://www.youtube.com/watch?v=cj0wQKPvE-o
[Brawler Comat 3]: https://www.youtube.com/watch?v=H6xsTAsOd74

[Create Locomotion State]: Right-Click -> Create -> Game Creator -> Characters -> Locomoation State
* Simple State & Advanced State here as well
* Mask defines what will be animated
 - If `Defend Mask` is _UpperBody_ then only the upperbody does the animation

[Blade Component]: script should be in the Prefabs denoting hands & feet (used as weapons)

* Remember to add the `State Machine Controller (Script)` component and put in the right `State Machine`

* Make sure in the `Player` in the `Player Character` script in _Inspector_ make sure that
  _Face Direction_ is set to **Camera Direction**
 + Keep in mind in `Brawler Combat` you automatically face the nearest opponent

* In the `Stats` component you import
 - Vitality is health
 - If you toggle on the radio button _Base Value (override)_, you can set a custom value
   (for any of the stats)

* Set up the _global variable_ `Brawler_Player`
 + Choose the _Player_ in `Inspector`
 + Click `Add Component`
 + 
 
**May want to delete the Nav Mesh Obstacle from player in order to integrate with the ABC
  tool kit (the collider should take care of what the Nav Mesh Obstacle was supposed to**



-----------------------------------------------
-----------------------------------------------

**Make sure all the Hit Reactions have something in them in order to prevent ->** `OutOfIndexError`
+ _ESPECIALLY THE KNOCKBACK REACTION_

-----------------------------------------------
-----------------------------------------------

# = = = = = = = = = = = = = = = = = = = = = = =
# CAMEAR EFFECTS = = = = = = = = = = = = = = = =

**CAMERA MOTOR**
+ Make it an `Orbit Camera` (look to video 1 to install that)
+ Set the `Camera Motor`
 - _Initial Zoom_ to: `1`
 - _Target Offset_ to:
     X:  0
     Y:  1.5
     Z:  0
+ Set the `Auto Reposition Speed` to _2.5 or  _0.7_ or whatever you feel like


[Feel Asset for Camera Motor]: Install the FEEL asset from Unity
+ Add the `MMWeiggle` Component
 - Toggle on `Position` on
  * Toggle **OFF** _Wiggle Permitted_
  * Set _Wiggle Type_ to _Curve_
 - Toggle on `Rotation` on
  * Toggle **OFF** _Wiggle Permitted_
  * Set _Wiggle Type_ to _Curve_


+ Add the `MMCameraShaker` Component
 - Make sure the proper _Channel_ is set
  * _Default_ is `0`
  * This designates _which camera to provide feedback for_

-----------------------------------------------
-----------------------------------------------

# = = = = = = = = = = = = = = = = = = = = = = =
# MELEE CLIP = = = = = = = = = = = = = = = = = =

**COMBOS**
+ Remember to _toggle on_ the `Is Enbabled` button when making combos!!!!!!!!!!!!!!
+ The `Order` of the **comobs** determines the _PRIORITY_

- - - - - - - - - - - - - -

**EFFECTS**
+ Audio can be set for 
   _draw_
   _sheathe_
   2 kinds of _impact_
   
+ In the `MeleeClip` there is an **On Hit** option
 - Click the `Choose Action` button
  * Select the `Instantiate` option
  * Drag and drop the prefab for Impact
  * Select the _Invoker_ option and set the offset accordingly (like `X: 0  Y: 1.3  Z: 0`)

 - `IF YOU'RE FOLLOWING THE RVR BRAWLER TUTORIAL`
   * MAKE SURE THE XYZ COORDS OF THE _BLADE EDGE_ OF POINTS
     `A` AND `B` ARE SET TO **ZERO** !!!!!!
     
 - An Explosion or animation can be a prefab
 - Make sure the `Prefab`'s _Scale_ is rigth so it's the right size
     
 - Click the `Add Action` button
  * Select `Play Sound`
  * Now _drag and drop_ the _sound_ you want to play on impact

+ Make sure that `Push Force` is set appropriately
 - otherwise the attack will push the victim too much or too little

- - - - - - - - - - - - - -

**TRAIL - WEAPONS/FISTS**
+ Should be in the `Blade Component Script` which is in the _Prefab_ (weapon or fists)

- - - - - - - - - - - - - -

**COUNTERS**
+ Select the `Player`
 - Add the _Local Variable_ component
  * Name it `Counter`
  
+ When doing the `Perfect Block Reaction` or `Special Skill` (probably from _WeMakeTheGame_),
  the animations are built to be in sync at a certain distance
 - That `distance` is usually **1**


# This may be obsolete - - - - - - - - - - - -
 **Perfect Block Reaction - On Execute Section of MeleeClip**
+ Add the action `Transform`
 - Click the _Add Action_ button
 - Search _Transform_ and select that option
+ In the _Transform_ action set:
 - Target:               Invoker
 - Change Parent:        Change Parent
 - New Parent:           Player
 - Change Position:      (toggled on)
 - Position Relativity:  Local
 - Position:             Position
                            `X: 0  Y: 0  Z: 1` __<--- Z is probably 1, but might be different_
+ Add the action `Melee Focus Target`
 - Character:  Player
 - Target:     Release Target
+ Add the action `Melee Focus Target`
 - Character:  Invoker
 - Target:     Release Target
+ Add the action `Enable Component`
 - Target:          Invoker
 - Component Name:  CharacterController
 - Enable:          Value
                    _Toggled OFF_
+ Add the action `Wait`
 - Set the `time` to _the length of the animation_
 - **Make sure the Perfect Block Counter IS THE SAME LENGTH**
+ Add the action `Transform`
 - Target:               Invoker
 - Change Parent:        Clear Parent
 - Toggle Off all the other options

+ Place this `Perfect Block Reaction Melee Clip` in the _Perfect Block Reactions_ section
  within the `Defense` asset from _Game Creator Melee Module_

-----------------------------------------------
-----------------------------------------------

# = = = = = = = = = = = = = = = = = = = = = = =
# ENEMIES = = = = = = = = = = = = = = = = = = =

**MANUALLY ADD TRIGGER & ACTION TO ARM OR ELSE BEHAVIOR TREE WON'T RECOGNIZE IT!!!**

* Remember to add the `State Machine Controller (Script)` component and put in the right `State Machine`

+ Create an _Enemy_ & _Dead_ tag
 - Select the Enemy character and look at the `Inspector` window
 - Click the drop down menu next to `Tag`
 - Click `Add Tag`
 - Click the `+` button and enter the _Enemy_ tag
 
+ Make sure `Brawler_Target` _global variable_ is set
  (See Global Variable section below)

**Local Variables - MUST HAVE THESE IN ENEMIES!!!!!!**
 - bool: isTarget
 - bool: AttackAlert
 - bool: Dead

## If the Canvas is not made, it will break the State Machine part dealing with the canvas
 + Set up a **Canvas**** for the thunderbolts when opponent is attacking
  - Make sure that `Gizmos` is still turned on
  - _Right-click_ the opponent in `Hierarchy Window` -> UI -> Canvas
  - _Right-Click_ the canvs -> UI -> Image
  
  - In the Inspector Window
   * Set `Render Mode` to _World Space_
   * Set `Width` and `Height` to _100_
   * Set `Scale` to all _0.01_
   
  - Position the canvas over the character
  - Select the image in the `Project` folder
   * Set the `Texture Type` to _Sprite (2D and UI)_
  - Select Image (shuould be nested under the sprite you just made)
  - Drag and drop the image sprite into the canvas's _Source Image_ section
  - Resize the image as needed
  
 + Click `Add Component` and Select `Trigger` then also add and `Actions`
  - Set the trigger to `On Enable`
  - _Drag and drop_ the _Actions_ into the trigger actions section (delete the made one in nested)
  - Set action to `Look At`
   * Have the `Target` be _Camera_
  - Click the `Add Action` button and set it to _Restart the action_
  
 + Now select the **Canvas** and go to the inspector and unenable it so you don't see it
  - It should be the check mark next to it's name at the top of the `Inspector`
  
 + Set the conditions and triggers under the `Enemy` with the canvas
  - Follow 23:08 of the `Unity Game Creator - Bralwer Combat Part 2` @ _23:08_
  
 
## Enemy Behavior - RECAP
+ Recap @ 50:23 of the `Unity Game Creator - Bralwer Combat Part 2` @ _50:23_
+ To allow it to be counterable, the **first attack** of _enemies_ will trigger:
 - Change _Time Scale_ so time slows (maybe set it to 0.07)
 - Wait 0.05 seconds (or more)
 - Set _Time Scale_ back to 1 (regular time)
 
## Enemies Can't Hit Each Other
+ Enemies have to be set to a new layer
+ Select the `Enemy Character` in `Hierarchy`
+ In `Inspector`, click the _Layer_ dropdown
 - Set it to **Enemy**
 - If it doesn't exist, add it
  * Select `Add Layer...` and add it
  
+ Make sure to deselect `Enemy` in the _Layer Mask_ for _Enemy Prefabs_
 - Double click the prefab
 - Click the drop down for `Layer Mask`
 - De-select `Enemy`


-----------------------------------------------
-----------------------------------------------



#-------------------------------------------------------------------------------------------------#

#-------------------------------------------------------------------------------------------------#


# ============================================================== #
# ====================== AI NAVIGATION ========================= #
# ============================================================== #

[How to Open]: Window -> AI -> Navigation


**NAVMESH / NAVIGATION MESH - SETUP**
+ Select the `Terrain`, `Plane`, or ground I want the AI to navigate
   [Terrain]: RightClick -> 3D Object -> Terrain
+ Select: _Window -> AI -> Navigation_
+ Select: _Window -> AI -> Navigation_
 - A `Navigation` window should have appeared
- - - - - - - - - - - - - - - - - - 
+ Click the `Object` tab in the `Navigation` window
 - Click on`Mesh Renderers`
 - Select what to apply the mesh to in the `Hierarchy` window (should be on your left)
 - In the `Navigation window -> Object Tab -> MeshRenders`
  * Toggle on _Navigation State_
- - - - - - - - - - - - - - - - - - 
+ Click the `Bake` tab in the `Navigation` window
 - Play around with the _Agent Radius_ value
+ Click the `Bake Button` (should be around the middle of the `Bake` tab)


**HIERARCHY WINDOW - ISSUE**
+ If the `Hierarchy` window only shows plane (or whatever the navmesh is on),
  click the small `x` in the search bar (right of the `+` button)


**PLAYER COMPONENT - NAV MESH OBSTACLE - SETUP**
+ Select the `Player`
 - Add the `Nav Mesh Obstacle` component (prevents enemies navigating to player space)
 - In the `Shape` section, select the _Capsule_ option
 - Set the _Radius_ to `0.1` or whatever you feel like
 - Set `Y` to `1`
 - Toggle on the `Carve` radio button
  * Untoggle the `Carve Only Stationary`


#-------------------------------------------------------------------------------------------------#

#-------------------------------------------------------------------------------------------------#



