using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Throwing
{
    public class MythrilThrowingDagger : ModItem
	{
		public override void SetDefaults()
		{
			Item.shootSpeed = 11f;
			Item.damage = 24;
			Item.knockBack = 2f;
			Item.useStyle = 1;
			Item.useAnimation = 14;
			Item.useTime = 14;
			Item.width = 10;
			Item.height = 24;
			Item.maxStack = 999;
			Item.rare = 4;

			Item.consumable = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Ranged;

			Item.UseSound = SoundID.Item1;
			Item.value = 150;
            Item.shoot = Mod.Find<ModProjectile>("MythrilThrowingDagger").Type;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(ItemID.MythrilBar, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}