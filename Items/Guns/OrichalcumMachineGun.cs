using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Guns
{
    public class OrichalcumMachineGun : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 30;
			Item.height = 7;
			Item.useTime = 7;
			Item.useAnimation = 7;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = 110000;
			Item.rare = 4;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override bool CanConsumeAmmo(Item ammo, Player player) {
			return Main.rand.NextFloat() >= 0.40f;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y - 2)) * 25f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(5));
			
			Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);

			return false;
		}
		
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 1);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.OrichalcumBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
