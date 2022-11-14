------------------------------------------------
# <span style="color:tomato">Game Creator 2 & FEEL Asset Integration</span>
--------

## Getting Started 

1. Make sure the `asset` (character/asset) has the <span style="color:aquamarine;">`MMF Player` component</span> 
	* (Or whatever <span style="color:aquamarine;">`MM` component</span> that's relevant)
	
	* You can have it in an <span style="color:aquamarine;">`Empty Object`</span> that's imbedded under the target `asset`
		* ...this way you don't clutter that `asset`
	
	* Make sure to <span style="color:Gold;">"Drag & Drop"</span> the `target model` (character/asset) into the <span style="color:aquamarine;">`MMF Player`'s component</span> `Animate Rotation Target`  _field_
	
	* You can select  `Add new feedback... -> Transform -> Rotation`
		* `Add new feedback...` should be a drop down within <span style="color:aquamarine;">`MMF Player`</span>
  
2. Make sure that the `Main Camera` has the component <span style="color:aquamarine;">`CinemachineVirtualCamera`</span>

---------------------------------------------------------------------------

## Coding - Game Creator 2 Custom `INSTRUCTION` using FEEL

3. Within the `Project` window (the one with the folders and files in SSD)
   `Right click -> Create -> Game Creator -> Developer -> C# Instruction`
   
  + You can open this C# script in a text editor (like VS Code)
  
4. Within the **Custom Game Creator C# Event** you can put this:

Example_Template
```C#
using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using UnityEngine.Events;

[Serializable]
public class [Name_Of_Instruction] : Instruction
{
    [Header("Hero Settings")]
    /// a key the Player has to press to make our Hero jump
    public KeyCode ActionKey = KeyCode.Space;
    /// the force to apply vertically to the Hero's rigidbody to make it jump up
    public float JumpForce = 8f;

    [Header("Feedbacks")]
    /// a MMFeedbacks to play when the Hero starts jumping
    public MMFeedbacks JumpFeedback;
    /// a MMFeedbacks to play when the Hero lands after a jump
    public MMFeedbacks LandingFeedback;

    private const float _lowVelocity = 0.1f;
    private Rigidbody _rigidbody;
    private float _velocityLastFrame;
    private bool _jumping = false;

    protected override Task Run(Args args)
    {
        // Your code here...
        return DefaultResult;
    }
}

```

5. Now _drag and drop_ the **Feedback** you made in `Getting Started`
  + This is the object with the **MMFeedback** component!!!
   - Or whatever FEEL component you put in it

6. Once this `Game Creator Instruction` is created, you should be able to 
   select this instruction

7. Now continue writing your customized instruction

### Example - FEEL Rotation: Custom Game Creator 2 Instruction

8. Here's an example that has an object rotate when activated:

```FEEL_Rotation_Instruction.cs
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using MoreMountains.Feedbacks;

[Serializable]
public class FEEL_Rotation_Instruction : Instruction
{

    [Header("Feedbacks")]
    /// a MMFeedbacks to play when the Hero starts jumping
    public MMFeedbacks Feedback = null;

    protected override Task Run(Args args)
    {
        if (Feedback == null)
        {
            Debug.Log("GameCreator2 & FEELMMFeedback Integration: MMFeedback is NULL. Is there a MMFeedback component attached?");
        } else {
            Feedback?.PlayFeedbacks();
        }
        return DefaultResult;
    }
}
```
  + Now _drag and drop_ the **Feedback** you made in `Getting Started`
   - This is the object with the **MMF Player** component!!!

9. You can use `.GetComponent()` to try to _ACCESS_ the 
   **MMF Player** component!!!
  + This should help automate grabbing it so I don't do it manually 
  
Unity Documentation: https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html

---------------------------------------------------------------------------

## Coding - Game Creator 2 Custom `EVENT` using FEEL

3. Within the `Project` window (the one with the folders and files in SSD)
   _Right click -> Create -> Game Creator -> Developer -> C# Event_
   
  + You can open this C# script in a text editor (like VS Code)
  
4. Within the **Custom Game Creator C# Event** you can put this:
```


```
  + You should now have fields you can interact with in the UI
  + Note the **public MMFeedbacks** object!!!
  + Make sure that `public class [NameOfEvent]: Event` is **modified to**
    `public class [NameOfEvent] : GameCreator.Runtime.VisualScripting.Event`
   - Otherwise you'll get an error about ambiguous event
     (since GameCreator Events and Unity Events get confused)

-------

## FEELGC2_Integration.cs
```C#
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

using UnityEngine;
using UnityEngine.Events;

using MoreMountains.Feedbacks;
using MoreMountains.Tools;

using FEELGC2_Integration;

[Category("FEEL/ScaleFeedback")]
[Dependency("MoreMountains.Feedbacks", 3, 3, 3)]
[Dependency("MoreMountains.Tools", 3, 3, 3)]
[Dependency("FEELGC2_Integration", 3, 3, 3)]
[Keywords("Feel", "Animation", "Effects", "Special Effects")]
[Serializable]
public class ScaleFeedback : Instruction
{
    [Header("Feedbacks")]
    // Target GameObject that FEEL will add its stuff on
    public GameObject TargetObject = null;
    protected FEELGC2_SetupComponents components;
    protected string Label = "Scale"; // THIS IS IMPORTANT!!! cause i reference this by the label name later

    protected override Task Run(Args args)
    {
        // Checks if the GameObject has been dragged & dropped...
        if (TargetObject == null) {
            Debug.Log("GameCreator2 & FEEL Integration: GameObject is NULL");
            return DefaultResult;
        } else { //... if so, setup the NEEDED COMPONENTS
            components = new FEELGC2_SetupComponents(TargetObject);
        }

        // Check if this `MMF_Scale` Feedback was already added
        if (components.cMMFPlayer.GetFeedbackOfType<MMF_Scale>(this.Label) == null) {
            SetMMFScaleFeedback(); // If NOT added, so lets add it
        }

        Debug.Log("1");
        //components.cMMFPlayer.PlayFeedbacks();   // Play feedback

        return DefaultResult;
    }

    // Sets the `MMF_Scale` component
    protected void SetMMFScaleFeedback()
    {
        try {
            MMF_Scale scale = new MMF_Scale();
            scale.Label = this.Label; // THIS IS IMPORTANT!!! cause i reference this by the label name later
            scale.AnimateScaleTarget = TargetObject.transform; // set `Transform` component
            components.cMMFPlayer.AddFeedback(scale); // Adds feedback
        } catch {
            Debug.Log("GameCreator2 & FEEL Integration Catch Statement - ScaleFeedback:SetMMFScaleFeedback");
        }
    }
}


```

-----------------------

## ScaleFeedback.cs 
```C#
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

using UnityEngine;
using UnityEngine.Events;

using MoreMountains.Feedbacks;
using MoreMountains.Tools;

using FEELGC2_Integration;

[Category("FEEL/ScaleFeedback")]
[Dependency("MoreMountains.Feedbacks", 3, 3, 3)]
[Dependency("MoreMountains.Tools", 3, 3, 3)]
[Dependency("FEELGC2_Integration", 3, 3, 3)]
[Keywords("Feel", "Animation", "Effects", "Special Effects")]
[Serializable]
public class ScaleFeedback : Instruction
{
    [Header("Feedbacks")]
    // Target GameObject that FEEL will add its stuff on
    public GameObject TargetObject = null;
    protected FEELGC2_SetupComponents components;
    protected string Label = "Scale"; // THIS IS IMPORTANT!!! cause i reference this by the label name later

    protected override Task Run(Args args)
    {
        // Checks if the GameObject has been dragged & dropped...
        if (TargetObject == null) {
            Debug.Log("GameCreator2 & FEEL Integration: GameObject is NULL");
            return DefaultResult;
        } else { //... if so, setup the NEEDED COMPONENTS
            components = new FEELGC2_SetupComponents(TargetObject);
        }

        // Check if this `MMF_Scale` Feedback was already added
        if (components.cMMFPlayer.GetFeedbackOfType<MMF_Scale>(this.Label) == null) {
            SetMMFScaleFeedback(); // If NOT added, so lets add it
        }

        Debug.Log("1");
        //components.cMMFPlayer.PlayFeedbacks();   // Play feedback

        return DefaultResult;
    }

    // Sets the `MMF_Scale` component
    protected void SetMMFScaleFeedback()
    {
        try {
            MMF_Scale scale = new MMF_Scale();
            scale.Label = this.Label; // THIS IS IMPORTANT!!! cause i reference this by the label name later
            scale.AnimateScaleTarget = TargetObject.transform; // set `Transform` component
            components.cMMFPlayer.AddFeedback(scale); // Adds feedback
        } catch {
            Debug.Log("GameCreator2 & FEEL Integration Catch Statement - ScaleFeedback:SetMMFScaleFeedback");
        }
    }
}


```

