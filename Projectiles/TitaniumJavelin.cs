﻿using Specializations.Items.Throwing;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Projectiles
{
	public class TitaniumJavelin : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 113;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 3;
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = height = 10;
			return true;
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
			{
				targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
			}
			return projHitbox.Intersects(targetHitbox);
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
			Vector2 usePos = projectile.position; 
			Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;

			for (int i = 0; i < 20; i++)
			{
				Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, 81);
				dust.position = (dust.position + projectile.Center) / 2f;
				dust.velocity += rotVector * 2f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
				usePos -= rotVector * 8f;
			}

			int item = 
                    Main.rand.Next(18) == 0
					? Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("TitaniumJavelin"))
					: 0;

			if (Main.netMode == 1 && item >= 0)
			{
				NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item, 1f);
			}
		}

		public bool isStickingToTarget
		{
			get { return projectile.ai[0] == 1f; }
			set { projectile.ai[0] = value ? 1f : 0f; }
		}

		public float targetWhoAmI
		{
			get { return projectile.ai[1]; }
			set { projectile.ai[1] = value; }
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit,
			ref int hitDirection)
		{
			isStickingToTarget = true;
			targetWhoAmI = (float)target.whoAmI; 
			projectile.velocity =
				(target.Center - projectile.Center) *
				0.75f; 
			projectile.netUpdate = true; 
			target.AddBuff(mod.BuffType("RapierBleed"), 900); 

			projectile.damage = 0; 

			int maxStickingJavelins = 6; 
			Point[] stickingJavelins = new Point[maxStickingJavelins];
			int javelinIndex = 0; 
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				Projectile currentProjectile = Main.projectile[i];
				if (i != projectile.whoAmI 
				    && currentProjectile.active 
				    && currentProjectile.owner == Main.myPlayer
				    && currentProjectile.type == projectile.type
				    && currentProjectile.ai[0] == 1f 
				    && currentProjectile.ai[1] == (float)target.whoAmI
				) 
				{
					stickingJavelins[javelinIndex++] =
						new Point(i, currentProjectile.timeLeft); 
					if (javelinIndex >= stickingJavelins.Length
					) 
					{
						break;
					}
				}
			}
		
			if (javelinIndex >= stickingJavelins.Length)
			{
				int oldJavelinIndex = 0;
	
				for (int i = 1; i < stickingJavelins.Length; i++)
				{
					
					if (stickingJavelins[i].Y < stickingJavelins[oldJavelinIndex].Y)
					{
						oldJavelinIndex = i; 
					}
				}
				
				Main.projectile[stickingJavelins[oldJavelinIndex].X].Kill();
			}
		}

		private const float maxTicks = 45f;

		private const int alphaReduction = 25;

		public override void AI()
		{
			
			if (projectile.alpha > 0)
			{
				projectile.alpha -= alphaReduction;
			}
			
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
			
			if (!isStickingToTarget)
			{
				targetWhoAmI += 1f;
				
				if (targetWhoAmI >= maxTicks)
				{
					
					float velXmult = 0.98f;
					float
						velYmult = 0.35f;
					targetWhoAmI = maxTicks;
					projectile.velocity.X = projectile.velocity.X * velXmult;
					projectile.velocity.Y = projectile.velocity.Y + velYmult;
				}
				
				projectile.rotation =
					projectile.velocity.ToRotation() +
					MathHelper.ToRadians(90f); 
			}

			if (isStickingToTarget)
			{
				
				projectile.ignoreWater = true; 
				projectile.tileCollide = false; 
				int aiFactor = 15; 
				bool killProj = false;
				bool hitEffect = false; 
				projectile.localAI[0] += 1f;
				hitEffect = projectile.localAI[0] % 30f == 0f;
				int projTargetIndex = (int)targetWhoAmI;
				if (projectile.localAI[0] >= (float)(60 * aiFactor)
				    || (projTargetIndex < 0 || projTargetIndex >= 200))
				{
					killProj = true;
				}
				else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage)
				{
	
					projectile.Center = Main.npc[projTargetIndex].Center - projectile.velocity * 2f;
					projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
					if (hitEffect) 
					{
						Main.npc[projTargetIndex].HitEffect(0, 1.0);
					}
				}
				else 
				{
					killProj = true;
				}

				if (killProj) 
				{
					projectile.Kill();
				}
			}
		}
	}
}
