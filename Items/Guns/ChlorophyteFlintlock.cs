using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Guns
{
    public class ChlorophyteFlintlock : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.FlintlockPistol);
			Item.damage = 42;
			Item.value = 192000;
			Item.rare = 7;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 1);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
