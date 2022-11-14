
# Setup

1. Add `Stats` to both Player and Character from the _Inspector_
  + Make sure in the `Player` in the `Player Character` script in _Inspector_ make sure that
    _Face Direction_ is set to **Camera Direction**
  + Make sure character **CAN'T RUN**

2. Follow `CUSTOM WEAPON CREATION` in `gamecreator_abc_integration.md`
  + _Delete_  the `Weapon Graphic` since this is hand to hand
  + Call it based on class like **Explosion Boxer**


3. Add _Abilities_ through the `Controller Manager`
[Go To]: Controller Manager -> Weapon Settings -> Add Global Weapon
  + Make sure to choose **LINK** when **IMPORTING A WEAPON**
   (otherwise the _animation overides_ won't work properly)
   - Check `Import Weapon Abilities`
   - Check `Game Type` and set it as _Action_


----------------------------------------------------------------------


# Global UI

* Add `Stats` to both Player and Character

1. Drag and drop the player to the `Global UI`
  + Toggle on `Add Component Presets`
  + Toggle on `Setup For Weapons And Abilities`
  + Click the `Create Character` button

  +  Click the `Weapons` tab
   -  Click `Add Weapon` on Hand to Hand (make sure animations override doesn't happen anymore)
   -  Set `Import Type` to `Copy` <-------------!!!! YOU MUST SELECT COPY AND NOT LINK OR ELSE YOU CAN'T CUSTOMIZE !!!!
   - Toggle On `Import Weapon Abilities`

   + Click the `Ability Manager` button
    - Go to `H2H Strike` and `H2H Attack` and set `Input Key` to `F` (for now)
    * General -> Keys & Combo -> Key -> F


2. In `Player`, deselect `Nav Mesh Obstacle` and `Capsule Collider`

3. In `Enemy`, add the `ABC State Manager`,  Click the `State Manager` button
4. Go to `Settings -> Health`
5. Set `Health Integration Type` to `Game Creator`

6. Set `Health` and `Mana` to `Game Creator` for Player
7. Delete `Nav Mesh Obstacle` and `Capsule Collider` for the Player


* When testing the `Activate Ability` Action try making a `On Key Down` trigger for this ability: 
   H2H Attack
* You also try to go the `Add Global Ability` and choose the `Template - H2H Combo`

------------------------------------


## I COULDN'T GET THIS TO WORK
# From RVR

1. Add `Stats` to both Player and Character
2. Add `ABC_Controller` to Player
  +  Click `Enable Game Creator Integration` in `ABC_Controller Integrations`
  +  Click `Enable Game Creator Stats Integration` in `ABC_Controller` Integrations

3. Add `ABC State Manager` to Character
  +  Click the `State Manager` button
  +  Go to: Settings -> Health
  +  Change `Health Integration Type` to Game Creator

4. Go back to `ABC_Controller` and click `Ability Manager`
  +  Click `New Ability`
  +  Go to the `Genearl` tab
   - Select the `Settings` side tab
   - Set the name `Melee01`
   - Choose an `Icon Image`
   - Set `Type` as `Melee`
  + The `Key` in the `Key & Combo` side tab is set to `None`
 

5. Go to the `Aesthetic & Animation` tab
  + Go to the `Initiating` side tab
   - Toggle on the `Use Initiating Aesthetic` radio button
   - Import an animation into the `Animation Clip`
   - Set `Duration` to the duration of the selecte animation clip
   - Set a `Main Graphc`
   - Set `Graphic Position` to `Target`
   - Set a `Graphic Offset` (x: 0, y: 1, z: 0)

6. Go to the `General` tab and then the `Effects` side tab
  + Select `Adjust Health` from `Add New Effect`
  + Click the `+` button
  + Set the `Potency` to -30

7. Right-click the `Player` and select `Create Empty` and name it `Combat`

8. In that newly created object, add the `On Key Down` trigger
  + I set the `E` key
  + Click the `Actions` button and select the `Activate Ability` action

9. In the `Activate Ability`:
  + Set `Target` to `Player`
  + Set `Ability Ref Type` to `Ability Name`
  + Set `Ability Name` to `Melee01` (from step 4)

10. In the `ABC State Manager` for `Character`
   + Go to the `Settings` tab and then the `Hit Animations` side tab
   + Make sure `Activate from Hit` and `Activate from Effect` are on
   + Click the `+ Add Hit Animation` button
   + Click the `+` button next to `Animation Clips`
   + Select the animation
   + Set the duration for the animation

11. Open the `Ability Manager` again
   + Go to the `Colliion & Impact` tab and then the `Collider` side tab
   + Make sure that `Is Trigger` is unselected
   
12. I didn't do the model swap
13. Press Play Button and click `E` to high the character
14. Nothing is happending :( 
    Neither the animation is playing nor is the character taking damager
