[Original Location of Actions]: D:\UnityProjects\Models\Assets\Scenes\AnimeScene\Models\VROID\AvatarSample_E2\animations

### Setting up VROID model to have face animations
1. _Right-Click_ and `create` a Game Creator `character/player`
2. _Drag and drop_ the _model_ into this new `character/playter`
3. In the newly mader `character/player`
  + _Rename_ the `Face` in the drop down into a more **unique name**
   - This way it can be easily found
  + Add an _Animator_ component
  + In the _Controller_ in _Animator_ select **FaceVROID**
   - I made FaceVROID


### Using Game Creator Action to trigger these facial reactions
4. Now you can use game creator _actions_ that I made
  + Example: `Action_Talking_Animation`
  + The action _requests_ a `My Animation Controller`
5. Select the _Face_ that you **renamed int step 3** that has the **FaceVROID** animation controller
6. Things should work now
