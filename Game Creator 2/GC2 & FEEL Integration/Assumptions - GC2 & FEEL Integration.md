1. There will only be one Feedback on `MMFPlayer` when playing
	* Zero feedbacks before and after the playing
	* When a _custom_ `Feedback` is added and played from my _custom Instruction_, it will be immediately removed

2. That a `Player` Tag exists 

3. `FEELGameObject`:
	* That an `FEELGameObject` Tag exists
	* Assumes only 1 `GameObject` will be playing a FEEL effect at a given frame
	* This particular `GameObject` that is NOT the player that will have the effects added

4. Make sure the `Main Camera` has
	* CinemachineVirtualCamera
	* Universal Additional Camera Data (Script)

