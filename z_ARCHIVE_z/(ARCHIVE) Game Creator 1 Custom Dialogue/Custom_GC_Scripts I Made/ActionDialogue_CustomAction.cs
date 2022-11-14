/*
 Based on these CS files:
   * _ActionDisplayCanvasModel.cs_
   * _ActionSetActive.cs_
   * _ActionPlaySound3D.cs_   -> maybe switch to ActionPlaySound.cs_
*/

namespace GameCreator.UIComponents
{
	using System.Collections;
	using System.Collections.Generic;

	//Libraries that Game Creator Seems to use
	using GameCreator.Core;
	using GameCreator.Variables;

	using UnityEngine;
	using UnityEditor;
	using UnityEngine.Events;
	using UnityEngine.UI;
	using UnityEngine.Audio;
	using UnityEngine.Video;

	// Libraries that MountainFeedback (FEEL) uses
	//using MoreMountains.Feedbacks
	//using Random = UnityEngine.Random;
	//using UnityEngine.Assertions;


	/*
	 * The goal of this custom script is to:
	 *		1. Enable the raw image (targetRawImage)
	 *		2. Draw the provided model (targetModel) and draw it on the raw image (targetRawImage)
	 *		3. Then play a sound (audioClip)
	 *		4. TODO: While the sound is playing have a talking & blinking raw model, then replace it with just
	 *		         a blinking model when talking is done.
	*/

	/*  //YOU MAY WANT TO IMPORT THE ACTOR GC OBJECT TO DOUBLE CHECK VARIABLES
	 
	//  Get list of all audio that is currently playing: https://answers.unity.com/questions/546915/how-to-list-all-playing-audio-clips.html

	 using System;
	 using UnityEngine;
 
	 public class PlayingList : MonoBehaviour
	 {
 
	 AudioSource[] sources;
             
				 void Start () {
             
					  //Get every single audio sources in the scene.
					 sources = GameObject.FindSceneObjectsOfType(typeof(AudioSource)) as AudioSource[];
                 
				 }
         
				 void Update () {
                         
					 // When a key is pressed list all the gameobjects that are playing an audio
					 if(Input.GetKeyUp(KeyCode.A))
					 {
                     
						 foreach(AudioSource audioSource in sources)
						 {
							 if(audioSource.isPlaying) Debug.Log(audioSource.name+" is playing "+audioSource.clip.name);
						 }
						 Debug.Log("---------------------------"); //to avoid confusion next time
						 Debug.Break(); //pause the editor
                     
					 }
				 }
	 }
	*/


	/* 
	//  Checking if a specific audio source is playing: https://docs.unity3d.com/ScriptReference/AudioSource-isPlaying.html

	// When the audio component has stopped playing, play otherClip
	using UnityEngine;
	using System.Collections;

	public class ExampleClass : MonoBehaviour
	{
		public AudioClip otherClip;
		AudioSource audioSource;

		void Start()
		{
			audioSource = GetComponent<AudioSource>();
		}

		void Update()
		{
			if (!audioSource.isPlaying)
			{
				audioSource.clip = otherClip;
				audioSource.Play();
			}
		}
	}

	//If a specific audio clip is playing: https://answers.unity.com/questions/963324/if-audiosource-is-playing-a-specific-sound.html

	 private AudioClip clip, currentClip;
 
	private void PlayClip(AudioClip clip)
     {
         if (currentClip != clip) //checks if the provided clip is still playing
         {
             src.Stop(); //if not, it stops playback and changes the clip
             currentClip = clip;
             src.PlayOneShot(currentClip);
         }
         else
         {//otherwise, it checks if the src is currently playing the audioclip and plays it if it isn't
             if (!src.isPlaying)
             {
                 src.PlayOneShot(currentClip);
             }
         }
     }

	*/


	[AddComponentMenu("")]
	public class ActionDialogue_CustomActions : IAction
	{

		// TODO !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		//   + Drag in all the RAW_IMAGES that need to be SET TO INACTIVE before this dialogue starts
		//   + Since Game Creator allows my to copy and paste a component, this shouldn't be a big deal,
		//     since i just do i once and copying and pasting will automatically target those raw images
		/*//Some examples of what I could be using
		public TargetGameObject leftAnimatedPortraitRawImage = new TargetGameObject();
		public TargetGameObject rightAnimatedPortraitRawImage = new TargetGameObject();

		public TargetGameObject leftPlayerChoiceDialogueRawImage = new TargetGameObject();
		public TargetGameObject rightPlayerChoiceDialogueRawImage = new TargetGameObject();

		public TargetGameObject leftMAJORAnimatedPortraitRawImage = new TargetGameObject();
		public TargetGameObject rightMAJORAnimatedPortraitRawImage = new TargetGameObject();
		public TargetGameObject centerMAJORAnimatedPortraitRawImage = new TargetGameObject();
		*/

		// "SetActive for RawImage" is just directly done in `InstantExecute`
		// The `Display 3D Movel On Canvas` Variables ==============================================================================
		public TargetGameObject targetRawImage = new TargetGameObject();



		// Draw 3d Object on the RawImage  - from ActionDisplayCanvasModel.cs

		////Callsign: 1337 - I'm just going to internally set this to targetRawImage
		private GameObject targetObject; //sptargetObject, new GUIContent("Canvas RawImage")

		public GameObjectProperty targetModel = new GameObjectProperty(); //sptargetModel, new GUIContent("3D Model")

		public LayerMask objectImageLayer;
		private LightType objectLight;

		private bool spinObject;
		private bool dragObject;
		private bool mousedrag = true;
		private bool keydrag;
		private bool outlineObject;
		private bool outlineObjectKey;
		//private KeyCode selectedKey = KeyCode.None; //assigned but never used


		private bool xAxis;
		private bool yAxis;
		private bool xAxisAuto;
		private bool yAxisAuto;

		private bool modelPosition;
		private Vector3 mPosition;
		private Vector3 lPosition;

		[Range(0f, 40f)]
		private float lightIntensity = 5f;

		private Color lightColour = Color.white;

		[Range(1f, 100f)]
		public float objectSize = 4.0f; //this.spscale = this.serializedObject.FindProperty("objectSize");
										//scale, new GUIContent("Size of Model"));


		[Range(0.5f, 20f)]
		private float autoSpeed = 1f;

		[Range(1f, 30.0f)]
		private float dragSpeed = 10f;

		[Range(0f, 100f)]
		public float centerModel = 0.0f; //centerModel, new GUIContent("Reposition Model")

		[Range(-1000f, 1000f)]
		public float centerCamera = 0.0f; //centerCamera, new GUIContent("Reposition Camera")

		[Range(0.1f, 10.0f)]
		private float outlineWidth;
		private Color outlineColour;

		RenderTexture renderTexture;
		RectTransform rt;
		RawImage img;
		private Camera targetCamera;
		private GameObject imageObject;
		private Transform imageObjectTransform;

		private Vector3 axis = new Vector3(0, 1f, 0);
		float Rotation;
		private Light cameraLight;
		private Vector3 speed = Vector3.zero;
		private Vector3 averageSpeed = Vector3.zero;

		private Vector2 lastMousePosition = Vector2.zero;

		//private float RotationSpeed = 10f; //assigned but never used


		//private bool RotateX = true;
		private bool InvertX = false;
		private int _xMultiplier
		{
			get { return InvertX ? -1 : 1; }
		}


		//private bool RotateY = true; //assigned but never used
		private bool InvertY = false;
		private int _yMultiplier
		{
			get { return InvertY ? -1 : 1; }
		}

		private bool invertZ = false;
		private int invert;






		// The 3D Audio Variables =============================================================================================
		public enum AudioMixerType
		{
			None,
			Custom,
			DefaultSoundMixer
		}

		[Space] [Space] [Space] [Space] [Space] public AudioClip audioClip;
		public AudioMixerType audioMixer = AudioMixerType.DefaultSoundMixer;
		[Indent] public AudioMixerGroup mixerGroup;

		[Range(0f, 10f)]
		public float fadeIn;

		[Range(0.0f, 1.0f)]
		public float volume = 1f;

		[Range(0.0f, 1.0f)]
		public float spatialBlend = 0.85f;
		public NumberProperty pitch = new NumberProperty(1.0f);
		public TargetPosition position = new TargetPosition(TargetPosition.Target.Player);


		//Debug integer ==========================================================================================================
		[Space] [Space] [Space] [Space] [Space] public int example = 0;








		public override bool InstantExecute(GameObject target, IAction[] actions, int index)
		{
			//Variables I'm using
			//  1. TargetGameObject targetRawImage = new TargetGameObject();
			//        |
			//		  v "targetrawimage will be stored into targetObject internally"
			//	     GameObject targetObject; //sptargetObject, new GUIContent("Canvas RawImage")
			//  
			//  2. GameObjectProperty targetModel = new GameObjectProperty(); //sptargetModel, new GUIContent("3D Model");
			//  3. float objectSize = 4.0f;
			//  4. float centerModel = 0.0f;
			//  5. float centerCamera = 0.0f;

			//RawImage - ENABLE the target Raw Image-------------------------------------------
			//  "SetActive for RawImage"
			GameObject theRawImage = this.targetRawImage.GetGameObject(target);
			if (theRawImage != null) theRawImage.SetActive(true);

			////Callsign: 1337 - I'm just going to internally set targetObject to targetRawImage
			targetObject = theRawImage; //sptargetObject, new GUIContent("Canvas RawImage")


			//Play 3DSound --------------------------------------------------------------------
			AudioMixerGroup mixer = null;
			switch (this.audioMixer)
			{
				case AudioMixerType.DefaultSoundMixer:
					mixer = DatabaseGeneral.Load().soundAudioMixer;
					break;

				case AudioMixerType.Custom:
					mixer = this.mixerGroup;
					break;
			}

			AudioManager.Instance.PlaySound3D(
				this.audioClip,
				this.fadeIn,
				this.position.GetPosition(target),
				this.spatialBlend,
				this.pitch.GetValue(target),
				this.volume,
				mixer
			);


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

				imageObject = Instantiate(targetModel.GetValue(target), rt.position, Quaternion.identity);
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
				targetCamera.gameObject.layer = layermask_to_layer(objectImageLayer.value);
				targetCamera.cullingMask = objectImageLayer.value;
			}
			if (cameraLight == null)
			{
				cameraLight = targetCamera.gameObject.AddComponent<Light>();

				cameraLight.gameObject.layer = layermask_to_layer(objectImageLayer.value);
				cameraLight.cullingMask = objectImageLayer.value;
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

			if (!targetObject.gameObject.GetComponent<Outline>())
				targetObject.gameObject.AddComponent<Outline>();
			if (!targetObject.gameObject.GetComponent<MouseOver>())
				targetObject.gameObject.AddComponent<MouseOver>();

			targetObject.gameObject.GetComponent<Outline>().effectDistance = new Vector2(outlineWidth, -outlineWidth);
			targetObject.gameObject.GetComponent<Outline>().effectColor = outlineColour;
			targetObject.gameObject.GetComponent<Outline>().enabled = false;

			if (outlineObject == true)
			{
				targetObject.gameObject.GetComponent<MouseOver>().outlineObject = true;
			}
			else
			{
				targetObject.gameObject.GetComponent<MouseOver>().outlineObject = false;
			}

			//RawImage - DISABLE the target Raw Image------------------------------------------
			//  "SetActive for RawImage"
			//theRawImage = this.targetRawImage.GetGameObject(target);
			//if (theRawImage != null) theRawImage.SetActive(false);


			//Print the debug line-------------------------------------------------------------
			//It should be the `Example` integer in the interace
			Debug.Log(this.example);
			return true;
		}


		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		// ActionDisplayCanvasModel Methods START +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
		{
			return base.Execute(target, actions, index);
		}

		public static int layermask_to_layer(LayerMask layerMask)
		{
			int layerNumber = 0;
			int layer = layerMask.value;
			while (layer > 0)
			{
				layer = layer >> 1;
				layerNumber++;
			}
			return layerNumber - 1;
		}

		void Update()
		{
			if ((imageObject != null) && (spinObject == true))
			{
				float xAuto = 0;
				float yAuto = 0;
				if (xAxisAuto == true)
				{
					xAuto = autoSpeed;
				}
				if (yAxisAuto == true)
				{
					yAuto = autoSpeed;
				}
				if (imageObject != null)
					imageObject.transform.Rotate(yAuto, xAuto, 0);
			}

			if ((imageObject != null) && (dragObject == true) && (mousedrag == true))
			{
				bool overObj = targetObject.gameObject.GetComponent<MouseOver>().overObject;
				if (overObj == true)
				{
					if (lastMousePosition == Vector2.zero) lastMousePosition = Input.mousePosition;

					if (Input.GetMouseButton(0))
					{
						var mouseDelta = ((Vector2)Input.mousePosition - lastMousePosition) * 100;
						mouseDelta.Set(mouseDelta.x / Screen.width, mouseDelta.y / Screen.height);
						speed = new Vector3(-mouseDelta.x * _xMultiplier, mouseDelta.y * _yMultiplier, 0);
					}
					if (speed != Vector3.zero)
					{
						if (xAxis == true)
						{
							imageObject.transform.Rotate(0, speed.x * dragSpeed, 0);
						}
						if (yAxis == true)
						{
							imageObject.transform.Rotate(speed.y * dragSpeed, 0, 0);
						}
					}
					lastMousePosition = Input.mousePosition;
				}
			}
			if ((imageObject != null) && (dragObject == true) && (keydrag == true))
			{
				bool overObj = this.targetObject.gameObject.GetComponent<Outline>().enabled;
				if (overObj == true)
				{
					if (Input.GetKey(KeyCode.LeftArrow))
					{
						if (xAxis == true)
						{
							imageObject.transform.Rotate(Vector3.up * 10 * dragSpeed * Time.deltaTime);
						}
						if (yAxis == true)
						{
							imageObject.transform.Rotate(Vector3.right * 10 * dragSpeed * Time.deltaTime);
						}
					}
					if (Input.GetKey(KeyCode.RightArrow))
					{
						if (xAxis == true)
						{
							imageObject.transform.Rotate(Vector3.down * 10 * dragSpeed * Time.deltaTime);
						}
						if (yAxis == true)
						{
							imageObject.transform.Rotate(Vector3.left * 10 * dragSpeed * Time.deltaTime);
						}
					}
				}
			}
		}
		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		// ActionDisplayCanvasModel Methods END +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

#if UNITY_EDITOR
        public static new string NAME = "Custom/ActionDialogue_CustomActions";
#endif
	}
}
