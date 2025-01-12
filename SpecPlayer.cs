using Terraria;
using Terraria.ModLoader;

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
				if (Player.lifeRegen > 0)
				{
					Player.lifeRegen = 0;
				}

				Player.lifeRegenTime = 0;
				Player.lifeRegen -= 6;
			}
		}
	}
}