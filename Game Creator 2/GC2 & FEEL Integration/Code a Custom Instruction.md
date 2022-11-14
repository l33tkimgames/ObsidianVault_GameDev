------------------------------------------------
# <span style="color:tomato">Code a Custom Instruction</span>
---------------------------------------------------------------------------

## <span style="color:Gold;">CODING</span>
### Creating a _custom_  <span style="color:RoyalBlue;">Game Creator 2 INSTRUCTION</span> using <span style="color:HotPink;">FEEL</span>


1. Within the `Project` window (the one with the folders and files in _file system_):
   `Right click -> Create -> Game Creator -> Developer -> C# Instruction`

  + You can open this <span style="color:aquamarine;">C# script</span> in a _text editor_ (like _VS Code_)

2. Within the _custom_ <span style="color:RoyalBlue;">Game Creator 2 INSTRUCTION</span> you can put this:

_Example_ <span style="color:RoyalBlue;">Game Creator 2 INSTRUCTION</span>
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
    // a key the Player has to press to make our Hero jump
    public KeyCode ActionKey = KeyCode.Space;
    public float JumpForce = 8f; // This is specific to this example

    [Header("Feedbacks")]
    // Ae `MMFeedbacks` to play
    public MMFeedbacks CHOSEN_FEEDBACK;
    /*
    // An example feedback (jumping in this case)
    public MMFeedbacks JumpFeedback;
    // An example feedback (landing in this case)
    public MMFeedbacks landing;
    */

	// Global variables are specific to this example
	/*
	// Example global variables (for jumping in this case)
    private const float _lowVelocity = 0.1f;
    private Rigidbody _rigidbody;
    private float _velocityLastFrame;
    private bool _jumping = false;
	*/
	
	// This is the code that runs when this instruction is triggered
    protected override Task Run(Args args)
    {
        // Your code here...
        return DefaultResult;
    }
}
```

======================= v ARCHIVED v =======================
Archived since this has been automated
```
3. Now <span style="color:Gold;">drag & drop</span> the <span style="color:aquamarine;">`Feedback`</span> you made in `Getting Started`
  + This is the object with the <span style="color:aquamarine;">`MMFeedback`</span> component!!!
   - Or whatever <span style="color:HotPink;">FEEL</span> component you put in it
```
======================= ^ ARCHIVED ^ =======================

3. Once this <span style="color:RoyalBlue;">Game Creator Instruction</span> is created
	* You should be able to select this **_instruction_** (w/ **_Game Creator_**)

4. Now continue writing your _customized_ <span style="color:RoyalBlue;">Game Creator Instruction</span>

-----------------------

## <span style="color:Gold;">EXAMPLE</span>
### <span style="color:HotPink;">FEEL Rotation</span>: Custom <span style="color:RoyalBlue;">Game Creator 2 INSTRUCTION</span>


7. Here's an example that has an object rotate when activated:

### FEEL_Rotation_Instruction.cs
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

8. You can use `.GetComponent()` to try to _ACCESS_ the 
   **MMF Player** component!!!
  + This should help automate grabbing it so I don't do it manually 
  
Unity Documentation: https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html