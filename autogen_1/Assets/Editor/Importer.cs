using UnityEngine;
using System.Collections;
using UnityEditor;

public class Importer : AssetPostprocessor{
	void OnPreprocessModel()
	{
		//if(assetPath.CompareTo("Assets/Resources/Models/mymodel.fbx" == 0))
		if(assetPath.CompareTo("Assets/Resources/Models/mymodel.fbx") == 0){
			Debug.Log(assetPath);
				
			ModelImporter imp = assetImporter as ModelImporter;
			imp.animationType = ModelImporterAnimationType.Human;
			//MonoBehaviour.print (imp.animationType);
		}
	}
}
