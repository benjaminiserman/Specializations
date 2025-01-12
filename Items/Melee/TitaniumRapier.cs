using Specializations.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
    public class TitaniumRapier : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Inflicts bleeding on hit, and gives the user ironskin");
		}

		public override void SetDefaults()
		{
			Item.damage = 50;          
			Item.DamageType = DamageClass.Melee;         
			Item.width = 60;           
			Item.height = 60;         
			Item.useTime = 12;          
			Item.useAnimation = 12;         
			Item.useStyle = ItemUseStyleID.Rapier;         
			Item.knockBack = 4;        
			Item.value = 107333;         
			Item.rare = 4;              
			Item.UseSound = SoundID.Item1;      
			Item.autoReuse = true;   
			Item.shoot = ModContent.ProjectileType<TitaniumRapierProjectile>();
			Item.shootSpeed = 4.0f;
			Item.noUseGraphic = true;
			Item.noMelee = true;
		}
		
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(Mod.Find<ModBuff>("RapierBleed").Type, 300);
			player.AddBuff(BuffID.Ironskin, 180);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TitaniumBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
