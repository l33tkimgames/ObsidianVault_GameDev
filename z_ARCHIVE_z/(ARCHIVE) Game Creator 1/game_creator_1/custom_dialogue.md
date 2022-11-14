
------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------


# Things to take into account when implementing `Animated Portratis`

1. Make sure that the `Actor` objects have a `transparent` Sprite as a portrait
  + This way this portrait won't interfere or throw erros

2. Make sure the `Prefabs`, the `UI with the animated raw images`, & the `Dialogue Option for layer`
   **points to the same LAYER**

3. Make sure the `Dialogue Options` have the _portraits_ and _raw image_ sections all filled out

4. Make sure that the `Animated Portraits` are not physically overlapping in the _Scene_
  - otherwise there will be a trasparent thing in front of the portrait


------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------

# MAKE AN `AnimatedPortrait` Layer!!!!!!!!!!!!!

------------------------------------------------------------------------------------------------------------

# Custom Action 

* _ActionDisplayCanvasModel.cs_
* _ActionSetActive.cs_
* _ActionPlaySound3D.cs_  -> _maybe switch to ActionPlaySound.cs_

------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------

# Dialoge that is customized
[GC Basic UI @ 3:58]: https://www.youtube.com/watch?v=yI5f5Lr6_cs
[GC Default Dialogue Prefab]: DefaultDialogueSkin
 * you can search for it, make a copy, and modify it

- - - - - - - - - - - - - - - - -

## Customizing GameCreator Dialogue
[Actor.cs]:     Assets\Plugins\GameCreator\Dialogue\Mono

[DialogueItemRoot.cs]: Assets\Plugins\GameCreator\Dialogue\Mono\Dialogue
[DatabaseDialogue.cs]:       Assets\Plugins\GameCreator\Dialogue\ScriptableObjects
[DatabaseDialogueEditor.cs]: Assets\Plugins\GameCreator\Dialogue\Editor\Database

* _Dialogue.cs -> DialogueItemRoot.cs -> IDialogueItem.cs_
* _Dialogue.cs -> DatabaseDialogue.cs_


- - - - - - - - - - - - - - - - -

# Code Notes

+ For `SerializedProperty` Objects, 
 - `objectReferenceValue()` gets the actual object and you cast it as what you expect

+ Taking a Game Creator Global Variable and using it:
```
object result = VariablesManager.GetGlobal(variable);
text.Remove(match.Index, match.Length);
text.Insert(match.Index, result == null ? "" : result.ToString());
```


* Use the _actions_ TAB to put the _animated portraits_ for the `dialogue boxes AND choice dialouge`


**Choice Dialogue**
[DialogueItemChoiceGroupEditor.cs]: Assets\Plugins\GameCreator\Dialogue\Editor\DialogueItems
  + "Message"
  + "Choices"
  + "Actions"
  + "Conditions"
  + "Settings"
[DialogueChoiceEditor.cs]:          Assets\Plugins\GameCreator\Dialogue\Editor\DialogueItems
  + "Answer"
  + "Actions"
  + "Conditions"


**TYPEWRITER EFFECT**
[TypeWriterEffect.cs]: Assets\Plugins\GameCreator\Dialogue\Mono\Effects


- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -


#  CUSTOMIZING DIALOGUE - UI
##  (also what I CHANGED!!!!!)
[Logic - UI]: Dialgoue.cs -> IDialogue.cs -> IDialogueItemEditor.cs


    -------------------------------------------------------


[Dialogue.cs]:  Assets\Plugins\GameCreator\Dialogue\Mono\Dialogue
## `Dialogue.cs` is where the dialogue is actually played

1. Makes a stack of `IDialogueItems` to execute
  + `Stack<IDialogueItem> stackItems = new Stack<IDialogueItem>();`
  + `IDialogueItem item = stackItems.Pop()`
  + `yield return item.Run();` 


2. Dialogue Start in `Run()`  :  `DialogueUI.BeginDialogue();`

3. Dialogue End in `Run()`    :  `DialogueUI.EndDialogue();` 



                          |
                          |
                          v



[IDialogueItem.cs]:    Assets\Plugins\GameCreator\Dialogue\Mono\Dialogue
## `IDialogueItem.cs` it the acutal dialogue item within the `Dialogue` Object in the `Hierarchy`

 **I MODIFIED THIS FILE TO MAKE IT SHOW EXTRA COMPONENTS I WANT TO ADD FOR CUSTOMIZATION PURPOSES**
 
  1. _Global Variables_
    + The text of dialogue:       `public LocString content = new LocString("");`
    + The audio for the dialogue: `public AudioClip voice;`
    + The Actor:                  `public Actor actor;`
    + Actor Sprite Index:         `public int actorSpriteIndex = 0;`
    
         **WHAT I'M ADDING**
         1. _GameObject rawImage;_
           - This holds the raw image the user provides where animated portrait will be put
         2. _int actorSpriteIndex2 = 1;_
           - The index pointing to the second portrait (_idle or talking_)
           - Default is the 2nd index (2nd portrait)
           - THIS ASSUMES THERE ARE AT LEAST 2 PORTRAITS FOR EACH ACTOR
  
  
     
  
  ```Archive
  1. This has the variables associated with the `Message` tab in Dialogue
  
  2. If I want ot add more options to the Dialogue, edit the `IDialogueItem.cs`
    + For example, if I put `public Dialogue dialogue2` after `public Dialogue dialogue`...
     - I should see `Dialogue 2` for each Dialogue Item in the _Inspector_
  ```



                          |
                          |
                          v



[IDialogueItemEditor.cs]:    Assets\Plugins\GameCreator\Dialogue\Editor\DialogueItems
## `IDialogueItemEditor` sets the UI that's associated with a Dialogue Item

 **I MODIFIED THIS FILE TO MAKE IT SHOWS EXTRA COMPONENTS I WANT TO ADD FOR CUSTOMIZATION PURPOSES**

  + _Classes that extend off of this_
   - `public class DialogueItemRootEditor : IDialogueItemEditor`


  + _Global Varialbes-------------------------------------------------------_
      1. ONE TYPE OF GLOBAL VARIABLE
           The `const string` variables that have `PROP_` in the name references
           the _global variable names_ mentioned in `IDialogueItem.cs`
      2. ANOTHER TYPE OF GLOBAL VARIABLE
           The `SerializedProperty` uses `this.serializedObject.FindProperty(<PROP_VARIABLE>)`
           to get the _IDialogueItem's global variable_ from by supplying the `PROP_` string
           variable mentioned above
     
   - Dialogue
    * `private const string PROP_DIALOGUE = "dialogue";`
    * `public IDialogueItem targetItem;`
    * `public SerializedProperty spDialogue;`
    
   - Text
    * `private const string PROP_CONTENT = "content";`
    * `private const string PROP_CONTENT_STR = "content";`
    * `public SerializedProperty spContent;`
   
   - Voice
    * `private const string PROP_VOICE = "voice";`
    * `public SerializedProperty spVoice;`
    
   - Actor
    * `private const string PROP_ACTOR = "actor";`
    * `private const string PROP_ACTOR_SPRITE = "actorSpriteIndex";`
    * `public SerializedProperty spActor;`
    * `public SerializedProperty spActorSpriteIndex;`
       
       
       
   **WHAT I'M ADDING - (references what I added in `IDialogueItem.cs`**
       1. _private const string PROP_RAW_IMAGE = "rawImage";_
         + References `IDialogueItem`'s _GameObject rawImage;_
        
       2. _private const string PROP_ACTOR_SPRITE = "actorSpriteIndex2";_
         + References `IDialogueItem`'s _int actorSpriteIndex2 = 1;_



  + _Method: OnEnableBase()--------------------------------------------------_
   - Dialogue
    * `this.targetItem = (IDialogueItem)target;`
    * `this.spDialogue = this.serializedObject.FindProperty(PROP_DIALOGUE);`
            
   - Text
    * `this.spContent = serializedObject.FindProperty(PROP_CONTENT);`
    * `this.spContentString = this.spContent.FindPropertyRelative(PROP_CONTENT_STR);`
    
   - Voice
    * `this.spVoice = this.serializedObject.FindProperty(PROP_VOICE);`
    
   - Actor
    * `this.spActor = this.serializedObject.FindProperty(PROP_ACTOR);`
    * `this.spActorSpriteIndex = this.serializedObject.FindProperty(PROP_ACTOR_SPRITE);`



  + _Method: PaintContentTab()-----------------------------------------------_
   - This method deals with the _UI_ of the **Message tab in Dialogue**
   - Formatting the GUI
    * `EditorGUI.indentLevel--;`
    * `EditorGUILayout.Space();`
    * `EditorGUI.BeginChangeCheck();`
    * `EditorGUILayout.PropertyField(this.spActor);`
    * `EditorGUI.indentLevel++;`
   
   - Text
    * `EditorGUILayout.PropertyField(this.spContent);`
   
   - Voice
    * `EditorGUILayout.PropertyField(this.spVoice);`
    * `AudioClip audioClip = (AudioClip)this.spVoice.objectReferenceValue;`
    
   - Actor 
     ```
     EditorGUILayout.PropertyField(this.spActor);
     if (EditorGUI.EndChangeCheck())
     {
         Actor actor = this.spActor.objectReferenceValue as Actor; // <--- cast SerializedProperty to Actor
         if (actor != null) ActorUtility.Add(actor);
     }
     
     if (this.spActor.objectReferenceValue == null)
     {
       [...]
     }
     else
     {
         EditorGUI.indentLevel++;
         this.spActorSpriteIndex.intValue = EditorGUILayout.IntPopup(
             "Portrait",
             this.spActorSpriteIndex.intValue,
             ((Actor)this.spActor.objectReferenceValue).GetPortraitNames(),
             ((Actor)this.spActor.objectReferenceValue).GetPortraitValues()
         );
         EditorGUILayout.PropertyField(this.spActorTransform, GC_TRANSFORM);
         EditorGUI.indentLevel--;
     }
     ```
  
  

  + _Method: SetupJumpOptions()----------------------------------------------_
   - Ignore this for now



- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -


#  CUSTOMIZING DIALOGUE - UI
##  (also what I CHANGED!!!!!)
[Logic - UI]: Dialgoue.cs -> IDialogue.cs -> IDialogueItemEditor.cs


    -------------------------------------------------------


[Dialogue.cs]:  Assets\Plugins\GameCreator\Dialogue\Mono\Dialogue
## `Dialogue.cs` is where the dialogue is actually played

  1. Makes a stack of `IDialogueItems` to execute
    + `Stack<IDialogueItem> stackItems = new Stack<IDialogueItem>();`
    + `IDialogueItem item = stackItems.Pop()`
    + `yield return item.Run();` 



                          |
                          |
                          v



[IDialogueItem.cs]:    Assets\Plugins\GameCreator\Dialogue\Mono\Dialogue
## `IDialogueItem.cs` it the acutal dialogue item within the `Dialogue` Object in the `Hierarchy`


**!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!**
**!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!**
**!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!**

TODO: LOOK AT `Dialogue.cs -> Run()`
+ You'll see: `IDialogueItem item = stackItems.Pop();`
 - I can use the _IDialogueItem item_ to interact with the variables I want
   _(like actorSpriteIndex, actorSpriteIndex2, and rawImage)_
  * Such _enabling the raw image_ as drawing the_animated portrait_
  
 - I might need to modify the `Run()` in `IDialogueItem` method to swap out the _animated portraits_
  * When switching from talking to idle animated portraits
  
 - Do I _disable the rawImage_ after the `DialogueUI.EndDialogue();` line?????
```
IDialogueItem item = stackItems.Pop(); //a stack of dialogue items to execute is here; tagline: l33tkim
if (!item.CheckConditions()) continue;
yield return item.Run(); //This seem to execute the actual dialogue component; tagline: l33tkim
```


   **THIS IS THE METHOD OF INTEREST FOR SOUND STUFF!!!!!!!!!!!!!!!!!!!!!!!!!!!!**
 1. _METHOD: IDialogueItem.RunShowText()_  **IDialogueItem -> RunShowText()**
   + Start _printing_ the **dialogue text**
         `DatabaseDialogue.ConfigData configData = this.GetConfigData();`
         `DialogueUI.StartLine(this, configData);`
         
   + THE END OF THIS METHOD SHOULD BE THE END OF THE DIALOGUE LINE

    -----------------------------------------------------

   + If `voice` is not null, start the **voice sound**
    - The voice is stopped in `DialogueItemText:RunItem()` or 
                              `DialogueItemItemChoiceGroup.RunItem()`

    -----------------------------------------------------

   + This method was **called** from _2 places_:
    

       - _DialogueItemChoiceGroup:RunItem()_
        * extend IDialogueItem
           `Mono/Dialogue/DialogueItemChoiceGroup.cs`
           `40:                yield return this.RunShowText();`
        * Voice is also stopped here: `AudioManager.Instance.StopVoice(this.voice);`
       
       
       - _DialogueItemText:RunItem()_
        * extend IDialogueItem
           `Mono/Dialogue/DialogueItemText.cs`
           `16:            yield return this.RunShowText();`
        * Voice is also stopped here: `AudioManager.Instance.StopVoice(this.voice);`


**!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!**
**!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!**
**!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!**


  2. _METHOD: IDialogueItem.GetContent()_
    + This method is called when getting the actual _text_ of the dialogue
  
  3. _METHOD: IDialogueItem.Run()_
    + This method seem to determine what type of execution behavior and then calls
      `RunItem()` to execute
  


  4. _METHOD: IDialogueItem.RunItem()_
    + This method runs the action
    + In `IDialogueItem` it uses the `virtual` keyworkd so this method is expected to be
      overidden by a `class` that `inherits (:)` this
      ```
      protected virtual IEnumerator RunItem()
      {
          yield break;
      }
      ```
    + _Classes that inherit IDialogueItem_
     - _Editor/DialogueEditor.cs_
         `441:        public T CreateDialogueItem<T>() where T : IDialogueItem`


       
     - _Mono/Dialogue/DialogueItemRoot.cs_
         `9:    public class DialogueItemRoot : IDialogueItem`
           * GetContent() just does `return "root";`
       
     - _Mono/Dialogue/DialogueItemChoice.cs_
         `10:    public class DialogueItemChoice : IDialogueItem`
          * This doesn't have a GetContent() method and I also don't see 
            anything that extends off of this
            
     - _Mono/Dialogue/DialogueItemText.cs_
         `10:    public class DialogueItemText : IDialogueItem`
           * This seems to just to stop the _voice_
             `AudioManager.Instance.StopVoice(this.voice);`
           **Does StopVoice actually stop the sound from playing?**
      
     - _Mono/Dialogue/DialogueItemChoiceGroup.cs_
         `11:    public class DialogueItemChoiceGroup : IDialogueItem`
           * This seems to do stuff regarding choices/timed choices
           * Also, stops the _voice_
             `AudioManager.Instance.StopVoice(this.voice);`
           **Does StopVoice actually stop the sound from playing?**



                          |
                          |
                          v

DialogueUI.StartLine


- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -



### `DatabaseDialogue.cs` has the contents from `Settings` tab in `Dialogue`

1. Set default from the `Settings` tab
2. The `typewriter effect` instantiated here






























































- - - - - - - - - - - - - - - - -




- - - - - - - - - - - - - - - - -


### The tabs for each dialogue

**Regular Dialogue**
 [DialogueItemTextEditor.cs]: Assets\Plugins\GameCreator\Dialogue\Editor\DialogueItems
  + "Message"
   - OnInspectorGUI() -> PaintOptionMessage()
    * PaintOptionMessage() -> EditorGUILayout.BeginVertical()
    * PaintOptionMessage() -> this.PaintContentTab()   <------IDialogueItemEditor.cs
    * PaintOptionMessage() -> EditorGUILayout.Space()
    * PaintOptionMessage() -> this.PaintAfterRunTab()  <------IDialogueItemEditor.cs
  + "Actions"
  + "Conditions"
  + "Settings"
            


- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

## Customizing GameCreator Actor
* _Actor.cs_




------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------


## ANIMATED PORTRAITS with GAME CREATOR
[Link @ 42:11]: https://www.youtube.com/watch?v=J_h-R5vPbGs
[Using the Canvas]: https://www.youtube.com/watch?v=VHFJgQraVUs
[Crating Raw Image on Panel within Canvas @ 42:10]: https://www.youtube.com/watch?v=J_h-R5vPbGs
[GC Actions Used]: Set_active & Display_3D_Model_On_Canvas


- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

  * [ ] Set an **AnimatedPortrait** Layer to use
 
  * [ ] Set an **Scale of the `Prefab`** that will be used as the _animated portaits_
        appropriately
       - Maybe set it to _X=100  Y=100_

  * [ ] Maybe store everything in an `Empty Game Object`
   + **Set Layer of this to `AnimatedPortrait`!!!**

- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

1. Creating the **Canvas**
  + **Set Layer of this to `UI`!!!**
  
  + Right click in `Hierarchy` -> UI -> Canvas
   - Set `Render Mode` to _Screen Space - Overlay_
   - Set `UI Scale Mode` to _Scale With Screen Size_
   - Set `Reference Resolution` to _X: 1920  Y: 1080_
   - Set `Match` scroll ball all the way to the right to _Height_
    * (should say `1` on the right of the scroll bar)

- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

2. Creating the **Panel**
  + **Set Layer of this to `AnimatedPortrait`!!!**


  + Right click the **Canvas**  -> UI -> Panel
  
   - Make this `Panel` completely _transparent_
    * Click the `Color` Section
    * Set the `A` scroll option all the way _to the left_ 
  
   - Click the `Anchor Preset` icon and set it to _Bottom Left_
    * It should be the icon to the left of the _PosX & Width_
    * Set `Pos X, Pos Y, & Pos Z_ to` _0_
    * Set `Width` and `Height` to _600_
    * Set `Pivot`'s _X_ and _Y_ to _0_
   
   
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

3. Creating the **Raw Image**
  + **Set Layer of this to `AnimatedPortrait`!!!**
  
  + _Make sure it's NOT ENABLED by default_ (it'll get enabled as an action)
  + Remember to use the `Set active` action when enabling this _Raw Image_ 

  + Right click the **Panel**  -> UI -> Raw Image
   - Click the `Anchor Preset` and set it to _Bottom Left_
    * It should be the icon to the left of the _PosX & Width_
   - Set `Pos X, Pos Y, & Pos Z_ to` _0_
   - Set `Width` and `Height` to _600_
   - Set `Pivot`'s _X_ and _Y_ to _0_
   
  + **This is the raw image you'll drag into the Action to** `Display 3D Model On Canvas`

- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

4. Make sure the `Prefabs` that will be the _animated portraits are..._
  + **Set Layer of this to `UI`!!!**

- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

5. When using the `Display 3D Model on Canvas` action:
  + **Set `Image Layer of Model` section of action to `UI`!!!**
  
  + Note that the `Display 3D Model on Canvas` action is part the **UI Component** asset from
    _Pivec Labs_

  + You may need to change the `Scale of the Prefab` that will be used as the
    _animated portrait_ (example: X=100 & Y=100)
    
  + You may need to _play around_ with the `Size of Model`, `Reposition Model`, & `Reposition Camera`
    * **Alternatively:**                   _Object Size_,   _Center Model_,     & _Center Camera_
   - Mostly      ->      `Reposition Model` & `Size of Model`
    * **Alternatively:** _Center Model_     & _Object Size_
   - _Example:_
    * Reposition Model / Center Model: 8.5
    * Size of Model    / Object Size:  11.9


- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -


------------------------------------------------------------------------------------------------------------


## Animated Portraits - More Stuff

**This should match the Dialogue Prefab, but NameBox should be bigger than original**
* _Left_, _Height_, & _PosY_ will the main variables (maybe _Right_ as well)

1. Animated `Dialogue Boxes` in _Dialogue_
  + **Set Layer of this to `AnimatedPortrait`!!!**
  
  + Right click the **Canvas**  -> UI -> **Panel**

   - Make this `Panel` completely _transparent_
    * Click the `Color` Section
    * Set the `A` scroll option all the way _to the left_ 
  
   - Click the `Anchor Preset` icon and set it to _Stretch Stretch_
    * Set `Left`  to _700_ and `Top` & `PosZ` to _0_
    * Set `Right` to _100_ and `Bottom` to _0_
    * Set `Pivot`'s _X_ and _Y_ to _0.5_



2. Animated `Name Box` in _Dialogue_
  + **Set Layer of this to `AnimatedPortrait`!!!**
  + _Make sure it's NOT ENABLED by default_ (it'll get enabled as an action)
  + Remember to use the `Set active` action when enabling this _Raw Image_ 
  + Right click the **Panel**  -> UI -> **Raw Image**
  
   - Click the `Anchor Preset` icon and set it to _Bottom Stretch_
    * Set `Pivot`'s _X_ to _0.5_
    * Set `Pivot`'s _Y_ to _0_
   
    * Set `Left`   to _-20_ <--- this will be different from original dialogue prefab
    * Set `Right`  to _900_ (maybe change this as well _make it bigger to better fit_)
    * Set `Height` to _100_ <--- this will be different from original dialogue prefab
    
    * Set `PosY` to _200_   <--- this will be different from original dialogue prefab
    * Set `PosZ`  to _0_ 
    
    


3. Animated `Message Box` in _Dialogue_
  + **Set Layer of this to `AnimatedPortrait`!!!**
  + _Make sure it's NOT ENABLED by default_ (it'll get enabled as an action)
  + Remember to use the `Set active` action when enabling this _Raw Image_ 
  + Right click the **Panel**  -> UI -> **Raw Image**

   - Click the `Anchor Preset` icon and set it to _Bottom Stretch_
    * Set `Pivot`'s _X_ to _0.5_
    * Set `Pivot`'s _Y_ to _0_
   
    * Set `Left`   to _0_
    * Set `Right`  to _0_
    * Set `Height` to _198.1818_
    
    * Set `PosY`  to _0_
    * Set `PosZ`  to _0_ 
    
    
    
------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------





# ARCHIVE
```

3. I made an `Animated Portraits` Object
  + For `LEFT_PANEL`, `RIGHT_PANEL`, `MAJOR-LEFT_PANEL`, & `MAJOR-RIGHT_PANEL`
   - I made and attached a component called `RepositionRawImage_AddComponentToPanel.cs`
    * _Drag & Drop_ the corresponding **Raw Image**
    * _Drag & Drop_ the **parent Canvas**
    * _Drag & Drop_ the **Panel that this script is attached to**
```

