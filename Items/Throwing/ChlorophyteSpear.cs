using Specializations.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Throwing
{
	public class ChlorophyteSpear : ModItem
	{
		public override void SetDefaults()
		{
			item.shootSpeed = 13f;
			item.damage = 64;
			item.knockBack = 5f;
			item.useStyle = 1;
			item.useAnimation = 25;
			item.useTime = 25;
			item.width = 38;
			item.height = 38;
			item.maxStack = 999;
			item.rare = 7;

			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;

			item.UseSound = SoundID.Item1;
			item.value = 150;
            item.shoot = mod.ProjectileType("ChlorophyteSpear");
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 25);
            recipe.AddRecipe();
        }
    }
}
