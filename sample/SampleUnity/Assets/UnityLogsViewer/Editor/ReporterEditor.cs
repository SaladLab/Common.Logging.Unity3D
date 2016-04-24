﻿using UnityEngine;
using UnityEditor ;
using UnityEditor.Callbacks;

using System.IO;
using System.Collections;



public class MyAssetModificationProcessor : UnityEditor.AssetModificationProcessor
{
    
	[MenuItem("Reporter/Create")]
	public static void CreateReporter()
	{
		GameObject reporterObj = new GameObject();
		reporterObj.name = "Reporter";
		Reporter reporter = reporterObj.AddComponent<Reporter>();
		reporterObj.AddComponent<ReporterMessageReceiver>();
		//reporterObj.AddComponent<TestReporter>();

		reporter.images = new Images();
		reporter.images.clearImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/clear.png", typeof(Texture2D));
		reporter.images.collapseImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/collapse.png", typeof(Texture2D));
		reporter.images.clearOnNewSceneImage= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/clearOnSceneLoaded.png", typeof(Texture2D));
		reporter.images.showTimeImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/timer_1.png", typeof(Texture2D));
		reporter.images.showSceneImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/UnityIcon.png", typeof(Texture2D));
		reporter.images.userImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/user.png", typeof(Texture2D));
		reporter.images.showMemoryImage 	= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/memory.png", typeof(Texture2D));
		reporter.images.softwareImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/software.png", typeof(Texture2D));
		reporter.images.dateImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/date.png", typeof(Texture2D));
		reporter.images.showFpsImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/fps.png", typeof(Texture2D));
		reporter.images.showGraphImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/.png", typeof(Texture2D));
		reporter.images.graphImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/chart.png", typeof(Texture2D));
		reporter.images.infoImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/info.png", typeof(Texture2D));
		reporter.images.searchImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/search.png", typeof(Texture2D));
		reporter.images.closeImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/close.png", typeof(Texture2D));
		reporter.images.buildFromImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/buildFrom.png", typeof(Texture2D));
		reporter.images.systemInfoImage 	= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/ComputerIcon.png", typeof(Texture2D));
		reporter.images.graphicsInfoImage 	= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/graphicCard.png", typeof(Texture2D));
		reporter.images.backImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/back.png", typeof(Texture2D));
		reporter.images.cameraImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/.png", typeof(Texture2D));
		reporter.images.logImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/log_icon.png", typeof(Texture2D));
		reporter.images.warningImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/warning_icon.png", typeof(Texture2D));
		reporter.images.errorImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/error_icon.png", typeof(Texture2D));
		reporter.images.barImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/bar.png", typeof(Texture2D));
		reporter.images.button_activeImage 	= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/button_active.png", typeof(Texture2D));
		reporter.images.even_logImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/even_log.png", typeof(Texture2D));
		reporter.images.odd_logImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/odd_log.png", typeof(Texture2D));
		reporter.images.selectedImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/selected.png", typeof(Texture2D));

		reporter.images.reporterScrollerSkin = (GUISkin)AssetDatabase.LoadAssetAtPath("Assets/Middlewares/UnityLogsViewer/Images/reporterScrollerSkin.guiskin", typeof(GUISkin));

	}
	/*
	[InitializeOnLoad]
	public class BuildInfo
	{
		static BuildInfo ()
	    {
	        EditorApplication.update += Update;
	    }
	 
		static bool isCompiling = true ; 
	    static void Update ()
	    {
			if( !EditorApplication.isCompiling && isCompiling )
			{
	        	//Debug.Log("Finish Compile");
				if( !Directory.Exists( Application.dataPath + "/StreamingAssets"))
				{
					Directory.CreateDirectory( Application.dataPath + "/StreamingAssets");
				}
				string info_path = Application.dataPath + "/StreamingAssets/build_info.txt" ;
				StreamWriter build_info = new StreamWriter( info_path );
				build_info.Write(  "Build from " + SystemInfo.deviceName + " at " + System.DateTime.Now.ToString() );
				build_info.Close();
			}
			
			isCompiling = EditorApplication.isCompiling ;
	    }
	}
	*/
}
