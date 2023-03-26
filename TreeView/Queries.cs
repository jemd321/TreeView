namespace TreeView
{
    /// <summary>
    /// Contains example queries across categories.
    /// </summary>
    public class Queries
    {
        /// <summary>
        /// Gets a list of all items in a sequence of catergories.
        /// </summary>
        /// <param name="categories">The sequence of categories to query.</param>
        /// <returns>A list of all the <see cref="Item"/>s found.</returns>
        public static List<Item> GetAllItems(IEnumerable<Category> categories)
        {
            var items = new List<Item>();
            IEnumerable<RootFolder> rootfolders = categories.Select(c => c.RootFolder);
            foreach (ParentFolder folder in rootfolders)
            {
                GetAllItemsFromFolders(folder, items);
            }

            return items;
        }

        private static List<Item> GetAllItemsFromFolders(ParentFolder folder, List<Item> items)
        {
            items.AddRange(folder.ChildItems);
            foreach (Folder childFolder in folder.ChildFolders)
            {
                items = GetAllItemsFromFolders(childFolder, items);
            }

            return items;
        }
    }
}
