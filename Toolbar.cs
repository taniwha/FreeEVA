/*
This file is part of FreeEVA.

FreeEVA is free software: you can redistribute it and/or
modify it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

FreeEVA is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with FreeEVA.  If not, see
<http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FreeEVA {
	using Toolbar;

	[KSPAddon (KSPAddon.Startup.Flight, false)]
	public class FreeEVAToolbar : MonoBehaviour
	{
		private IButton button;

		public void Awake ()
		{
			if (ToolbarManager.Instance == null) {
				return;
			}
			button = ToolbarManager.Instance.add ("FreeEVA", "button");
			button.TexturePath = "FreeEVA/FreeEVA";
			button.ToolTip = "Toggle FreeEVA";
			button.OnClick += (e) => FreeEVA.instance.Toggle ();
		}

		void OnDestroy()
		{
			if (button != null) {
				button.Destroy ();
			}
		}
	}
}
