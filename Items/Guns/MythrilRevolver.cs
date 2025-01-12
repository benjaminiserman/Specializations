using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Guns
{
    public class MythrilRevolver : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 43;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 17;
			Item.height = 12;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = 72000;
			Item.rare = 4;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 14f;
			Item.useAmmo = AmmoID.Bullet;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(3, 2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MythrilBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
