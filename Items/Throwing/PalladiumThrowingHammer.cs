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
			Item.shootSpeed = 10f;
			Item.damage = 53;
			Item.knockBack = 7f;
			Item.useStyle = 1;
			Item.useAnimation = 19;
            Item.useTime = 19;
			Item.width = 30;
			Item.height = 30;
			Item.maxStack = 999;
			Item.rare = 4;

			Item.consumable = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Ranged;

			Item.UseSound = SoundID.Item1;
			Item.value = 150;
			Item.shoot = ModContent.ProjectileType<PalladiumThrowingHammerProjectile>();
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.PalladiumBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}