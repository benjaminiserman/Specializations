using Specializations.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
    public class MythrilRapier : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 42;          
			Item.DamageType = DamageClass.Melee;         
			Item.width = 44;           
			Item.height = 44;         
			Item.useTime = 13;          
			Item.useAnimation = 13;         
			Item.useStyle = ItemUseStyleID.Rapier;         
			Item.knockBack = 4;        
			Item.value = 69000;         
			Item.rare = 4;              
			Item.UseSound = SoundID.Item1;      
			Item.autoReuse = true;   
			Item.shoot = ModContent.ProjectileType<MythrilRapierProjectile>();
			Item.shootSpeed = 2.1f;
			Item.noUseGraphic = true;
			Item.noMelee = true;
		}
		
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(Mod.Find<ModBuff>("RapierBleed").Type, 300);
            player.AddBuff(BuffID.Sharpened, 300);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MythrilBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
