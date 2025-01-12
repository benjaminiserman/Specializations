using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Specializations.Projectiles
{
    public class CobaltShuriken : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Shuriken);
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position); 
            Vector2 usePos = Projectile.position;
                                                
            for (int i = 0; i < 6; i++)
            {
               Dust.NewDust(usePos, 8, 8, 1);
            }

            int item = Main.rand.Next(2) == 0 ? Item.NewItem((int)Projectile.position.X, (int)Projectile.position.Y, Projectile.width, Projectile.height, Mod.Find<ModItem>("CobaltShuriken").Type) : 0;

            if (Main.netMode == 1 && item >= 0)
            {
                NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item, 1f);
            }
        }
    }
}