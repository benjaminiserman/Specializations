using System.Drawing.Text;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Projectiles
{
    public class PalladiumRapierProjectile : ModProjectile
    {
        public const int FadeInDuration = 7;
		public const int FadeOutDuration = 4;

		public const int TotalDuration = 16;
        public const int SpriteSize = 46;

        public int Timer 
        {
			get => (int)Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}

		public float CollisionWidth => 10f * Projectile.scale;
		public float CollisionLength => 24f * Projectile.scale;

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.PlatinumShortswordStab);
            Projectile.Size = new Vector2(72);
            Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.scale = 1f;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.ownerHitCheck = true;
			Projectile.extraUpdates = 1;
			Projectile.timeLeft = 360;
			Projectile.hide = true;
        }

        public override void AI() 
        {
			Player player = Main.player[Projectile.owner];

			Timer += 1;
			if (Timer >= TotalDuration) {
				Projectile.Kill();
				return;
			}
			else {
				player.heldProj = Projectile.whoAmI;
			}

			Projectile.Opacity = Utils.GetLerpValue(0f, FadeInDuration, Timer, clamped: true) * Utils.GetLerpValue(TotalDuration, TotalDuration - FadeOutDuration, Timer, clamped: true);

			Vector2 playerCenter = player.RotatedRelativePoint(player.MountedCenter, reverseRotation: false, addGfxOffY: false);
			Projectile.Center = playerCenter + Projectile.velocity * (Timer - 1f);

			Projectile.spriteDirection = (Vector2.Dot(Projectile.velocity, Vector2.UnitX) >= 0f).ToDirectionInt();

			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

			SetVisualOffsets();
		}

		private void SetVisualOffsets() 
        {
			const int HalfSpriteWidth = SpriteSize / 2;

			int HalfProjWidth = Projectile.width / 2;

			if (Projectile.spriteDirection == 1) 
            {
				DrawOriginOffsetX = -(HalfProjWidth - HalfSpriteWidth);
				DrawOffsetX = -(int)DrawOriginOffsetX * 2;
				DrawOriginOffsetY = 0;
			}
			else 
            {
				DrawOriginOffsetX = HalfProjWidth - HalfSpriteWidth;
				DrawOffsetX = 0;
				DrawOriginOffsetY = 0;
			}
		}

		public override bool ShouldUpdatePosition()
         {
			// Update Projectile.Center manually
			return false;
		}

		public override void CutTiles() 
        {
			// "cutting tiles" refers to breaking pots, grass, queen bee larva, etc.
			DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
			Vector2 start = Projectile.Center;
			Vector2 end = start + Projectile.velocity.SafeNormalize(-Vector2.UnitY) * 10f;
			Utils.PlotTileLine(start, end, CollisionWidth, DelegateMethods.CutTiles);
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
			// "Hit anything between the player and the tip of the sword"
			// shootSpeed is 2.1f for reference, so this is basically plotting 12 pixels ahead from the center
			Vector2 start = Projectile.Center;
			Vector2 end = start + Projectile.velocity * CollisionLength;
			float collisionPoint = 0f; // Don't need that variable, but required as parameter
			return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), start, end, CollisionWidth, ref collisionPoint);
		}
    }
}