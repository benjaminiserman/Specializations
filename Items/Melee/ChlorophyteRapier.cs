using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
    public class ChlorophyteRapier : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Inflicts bleeding and poison on hit");
		}

		public override void SetDefaults()
		{
			Item.damage = 72;          
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;         
			Item.width = 60;           
			Item.height = 60;         
			Item.useTime = 12;          
			Item.useAnimation = 12;         
			Item.useStyle = 3;         
			Item.knockBack = 4;        
			Item.value = 184000;         
			Item.rare = 4;              
			Item.UseSound = SoundID.Item71;      
			Item.autoReuse = true;   
		}
		
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(Mod.Find<ModBuff>("RapierBleed").Type, 300);
			target.AddBuff(BuffID.Poisoned, 300);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
