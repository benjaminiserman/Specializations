using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Guns
{
    public class HallowedMachinePistol : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 22;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 17;
			Item.height = 12;
			Item.useTime = 11;
			Item.useAnimation = 10;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = 166666;
			Item.rare = 4;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 11f;
			Item.useAmmo = AmmoID.Bullet;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(3, 2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
