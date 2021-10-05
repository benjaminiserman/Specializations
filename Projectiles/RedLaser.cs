using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Projectiles
{
	public class RedLaser : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.PurpleLaser);
			aiType = ProjectileID.PurpleLaser;
			projectile.penetrate = 3;
		}
	}
}
