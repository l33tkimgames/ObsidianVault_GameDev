namespace GameCreator.Dialogue
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GameCreator.Core;
    using GameCreator.Localization;
    using GameCreator.Variables;

    [AddComponentMenu("")]
    public class DialogueItemChoiceGroup : IDialogueItem
    {
        public enum TIMEOUT_BEHAVIOR
        {
            FirstChoice,
            RandomChoice,
            SkipChoiceGroup
        }

        // PROPERTIES: ----------------------------------------------------------------------------

        public bool shuffleChoices = false;
        public bool timedChoice = false;
        public NumberProperty timeout = new NumberProperty(5.0f);
        public TIMEOUT_BEHAVIOR timeoutBehavior = TIMEOUT_BEHAVIOR.FirstChoice;

        private float startTime = 0f;
        private bool hasChoicesAvailable = false;
        private bool hasMadeChoice = false;
        private int choiceIndex = -1;

        // OVERRIDE METHODS: ----------------------------------------------------------------------

        protected override IEnumerator RunItem()
        {
            if (this.children.Count <= 0) yield break;

            this.DrawIdlePortraitOnRawImage(); //When the character makes a decision, it should just be an idle image; tagline: l33tkim

            if (!string.IsNullOrEmpty(this.GetContent()))
            {
                //Maybe this just says something like: "What should I say?" and later on before `yield return waitUntil` you'll give the dialogue choices
                Debug.Log("DialogueItemChoiceGroup.cs -> RunItem() - Choice Dialogue line should have just STARTED: '" + this.content.GetText() + "'"); //debug line when text gets called; tagline: l33tkim
                yield return this.RunShowText();
                Debug.Log("DialogueItemChoiceGroup.cs -> RunItem() - Choice Dialogue line should have just FINISHED: '" + this.content.GetText() + "'"); //debug line when text gets called; tagline: l33tkim
            }

            this.hasMadeChoice = false;
            this.choiceIndex = -1;
            this.startTime = Time.time;

            DatabaseDialogue.ConfigData configData = this.GetConfigData();
            this.hasChoicesAvailable = DialogueUI.StartChoices(this, configData);

            WaitUntil waitUntil = new WaitUntil(() =>
            {
                if (this.dialogue.IsStoppingDialogue()) return true;
                if (!this.hasChoicesAvailable) return true;
                if (this.timedChoice && Time.time > this.startTime + this.timeout.GetValue(gameObject))
                {
                    return true;
                }

                return this.hasMadeChoice;
            });

            //This is where I change the UI
            Debug.Log("DialogueItemChoiceGroup.cs -> RunItem() - Choices should now be visible"); //debug line when text gets called; tagline: l33tkim
            yield return waitUntil;
            Debug.Log("DialogueItemChoiceGroup.cs -> RunItem() - Choices should now be NOT be visible"); //debug line when text gets called; tagline: l33tkim

            if (this.voice != null)
            {
                AudioManager.Instance.StopVoice(this.voice);
            }

            Debug.Log("DialogueItemChoiceGroup.cs -> RunItem() - Specific choice should now be visible"); //debug line when text gets called; tagline: l33tkim
            DialogueUI.CompleteLine(this);
            DialogueUI.HideText();
            DialogueUI.HideChoices();
            Debug.Log("DialogueItemChoiceGroup.cs -> RunItem() - Specific choice should NOT BE visible"); //debug line when text gets called; tagline: l33tkim
            this.DisableRawImage(); //once a choice has been made this rawImage is unnecessary; tagline: l33tkim
        }

        public override IDialogueItem[] GetNextItem()
        {
            if (!this.hasChoicesAvailable) return null;
            if (this.timedChoice && !this.hasMadeChoice)
            {
                switch (this.timeoutBehavior)
                {
                case TIMEOUT_BEHAVIOR.FirstChoice:
                    this.hasMadeChoice = true;
                    this.choiceIndex = 0;
                    break;

                case TIMEOUT_BEHAVIOR.RandomChoice:
                    this.hasMadeChoice = true;
                    this.choiceIndex = Random.Range(0, this.children.Count);
                    break;
                }
            }

            if (!this.hasMadeChoice) return null;
            if (this.choiceIndex >= this.children.Count) 
            {
                Debug.LogError("Not enough answers");
                return null;
            }

            DialogueUI.CompleteChoice(this.children[this.choiceIndex]);
            return new IDialogueItem[] { this.children[this.choiceIndex] };
        }

        public override bool CanHaveParent(IDialogueItem parent)
        {
            return base.CanHaveParent(parent);
        }

        // PUBLIC METHODS: ------------------------------------------------------------------------

        public void OnMakeChoice(int choiceIndex)
        {
            this.hasMadeChoice = true;
            this.choiceIndex = choiceIndex;
        }
    }
}
