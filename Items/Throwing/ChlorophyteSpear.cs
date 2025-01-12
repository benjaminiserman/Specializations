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
			Item.shootSpeed = 13f;
			Item.damage = 64;
			Item.knockBack = 5f;
			Item.useStyle = 1;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.width = 38;
			Item.height = 38;
			Item.maxStack = 999;
			Item.rare = 7;

			Item.consumable = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Throwing;

			Item.UseSound = SoundID.Item1;
			Item.value = 150;
            Item.shoot = Mod.Find<ModProjectile>("ChlorophyteSpear").Type;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
