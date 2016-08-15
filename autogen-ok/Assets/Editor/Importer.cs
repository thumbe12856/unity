using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Animations;

public class Importer : AssetPostprocessor{
	void OnPreprocessModel()
	{
		//if(assetPath.CompareTo("Assets/Resources/Models/mymodel.fbx" == 0))
		if (assetPath.CompareTo ("Assets/Resources/Models/mymodel.fbx") == 0) {
			Debug.Log (assetPath);
				
			ModelImporter imp = assetImporter as ModelImporter;
			imp.animationType = ModelImporterAnimationType.Human;
			//MonoBehaviour.print (imp.animationType);
		} 
		else if (assetPath.CompareTo ("Assets/Resources/Beta/test.fbx") == 0) {
			AnimationClip[] clips;
			clips = new AnimationClip[1];
			clips[0] = Resources.Load("Beta/test@walking",typeof(AnimationClip)) as AnimationClip;
			CreateController ("Assets/Resources/Beta/AnimationControllers/StateMachineTransitions.controller", clips);
		}
	}

	static void CreateController(string path , AnimationClip[] clips) {

		// Creates the controller
		AnimatorController controller = UnityEditor.Animations.AnimatorController.CreateAnimatorControllerAtPath (path);

		var rootStateMachine = controller.layers[0].stateMachine;
		AnimatorState idleState = rootStateMachine.AddState("Idle");
		idleState.motion = clips[0];

		idleState.AddExitTransition (idleState);

		// Add parameters
		/*
		 * controller.AddParameter("TransitionNow", AnimatorControllerParameterType.Trigger);
		controller.AddParameter("Reset", AnimatorControllerParameterType.Trigger);
		controller.AddParameter("GotoB1", AnimatorControllerParameterType.Trigger);
		controller.AddParameter("GotoC", AnimatorControllerParameterType.Trigger);

		// Add StateMachines
		var rootStateMachine = controller.layers[0].stateMachine;
		var stateMachineA = rootStateMachine.AddStateMachine("smA");
		var stateMachineB = rootStateMachine.AddStateMachine("smB");
		var stateMachineC = stateMachineB.AddStateMachine("smC");
		
		// Add States

		var stateA1 = stateMachineA.AddState("stateA1");
		var stateB1 = stateMachineB.AddState("stateB1");
		var stateB2 = stateMachineB.AddState("stateB2");
		stateMachineC.AddState("stateC1");
		var stateC2 = stateMachineC.AddState("stateC2"); // don’t add an entry transition, should entry to state by default
		
		// Add Transitions
		var exitTransition = stateA1.AddExitTransition();
		exitTransition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.If, 0, "TransitionNow");
		exitTransition.duration = 0;
		
		var resetTransition = stateMachineA.AddAnyStateTransition(stateA1);
		resetTransition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.If, 0, "Reset");
		resetTransition.duration = 0;
		
		var transitionB1 = stateMachineB.AddEntryTransition(stateB1);
		transitionB1.AddCondition(UnityEditor.Animations.AnimatorConditionMode.If, 0, "GotoB1");
		stateMachineB.AddEntryTransition(stateB2);
		stateMachineC.defaultState = stateC2;
		var exitTransitionC2 = stateC2.AddExitTransition();
		exitTransitionC2.AddCondition(UnityEditor.Animations.AnimatorConditionMode.If, 0, "TransitionNow");
		exitTransitionC2.duration = 0;
		
		var stateMachineTransition = rootStateMachine.AddStateMachineTransition(stateMachineA, stateMachineC);
		stateMachineTransition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.If, 0, "GotoC");
		rootStateMachine.AddStateMachineTransition(stateMachineA, stateMachineB);	
		*/
	}

}