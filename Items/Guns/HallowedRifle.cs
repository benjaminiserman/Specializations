using Microsoft.Xna.Framework;
using Specializations.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Guns
{
    public class HallowedRifle : ModItem
	{
		
		public override void SetDefaults()
		{
			Item.damage = 31;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 20;
			Item.height = 7;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = 200000;
			Item.rare = 4;
			Item.UseSound = SoundID.Item91;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 3;
			Item.useAmmo = AmmoID.Bullet;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (type == ProjectileID.Bullet) 
			{
				type = ModContent.ProjectileType<RedLaser>();
			}
			
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y - 2)) * 25f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);

			return false;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(3, 2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
