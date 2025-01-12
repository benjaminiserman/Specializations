using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Guns
{
    public class ChlorophyteMusket : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Musket);
			Item.damage = 92;
			Item.value = 240000;
			Item.rare = 7;
			Item.useStyle = 5;
			Item.width = 30;
			Item.height = 7;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
