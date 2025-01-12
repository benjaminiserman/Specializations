using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Guns
{
    public class TitaniumCarbine : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 70;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 30;
			Item.height = 7;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = 140000;
			Item.rare = 4;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 15f;
			Item.useAmmo = AmmoID.Bullet;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 1);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TitaniumBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
