using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Specializations.Items.Guns
{
	public class PalladiumRifle : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Only the first shot consumes ammo.");
		}
		
		public override void SetDefaults()
		{
			item.damage = 24;
			item.ranged = true;
			item.width = 30;
			item.height = 7;
			item.useTime = 5;
			item.useAnimation = 15;
			item.reuseDelay = 17;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 0;
			item.value = 80000;
			item.rare = 4;
			item.UseSound = SoundID.Item31;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY-2)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}
		
		public override bool ConsumeAmmo(Player player)
		{
			return !(player.itemAnimation < item.useAnimation - 2);
		}
		
		public override Vector2?HoldoutOffset()
		{
			return new Vector2(0, 1);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PalladiumBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	
	}
}
