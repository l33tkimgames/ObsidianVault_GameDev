using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MoreMountains.Feedbacks;
using MoreMountains.Tools;


namespace FEELGC2_CustomFeedbacks
{
    // Static class with static methods that return customized `MMF_Feedbacks`s
    public static class CustomFeedbacks
    {
        /*  // This function will generate custom `MMF_Feeback` -> JumpAndScale
            *  This method will get the corresponding `MMF_Feedback` based on the value of `searchLabel`.
            *
            *  feedbackLabel [string]: the string value that represents this feedback's `Label`.
            *  TargetObject [GameObject]: The Target GameObject that FEEL will add its stuff on.
            *
            *  Returns: Customized JumpAndScale `MMF_Feedback` object.
        */
        public static MMF_Feedback JumpAndScale(string feedbackLabel, 
                                                GameObject targetObject)
        {
            MMF_Scale scale = new MMF_Scale();
            scale.Label = feedbackLabel; // THIS IS IMPORTANT!!! cause i reference this by the label name later
            scale.AnimateScaleTarget = targetObject.transform; // set `Transform` component
            return scale;
        }

        //----------------------------------------------------------------//
        //----------------------------------------------------------------//
        //----------------------------------------------------------------//


        //---------------------------//
        // Feedback (2) -------------//
        public static MMF_Feedback RotateRight(string feedbackLabel,
                                              GameObject targetObject)
        {
            MMF_Rotation rotation = new MMF_Rotation();
            rotation.Label = feedbackLabel; // THIS IS IMPORTANT!!! cause i reference this by the label name later
            rotation.AnimateRotationTarget = targetObject.transform; // set `Transform` component

            // This is so I'm only rotation horizontally
            rotation.AnimateX = false;
            rotation.AnimateY = true;
            rotation.AnimateZ = false;

            // This makes the rotation smoother
            rotation.AnimateRotationTweenY = new MMTweenType (MMTween.MMTweenCurve.LinearTween);

            return rotation;
        }

        //---------------------------//
        // Feedback (3) -------------//
        public static MMF_Feedback RotateLeft(string feedbackLabel,
                                              GameObject targetObject)
        {
            MMF_Rotation rotation = new MMF_Rotation();
            rotation.Label = feedbackLabel; // THIS IS IMPORTANT!!! cause i reference this by the label name later
            rotation.AnimateRotationTarget = targetObject.transform; // set `Transform` component

            // This is so I'm only rotation horizontally
            rotation.AnimateX = false;
            rotation.AnimateY = true;
            rotation.AnimateZ = false;

            // This makes the rotation smoother
            rotation.AnimateRotationTweenY = new MMTweenType (MMTween.MMTweenCurve.AntiLinearTween);

            return rotation;
        }


        //---------------------------//
        // Feedback (4) -------------//
        public static MMF_Feedback SquashAndStretch(string feedbackLabel,
                                               GameObject targetObject)
        {
            MMF_SquashAndStretch squashAndStretch = new MMF_SquashAndStretch();
            squashAndStretch.Label = feedbackLabel; // THIS IS IMPORTANT!!! cause i reference this by the label name later
            squashAndStretch.SquashAndStretchTarget = targetObject.transform; // set `Transform` component

            // This makes the height of the stretch shorter than the minimum
            float stretchFloat = (float) 1.3;
            squashAndStretch.RemapCurveOne = stretchFloat;

            return squashAndStretch;
        }


        //---------------------------//
        // Feedback (5) -------------//


        //---------------------------//
        // ADD FEEL STUFF HERE 


        //----------------------------------------------------------------//
        //----------------------------------------------------------------//
        //----------------------------------------------------------------//

        /*  /* 
                *  This modify the given `GameObject`'s Y Axis so `targetObject` doesn't phase through ground (hopefully).
                *
                *  TargetObject [GameObject]: The Target GameObject that FEEL will add its stuff on.
                *
                *  Returns: `Vector3` object with the modified Y axis.
        */
        public static Vector3 AdjustYAxis(GameObject targetObject)
        {
            // ...make `targetObject`  jump so it doesn't phase through ground
            //    (the `GameObject` "should" still be in the air by the time the `MMF_Feedback` plays)
            int jumpHeight = 3;
            return new Vector3(targetObject.transform.position.x, 
                               targetObject.transform.position.y + jumpHeight, 
                               targetObject.transform.position.z);
        }
    }
}
