# IMPORTED FROM GAME CREATOR HUB =================================

* IMPORT THE ETK TEMPLATE FIRST SO YOU DON'T FUCK SHIT UP!!!!!!!!!!!!!!!!!!!

* Skills Module
* UI Components from Pivec Labs

## Conditions - - - - - - - - - - - - - - - - - - - - - - - - - -

1.
[Has Local Variable]: D:\UnityAssets\GameCreatorHub_Imports\HasLocalVariable.unitypackage
```
Checks if a given object or its children has a Local Variable with a specific name. This Condition proves very useful when used together with a On Trigger Enter, where you need to filter the different objects.
```

2.
[Condition Not Null GameObject]: D:\UnityAssets\GameCreatorHub_Imports\ConditionNotNullObject.cs
+ Copy and paste the C# script into _Plugins -> GameCreatorHub -> Conditions_

3.
[Is Not Equal to (!=) Variable GameObject]: D:\UnityAssets\GameCreatorHub_Imports\ConditionIsNotVariableGameObject.cs

+ Copy and paste the C# script into _Plugins -> GameCreatorHub -> Conditions_
```
Check whether or not a variable gameObject is not equal to an object. For example, check to see whether your variable is not null.

Condition is listed as '!= Variable GameObject' in the Conditions drop-down, under Variables.
```

4.
[Character Is Moving Condition]: D:\UnityAssets\GameCreatorHub_Imports\CharacterIsMovingCondition.unitypackage
+ Main script goes into the `Asset` folder; move C# script into _Plugins -> GameCreatorHub -> Conditions_
```
Condition that when triggered checks if the character is currently in movement or not. Add a character object with CharacterController component as a parameter to Character property and specify with Value property whether condition should expect the character to moving or not.
```

5.
[Audio Source is Playing]: D:\UnityAssets\GameCreatorHub_Imports\ConditionAudioSourceIsPlaying.cs
+ Main script goes into the `Asset` folder; move C# script into _Plugins -> GameCreatorHub -> Conditions_
```
A simple condition that return True if AudioSource is playing and False if it isn't.
```


6.
[Character is wielding melee weapon]: D:\UnityAssets\GameCreatorHub_Imports\CharacterIsWieldingAWeaponCondition.unitypackage
+ Main script goes into the `Asset` folder; move C# script into _Plugins -> GameCreatorHub -> Conditions_
```
Condition that is fulfilled, returns true, if the character is currently wielding a melee weapon specified in the parameter.
```

7.
[Has Local Variable]: D:\UnityAssets\GameCreatorHub_Imports\ConditionCanSee.unitypackage
```
Returns true or false depending on whether there's an obstacle between two objects.

The comparison is made using a Raycast from the origin of A to B. The second object should have a collider in order to work (or one if its children).
```


8.
[Compare Stats / Attributes]: D:\UnityAssets\GameCreatorHub_Imports\Conditions_Compare_Stats_Attributes.unitypackage
```
This package contains three conditions to compare stats with stats, attributes with attributes and stats with attributes. 

Scripts:
- ConditionCompareAttribute.cs
- ConditionCompareStatAttribute.cs
- ConditionCompareStats.cs
```


9.
[Conditions By Chances]: D:\UnityAssets\GameCreatorHub_Imports\Chance_By_Stat_Variable_Value.unitypackage
+ Main script goes into the `Asset` folder; move C# script into _Plugins -> GameCreatorHub -> Conditions_
```
This package contains three conditions for chances. One by a fixed value, one by variable and one by a stat.

Scripts:
- ConditionChanceByStat.cs
- ConditionChanceByValue.cs
- ConditionChanceByVariable.cs
```

10.
[Compare Stats / Attributes]: D:\UnityAssets\GameCreatorHub_Imports\ConditionIsAiming.unitypackage
+ Main script goes into the `Asset` folder; move C# script into _Plugins -> GameCreatorHub -> Conditions_
```
This condition checks if the target is currently aiming or not.
```


11.
[Condition - Has Required Items For Recipe]: D:\UnityAssets\GameCreatorHub_Imports\ConditionHasRequiredItemsForRecipe.unitypackage
```
This is a simple condition which, when given a target item, checks if the items required to craft it are present in the player's inventory.

I'm new to GC, and this is my first upload to the Hub, so please let me know if I can improve this in any way. I tested this fairly thoroughly, but there's always the possibility that there's something I didn't know to check.
```




11.
[Action - Change Character Avatar]: D:\UnityAssets\GameCreatorHub_Imports\ActionCharacterAvatar.unitypackage
```
Change's the character's avatar.
```

-------------------------

## Actions - - - - - - - - - - - - - - - - - - - - - - - - - - - -

1.
[MeleeUpgrade]: D:\UnityAssets\GameCreatorHub_Imports\MeleeUpgrade

2.
[Orbit Camera]:
D:\UnityAssets\GameCreatorHub_Imports\GC_OrbitCamera.unitypackage

3.
[Action Number to Variable Number]: D:\UnityAssets\GameCreatorHub_Imports\ActionNumberToVariableNumber.unitypackage
```
Saves a number or a number variable to another number variable.
```

4.
[Copy Local Variable]: D:\UnityAssets\GameCreatorHub_Imports\ActionCopyLocalVariable.unitypackage
```
Searches and copies the value of a Local Variable found at a given target into another Variable.
```

5. 
[Copy Variable]: D:\UnityAssets\GameCreatorHub_Imports\ActionCopyVariable.cs
+ Copy and paste the C# script into _Plugins -> GameCreatorHub -> Actions_
```
Searches and copies the value of a Local Variable found at a given target into another Variable.
```

6.
[Action Play Melee Clip]: D:\UnityAssets\GameCreatorHub_Imports\ActionPlayMeleeClip.unitypackage
```
Allows you to play a melee clip at any time.
```

7.
[Swap Characters Position]: D:\UnityAssets\GameCreatorHub_Imports\swap-characters.unitypackage
+ Main script goes into the `Asset` folder; move C# script into _Plugins -> GameCreatorHub -> Actions_
```
Swaps two character positions. Very useful for allowing multiple playable characters
```


8.
[Wander Actions]: D:\UnityAssets\GameCreatorHub_Imports\Wander
+ Main script goes into the `Asset` folder; move C# script into _Plugins -> GameCreatorHub -> Actions_
+ There is a pdf file in the folder mentioned above about how to use _ActionWanderAround_
```
- Wander Action NavMesh ----------------
This action will make character wander around the navmesh. You just need to put the wander distance then add navmeshagent to the character and bake the navemesh.

- Wander Around -----------------------
Let your character wander around. Choose between 2 modes By range or by marker

Range: Set min and max range, set wait time between each move This mode works without marker

Marker: Random : Character moves randomly between markers which are stored in a waypointgroup and wait for min/max seconds to move to the next random marker

Not random : Character moves from first to last marker and start again at first. Character will wait for min/max seconds to move to the next maker
```


#-------------------------------------------------------------------------------------------------#

#-------------------------------------------------------------------------------------------------#

**When Duplicating a melee clip, make sure to to use the DUPLICATE BUTTON built into the clip in the
  Inspector window!!!!**

**bool conditions**
+ Compare <variable> with True  :   means _if variable is False_
 * basically the `Compare To` check mark is toggled **ON**

+ Compare <variable> with False :   means _if variable is True_
 * basically the `Compare To` check mark is toggled **OFF**

----------------------------------------------------------------

# STATE MACHINE =================================================
[Link]: https://www.youtube.com/watch?v=0XMscaCU1j8

<Setup>
1. In the `Project` folder (maybe in the `Scenes`folder within)
  + Right-Click: `Create -> Game Creator -> State Machine`
  + Give it name like _Player_ or _NPC_

2. On the Player in the `Inspector` (from _Game Creator_)
  + Click: `Add Component` - options:
   - `Character Melee` - from the _Melee Module from Game Creator_
   - `Player Shooter`  - from the _Shooter Module from Game Creator_
     * there is also `Character Shooter`
   - `State Machine`   - from the _State Machine component from Game Creator_

3. `Make Transition` by _drag and drop_ the `State Machine` that was created in _Step1_
   into the _State Machine_ section in the `State Machine Controller`
   
4. Choose in the UI what _Play Mode_ to use:
     _On Start_
     _On Enable_
     _Manual_
   
5. Now double click the very same `State Machine` form steps 1 and 3
   to edit it
</Setup>

----------------------------------------------------------------

## STATE MACHINE - Triggers, Actions, & Conditions = = = = = = = = =

[How to Create Trigger]: Right click  -> Create Trigger
[How to Create Action]:  Right click  -> Create Actions
[How to Connect Trigger and Action]: Right Click Trigger -> Drag to Action & Left Click


<Triggers>
 + On the right hand side, you can click `Change Trigger`
  * Example Triggers:
     _On Key Down_
     _On Key Hold_
     _On Key Up_
     _On Mouse Down_
     _On Mouse Up_
     _etc_
     
+ When **Trigger and Action are connected**, click the _line arrow_ connecting the two
 - You can toggle on the `Use Conditions` options
 - Then click `Add Condition` and set a condition
</Triggers>


<Actions>
+ Click the Action
+ Click the `Add Action` button and select and action
 * Example Actions:
    _Draw Weapon_
    _Sheathe Weapons_ / _Holster Weapon_
    _etc_
+ Make sure that the `Character` is set to **Invoker**!!!!

**Triggering an Effect with Prefab**
+ Click the `Create Action` button
+ Choose the `Instantiate`
+ Drag and drop the _object_ (such as the explosion) into `Game Object`
+ For `Init Location` choose _Invoker_
 - Set the `Offset where needed`
 - The `Boxing Jab's` _offset_ was: _X: 0  Y: 1.3  Z: 0_
</Actions>

----------------------------------------------------------------

## STATE MACHINE - Sub-State Machine  = = = = = = = = = = = = =
+ You can create a `sub-StateMachine`
+ You can make `Make Transition` from Trigger to the `sub-StateMachine`
 - Then you'll get options:
    _States_
      * You can choose the _Start_ option so the `sub-StateMachine` starts after the trigger
    _StateMachine_
      * Idk what this does yet

----------------------------------------------------------------

## STATE MACHINE - Conditions  = = = = = = = = = = = = = = = = =
+ After the _drag and connect_ `Make Transition` process connecting `Trigger` & `Action` ...
 - Click on the `arrow line` connecting the Action and Trigger
 - Toggle on the _radio button_ reading `Use Conditions`
  * Now _set the condition_ on that `arrow line`


#-------------------------------------------------------------------------------------------------#

#-------------------------------------------------------------------------------------------------#


# Melee Module ==================================================
[Fundamentals]: https://www.youtube.com/watch?v=NDGD1Et8Fk8


<MeleeWeapon>
[You can look at the default Weapons as reference]: Assets\Plugins\GameCreator\MeleeExamples\Assets\Weapons
[How to Make Melee Weapon Module (fists count here)]: Right Click -> Create -> Game Creator -> Melee Weapon


**General**
[State Example]: Assets\Plugins\GameCreator\MeleeExamples\Assets
+ You can set the `Weapon Name` & `Weapon Description`
+ `Default Shield` - you can drag and drop a **MeleeShield** _optional_
+ `Charcater State` - A character state that sets _animation clip_ for every state
 * Example
    _Character@idle_
    _Character@walkLeft_
    _DashLeft_
    _Character@additivePose_
    _etc._


**Weapon Model**
+ `Prefab` - you can _drag and drop_ the _model_


**Effects**
+ You you can set differnt `audio` by _drag and drop_
+ `Prefab Impact Normal`
+ `Prefab Impact Knockback`


**Combos Creator**
+ Here you can make **combos** that have a _letter designation_
+ You can click the `+` button to add multiple **combos**
+ The `default weapons` will be denoted as `A`
   It _DOESN'T mean it's necessarily clicking_ `A`, it's just a designation
+ Each **combo** can hava a _conditional_ like _On Air_ or _After Perfect Block_
+ Then there will be a **MeleeClip** you can `drag and drop`


**Hit Reactions**
+ `Hit Reaction - Grounded & Front`
 - You can click the `+` button to add multiple **reactions**
+ `Hit Reaction - Grounded & Behind`
 - You can click the `+` button to add multiple **reactions**
+ `Hit Reaction - Airborne & Frontal`
 - You can click the `+` button to add multiple **reactions**
+ `Hit Reaction - Airborne & Behind`
 - You can click the `+` button to add multiple **reactions**
+ `Hit Reaction - Knockback`
 - You can click the `+` button to add multiple **reactions**
 
 
   <MeleeWeaponPrefabEffects>
   [GameCreator SwordWeapon Example]: Assets\Plugins\GameCreator\MeleeExamples\Assets
   [Look at 11:04]: https://www.youtube.com/watch?v=NDGD1Et8Fk8
   
   + Go to the Prefab of the weapon
   + Click `Add Component`
   + Select `Blade Component` - a script

   + `Double-click` the Prefab to do the stuff in the video at `11:04`
  
   + If you hit the **pause button** _mid swing_ you can look at the melee weapon prefab's
     attack details (12:52)
    - _Double Clicking_ the pause button will increment the animation _forward_
    - _Red Box_ only appears when you're attacking so you're sword only does damage when
       you attack
    
   **Blade Component**
   + You can play around with the _Box Center_ & _Box Size_ for the `mesh` (you _DON'T need a collider_)
   </MeleeWeaponPrefabEffects>
</MeleeWeapon>


----------------------------------------------------------------

<MeleeClip>
[You can look at the default Clips as reference]: Assets\Plugins\GameCreator\MeleeExamples\Assets\MeleeClips
[How to Melee Clip for combos]: Right Click -> Create -> Game Creator -> Melee Clip

**Animation**
+ `Animation Clip` section you can _drag and drop_ the **animation** in
+ You can change _transition in_ & _transition out_ for time delays


**Motion**
+ Click the `Extract Root Motion` to go back to default
+ You can select _Movement Forward_, _Movement Sides_, _Movement Vertical_ and drag the dots on graph
+ You can alter the _Movement Multiplier_ integer
+ You can alter scrollbar for _Gravity Influence_


**Effect**
+ _Sound Effect_ can have audio dragged and dropped here (or clicking the right button to select)
+ You can toggle the _Hit Pause_ option
 - You can vary the _Hit Pause Amount_ and _Hit Pause Duration_


**Combat**
+ Toggle `Is Attack`
 - Toggle _Is Blockable_
 - Set _Defense Damage_ integer
 - Set _Poise Damage_ integer
+ Set the `Interruptible` variable
 * Examples:
    _Interruptible_
    _Uninterruptible_
+ Set the `Vulnerability` variable
 * Examples:
    _Vulnerable_
    _Invincible_
+ Set the `Posture` variable
 * Examples:
    _Steady_
    _Stagger_


**Combat Time Scrollbar**
+ When you select a `MeleeClip`, you can drag and drop your _model_ into the _Preview Character_ section
 - Some clips allow to have a **time scrollbar** _has blue greeen and organe colors_ of the clips
  * Click the _white bar_ in the _colored bar_ and drag it left and right
  * Observe the `model` that got dragged and dropped in the `Scene` section and watch the animation relative
    to the white bar in the **time scrollbar**


**On Hit & On Execute**
+ You can click the `Add Action` button to select an action after **On Hit** & **On Execute**

+ You can click choose `Instatiate` action and set a special hit effect
+ You can do the same thing with `Play Sound` action
+ You also want to use `Change Attribute` action to do things like subtracting health/MP/Stamina/etc.
 - Set `Target` in _Invoker_ (which will be the opponent you hit in this case)
 - Set `Attribute` to what's in `Stats` (such as health)
 - Set `Operation` as needed (subtract, add, etc.)
 - Set the `Value Type` and `Amount` as necessary (probably Vaue & Value)
  * note that _health_ is _vitatlity_ in the `Stats` component (by default anyway)
</MeleeClip>

----------------------------------------------------------------

<MeleeShield>
[You can look at the default Weapons as reference]: Assets\Plugins\GameCreator\MeleeExamples\Assets\Weapons
[How to Make Melee Weapon Shield (fist block count here)]: Right Click -> Create -> Game Creator -> Melee Weapon

**Blocking Hits**
+ This is where you _drag and drop_ **MeleeClips**
 - `Perfect Block Clip`
 - `Block Reaction`
  * You can click the `+` button to add multiple `Block Reaction` _melee clips_
 - `Perfect Block Reaction`
     _Ground Perfect Block_
     _Airborn Perfect Block_
</MeleeShield>


#-------------------------------------------------------------------------------------------------#
#-------------------------------------------------------------------------------------------------#
#-------------------------------------------------------------------------------------------------#


# Skills for Game Creator 1 =====================================


#-------------------------------------------------------------------------------------------------#
#-------------------------------------------------------------------------------------------------#
#-------------------------------------------------------------------------------------------------#


# Stats Module ==================================================


#-------------------------------------------------------------------------------------------------#
#-------------------------------------------------------------------------------------------------#
#-------------------------------------------------------------------------------------------------#


# Behavior Module ===============================================


#-------------------------------------------------------------------------------------------------#
#-------------------------------------------------------------------------------------------------#
#-------------------------------------------------------------------------------------------------#


# Traversal Module ==============================================


#-------------------------------------------------------------------------------------------------#
#-------------------------------------------------------------------------------------------------#
#-------------------------------------------------------------------------------------------------#


# Inventory Module ==============================================


#-------------------------------------------------------------------------------------------------#
#-------------------------------------------------------------------------------------------------#
#-------------------------------------------------------------------------------------------------#


# Easy Template Kit (RVR) =======================================


#-------------------------------------------------------------------------------------------------#
#-------------------------------------------------------------------------------------------------#
#-------------------------------------------------------------------------------------------------#


# Action Pack 3 for Game Creator 1 ==============================


#-------------------------------------------------------------------------------------------------#
#-------------------------------------------------------------------------------------------------#
#-------------------------------------------------------------------------------------------------#

