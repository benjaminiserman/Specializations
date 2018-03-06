using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations
{
	public class SpecGlobalNPC : GlobalNPC
	{
		
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
		
		public bool rapierDebuff = false;

        public override void ResetEffects(NPC npc)
        {
            rapierDebuff = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (rapierDebuff)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 12;
			}
		}
	}
}