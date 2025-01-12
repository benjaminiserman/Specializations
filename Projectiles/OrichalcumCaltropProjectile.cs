using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Projectiles
{
    public class OrichalcumCaltropProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.SpikyBall);
        }
    }
}