using Specializations.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Throwing
{
	public class TitaniumJavelin : ModItem
	{
		public override void SetDefaults()
		{
			item.shootSpeed = 12.5f;
			item.damage = 45;
			item.knockBack = 5f;
			item.useStyle = 1;
			item.useAnimation = 23;
			item.useTime = 23;
			item.width = 40;
			item.height = 40;
			item.maxStack = 999;
			item.rare = 4;

			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;

			item.UseSound = SoundID.Item1;
			item.value = 150;
            item.shoot = mod.ProjectileType("TitaniumJavelin");
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 25);
            recipe.AddRecipe();
        }
    }
}
