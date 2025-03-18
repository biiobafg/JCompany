using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;
using JCompany.Model;

namespace JCompany
{
    public static class Tools
    {
        public static bool SearchDat(this Item item, string fieldName, out float? value)
        {
            bool response = item.SearchDat(fieldName, out string? value2);
            if (response)
            {
                value = float.Parse(value2);
                return response;
            }
            value = null;
            return response;
        }


        public static bool SearchDat(this Item item, string fieldName, out string? value)
        {
            value = null;

            if (item == null || string.IsNullOrEmpty(fieldName) || string.IsNullOrEmpty(item.DatPath))
                return false;

            try
            {
                if (!File.Exists(item.DatPath))
                    return false; 
                using var reader = new StreamReader(item.DatPath, Encoding.UTF8, true, 4096);
                string? line;
                int fieldNameLength = fieldName.Length;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length > fieldNameLength &&
                        line.StartsWith(fieldName, StringComparison.Ordinal) &&
                        char.IsWhiteSpace(line[fieldNameLength]))
                    {
                        value = line.Substring(fieldNameLength).TrimStart();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
        public static bool SearchEng(this Item item, string fieldName, out string? value)
        {
            value = null;

            if (string.IsNullOrEmpty(fieldName) || string.IsNullOrEmpty(item.EngPath))
                return false;

            try
            {
                using var reader = new StreamReader(item.EngPath, Encoding.UTF8, true, 4096);
                string? line;
                int fieldNameLength = fieldName.Length;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length > fieldNameLength &&
                        line.StartsWith(fieldName, StringComparison.Ordinal) &&
                        char.IsWhiteSpace(line[fieldNameLength]))
                    {
                        value = line.Substring(fieldNameLength).TrimStart();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        public static List<Item> GetItemsByGUID(this List<Item> _items, string tGUID, Item? itemToIgnore = null)
        {
            if (itemToIgnore == null)
            {
                return _items.Where(x => x.GUID == tGUID).ToList();
            }
            return _items.Where(x => x.GUID == tGUID && x != itemToIgnore).ToList();
        }
        public static List<Item> GetItemsByID(this List<Item> _items, string tID, Item? itemToIgnore = null)
        {
            if (itemToIgnore == null)
            {
                return _items.Where(x => x.Id == tID).ToList();
            }
            return _items.Where(x => x.Id == tID && x != itemToIgnore).ToList();
        }

        public static Item GetItemByGUID(string tGUID, Item? itemToIgnore = null)
        {
            if (itemToIgnore == null)
            {
                return Extractor._items.FirstOrDefault(x => x.GUID == tGUID);
            }
            return Extractor._items.FirstOrDefault(x => x.GUID == tGUID && x != itemToIgnore);
        }
        public static Item GetItemByID(string tID, Item? itemToIgnore = null)
        {
            if (itemToIgnore == null)
            {
                return Extractor._items.FirstOrDefault(x => x.Id == tID);
            }
            return Extractor._items.FirstOrDefault(x => x.Id == tID && x != itemToIgnore);
        }
        public static string RemoveComments(this string input, string marker = "//")
        {
            string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                int commentIndex = lines[i].IndexOf(marker);
                if (commentIndex >= 0)
                {
                    lines[i] = lines[i][..commentIndex].TrimEnd();
                }
            }

            return string.Join(Environment.NewLine, lines);
        }


        /// <summary>
        /// this doesnt fucking work - will fix later
        /// </summary>
        public static string AddComments(this string input, Item item, string marker = "//")
        {
            string content = input;

            if (item?.Type == "Vendor")
            {
                
                item.SearchDat("Selling", out float? sellCount);
                {
                    for (int i = 0; i < sellCount; i++)
                    {
                        item.SearchDat($"Selling_{i}_ID", out string? sellingItemId);
                        Item? foundItem = Extractor._items.FirstOrDefault(x => x.Id == sellingItemId);
                        if (foundItem != null)
                        {
                            // nesting, :Drooling:
                            if (!string.IsNullOrEmpty(foundItem.Name))
                                content = Comment(content, $"Selling_{i}_ID", foundItem.Name);
                        }
                    }
                }
                item.SearchDat("Currency", out string? CurrencyGUID);
                Item? currencyItem = Extractor._items.FirstOrDefault(x => x.GUID == CurrencyGUID);
                if (currencyItem != null)
                {
                    if (!string.IsNullOrEmpty(currencyItem.Name))
                        content = Comment(content, "Currency", currencyItem.Name);
                }
            }

            if (item.SearchDat("Magazine", out string? MagazineID))
            {
                Item magItem = GetItemByID(MagazineID);
                if (magItem?.Name != null)
                    content = Comment(content, "Magazine", magItem.Name);
            }

            if (item.SearchDat("Tactical", out string? TacticalID))
            {
                Item tacItem = GetItemByID(TacticalID);
                if (tacItem?.Name != null)
                    content = Comment(content, "Tactical", tacItem.Name);
            }

            if (item.SearchDat("Barrel", out string? BarrelID))
            {
                Item barItem = GetItemByID(BarrelID);
                if (barItem?.Name != null)
                    content = Comment(content, "Barrel", barItem.Name);
            }

            if (item.SearchDat("Sight", out string? SightID))
            {
                Item sigItem = GetItemByID(SightID);
                if (sigItem?.Name != null)
                    content = Comment(content, "Sight", sigItem.Name);
            }

            if (item.SearchDat("Player_Damage", out float? baseDMG) &&
                item.SearchDat("Player_Leg_Multiplier", out float? LegMulti) &&
                item.SearchDat("Player_Arm_Multiplier", out float? ArmMulti) && 
                item.SearchDat("Player_Spine_Multiplier", out float? SpineMulti) &&
                item.SearchDat("Player_Skull_Multiplier", out float? HeadMulti)
                )
            {
                content = Comment(content, "Player_Arm_Multiplier", Math.Round((double)(baseDMG * ArmMulti), 1).ToString());
                content = Comment(content, "Player_Leg_Multiplier", Math.Round((double)(baseDMG * LegMulti), 1).ToString());
                content = Comment(content, "Player_Spine_Multiplier", Math.Round((double)(baseDMG * SpineMulti), 1).ToString());
                content = Comment(content, "Player_Skull_Multiplier", Math.Round((double)(baseDMG * HeadMulti), 1).ToString());
            }
            
            if (item.SearchDat("Width", out float? WSlots) && item.SearchDat("Height", out float? HSlots))
            {
                content = Comment(content, "Width", $"{(int)(WSlots * HSlots)} Slots Total");
                content = Comment(content, "Height", $"{(int)(WSlots * HSlots)} Slots Total");
            }

            if (item.SearchDat("Blueprints", out float? BPCount))
            {
                for (int i = 0; i < BPCount; i++)
                {
                     item.SearchDat($"Blueprint_{i}_Product", out string? Proditemid);
                     item.SearchDat($"Blueprint_{i}_Tool", out string? Toolitemid);
                     item.SearchDat($"Blueprint_{i}_Supply_0_ID", out string? itemid);


                    Item supply = GetItemByID(itemid);
                    Item tool = GetItemByID(Toolitemid);
                    Item product = GetItemByID(Proditemid);

                    if (supply != null)
                    {
                        content = Comment(content, $"Blueprint_{i}_Supply_0_ID", supply.Name);
                    }

                    if (tool != null)
                    {
                        content = Comment(content, $"Blueprint_{i}_Tool", tool.Name);
                    }

                    if (product != null)
                    {
                        content = Comment(content, $"Blueprint_{i}_Product", product.Name);
                    }


                    if (item.SearchDat($"Blueprint_{i}_Outputs", out float? BPOut))
                    {
                        for (int i2 = 0; i2 < BPOut; i2++)
                        {
                            item.SearchDat($"Blueprint_{i}_Output_{i2}_ID", out string? CraftID);
                            Item craftItm = GetItemByID(CraftID);
                            if (craftItm != null)
                            {
                                content = Comment(content, $"Blueprint_{i}_Output_{i2}_ID", craftItm.Name);
                            }
                        }
                    }


                    if (item.SearchDat($"Blueprint_{i}_Rewards", out float? BPReward))
                    {
                        for (int j = 0; j < BPReward; j++)
                        {
                            item.SearchDat($"Blueprint_{i}_Reward_{j}_ID", out string? RWardID);
                            Item rWar = GetItemByID(RWardID);
                            if (rWar != null)
                            {
                                content = Comment(content, $"Blueprint_{i}_Reward_{j}_ID", rWar.Name);
                            }
                        }
                    }


                    if (item.SearchDat($"Blueprint_{i}_Supplies", out float? BPSupplies))
                    {
                        for(int v = 0;v < BPSupplies; v++)
                        {
                            item.SearchDat($"Blueprint_{i}_Supply_{v}_ID", out string? BPSupplyID);
                            Item item1 = GetItemByID(BPSupplyID);
                            if (item1 != null)
                            {
                                content = Comment(content, $"Blueprint_{i}_Supply_{v}_ID", item1.Name);
                            }
                        }
                    }






                }
            }


            return content;
        }

        private static string Comment(string input, string key, string comment, string marker = "//")
        {
            string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;

                string[] words = lines[i].TrimStart().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (words.Length > 0 && words[0].Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    if (!lines[i].Contains(marker))
                    {
                        lines[i] = $"{lines[i].TrimEnd()} {marker} {comment}";
                    }
                    return string.Join(Environment.NewLine, lines);
                }
            }

            return input;
        }

    }
}
