using Specializations.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Throwing
{
	public class MythrilThrowingDagger : ModItem
	{
		public override void SetDefaults()
		{
			item.shootSpeed = 11f;
			item.damage = 24;
			item.knockBack = 2f;
			item.useStyle = 1;
			item.useAnimation = 14;
			item.useTime = 14;
			item.width = 10;
			item.height = 24;
			item.maxStack = 999;
			item.rare = 4;

			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;

			item.UseSound = SoundID.Item1;
			item.value = 150;
            item.shoot = mod.ProjectileType("MythrilThrowingDagger");
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}