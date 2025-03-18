

using System.Diagnostics;
using JCompany.Model;
using static JCompany.Tools;
namespace JCompany
{
    public class Extractor
    {
        // now including caller as a way to instance it so i can ask it to be cleared is a bad way of doing this but again, i dont really care it works
        internal static void ExtractAll(string selectedPath, bool ClearList, ItemStudio caller)
        {
            if (!Directory.Exists(selectedPath))
            {
                return;
            }
            if (ClearList)
            {
                _items.Clear();
            }

            string[] dirs = Directory.GetDirectories(selectedPath, "*", SearchOption.AllDirectories);
            Parallel.ForEach(dirs, dir =>
            {
                string? datpath = Directory.GetFiles(dir, "*.dat").FirstOrDefault(x => !x.ToLower().EndsWith("english.dat"));
                if (string.IsNullOrEmpty(datpath) || !File.Exists(datpath))
                    return;

                // dat path exists, Check for english.dat
                // if the english exists then its an item otherwise check it for any item type that doesnt require an English.dat like effects / spawntables
                string? engPath = Path.Combine(dir, "English.dat");
                if (!File.Exists(engPath))
                {
                    // so it doesnt exist, check the .dat to see if it contains any fields that doesnt require a thingy thing
                    string notVeryEfficient = File.ReadAllText(datpath).ToLower();
                    if (notVeryEfficient.Contains("effect") || notVeryEfficient.Contains("spawn"))
                    {
                        Item item = new(engPath, datpath);
                        _items.Add(item);
                    }
                }
                else
                {
                    Item item = new(engPath, datpath);
                    _items.Add(item);
                }
            });
            List<Item> itemsToRemove = new List<Item>();
            Parallel.ForEach(_items, item =>
            {
                // this is a very very poor fix, i dont really know what else to do for this since ghost items now exist from the Artist stuff in the unturned items/outfits directory.
                // if you have a better fix for this, dm ._.dog on discord so i can fix this - im currently too lazy to get a better fix so it will remain
                if (string.IsNullOrEmpty(item.Id))
                {
                    itemsToRemove.Add(item);
                }

                if (item.Overlap != null)
                    return;

                List<Item> items = new List<Item>();
                if (string.IsNullOrEmpty(item.GUID) || string.IsNullOrEmpty(item.Id))
                    return;
                _items.GetItemsByGUID(item.GUID, item).ForEach(t => items.Add(t));
                _items.GetItemsByID(item.Id, item).ForEach(t => items.Add(t));

                if (items == null || items.Count == 0)
                    return;
                item.Overlap = new();

                foreach (var item1 in items)
                {
                    item.Overlap?.Add(item1);
                }
            });
            foreach(var item in itemsToRemove)
            {
                _items.Remove(item);
            }

            caller.AskUpdateList(_items);
        }

        public static List<Item> _items = new List<Item>();
        public static Item? Getitem( string itemid, string itemtype, string itemname, object itempath)
        {
            return _items.FirstOrDefault(x => x.Id == itemid && x.Type == itemtype && x.Name == itemname && x.DatPath == itempath);
        }



    }
}
