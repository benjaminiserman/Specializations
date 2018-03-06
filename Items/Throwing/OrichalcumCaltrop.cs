using Specializations.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Throwing
{
	public class OrichalcumCaltrop : ModItem
	{
		public override void SetDefaults()
		{
			item.shootSpeed = 10f;
			item.damage = 28;
			item.knockBack = 0;
			item.useStyle = 1;
			item.useAnimation = 14;
            item.useTime = 14;
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.rare = 4;

			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;

			item.UseSound = SoundID.Item1;
			item.value = 150;
			item.shoot = mod.ProjectileType("OrichalcumCaltrop");
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}