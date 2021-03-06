#region Copyright & License Information
/*
 * Copyright 2007-2016 The OpenRA Developers (see AUTHORS)
 * This file is part of OpenRA, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version. For more
 * information, see COPYING.
 */
#endregion

using OpenRA.Graphics;

namespace OpenRA.Widgets
{
	public class RootWidget : ContainerWidget
	{
		public RootWidget()
		{
			IgnoreMouseOver = true;
		}

		public override bool HandleKeyPress(KeyInput e)
		{
			if (e.Event == KeyInputEvent.Down)
			{
				var hk = Hotkey.FromKeyInput(e);

				if (hk == Game.Settings.Keys.DevReloadChromeKey)
				{
					ChromeProvider.Initialize(Game.ModData);
					return true;
				}

				if (hk == Game.Settings.Keys.HideUserInterfaceKey)
				{
					foreach (var child in Children)
						child.Visible ^= true;

					return true;
				}

				if (hk == Game.Settings.Keys.TakeScreenshotKey)
				{
					if (e.Event == KeyInputEvent.Down)
						Game.TakeScreenshot = true;

					return true;
				}
			}

			return base.HandleKeyPress(e);
		}
	}
}
