/*
	FreeEVA.cs

	Expose control of the Kerbal auto-rotation feature of KSP.

	Copyright (C) 2014 Bill Currie <bill@taniwha.org>

	Author: Bill Currie <bill@taniwha.org>
	Date: 2014/9/30

	This program is free software; you can redistribute it and/or
	modify it under the terms of the GNU General Public License
	as published by the Free Software Foundation; either version 2
	of the License, or (at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	See the GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program; if not, write to:

		Free Software Foundation, Inc.
		59 Temple Place - Suite 330
		Boston, MA  02111-1307, USA

*/
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using KSP.IO;

namespace FreeEVA {

	[KSPAddon (KSPAddon.Startup.Flight, false)]
	public class FreeEVA : MonoBehaviour
	{
		internal static FreeEVA instance;

		void Awake ()
		{
			if (!CompatibilityChecker.IsWin64 ()) {
				enabled = true;
			} else {
				enabled = false;
			}
			instance = this;
		}

		void OnDestroy ()
		{
			instance = null;
		}

		void OnStart ()
		{
			// Reset to factory default on start (least surprise)
			if (CompatibilityChecker.IsWin64 ()) {
				GameSettings.EVA_ROTATE_ON_MOVE = true;
			}
		}

		internal void Toggle ()
		{
			GameSettings.EVA_ROTATE_ON_MOVE = !GameSettings.EVA_ROTATE_ON_MOVE;
			if (!GameSettings.EVA_ROTATE_ON_MOVE) {
				ScreenMessages.PostScreenMessage ("FreeEVA enabled. Press space to reset orientation.", 3.0f, ScreenMessageStyle.UPPER_CENTER);
			} else {
				ScreenMessages.PostScreenMessage ("FreeEVA disabled.", 3.0f, ScreenMessageStyle.UPPER_CENTER);
			}
		}

		void Update ()
		{
			if (CompatibilityChecker.IsWin64 ()) {
				return;
			}
			if (Input.GetKeyDown(KeyCode.F) && Input.GetKey(KeyCode.LeftAlt)) {
				Toggle ();
			}
		}
	}
}
