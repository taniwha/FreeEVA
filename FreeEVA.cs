using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using KSP.IO;

namespace FreeEVA {

	[KSPAddon (KSPAddon.Startup.Flight, false)]
	public class ExSurveyTracker : MonoBehaviour
	{
		void Awake ()
		{
			enabled = true;
		}

		void Start ()
		{
			// Reset to factory default on start (least surprise)
			GameSettings.EVA_ROTATE_ON_MOVE = true;
		}

		void Update ()
		{
			if (Input.GetKeyDown(KeyCode.F) && Input.GetKey(KeyCode.LeftAlt)) {
				GameSettings.EVA_ROTATE_ON_MOVE = !GameSettings.EVA_ROTATE_ON_MOVE;
				if (!GameSettings.EVA_ROTATE_ON_MOVE) {
					ScreenMessages.PostScreenMessage ("FreeEVA enabled. Press space to reset orientation.");
				} else {
					ScreenMessages.PostScreenMessage ("FreeEVA disabled.");
				}
			}
		}
	}
}
