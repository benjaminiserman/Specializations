using Specializations.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
    public class CobaltRapier : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 36;          
			Item.DamageType = DamageClass.Melee;         
			Item.width = 44;           
			Item.height = 44;         
			Item.useTime = 13;          
			Item.useAnimation = 13;         
			Item.useStyle = ItemUseStyleID.Rapier;         
			Item.knockBack = 4;        
			Item.value = 55200;         
			Item.rare = 4;              
			Item.UseSound = SoundID.Item1;      
			Item.autoReuse = true;   
			Item.shoot = ModContent.ProjectileType<CobaltRapierProjectile>();
			Item.shootSpeed = 2.1f;
			Item.noUseGraphic = true;
			Item.noMelee = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CobaltBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
