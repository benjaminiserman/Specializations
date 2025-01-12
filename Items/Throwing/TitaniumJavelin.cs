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
			Item.shootSpeed = 12.5f;
			Item.damage = 45;
			Item.knockBack = 5f;
			Item.useStyle = 1;
			Item.useAnimation = 23;
			Item.useTime = 23;
			Item.width = 40;
			Item.height = 40;
			Item.maxStack = 999;
			Item.rare = 4;

			Item.consumable = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Ranged;

			Item.UseSound = SoundID.Item1;
			Item.value = 150;
            Item.shoot = ModContent.ProjectileType<TitaniumJavelinProjectile>();
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.TitaniumBar, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
