using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace Specializations.Projectiles
{
    public class HallowedGrenadeProjectile : ModProjectile
    {
		public override void SetStaticDefaults() 
		{
			ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true;
			ProjectileID.Sets.Explosive[Type] = true;
		}

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Grenade);
            Projectile.timeLeft = 240;
			AIType = ProjectileID.Grenade;
        }

		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			if (Main.expertMode)
			{
				if (target.type >= NPCID.EaterofWorldsHead && target.type <= NPCID.EaterofWorldsTail)
				{
					modifiers.FinalDamage /= 5;
				}
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
            if (Projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
			{
				Projectile.velocity.X = oldVelocity.X * -0.5f;
			}
			if (Projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
			{
				Projectile.velocity.Y = oldVelocity.Y * -0.5f;
			}
			return false;
		}

		public override void OnKill(int timeLeft)
		{
			// Play explosion sound
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			// Smoke Dust spawn
			for (int i = 0; i < 50; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 2f);
				dust.velocity *= 1.4f;
			}

			// Large Smoke Gore spawn
			for (int g = 0; g < 2; g++) {
				var goreSpawnPosition = new Vector2(Projectile.position.X + Projectile.width / 2 - 24f, Projectile.position.Y + Projectile.height / 2 - 24f);
				Gore gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
				gore.scale = 1.5f;
				gore.velocity.X += 1.5f;
				gore.velocity.Y += 1.5f;
				gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
				gore.scale = 1.5f;
				gore.velocity.X -= 1.5f;
				gore.velocity.Y += 1.5f;
				gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
				gore.scale = 1.5f;
				gore.velocity.X += 1.5f;
				gore.velocity.Y -= 1.5f;
				gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
				gore.scale = 1.5f;
				gore.velocity.X -= 1.5f;
				gore.velocity.Y -= 1.5f;
			}
        } 
    }
}