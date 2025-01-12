using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Specializations.Items.Throwing;

namespace Specializations.Projectiles
{
    public class PalladiumThrowingHammerProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.aiStyle = 2;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 1;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position); 
            Vector2 usePos = Projectile.position;
                                                
            for (int i = 0; i < 10; i++)
            {
               Dust.NewDust(usePos, 8, 8, 1);
            }

            if (Projectile.owner == Main.myPlayer) 
            {
				var item = 0;
				if (Main.rand.NextBool(2)) 
                {
					item = Item.NewItem(Projectile.GetSource_DropAsItem(), Projectile.getRect(), ModContent.ItemType<PalladiumThrowingHammer>());
				}

				if (Main.netMode == NetmodeID.MultiplayerClient && item >= 0) 
                {
					NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item, 1f);
				}
            }
        }
    }
}