using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Projectiles
{
    public class RedLaser : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.PurpleLaser);
			AIType = ProjectileID.PurpleLaser;
			Projectile.penetrate = 3;
		}
	}
}
