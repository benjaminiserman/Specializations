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
			Item.shootSpeed = 10f;
			Item.damage = 28;
			Item.knockBack = 0;
			Item.useStyle = 1;
			Item.useAnimation = 14;
            Item.useTime = 14;
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.rare = 4;

			Item.consumable = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Ranged;

			Item.UseSound = SoundID.Item1;
			Item.value = 150;
			Item.shoot = ModContent.ProjectileType<OrichalcumCaltropProjectile>();
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(ItemID.OrichalcumBar, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}