namespace GameCreator.Dialogue
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GameCreator.Core;
    using GameCreator.Localization;

    [AddComponentMenu("")]
    public class DialogueItemText : IDialogueItem
    {
        // OVERRIDE METHODS: ----------------------------------------------------------------------

        protected override IEnumerator RunItem()
        {
            //Debug.Log("DialogueItemText.cs -> RunItem() - Regular Dialogue line should have just STARTED: '" + this.content.GetText() + "'"); //debug line when text gets called; tagline: l33tkim
            this.DrawTalkingPortraitOnRawImage(); //draw the TALKING animated portrait; tagline: l33tkim
            yield return this.RunShowText(); //somewhere in this method the IDLE animated portrait will be swapped out

            if (this.voice != null)
            {
                AudioManager.Instance.StopVoice(this.voice);
            }

            DialogueUI.CompleteLine(this);
            DialogueUI.HideText();

            this.DisableRawImage(); //DISABLE the second raw image (assuming the first one is already disabled); tagline: l33tkim
            //Debug.Log("DialogueItemText.cs -> RunItem() - Regular Dialogue line should have just FINISHED: '" + this.content.GetText() + "'"); //debug line when text gets called; tagline: l33tkim

            yield break;
        }

        public override IDialogueItem[] GetNextItem()
        {
            if (this.children == null || this.children.Count == 0) return null;
            return this.children.ToArray();
        }

        public override bool CanHaveParent(IDialogueItem parent)
        {
            if (parent.GetType() == typeof(DialogueItemChoiceGroup)) return false;
            return base.CanHaveParent(parent);
        }

    }
}