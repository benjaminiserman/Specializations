using Terraria;
using Terraria.ModLoader;
namespace Specializations.Buffs
{
	public class RapierBleed : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Rapier Wounds");
			// Description.SetDefault("Losing life");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<SpecPlayer>(Mod).rapierDebuff = true;
		}
		
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<SpecGlobalNPC>(Mod).rapierDebuff = true;
		}
	}
}
