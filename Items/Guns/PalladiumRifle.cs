using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Specializations.Items.Guns
{
	public class PalladiumRifle : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Only the first shot consumes ammo.");
		}
		
		public override void SetDefaults()
		{
			Item.damage = 24;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 30;
			Item.height = 7;
			Item.useTime = 5;
			Item.useAnimation = 15;
			Item.reuseDelay = 17;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.value = 80000;
			Item.rare = 4;
			Item.UseSound = SoundID.Item31;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Bullet;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY-2)) * 25f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			return true;
		}
		
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return !(player.itemAnimation < Item.useAnimation - 2);
		}
		
		public override Vector2?HoldoutOffset()
		{
			return new Vector2(0, 1);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PalladiumBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
