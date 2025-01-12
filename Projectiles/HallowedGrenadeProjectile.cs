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
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Grenade);

            Projectile.timeLeft = 240;
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

		public override void AI()
		{
			if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3)
			{
				Projectile.tileCollide = false;
				Projectile.alpha = 255;
				Projectile.position.X = Projectile.position.X + Projectile.width / 2;
				Projectile.position.Y = Projectile.position.Y + Projectile.height / 2;
				Projectile.width = 40;
				Projectile.height = 40;
				Projectile.position.X = Projectile.position.X - Projectile.width / 2;
				Projectile.position.Y = Projectile.position.Y - Projectile.height / 2;
				Projectile.damage = 200;
				Projectile.knockBack = 10f;
			}
			else
			{
				if (Main.rand.NextBool(2))
				{
					int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100, default, 1f);
					Main.dust[dustIndex].scale = 0.1f + Main.rand.Next(5) * 0.1f;
					Main.dust[dustIndex].fadeIn = 1.5f + Main.rand.Next(5) * 0.1f;
					Main.dust[dustIndex].noGravity = true;
					Main.dust[dustIndex].position = Projectile.Center + new Vector2(0f, (float)(-(float)Projectile.height / 2)).RotatedBy(Projectile.rotation, default) * 1.1f;
					dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default, 1f);
					Main.dust[dustIndex].scale = 1f + Main.rand.Next(5) * 0.1f;
					Main.dust[dustIndex].noGravity = true;
					Main.dust[dustIndex].position = Projectile.Center + new Vector2(0f, (float)(-(float)Projectile.height / 2 - 6)).RotatedBy(Projectile.rotation, default) * 1.1f;
				}
			}
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] > 5f)
			{
				Projectile.ai[0] = 10f;
				if (Projectile.velocity.Y == 0f && Projectile.velocity.X != 0f)
				{
					Projectile.velocity.X = Projectile.velocity.X * 0.97f;
					{
						Projectile.velocity.X = Projectile.velocity.X * 0.99f;
					}
					if (Projectile.velocity.X > -0.01 && Projectile.velocity.X < 0.01)
					{
						Projectile.velocity.X = 0f;
						Projectile.netUpdate = true;
					}
				}
				Projectile.velocity.Y = Projectile.velocity.Y;
			}
			Projectile.rotation += Projectile.velocity.X * 0.1f;
			return;
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

			// Fire Dust spawn
			for (int i = 0; i < 80; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 3f);
				dust.noGravity = true;
				dust.velocity *= 5f;
				dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 2f);
				dust.velocity *= 3f;
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