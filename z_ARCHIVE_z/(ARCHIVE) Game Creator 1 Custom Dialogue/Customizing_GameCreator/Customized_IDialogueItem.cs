namespace GameCreator.Dialogue
{
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GameCreator.Core;
    using GameCreator.Localization;
    using GameCreator.Variables;


    // These are libraries I'm importing to draw the animated portrait on the rawimage; tagline: l33tkim
    using UnityEditor;         //library; tagline: l33tkim
    using UnityEngine.Events;  //library; tagline: l33tkim
    using UnityEngine.UI;      //library; tagline: l33tkim
    using UnityEngine.Audio;   //library; tagline: l33tkim
    using UnityEngine.Video;   //library; tagline: l33tkim


    public class IDialogueItem : GlobalID
    {
        protected const float TIME_SAFE_OFFSET = 0.1f;
        protected static readonly Regex REGEX_GLOBAL = new Regex(@"global\[[a-zA-Z0-9_-]+\]");

        public enum ExecuteBehaviour
        {
            Simultaneous,
            DialogueBeforeActions,
            ActionsBeforeDialogue
        }

        public enum AfterRunBehaviour
        {
            Continue,
            Exit,
            Jump
        }

        // PROPERTIES: This is for the draw on raw image action --------------------------------------

        //public LayerMask objectImageLayer;
        public int imageLayerIndex = 0; // this index will point to which layer is to be selected

        [Range(1f, 100f)]
        public float objectSize = 11.9f; //this.spscale = this.serializedObject.FindProperty("objectSize");
                                        //scale, new GUIContent("Size of Model"));
        [Range(0f, 100f)]
        public float centerModel = 8.5f; //centerModel, new GUIContent("Reposition Model")
        [Range(-1000f, 1000f)]
        public float centerCamera = 0.0f; //centerCamera, new GUIContent("Reposition Camera")

        // PROPERTIES: ----------------------------------------------------------------------------

        public Dialogue dialogue;
        public IDialogueItem parent;
        public List<IDialogueItem> children;

        [LocStringBigText]
        public LocString content = new LocString("");
        public AudioClip voice;
        public bool autoPlay = false;
        public float autoPlayTime = 3.0f;

        public Actor actor;
        public int actorSpriteIndex = 0;
        public int actorSpriteIndex2 = 1;  //the INDEX towards the 2ND PORTRAIT in `actor`;      tagline: l33tkim
        public GameObject idlePortrait;    //idle   portrait of ANIMATED PORTRAIT; tagline: l33tkim
        public GameObject talkingPortrait; //taling portrait of ANIMATED PORTRAIT; tagline: l33tkim
        public GameObject rawImage;        //the RAW IMAGE that will hold the ANIMATED PORTRAIT; tagline: l33tkim
        //public GameObject rawImage2;        //the RAW IMAGE that will hold the ANIMATED PORTRAIT; tagline: l33tkim

        public int numOfDrawCalls = 0;    //count how may time DrawAnimatedPortraitOnRawImage() is called;   tagline: l33tkim
        public TargetGameObject actorTransform = new TargetGameObject();

        public AfterRunBehaviour afterRun = AfterRunBehaviour.Continue;
        public IDialogueItem jumpTo;

        public ExecuteBehaviour executeBehavior = ExecuteBehaviour.Simultaneous;
        public IActionsList actionsList;
        public IConditionsList conditionsList;

        public bool overrideDefaultConfig = false;
        public DatabaseDialogue.ConfigData config = new DatabaseDialogue.ConfigData();

        // VIRTUAL METHODS: -----------------------------------------------------------------------

        public virtual string GetContent()
        {
            StringBuilder text = new StringBuilder(this.content.GetText());
            bool matchSuccess = true;
            while (matchSuccess)
            {
                Match match = REGEX_GLOBAL.Match(text.ToString());
                if (matchSuccess = match.Success)
                {
                    int sIndex = match.Value.IndexOf('[');
                    int eIndex = match.Value.IndexOf(']');
                    string variable = match.Value.Substring(sIndex + 1, eIndex - sIndex - 1);

                    object result = VariablesManager.GetGlobal(variable);
                    text.Remove(match.Index, match.Length);
                    text.Insert(match.Index, result == null ? "" : result.ToString());
                }
            }
            //Debug.Log("IDialogueItem.cs:GetContent() -> " + text.ToString()); //debug line when text gets called; tagline: l33tkim
            return text.ToString();
        }

        public virtual IDialogueItem[] GetNextItem()
        {
            return null;
        }

        protected virtual IEnumerator RunItem()
        {
            yield break;
        }

        public virtual bool CanHaveParent(IDialogueItem parent)
        {
            return true;
        }

        // PUBLIC METHODS: ------------------------------------------------------------------------

        public List<int> GetChildrenIDs()
        {
            List<int> listIDs = new List<int>();
            if (this.children == null) return listIDs;

            for (int i = 0; i < this.children.Count; ++i)
            {
                listIDs.Add(this.children[i].GetInstanceID());
            }

            return listIDs;
        }

        public IEnumerator Run()
        {
            string gid = this.GetID();
            this.dialogue.information.revisits[gid] = true;

            switch (this.executeBehavior)
            {
                case ExecuteBehaviour.Simultaneous:
                    if (this.actionsList != null) this.actionsList.Execute(gameObject, null);
                    yield return this.RunItem();
                    break;

                case ExecuteBehaviour.ActionsBeforeDialogue:
                    if (this.actionsList != null) yield return this.actionsList.ExecuteCoroutine(gameObject, null);
                    yield return this.RunItem();
                    break;

                case ExecuteBehaviour.DialogueBeforeActions:
                    yield return this.RunItem();
                    if (this.actionsList != null) yield return this.actionsList.ExecuteCoroutine(gameObject, null);
                    break;
            }
            
        }

        public virtual bool CheckConditions()
        {
            if (this.conditionsList == null) return true;
            return this.conditionsList.Check(gameObject);
        }

        public bool IsRevisit()
        {
            string gid = this.GetID();
            return (
                this.dialogue.information.revisits.ContainsKey(gid) &&
                this.dialogue.information.revisits[gid] == true
            );
        }

        // PROTECTED METHODS: ---------------------------------------------------------------------

        protected DatabaseDialogue.ConfigData GetConfigData()
        {
            DatabaseDialogue.ConfigData defaultConfig = DatabaseDialogue.Load().defaultConfig;
            DatabaseDialogue.ConfigData result = new DatabaseDialogue.ConfigData(defaultConfig);

            if (this.dialogue.overrideConfig)
            {
                if (this.dialogue.config.dialogueSkin != null)
                {
                    result.dialogueSkin = this.dialogue.config.dialogueSkin;
                }

                result.skipKey = this.dialogue.config.skipKey;
                result.secondSkipKey = this.dialogue.config.secondSkipKey;
                result.revisitChoiceOpacity = this.dialogue.config.revisitChoiceOpacity;

                result.enableTypewriterEffect = this.dialogue.config.enableTypewriterEffect;
                result.charactersPerSecond = this.dialogue.config.charactersPerSecond;
            }

            if (this.overrideDefaultConfig)
            {
                if (this.config.dialogueSkin != null) result.dialogueSkin = this.config.dialogueSkin;

                result.skipKey = this.config.skipKey;
                result.secondSkipKey = this.config.secondSkipKey;
                result.revisitChoiceOpacity = this.config.revisitChoiceOpacity;

                result.enableTypewriterEffect = this.config.enableTypewriterEffect;
                result.charactersPerSecond = this.config.charactersPerSecond;
            }

            return result;
        }

        protected IEnumerator RunShowText()
        {

            DatabaseDialogue.ConfigData configData = this.GetConfigData();

            //Debug.Log("IDialogueItem.cs -> TYPEWRITER EFFECT SHOULD HAVE STARTED"); // tagline: l33tkim
            DialogueUI.StartLine(this, configData); //starts the typewriter effect; tagline: l33tkim

            if (this.voice != null) AudioManager.Instance.PlayVoice(this.voice, 0f); //this is where the voice is played; tagline: l33tkim
            float textInitTime = Time.time;

            WaitForSeconds waitForSeconds = new WaitForSeconds(TIME_SAFE_OFFSET);
            yield return waitForSeconds;


            // =============================================================================================
            // THIS IS WHERE THE TYPE WRITER EFFECT STARTS =================================================
            // =============================================================================================


            yield return new WaitUntil(() =>
            {
                if (this.dialogue.IsStoppingDialogue()) 
                { 
                    return true;
                }

                if (Input.GetKeyUp(configData.skipKey) || Input.GetKeyUp(configData.secondSkipKey))
                {
                    if (configData.enableTypewriterEffect && DialogueUI.IsTypeWriting())
                    {
                        DialogueUI.CompleteTypeWriting();
                        return false;
                    }

                    return true;
                }

                bool timeout = Time.time - textInitTime > this.autoPlayTime;
                if (this.autoPlay && timeout) 
                { 
                    return true; 
                }

                return false;
            });
            
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //this for drawing the animated portrait on the Raw Image ///////////////////////////////////////////////////////////////////////////; tagline: l33tkim
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //REMEMBER THAT `targetRawImage` is `rawImage` here
        public GameObjectProperty targetModel = new GameObjectProperty();

        //private variables that will be used
        private LightType objectLight;


        //private KeyCode selectedKey = KeyCode.None; //assigned but never used

        private bool modelPosition;
        private Vector3 mPosition;
        private Vector3 lPosition;
        [Range(0f, 40f)]
        private float lightIntensity = 5f;
        private Color lightColour = Color.white;


        RenderTexture renderTexture;
        RectTransform rt;
        RawImage img;
        private Camera targetCamera;
        private GameObject imageObject;
        private Transform imageObjectTransform;
        private Vector3 axis = new Vector3(0, 1f, 0);

        private Light cameraLight;


        private bool invertZ = false;
        private int invert;



        public void EnableRawImage()
        {
            if (this.rawImage != null)
            {
                this.rawImage.SetActive(true); // this takes the global variable i made taking the raw image and setting it ACTIVE
                //Debug.Log("IDialogueItem.cs -> RawImage for the animated portrait is ENABLED :) = = = = = = = = =");
            }
            else
            {
                Debug.Log("IDialogueItem.cs -> rawImage is NULL in IDialogueItem:EnableRawImage(); MAKE SURE TO DRAG AND DROP THE raw image INTO THE DIALOGUE UI!!!");
            }

        }
        public void DisableRawImage()
        {
            if (this.rawImage != null)
            {
                this.rawImage.SetActive(false); // this takes the global variable i made taking the raw image and setting it INACTIVE
                //Debug.Log("IDialogueItem.cs -> RawImage for the animated portrait is DISABLED :|  = = = = = = = = =");
            }
            else
            {
                Debug.Log("IDialogueItem.cs -> rawImage is NULL in IDialogueItem:DisableRawImage(); MAKE SURE TO DRAG AND DROP THE raw image INTO THE DIALOGUE UI!!!");
            }
        }

        public void DrawTalkingPortraitOnRawImage()
        {
            //Debug.Log("IDialogueItem -> Talking");
            this.DrawAnimatedPortraitOnRawImage(this.talkingPortrait);
        }
        public void DrawIdlePortraitOnRawImage()
        {
            //Debug.Log("IDialogueItem -> Idle");
            this.DrawAnimatedPortraitOnRawImage(this.idlePortrait);
            
        }


        public void DrawAnimatedPortraitOnRawImage(GameObject theAnimatedPortrait)
        {
            if(theAnimatedPortrait == null || this.rawImage == null)
            {
                Debug.Log("Either `theAnimatedPortrait` or `rawImage` are NULL. Was this on purpose?");
                return;
            }

            // This is to prevent more than 2 calls to this method to execute (so the idle portrait doesn't keep getting redrawn)
            numOfDrawCalls++; // initially 1 for talking portraits and then 2 for the idle portrait; taking: l33tkim
            if(numOfDrawCalls > 2) // check how many times this method is called
            {
                Debug.Log("IDialogueItem:Draw [DON'T EXECUTE cause `numOfDrawCalls > 2`]");
                return;
            }


            //Make sure these are null to make sure `theAnimatedPortrait` gets drawn on `rawImage` ;tagline: l33tkim
            imageObject = null;
            renderTexture = null;
            targetCamera = null;
            cameraLight = null;


            GameObject targetObject = this.rawImage; //I'm just going to internally set targetObject to rawImage; tagline l33tkim; //sptargetObject, new GUIContent("Canvas RawImage")
            this.EnableRawImage(); //ENABLE the raw image to draw on; tagline: l33tkim

            //Determine Layer Mask variables
            string layerName = LayerMask.LayerToName(imageLayerIndex); ; // this will store a layer's name (IMPORTANT) tagline: l33tkim
            int layerMask = LayerMask.GetMask(layerName); // this is the integer that represents layerName's mask
            /*
            Debug.Log("LayerMask: " + LayerMask.NameToLayer("Default"));
            Debug.Log("LayerMask: " + LayerMask.NameToLayer("UI"));
            Debug.Log("LayerMask: " + LayerMask.NameToLayer("AnimatedPortrait"));
            */





            // Display 3D Model on the RawImage -------------------------------------------------
            invert = invertZ ? -1 : 1;

            if (renderTexture == null)
            {
                rt = (RectTransform)targetObject.transform;
                renderTexture = new RenderTexture((int)rt.rect.width * 2, (int)rt.rect.height * 2, 24, RenderTextureFormat.ARGB32);
                renderTexture.Create();

            }

            img = targetObject.gameObject.GetComponent<RawImage>();

            if (img != null)
            {
                img.texture = renderTexture;
            }

            if (imageObject == null)
            {
                imageObject = theAnimatedPortrait; //Instantiate(targetModel.GetValue(idlePortrait), rt.position, Quaternion.identity); // the original line
                imageObject.name = "UICloneObject";
                
                imageObjectTransform = imageObject.GetComponent<Transform>();
                imageObjectTransform.localScale = new Vector3(objectSize, objectSize, objectSize);

            }
            
            if (targetCamera == null)
            {
                GameObject camera3d = new GameObject();
                targetCamera = camera3d.AddComponent<Camera>();

                targetCamera.enabled = true;
                targetCamera.allowHDR = true;
                targetCamera.targetTexture = renderTexture;
                targetCamera.orthographic = true;

                targetCamera.name = "UI3DCamera";

                targetCamera.clearFlags = CameraClearFlags.SolidColor;
                targetCamera.backgroundColor = Color.clear;

                targetCamera.gameObject.layer = imageLayerIndex; //this is the int returned from the Layer UI;
                targetCamera.cullingMask = layerMask;            //64; //objectImageLayer.value;
            }

            if (cameraLight == null)
            {
                cameraLight = targetCamera.gameObject.AddComponent<Light>();
                cameraLight.gameObject.layer = imageLayerIndex; //this is the int returned from the Layer UI;
                cameraLight.cullingMask = layerMask;            //64; //objectImageLayer.value;
                cameraLight.type = objectLight;
                cameraLight.intensity = (lightIntensity / 10);
                cameraLight.range = 200;
                cameraLight.color = lightColour;
                cameraLight.bounceIntensity = 1;
            }
            
            Vector3 containerLocalPosition = imageObject.transform.position - targetCamera.transform.position;

            float DesireDistanceFromCamera = 1.0f;
            imageObjectTransform.position = targetCamera.transform.position + (containerLocalPosition * DesireDistanceFromCamera);
            imageObjectTransform.position = new Vector3(imageObject.transform.position.x, imageObject.transform.position.y, imageObject.transform.position.z - centerModel);
            targetCamera.transform.position = new Vector3(imageObject.transform.position.x, (imageObject.transform.position.y + centerCamera), invert);
            imageObjectTransform.rotation = Quaternion.Euler(this.mPosition);

            var position = imageObjectTransform.position + Vector3.up * 5;
            cameraLight.transform.LookAt(position);
            targetCamera.transform.LookAt(position + lPosition);
            targetCamera.Render();






        }





    }
}




//Debug.Log("DialogueItemText.cs -> =====actorSpriteIndex: " + this.actorSpriteIndex);
//Debug.Log("DialogueItemText.cs -> =====actorSpriteIndex2: " + this.actorSpriteIndex2);
//Debug.Log("DialogueItemText.cs -> =====imageLayerIndex: " + this.imageLayerIndex);


//public GameObjectProperty targetModel = new GameObjectProperty();
//new GameObjectProperty();
//Debug.Log("targetObject: "    +  targetObject.name);
//Debug.Log("idlePortrait: "    +  idlePortrait.ToString());
//Debug.Log("talkingPortrait: " +  talkingPortrait.ToString());

//debuglines ; tagline: l33tkim
//public LayerMask objectImageLayer;
//
//RawImage img;
//private Camera targetCamera;
//private GameObject imageObject;
//GameObject prefabPortrait = data.prefab;
//Debug.Log("IDialougeItem.cs -> # of portraits: " + animatedPortraitList.Length);
//Debug.Log("IDialougeItem.cs -> Portrait Name: " + prefabPortrait.name);
//return;

/*
//Get the actor's sprites
ActorSprites animatedPortraits = this.actor.actorSprites;
ActorSprites.Data[] animatedPortraitList = this.actor.actorSprites.data;

int portraitIndex = 1; // the customized line // <--------------------- MAYBE SET THIS TO THE GLOBAL SPRITE INDEX
ActorSprites.Data data = animatedPortraitList[portraitIndex];
ActorSprites.DataType dataType = data.type; //what type of enum? like -> dataType.Sprite or dataType.Prefab
                                            //string name = data.name;
if (dataType == ActorSprites.DataType.Sprite)
{
    imageObject = new GameObject("SpriteAnimatedPortrait");
    SpriteRenderer renderer = imageObject.AddComponent<SpriteRenderer>();
    renderer.sprite = data.sprite;
    Debug.Log("AnimatedPortrait: Sprite is being converted into a Prefab GameObject (does it work?) : IDialogueItem.cs");
}
else if (dataType == ActorSprites.DataType.Texture)
{
    //imageObject = data.texture; // the customized line
    Debug.Log("AnimatedPortrait: TEXTRUE SPRITES WILL NOT BE ACCEPTED BY THIS MODEL: IDialogueItem.cs!!!!!!!!!!!!!!!!!!!!!!!!!");
    return;
}
else
{
    //Debug.Log("AnimatedPortrait: Prefab");
    imageObject = data.prefab; // the customized line
}
*/

//Iterating over the differnt portraits in an actor; tagline: l33tkim
/*
//Get the actor's sprites
ActorSprites animatedPortraits = this.actor.actorSprites;
ActorSprites.Data[] animatedPortraitList = this.actor.actorSprites.data;

foreach (ActorSprites.Data data in animatedPortraitList)
{
    ActorSprites.DataType dataType = data.type; //what type of enum? like -> dataType.Sprite or dataType.Prefab
    string name = data.name;

    if(dataType == ActorSprites.DataType.Sprite)
    {
        Debug.Log("SPRITE animated_portrait_type - IDialogueItem:DrawAnimatedPortraitOnRawImage()");
    }
    else if (dataType == ActorSprites.DataType.Texture)
    {
        Debug.Log("TEXTURE animated_portrait_type - IDialogueItem:DrawAnimatedPortraitOnRawImage()");
    }
    else if (dataType == ActorSprites.DataType.Prefab)
    {
        Debug.Log("PREFAB animated_portrait_type - IDialogueItem:DrawAnimatedPortraitOnRawImage()");
    }

}
*/