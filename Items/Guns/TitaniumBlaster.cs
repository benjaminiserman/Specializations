using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Specializations.Items.Guns
{
	public class TitaniumBlaster : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 85;
			item.ranged = true;
			item.width = 12;
			item.height = 10;
			item.useTime = 34;
			item.useAnimation = 34;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 10;
			item.value = 112000;
			item.rare = 4;
			item.UseSound = SoundID.Item36;
			item.autoReuse = false;
			item.shoot = 10;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet) 
			{
				type = ProjectileID.ExplosiveBullet;
			}
			
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY-2)) * 25f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			return true;
		}
		
		public override Vector2?HoldoutOffset()
		{
			return new Vector2(3, 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
