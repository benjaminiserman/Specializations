using Specializations.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Throwing
{
	public class HallowedGrenade : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Three shall be the number of which you count, after pulling the holy pin");
        }

        public override void SetDefaults()
		{
			item.shootSpeed = 6f;
			item.damage = 200;
			item.knockBack = 10;
			item.useStyle = 1;
			item.useAnimation = 45;
			item.useTime = 45;
			item.width = 16;
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
			item.shoot = mod.ProjectileType("HallowedGrenade");
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
    }
}