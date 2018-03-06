using Specializations.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Throwing
{
	public class PalladiumThrowingHammer : ModItem
	{
		public override void SetDefaults()
		{
			item.shootSpeed = 10f;
			item.damage = 28;
			item.knockBack = 0;
			item.useStyle = 1;
			item.useAnimation = 19;
            item.useTime = 19;
			item.width = 30;
			item.height = 30;
			item.maxStack = 999;
			item.rare = 4;

			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;

			item.UseSound = SoundID.Item1;
			item.value = 150;
			item.shoot = mod.ProjectileType("PalladiumThrowingHammer");
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 25);
            recipe.AddRecipe();
        }
    }
}