using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Guns
{
    public class CobaltCarbine : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 37;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 30;
			Item.height = 7;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = 60000;
			Item.rare = 4;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 14f;
			Item.useAmmo = AmmoID.Bullet;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 1);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CobaltBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
