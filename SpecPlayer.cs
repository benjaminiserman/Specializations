using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace Specializations
{
	public class SpecPlayer : ModPlayer
	{
		public bool rapierDebuff = false;
		
		public override void ResetEffects()
		{
			rapierDebuff = false;
		}
		
		public override void UpdateDead()
		{
			rapierDebuff = false;
		}
		
		public override void UpdateBadLifeRegen()
		{
			if (rapierDebuff)
			{
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 6;
			}
		}
	}
}