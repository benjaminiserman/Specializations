using Microsoft.Xna.Framework;
using Specializations.Items.Throwing;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Projectiles
{
    public class TitaniumJavelinProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.JavelinFriendly);
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 113;
			Projectile.penetrate = 3;
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
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

		public override void OnKill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			Vector2 usePos = Projectile.position; 
			Vector2 rotVector = (Projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;

			for (int i = 0; i < 20; i++)
			{
				Dust dust = Dust.NewDustDirect(usePos, Projectile.width, Projectile.height, 81);
				dust.position = (dust.position + Projectile.Center) / 2f;
				dust.velocity += rotVector * 2f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
				usePos -= rotVector * 8f;
			}

			if (Projectile.owner == Main.myPlayer) 
            {
				var item = 0;
				if (Main.rand.NextBool(18)) 
                {
					item = Item.NewItem(Projectile.GetSource_DropAsItem(), Projectile.getRect(), ModContent.ItemType<TitaniumJavelin>());
				}

				if (Main.netMode == NetmodeID.MultiplayerClient && item >= 0) 
                {
					NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item, 1f);
				}
            }
		}

		public bool isStickingToTarget
		{
			get { return Projectile.ai[0] == 1f; }
			set { Projectile.ai[0] = value ? 1f : 0f; }
		}

		public float targetWhoAmI
		{
			get { return Projectile.ai[1]; }
			set { Projectile.ai[1] = value; }
		}

		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			isStickingToTarget = true;
			targetWhoAmI = target.whoAmI; 
			Projectile.velocity =
				(target.Center - Projectile.Center) *
				0.75f; 
			Projectile.netUpdate = true; 
			target.AddBuff(Mod.Find<ModBuff>("RapierBleed").Type, 900); 

			Projectile.damage = 0; 

			int maxStickingJavelins = 6; 
			Point[] stickingJavelins = new Point[maxStickingJavelins];
			int javelinIndex = 0; 
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				Projectile currentProjectile = Main.projectile[i];
				if (i != Projectile.whoAmI 
				    && currentProjectile.active 
				    && currentProjectile.owner == Main.myPlayer
				    && currentProjectile.type == Projectile.type
				    && currentProjectile.ai[0] == 1f 
				    && currentProjectile.ai[1] == target.whoAmI
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
			
			if (Projectile.alpha > 0)
			{
				Projectile.alpha -= alphaReduction;
			}
			
			if (Projectile.alpha < 0)
			{
				Projectile.alpha = 0;
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
					Projectile.velocity.X = Projectile.velocity.X * velXmult;
					Projectile.velocity.Y = Projectile.velocity.Y + velYmult;
				}
				
				Projectile.rotation =
					Projectile.velocity.ToRotation() +
					MathHelper.ToRadians(90f); 
			}

			if (isStickingToTarget)
			{
				
				Projectile.ignoreWater = true; 
				Projectile.tileCollide = false; 
				int aiFactor = 15; 
				bool killProj = false;
				bool hitEffect = false; 
				Projectile.localAI[0] += 1f;
				hitEffect = Projectile.localAI[0] % 30f == 0f;
				int projTargetIndex = (int)targetWhoAmI;
				if (Projectile.localAI[0] >= 60 * aiFactor
                    || projTargetIndex < 0 || projTargetIndex >= 200)
				{
					killProj = true;
				}
				else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage)
				{
	
					Projectile.Center = Main.npc[projTargetIndex].Center - Projectile.velocity * 2f;
					Projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
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
					Projectile.Kill();
				}
			}
		}
	}
}
