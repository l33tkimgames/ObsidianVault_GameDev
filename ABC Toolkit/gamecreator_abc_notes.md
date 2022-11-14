# ABC Getting Started ========================================
[How To Open]: Window -> ABC -> Global Portal

1. Drag and drop the **Player** into the _Character Game Object_ section on the 
   left of the pane

2. Set the **Character Type** 
```

  + Player
  + Enemy
  + Friendly
```

3. Set the **Game Type**
   ``` 
     + Action
     + FPS
     + TPS
     + RPGMMO
     + MOBA
     + Top Down Action
   ```

4. _Toggle_ the different **Character & Ability/Weapon Setup** options
  + Toggle oall on probably

5. _Toggle_ the different **UI, Canmera & Movement Setup**
```
  + Select a UI type
   - Local UI
   - Global Top UI
   - Global Side UI
   - Global Action UI
   - Global Shooter UI
   - Global Full
```

  + _Toggle OFF_ the **Add Camera** (or it will conflict with GameCreator)
  + _Toggle OFF_ the **Add Movement** (or it will conflict with GameCreator)


6. Click `Create Character`



# INTEGRATION - Game Creator / Emerald AI ====================

1. **ENABLE INTEGRATION with GAME CREATOR / EMERALD AI**
  + Choose the `Player` in the Hierarchy
  + Go to the `ABC_Controller (Script)` component
  + Click the _Integrations_ to expand it (these will take a few minutes to import)
   - Click `Enable Game Creator Integration`
   - Click `Enable Game Creator Stats Integration`
   - Click `Enable Emerald AI Integration`
    * 
   
2. Add the `GameCreator` _Stats_ component

3. `Health` w/ **Game Creator** & **Emerald AI**
  + Go to the `ABC_State Manager (Script)` component and click the _State Manager_ button
  + Go to the `Settings` tab
  + Click the `Health` tab on the left
  + Set the `Health Integration Type`
   - _Game Creator_ for Player and allies (maybe enemies)
   - _Emerald AI_ for enemies that use the **Emerald AI Asset**
   
4. `Mana` w/ **Game Creator** & **Emerald AI**
  + Go to `ABC_Controller (Script)` component and click the _Controller Manager_ button
  + Go to the `Settings` tab
  + Click the `Mana` tab on the left
  + Set the `Mana Integration Type`



# ANIMATOR MODIFICATIONS =====================================

**_ ** !!! DO THIS BEFORE MOVING ONTO WEAPONS/HAND-TO-HAND !!! ** _**

+ In `Inspector`
 - Right Click -> Game Creator -> Characters -> Player
+ Under the `Player` object, select the _second nested object_
 - It should have an `Animator` component
 - As of December 2021, it should look like
```
Player
    Robot         <--------first nested
        _Robot    <--------second nested (this one)
```

+ Click on the `Animator's` component _Controller_
 - should be called _Locomotion_
 - should open it in the `Project` window
 - **double click it** to open it
 
+ The `Animator` window should show
 - Click the `Parameters` tab
 - Then click the `+` sign (right of the tab options)
  * Then click `Int`
 - Scroll down to _New Int_
 - Rename _New Int_ to **AnimationMode**
  * Can rename it by double clicking it
 

# WEAPONS ====================================================

**Make sure to disable Animation Overrides**
1. Global Portal
`Weapons -> <select_weapon> -> Info` (this should open something in `Inspector`)
2. Inspector -> Click _Modify Weapon_
   (this should open a new window)
3. Weapon Window -> Animator Overrides -> Toggle Off _Enable Animator Overrides_

--------------------------------------------

+ If you want to see weapon's placement
  (may want to import model for this character beforehand)
 - In ABC's `Global Portal`, click the _Toggle Weapon Adjustment Mode_
[Video at 3:23]: https://www.youtube.com/watch?v=VGMZFIQ9Yi0&list=PL4nQzoXI-5QFL7KJp9q9EXrQarAlAZGj2&index=2

# HAND-TO-HAND ===============================================

**Make sure to disable Animation Overrides**
1. Global Portal
`Weapons -> <select_weapon> -> Info` (this should open something in `Inspector`)
2. Inspector -> Click _Modify Weapon_
   (this should open a new window)
3. Weapon Window -> Animator Overrides -> Toggle Off _Enable Animator Overrides_

--------------------------------------------

[Video]: https://www.youtube.com/watch?v=VGMZFIQ9Yi0&list=PL4nQzoXI-5QFL7KJp9q9EXrQarAlAZGj2&index=2

+ Import the **model you want** into `GameCreator's Player`
 - If you don't do this you may have to reposition later

+ Reposition the 4 parts to match the model
```
Player
    [...]
        ABC_WeaponSheath
            TagHolderRight          <--- right hand
            TagHolderLeft           <--- left  hand
            TagHolderRightVert      <--- right hip
            TagHolderLeftVert       <--- left  hip
```

+ Import the `Hand to Hand` weapon
  `Global Portal -> Weapons -> Hand to Hand -> Add Weapon`
  (this should open a new window)
 - Import Type: Link
 - Toggle on _Import Weapon Abilities_ and _Enable Game Type Modification_
 - Game Type: _Action_
 - If you wan to use **ABC's AI System** toggle on _Import Abilities AI Rules_
  * If you use this then for the enemy disable the `Character` & `Character Animator`
    components in the Inspector
  * If using the **ABC AI** use the **ABC Health and Mana**

+ Click `Import`


# ABC Portal =================================================



